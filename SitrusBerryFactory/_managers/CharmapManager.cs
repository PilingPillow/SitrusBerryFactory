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
        private readonly TrieNode<byte, string> _byteTrieRoot = null;
        private readonly TrieNode<char, byte[]> _stringTrieRoot = null;

        public CharmapManager(string filePath)
        {
            _byteTrieRoot = new TrieNode<byte, string>();
            _stringTrieRoot = new TrieNode<char, byte[]>();

            foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
            {
                // Ignore blank lines and comments
                if (string.IsNullOrWhiteSpace(line)|| line.StartsWith(";"))
                {
                    continue;
                }

                string[] parts = line.Split('=');
                if (parts.Length != KvpConstant.PartsCount)
                {
                    continue;
                }

                string hexKey = parts[KvpConstant.Key].RemoveSpace();
                string value = parts[KvpConstant.Val].RemoveSpace(spaceIfEmpty: true); // for " "

                byte[] bytes = new byte[hexKey.Length / BinaryConstant.HexCharsPerByte];
                for (int i = 0; i < bytes.Length; i++)
                {
                    int startIndex = i * BinaryConstant.HexCharsPerByte;
                    string hexByte = hexKey.Substring(startIndex, BinaryConstant.HexCharsPerByte);
                    bytes[i] = Convert.ToByte(hexByte, BinaryConstant.HexBase);
                }

                // Byte node
                TrieNode<byte, string> byteNode = _byteTrieRoot;
                foreach (byte b in bytes)
                {
                    if (!byteNode.Children.TryGetValue(b, out TrieNode<byte, string> next))
                    {
                        next = new TrieNode<byte, string>();
                        byteNode.Children[b] = next;
                    }

                    byteNode = next;
                }
                byteNode.Value = value;
                byteNode.IsTerminal = true;

                // String node
                TrieNode<char, byte[]> stringNode = _stringTrieRoot;
                foreach (char c in value)
                {
                    if (!stringNode.Children.TryGetValue(c, out TrieNode<char, byte[]> next))
                    {
                        next = new TrieNode<char, byte[]>();
                        stringNode.Children[c] = next;
                    }

                    stringNode = next;
                }
                stringNode.Value = bytes;
                stringNode.IsTerminal = true;
            }
        }

        public string BytesToString(
            byte[] buffer,
            int offset = 0, 
            int? maxLength = null)
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

                if (currentByte == CharConstant.Terminator)
                {
                    break;
                }

                if (currentByte == CharConstant.Newline)
                {
                    result.Append(Environment.NewLine);
                    i++;
                    continue;
                }

                int matchLength = 0;
                string matchedString = null;
                TrieNode<byte, string> node = _byteTrieRoot;

                for (int j = 0; j < length - i; j++)
                {
                    byte b = buffer[currentIndex + j];
                    if (!node.Children.TryGetValue(b, out TrieNode<byte, string> next))
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
            int targetLength = InvalidConstant.Val,
            byte paddingByte = CharConstant.Padding)
        {
            text = text ?? string.Empty;
            List<byte> result = new List<byte>();
            int i = 0;

            while (i < text.Length)
            {
                // Encode CRLF as a single newline byte
                if (text[i] == '\r' && i + 1 < text.Length && text[i + 1] == '\n')
                {
                    result.Add(CharConstant.Newline);
                    i += 2;
                    continue;
                }

                int matchLength = 0;
                byte[] matchedBytes = null;
                TrieNode<char, byte[]> node = _stringTrieRoot;

                for (int j = 0; j < text.Length - i; j++)
                {
                    char c = text[i + j];
                    if (!node.Children.TryGetValue(c, out TrieNode<char, byte[]> next))
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
                result.Add(CharConstant.Terminator);
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

    public sealed class TrieNode<TKey, TValue>
    {
        public Dictionary<TKey, TrieNode<TKey, TValue>> Children { get; }
        public TValue Value { get; set; }
        public bool IsTerminal { get; set; }

        public TrieNode(TValue value = default, bool isTerminal = false)
        {
            Children = new Dictionary<TKey, TrieNode<TKey, TValue>>();
            Value = value;
            IsTerminal = isTerminal;
        }
    }
}
