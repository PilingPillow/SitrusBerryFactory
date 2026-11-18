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
