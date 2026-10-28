using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers
{
    public sealed class CharmapManager
    {
        private readonly ByteTrieNode _byteTrieRoot = null;
        private readonly StringTrieNode _stringTrieRoot = null;

        public CharmapManager(string filePath)
        {
            _byteTrieRoot = new ByteTrieNode();
            _stringTrieRoot = new StringTrieNode();

            foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
            {
                // Ignore blank lines and comments
                if (string.IsNullOrWhiteSpace(line) 
                    || line.StartsWith(";", StringComparison.Ordinal))
                {
                    continue;
                }

                string[] parts = line.Split('=');
                int count = Enum.GetValues(typeof(PartName)).Length;
                if (parts.Length != count)
                {
                    continue;
                }

                string hexKey = parts[(int)PartName.Key].RemoveSpace();
                string value = parts[(int)PartName.Value].RemoveSpace();

                int byteLen = hexKey.Length / BinaryConstants.HexCharsPerByte;
                byte[] bytes = new byte[byteLen];
                for (int i = 0; i < byteLen; i++)
                {
                    int startIndex = i * BinaryConstants.HexCharsPerByte;
                    string hexByte = hexKey.Substring(startIndex, BinaryConstants.HexCharsPerByte);
                    bytes[i] = Convert.ToByte(hexByte, BinaryConstants.HexBase);
                }

                ByteTrieNode byteNode = _byteTrieRoot;
                foreach (byte b in bytes)
                {
                    if (!byteNode.Children.TryGetValue(b, out ByteTrieNode next))
                    {
                        next = new ByteTrieNode();
                        byteNode.Children[b] = next;
                    }

                    byteNode = next;
                }

                byteNode.Value = value;
                byteNode.IsTerminal = true;

                StringTrieNode stringNode = _stringTrieRoot;
                foreach (char c in value)
                {
                    if (!stringNode.Children.TryGetValue(c, out StringTrieNode next))
                    {
                        next = new StringTrieNode();
                        stringNode.Children[c] = next;
                    }

                    stringNode = next;
                }

                stringNode.Value = bytes;
                stringNode.IsTerminal = true;
            }
        }

        public string BytesToString(byte[] buffer, int offset = 0, int? maxLength = null)
        {
            if (buffer == null)
            {
                return string.Empty;
            }

            int availableLength = buffer.Length - offset;
            int length = maxLength.HasValue
                ? Math.Min(availableLength, Math.Max(0, maxLength.Value))
                : availableLength;

            StringBuilder result = new StringBuilder(length);
            int i = 0;
            while (i < length)
            {
                int currentIndex = offset + i;
                byte currentByte = buffer[currentIndex];

                if (currentByte == BinaryConstants.StrTerminatorByte)
                {
                    break;
                }

                if (currentByte == BinaryConstants.StrNewlineByte)
                {
                    result.Append(Environment.NewLine);
                    i++;
                    continue;
                }

                int matchLength = 0;
                string matchedString = null;
                ByteTrieNode node = _byteTrieRoot;

                for (int j = 0; j < length - i; j++)
                {
                    byte b = buffer[currentIndex + j];
                    if (!node.Children.TryGetValue(b, out ByteTrieNode next))
                    {
                        break;
                    }

                    node = next;
                    if (node.IsTerminal)
                    {
                        // Keep the longest matching entry
                        matchLength = j + 1;
                        matchedString = node.Value;
                    }
                }

                if (matchLength > 0 && matchedString != null)
                {
                    result.Append(matchedString);
                    i += matchLength;
                }
                else
                {
                    // Skip unmapped bytes
                    i++;
                }
            }

            return result.ToString();
        }

        public byte[] StringToBytes(
            string text,
            bool appendTerminator = true,
            int targetLength = BinaryConstants.InvalidValue,
            byte paddingByte = BinaryConstants.PaddingByte)
        {
            text = text ?? string.Empty;
            List<byte> result = new List<byte>();
            int i = 0;

            while (i < text.Length)
            {
                // Encode CRLF as a single newline byte
                if (text[i] == '\r' && i + 1 < text.Length && text[i + 1] == '\n')
                {
                    result.Add(BinaryConstants.StrNewlineByte);
                    i += 2;
                    continue;
                }

                int matchLength = 0;
                byte[] matchedBytes = null;
                StringTrieNode node = _stringTrieRoot;

                for (int j = 0; j < text.Length - i; j++)
                {
                    char c = text[i + j];
                    if (!node.Children.TryGetValue(c, out StringTrieNode next))
                    {
                        break;
                    }

                    node = next;
                    if (node.IsTerminal)
                    {
                        // Keep the longest matching entry
                        matchLength = j + 1;
                        matchedBytes = node.Value;
                    }
                }

                if (matchLength > 0 && matchedBytes != null)
                {
                    result.AddRange(matchedBytes);
                    i += matchLength;
                }
                else
                {
                    // Skip unmapped characters
                    i++;
                }
            }

            if (appendTerminator)
            {
                result.Add(BinaryConstants.StrTerminatorByte);
            }

            if (targetLength > 0)
            {
                while (result.Count < targetLength)
                {
                    result.Add(paddingByte);
                }
            }

            return result.ToArray();
        }

        public string TextLengthValidate(
            string text,
            int byteLength, 
            bool needTerminator = true)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            int maxBytes = needTerminator 
                ? byteLength - 1 
                : byteLength;

            if (StringToBytes(text, false).Length <= maxBytes)
            {
                return text;
            }

            StringInfo stringInfo = new StringInfo(text);
            int count = stringInfo.LengthInTextElements;

            string currentText = text;
            while (count > 0)
            {
                count--;
                currentText = stringInfo.SubstringByTextElements(0, count);

                byte[] bytes = StringToBytes(currentText, false);
                if (bytes.Length <= maxBytes)
                {
                    break;
                }
            }

            return currentText;
        }
    }

    public sealed class ByteTrieNode
    {
        public Dictionary<byte, ByteTrieNode> Children { get; set; }
        public string Value { get; set; }
        public bool IsTerminal { get; set; }

        public ByteTrieNode(string value = null, bool isTerminal = false)
        {
            Children = new Dictionary<byte, ByteTrieNode>();
            Value = value;
            IsTerminal = isTerminal;
        }
    }

    public sealed class StringTrieNode
    {
        public Dictionary<char, StringTrieNode> Children { get; set; }
        public byte[] Value { get; set; }
        public bool IsTerminal { get; set; }

        public StringTrieNode(byte[] value = null, bool isTerminal = false)
        {
            Children = new Dictionary<char, StringTrieNode>();
            Value = value;
            IsTerminal = isTerminal;
        }
    }
}
