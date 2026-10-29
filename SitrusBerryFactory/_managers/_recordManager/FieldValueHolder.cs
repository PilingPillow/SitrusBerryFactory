using System;
using System.Collections.Generic;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    public sealed class FieldValueHolder
    {
        public string Key { get; }
        public int Offset { get; set; }
        public FieldLength Lengths { get; set; }
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
            Interps.BitMapping = new List<BitDefinition>();

            // set the key
            Key = metadata.Key;

            // Set temporary lengths
            Lengths = new FieldLength();
            Lengths.EntryLength = metadata.Field.GetFieldSize();
            Lengths.AllowedLength = InvalidConstants.InvalidValue;

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
                            Lengths.AllowedLength = Lengths.EntryLength;
                            continue;
                        }

                        string AllowedLengthKey = kvp.Value[(int)StringAttrArgs.AllowedLengthArg];
                        Lengths.AllowedLength = (int)_sharedData.Config.AsDynamic()[AllowedLengthKey];
                        continue;

                    case AttrKind.Bit:
                        var config = _sharedData.Config.AsDynamic();
                        int currentPos = 0;

                        foreach (var bitLengthKey in kvp.Value)
                        {
                            int bitLength = (int)config[bitLengthKey];
                            Interps.BitMapping.Add(new BitDefinition(bitLengthKey, currentPos, bitLength));
                            currentPos += bitLength;
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
        public List<BitDefinition> BitMapping { get; set; }
    }
}
