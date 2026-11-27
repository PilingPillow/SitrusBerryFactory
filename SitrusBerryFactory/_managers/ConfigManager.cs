using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers
{
    public sealed class ConfigManager
    {
        private readonly Dictionary<string, int> _intCache = null;
        private readonly Dictionary<string, bool> _boolCache = null;

        private enum InterpType
        {
            Int,
            Pointer,
            Bool,
            ToDo,
        }

        private enum PartOffset
        {
            KeyName = 3,
            KindAndArg = 5,
        }

        private sealed class ConfigContext
        {
            public string Key { get; }
            public InterpType Kind { get; }
            public string Arg { get; }

            public ConfigContext(
                string key, 
                InterpType kind, 
                string arg)
            {
                Key = key;
                Kind = kind;
                Arg = arg;
            }
        }

        public int GetInt(string key) =>
            _intCache.TryGetValue(key, out var val) 
                ? val 
                : default;
        public bool GetBool(string key) =>
            _boolCache.TryGetValue(key, out var val) 
                ? val
                : default;

        public void ClearCurrentConfig()
        {
            _intCache.Clear();
            _boolCache.Clear();
        }

        public ConfigManager(string filePath)
        {
            _intCache = new Dictionary<string, int>();
            _boolCache = new Dictionary<string, bool>();

            foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
            {
                if (!TrySplitLine(line, out ConfigContext context))
                {
                    continue;
                }

                switch (context.Kind)
                {
                    case InterpType.Int:
                        int value = ParseToNumber(context.Arg);
                        _intCache[context.Key] = value;
                        break;
                    case InterpType.Pointer:
                        int pointer = ParseToNumber(context.Arg);
                        if (SharedData.RomData.TryReadPointer(pointer, out int offset))
                        {
                            _intCache[context.Key] = offset;
                        }
                        break;
                    case InterpType.Bool:
                        bool result = Convert.ToBoolean(context.Arg);
                        _boolCache[context.Key] = result;
                        break;
                }
            }

            // helper
            int ParseToNumber(string str)
            {
                if (str.StartsWith(PrefixConstant.Hex)) // 0x
                {
                    string hexPart = str.Substring(PrefixConstant.Hex.Length);
                    return ConvHelper.ParseHexToInt(hexPart);
                }

                return Convert.ToInt32(str.RemoveSpace());
            }
        }

        private static bool TrySplitLine(string line, out ConfigContext context)
        {
            // Whether contain '='
            int eqIndex = line.IndexOf('=');
            if (eqIndex < 0)
            {
                context = null;
                return false;
            }

            // Split at '='
            string[] parts = line.Split('=');

            // Get the key name
            string key = parts[(int)PartOffset.KeyName];

            // Get the kind
            var rightSideStr = parts[(int)PartOffset.KindAndArg];
            var openParenIndex = rightSideStr.IndexOf('(');
            var kindStr = rightSideStr.Substring(0, openParenIndex);
            InterpType kind = (InterpType)Enum.Parse(typeof(InterpType), kindStr);

            // Get the arg
            var closeParenIndex = rightSideStr.LastIndexOf(')');
            var arg = rightSideStr.Substring(
                openParenIndex + 1,
                closeParenIndex - openParenIndex - 1)
                .RemoveSpace();

            context = new ConfigContext(key, kind, arg);
            return true;
        }
    }
}
