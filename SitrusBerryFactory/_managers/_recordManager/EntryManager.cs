using System.Collections.Generic;
using System.Linq;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    public sealed class SingleEntry : DynamicAccessor<FieldValueHolder>
    {
        public int EntryIndex { get; }
        public int EntrySize { get; }

        public SingleEntry(
            int baseOffset,
            int entryIndex,
            List<FieldValueHolder> fields)
        {
            EntryIndex = entryIndex;
            EntrySize = fields.Sum(f => f.Lengths.EntryLength);

            int entryOffset = baseOffset + (EntryIndex * EntrySize);

            // Registers to the dictionary
            int currentPos = 0;
            foreach (var field in fields)
            {
                field.Offset = entryOffset + currentPos;
                Register(field.Key, field);

                currentPos += field.Lengths.EntryLength;
            }
        }
    }

    public sealed class EntryTable
    {
        public List<SingleEntry> Entries { get; }

        public EntryTable(
            string defFileName,
            int baseOffset,
            int entryCount,
            SharedData sharedData)
        {
            Entries = new List<SingleEntry>();

            // Analyzes the def file
            var fieldMetaDataList = MetadataReader.Create(defFileName);

            // For each Entry
            for (int i = 0; i < entryCount; i++)
            {
                var entryFields = new List<FieldValueHolder>();

                // For each Field
                for (int j = 0; j < fieldMetaDataList.Count; j++)
                {
                    var fieldValue = new FieldValueHolder(
                        fieldMetaDataList[j],
                        sharedData);
                    entryFields.Add(fieldValue);
                }

                Entries.Add(new SingleEntry(baseOffset, i, entryFields));
            }
        }
    }
}
