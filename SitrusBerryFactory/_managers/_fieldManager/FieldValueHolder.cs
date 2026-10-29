using System;
using System.Collections.Generic;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._fieldManager
{
    public sealed class FieldValueHolder
    {
        public string Key { get; }
        public int Offset { get; set; }
        public FieldLength Lengths { get; }
        public ValueInterpretations Interps { get; }
        public byte[] BinaryData
        {
            get
            {
                var length = Lengths.EntryLength;
                byte[] buffer = new byte[length];
                Array.Copy(_sharedData.RomData, Offset, buffer, 0, length);
                return buffer;
            }

            set
            {
                Array.Copy(value, 0, _sharedData.RomData, Offset, Lengths.EntryLength);
            }
        }

        private SharedData _sharedData = null;

        public FieldValueHolder(FieldMetadata metadata, SharedData sharedData)
        {
            _sharedData = sharedData;
            Interps = new ValueInterpretations();
            Interps.IsSigned = metadata.Field.IsSigned();
            Interps.IsPointer = metadata.Attrs.ContainsKey(AttrKind.Pointer);
            Interps.BitSequence = new List<BitAttrDefinition>();

            // set the key
            Key = metadata.Key;

            // Set temporary lengths
            Lengths = new FieldLength();
            Lengths.EntryLength = metadata.Field.GetFieldSize();
            Lengths.AllowedLength = BinaryConstants.InvalidValue;

            // check attributes
            foreach (KeyValuePair<AttrKind, string[]> kvp in metadata.Attrs)
            {
                switch (kvp.Key)
                {
                    case AttrKind.String:
                        string entryLenthKey = kvp.Value[(int)StringAttrArgs.EntryLengthArg];
                        Lengths.EntryLength = (int)_sharedData.Config.AsDynamic()[entryLenthKey];

                        // Second argument (AllowedLengthArg) may be omitted
                        if (kvp.Value.Length < Enum.GetNames(typeof(StringAttrArgs)).Length)
                        {
                            continue;
                        }

                        string AllowedLengthKey = kvp.Value[(int)StringAttrArgs.AllowedLengthArg];
                        Lengths.AllowedLength = (int)_sharedData.Config.AsDynamic()[AllowedLengthKey];
                        continue;

                    case AttrKind.Bit:
                        var inc = Enum.GetNames(typeof(PartName)).Length;

                        for (int i = 0; i < kvp.Value.Length; i += inc)
                        {
                            string name = kvp.Value[i + (int)PartName.Key];
                            int length = kvp.Value[i + (int)PartName.Value].ParseStringToInt();
                            Interps.BitSequence.Add(new BitAttrDefinition(name, length));
                        }
                        continue;
                }
            }
        }
    }

    public sealed class FieldLength
    {
        public int EntryLength { get; set; }
        public int AllowedLength { get; set; }
    }

    public sealed class ValueInterpretations
    {
        public bool IsSigned { get; set; }
        public bool IsPointer { get; set; }
        public List<BitAttrDefinition> BitSequence { get; set; }
    }
}
