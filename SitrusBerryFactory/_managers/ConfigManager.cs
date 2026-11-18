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
        /// <summary>
        /// Maps configuration names to file paths.
        /// </summary>
        public Dictionary<string, string> NamesToPaths{ get; }

        // Calculate In advance
        private static readonly int PartsCount = Enum.GetValues(typeof(Kvp)).Length;

        // Cached by loadconfig
        private readonly Dictionary<string, int> _intCache = null;
        private readonly Dictionary<string, bool> _boolCache = null;

        public int GetInt(string key) =>
            _intCache.TryGetValue(key, out var val) 
                ? val 
                : default;
        public bool GetBool(string key) =>
            _boolCache.TryGetValue(key, out var val) 
                ? val
                : default;

        public ConfigManager(string folderPath)
        {
            NamesToPaths = new Dictionary<string, string>();
            var searchExt = $"*.{ExtConstant.Ini}";

            foreach (string filePath in Directory.EnumerateFiles(folderPath, searchExt))
            {
                string name = Path.GetFileNameWithoutExtension(filePath);
                NamesToPaths[name] = filePath;
            }

            // In advance
            _intCache = new Dictionary<string, int>();
            _boolCache = new Dictionary<string, bool>();
        }

        public void LoadConfig(string configName, byte[] source)
        {
            _intCache.Clear();
            _boolCache.Clear();

            foreach (string line in File.ReadLines(NamesToPaths[configName], Encoding.UTF8))
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
                    && IoHelper.TryReadPointer(source, pointerOffset, out int resultOffset))
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

            if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";"))
            {
                return false;
            }

            // Split at '='
            string[] parts = line.Split('=');
            if (parts.Length != PartsCount)
            {
                return false;
            }

            key = parts[(int)Kvp.Key].RemoveSpace();
            rawValue = parts[(int)Kvp.Val].RemoveSpace();
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
