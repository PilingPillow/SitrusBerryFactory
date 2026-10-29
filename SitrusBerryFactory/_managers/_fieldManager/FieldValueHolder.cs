using System;
using System.Collections.Generic;
using System.Linq;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._fieldManager
{
    public sealed class FieldValueHolder
    {
        public string Key { get; }
        public int Offset { get; set; }
        public FieldLength Lengths { get; }
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
        private bool _isPointer = false;
        private bool _isSigned = false;

        public FieldValueHolder(FieldMetadata metadata, SharedData sharedData)
        {
            _sharedData = sharedData;

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
                        if (kvp.Value.Length < Enum.GetNames(typeof(AttrKind)).Length)
                        {
                            continue;
                        }

                        string AllowedLengthKey = kvp.Value[(int)StringAttrArgs.AllowedLengthArg];
                        Lengths.AllowedLength = (int)_sharedData.Config.AsDynamic()[AllowedLengthKey];
                        continue;

                    case AttrKind.Pointer:
                        _isPointer = true;
                        continue;

                    case AttrKind.Bit:
                        // 
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
}
