using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers
{
    /// <summary>
    /// Loads values from configuration files.
    /// </summary>
    public sealed class ConfigManager : DynamicAccessor<object>
    {
        /// <summary>
        /// Maps configuration names to file paths.
        /// </summary>
        public Dictionary<string, string> Dict { get; }

        public ConfigManager(string folderPath)
        {
            var searchExt = $"*.{ExtConstants.IniExt}";
            Dict = new Dictionary<string, string>();

            foreach (string filePath in Directory.EnumerateFiles(folderPath, searchExt))
            {
                string name = Path.GetFileNameWithoutExtension(filePath);
                Dict[name] = filePath;
            }
        }

        public void LoadConfig(string configName, byte[] source)
        {
            ClearDict();

            if (!Dict.TryGetValue(configName, out string filePath))
            {
                return;
            }

            foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
            {
                if (!TryParseLine(line, out string key, out string rawValue))
                {
                    continue;
                }

                if (bool.TryParse(rawValue, out bool boolValue))
                {
                    Register(key, boolValue);
                    continue;
                }

                // '*' marks a pointer offset
                if (rawValue.StartsWith("*")
                    && TryParseNumber(rawValue.Substring(1), out int pointerOffset)
                    && IoHelper.TryReadPointer(source, pointerOffset, out int resultOffset))
                {
                    Register(key, resultOffset);
                    continue;
                }

                if (TryParseNumber(rawValue, out int numberValue))
                {
                    Register(key, numberValue);
                }
            }
        }

        private static bool TryParseLine(string line, out string key, out string rawValue)
        {
            key = string.Empty;
            rawValue = string.Empty;

            if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";"))
            {
                return false;
            }

            // Split at '='
            string[] parts = line.Split('=');
            int count = Enum.GetValues(typeof(PartName)).Length;
            if (parts.Length != count)
            {
                return false;
            }

            key = parts[(int)PartName.Key].RemoveSpace();
            rawValue = parts[(int)PartName.Value].RemoveSpace();
            return true;
        }

        private bool TryParseNumber(string rawValue, out int parsedValue)
        {
            if (rawValue.StartsWith(PrefixConstants.HexPrefix)) // 0x
            {
                string hexPart = rawValue.Substring(PrefixConstants.HexPrefix.Length);
                parsedValue = ConvHelper.ParseStringToInt(hexPart);
                return true;
            }

            return int.TryParse(rawValue, out parsedValue);
        }
    }
}
