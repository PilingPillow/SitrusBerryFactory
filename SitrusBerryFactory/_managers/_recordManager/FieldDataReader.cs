using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    /// <summary>
    /// The order of separated values in each line.
    /// </summary>
    public enum FieldDataOrder
    {
        Key,
        Field,
        Attr,
    }

    public sealed class FieldData
    {
        public string Key { get; }
        public FieldKind Field { get; }
        public Dictionary<AttrKind, string[]> Attrs { get; }

        public FieldData(
            string key,
            FieldKind field,
            Dictionary<AttrKind, string[]> attrs)
        {
            Key = key;
            Field = field;
            Attrs = attrs;
        }
    }

    public static class FieldDataReader
    {
        /// <summary>
        /// Parses a file and returns a list of FieldMetadata.
        /// </summary>
        public static List<FieldData> Create(string fileName)
        {
            var splitLines = ReadFile(fileName);
            return ReadFields(splitLines);
        }

        private static List<string[]> ReadFile(string fileName)
        {
            List<string[]> splitLines = new List<string[]>();

            var foundFiles = Directory.GetFiles(
                Path.Combine(Application.StartupPath, ExtConstants.DefExt),
                Path.ChangeExtension(fileName, ExtConstants.DefExt),
                SearchOption.AllDirectories);

            // Read the first matching file
            var allLines = File.ReadAllLines(foundFiles[0], Encoding.UTF8);

            foreach (var line in allLines)
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Split by colons
                var parts = line
                    .Split(':')
                    .Select(p => p.RemoveSpace())
                    .ToArray();

                splitLines.Add(parts);
            }

            return splitLines;
        }

        private static List<FieldData> ReadFields(List<string[]> splitLines)
        {
            var metaDataList = new List<FieldData>();

            foreach (var line in splitLines)
            {
                string key = line[(int)FieldDataOrder.Key];

                string fieldStr = line[(int)FieldDataOrder.Field];
                var fieldKind = (FieldKind)Enum.Parse(typeof(FieldKind), fieldStr);

                // Read the attribute
                var attrs = new Dictionary<AttrKind, string[]>();
                for (int i = (int)FieldDataOrder.Attr; i < line.Length; i++)
                {
                    string attrStr = line[i];

                    // Find the parentheses ( must have )
                    var openParenIndex = attrStr.IndexOf('(');
                    var closeParenIndex = attrStr.LastIndexOf(')');

                    // Parse the attribute kind
                    var attrKind = (AttrKind)Enum.Parse(typeof(AttrKind), attrStr.Substring(0, openParenIndex));

                    // Extract the attribute arguments
                    var argsStr = attrStr.Substring(openParenIndex + 1, closeParenIndex - openParenIndex - 1);

                    // Split arguments by commas
                    var argParts = argsStr
                        .Split(',')
                        .ToArray();

                    // Store the attribute and its arguments
                    attrs[attrKind] = argParts;
                }

                // Store the field metadata
                metaDataList.Add(new FieldData(key, fieldKind, attrs));
            }

            return metaDataList;
        }
    }
}
