using System.Collections.Generic;
using System.IO;
using System.Text;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers
{
    public sealed class ConfigManager
    {
        private readonly Dictionary<ConfigKey, int> _intCache = null;
        private readonly Dictionary<ConfigKey, bool> _boolCache = null;

        public int GetInt(ConfigKey key) =>
            _intCache.TryGetValue(key, out var val) 
                ? val 
                : default;
        public bool GetBool(ConfigKey key) =>
            _boolCache.TryGetValue(key, out var val) 
                ? val
                : default;

        public sealed class ConfigKey
        {

        }

        public ConfigManager(string filePath)
        {
            _intCache = new Dictionary<ConfigKey, int>();
            _boolCache = new Dictionary<ConfigKey, bool>();

            foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
            {
                if (!TrySplitLine(line, out string key, out string rawValue))
                {
                    continue;
                }

                if (bool.TryParse(rawValue, out bool boolValue))
                {
                    _boolCache[key] = boolValue;
                    continue;
                }

                // '*' marks a pointer offset
                if (rawValue.StartsWith("*")
                    && TryParseNumber(rawValue.Substring(1), out int pointerOffset)
                    && IoHelper.TryReadPointer(SharedData.RomData, pointerOffset, out int resultOffset))
                {
                    _intCache[key] = resultOffset;
                    continue;
                }

                if (TryParseNumber(rawValue, out int numberValue))
                {
                    _intCache[key] = numberValue;
                }
            }
        }

        private static bool TrySplitLine(string line, out string key, out string rawValue)
        {
            key = string.Empty;
            rawValue = string.Empty;

            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
            {
                return false;
            }

            // Split at '='
            string[] parts = line.Split('=');
            if (parts.Length != KvpConstant.PartsCount)
            {
                return false;
            }

            key = parts[KvpConstant.Key].RemoveSpace();
            rawValue = parts[KvpConstant.Val].RemoveSpace();
            return true;
        }

        private bool TryParseNumber(string rawValue, out int parsedValue)
        {
            if (rawValue.StartsWith(PrefixConstant.Hex)) // 0x
            {
                string hexPart = rawValue.Substring(PrefixConstant.Hex.Length);
                parsedValue = ConvHelper.ParseHexToInt(hexPart);
                return true;
            }

            return int.TryParse(rawValue, out parsedValue);
        }
    }
}
