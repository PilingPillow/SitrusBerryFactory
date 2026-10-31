using System;
using System.Collections.Generic;
using System.Linq;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._managers._historyManager;
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

        private readonly SharedData _sharedData = null;

        public FieldValueHolder(FieldMetadata metadata, SharedData sharedData)
        {
            _sharedData = sharedData;
            var config = _sharedData.Config.AsDynamic();

            Key = metadata.Key;

            // Check StringAttr
            if (metadata.Attrs.TryGetValue(AttrKind.String, out string[] lengths))
            {
                string entryLenthKey = lengths[(int)StringAttrArgs.EntryLengthArg];
                int entryLength = (int)config[entryLenthKey];
                int allowedLength = entryLength;

                // Second argument (AllowedLengthArg) may be omitted
                if (lengths.Length == Enum.GetNames(typeof(StringAttrArgs)).Length)
                {
                    string AllowedLengthKey = lengths[(int)StringAttrArgs.AllowedLengthArg];
                    allowedLength = (int)config[AllowedLengthKey];
                }

                Lengths = new FieldLength(entryLength, allowedLength);
            }
            else
            {
                Lengths = new FieldLength(metadata.Field.GetFieldSize());
            }

            // Check Others
            Interps = new ValueInterpretations(
                metadata.Field.IsSigned(),
                metadata.Attrs.ContainsKey(AttrKind.Pointer),
                new List<BitDefinition>());

            // check BitAttr
            if (metadata.Attrs.TryGetValue(AttrKind.Bit, out string[] args))
            {
                int currentPos = 0;
                foreach (var bitLengthKey in args)
                {
                    int bitLength = (int)config[bitLengthKey];
                    Interps.BitMapping.Add(new BitDefinition(bitLengthKey, currentPos, bitLength));
                    currentPos += bitLength;
                }
            }
        }

        public ConvData<T> GetData<T>(Func<FieldValueHolder, CharmapManager, ConvData<T>> converter = null)
        {
            return converter != null
                ? converter(this, _sharedData.Charmap)
                : FieldValueConv.ConvBytesToModel<T>(this, _sharedData.Charmap);
        }

        public void SetData<T>(
            ConvData<T> newData,
            Func<ConvData<T>, FieldValueHolder, CharmapManager, byte[]> converter = null)
        {
            BinaryData = converter != null
                    ? converter(newData, this, _sharedData.Charmap)
                    : FieldValueConv.ConvModelToBytes(newData, this, _sharedData.Charmap);
        }

        /// <summary>
        /// For not variable data.
        /// </summary>
        public void UpdateData<T>(
            HistoryManager commandManager,
            ConvData<T> newData,
            string desc)
        {
            var command = CreateUpdateCommand(newData, desc);

            if (command != null)
            {
                commandManager.PushCommand(command);
            }
        }

        public ICommand CreateUpdateCommand<T>(
            ConvData<T> data, 
            string desc)
        {
            byte[] oldBinary = BinaryData;
            SetData(data);
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
        public List<BitDefinition> BitMapping { get; }

        public ValueInterpretations(
            bool isSigned, 
            bool isPointer,
            List<BitDefinition> bitMapping)
        {
            IsSigned = isSigned;
            IsPointer = isPointer;
            BitMapping = bitMapping;
        }
    }
}
