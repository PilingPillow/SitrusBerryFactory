using System;
using System.Linq;
using SitrusBerryFactory._managers._historyManager;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
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

        private readonly SharedData _sharedData = null;

        public FieldValueHolder(FieldData fieldData, SharedData sharedData)
        {
            _sharedData = sharedData;
            var config = _sharedData.Config.AsDynamic();

            Key = fieldData.Key;

            // Create Interps
            Interps = new ValueInterpretations(
                fieldData.Field.IsSigned(),
                fieldData.Attrs.ContainsKey(AttrKind.Pointer),
                new BitValueMapping()); // not null

            // Check StringAttr
            if (fieldData.Attrs.TryGetValue(AttrKind.String, out string[] lengths))
            {
                string entryLenthKey = lengths[(int)StringAttrArgs.EntryLengthArg];
                int entryLength = (int)config[entryLenthKey]; // get from config
                int allowedLength = entryLength; // temporarily

                // Second argument (AllowedLengthArg) may be omitted
                if (lengths.Length == Enum.GetNames(typeof(StringAttrArgs)).Length)
                {
                    string AllowedLengthKey = lengths[(int)StringAttrArgs.AllowedLengthArg];
                    allowedLength = (int)config[AllowedLengthKey]; // overwrite
                }

                Lengths = new FieldLength(entryLength, allowedLength);
            }
            else
            {
                Lengths = new FieldLength(fieldData.Field.GetFieldSize());
            }

            // Check BitAttr
            if (fieldData.Attrs.TryGetValue(AttrKind.Bit, out string[] args))
            {
                int currentPos = 0;
                foreach (var bitLengthKey in args)
                {
                    int bitLength = (int)config[bitLengthKey]; // get from config
                    int startBit = Lengths.EntryLength * BinaryConstants.BitsPerByte - currentPos - bitLength;
                    Interps.BitValues.Register(bitLengthKey, new BitValueDefinition(startBit, bitLength));

                    currentPos += bitLength;
                }
            }
        }

        public T GetData<T>(
            Func<FieldValueHolder, CharmapManager, T> converter = null)
        {
            return converter != null
                ? converter(this, _sharedData.Charmap)
                : FieldValueConv.ConvBytesToModel<T>(this, _sharedData.Charmap);
        }

        public void SetData<T>(
            T newValue,
            Func<T, FieldValueHolder, CharmapManager, byte[]> converter = null)
        {
            BinaryData = converter != null
                    ? converter(newValue, this, _sharedData.Charmap)
                    : FieldValueConv.ConvModelToBytes(newValue, this, _sharedData.Charmap);
        }

        /// <summary>
        /// For not variable data.
        /// </summary>
        public void UpdateData<T>(
            HistoryManager commandManager,
            T newValue,
            string desc)
        {
            var command = CreateUpdateCommand(newValue, desc);

            if (command != null)
            {
                commandManager.PushCommand(command);
            }
        }

        public ICommand CreateUpdateCommand<T>(
            T newValue, 
            string desc)
        {
            // Store the old data
            byte[] oldBinary = BinaryData;

            SetData(newValue);
            byte[] newBinary = BinaryData;

            // Ignores if the same
            if (oldBinary.SequenceEqual(newBinary)) return null;

            return new FieldValueChangeCommand(
                this,
                oldBinary,
                newBinary,
                desc);
        }
    }

    public sealed class FieldLength
    {
        public int EntryLength { get; }
        public int AllowedLength { get; }

        public FieldLength(
            int entryLength, 
            int allowedLength = InvalidConstants.InvalidValue)
        {
            EntryLength = entryLength;
            AllowedLength = allowedLength;
        }
    }

    public sealed class ValueInterpretations
    {
        public bool IsSigned { get; }
        public bool IsPointer { get; }
        public BitValueMapping BitValues { get; }

        public ValueInterpretations(
            bool isSigned, 
            bool isPointer,
            BitValueMapping bitValues)
        {
            IsSigned = isSigned;
            IsPointer = isPointer;
            BitValues = bitValues;
        }
    }
}
