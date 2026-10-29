using System;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._fieldManager
{
    /// <summary>
    /// Includes bit values.
    /// </summary>
    public sealed class ConvData<T> : DynamicAccessor<long>
    {
        public T PrimaryData { get; }

        public ConvData(T primaryData)
        {
            PrimaryData = primaryData;
        }

        public static explicit operator T(ConvData<T> convData)
            => convData.PrimaryData;
    }

    public static class FieldValueConv
    {
        public static ConvData<T> ConvBytesToModel<T>(
            FieldValueHolder fieldValue,
            ValueInterpretations interp,
            CharmapManager charmap)
        {
            var entryLength = fieldValue.Lengths.EntryLength;
            var binaryData = fieldValue.BinaryData;

            // String
            if (fieldValue.Lengths.AllowedLength > 0)
            {
                var primaryData = (T)Convert.ChangeType(
                    charmap.BytesToString(binaryData, 0, entryLength),
                    typeof(T));
                return new ConvData<T>(primaryData);
            }

            long rawFieldValue = binaryData.ReadBytesAsLong(
                0,
                entryLength,
                isLittleEndian: true,
                isSigned: interp.IsSigned);

            // Pointer
            if (interp.IsPointer)
            {
                var primaryData = rawFieldValue == 0L
                    ? (T)Convert.ChangeType(InvalidConstants.InvalidValue, typeof(T))
                    : (T)Convert.ChangeType(rawFieldValue - BinaryConstants.BaseAddr, typeof(T));
                return new ConvData<T>(primaryData);
            }

            // Temporary ConvData
            var convData = new ConvData<T>((T)Convert.ChangeType(rawFieldValue, typeof(T)));

            // Adding Bit Values
            foreach (var bitDef in interp.BitMapping)
            {
                long rawBitValue = binaryData.GetBitValue(0, entryLength, bitDef);
                convData.Register(bitDef.Name, rawBitValue);
            }

            return convData;
        }
    }
}
