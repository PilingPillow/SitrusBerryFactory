using System;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    public static class FieldValueConv
    {
        public static ConvData<T> ConvBytesToModel<T>(
            this FieldValueHolder fieldValue,
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
                isSigned: fieldValue.Interps.IsSigned);

            // Pointer
            if (fieldValue.Interps.IsPointer)
            {
                var primaryData = rawFieldValue == 0L
                    ? (T)Convert.ChangeType(InvalidConstants.InvalidValue, typeof(T))
                    : (T)Convert.ChangeType(rawFieldValue - BinaryConstants.BaseAddr, typeof(T));
                return new ConvData<T>(primaryData);
            }

            // Temporary ConvData
            var convData = new ConvData<T>((T)Convert.ChangeType(rawFieldValue, typeof(T)));

            // Adding Bit Values
            foreach (var bitDef in fieldValue.Interps.BitMapping)
            {
                long rawBitValue = binaryData.GetBitValue(0, entryLength, bitDef);
                convData.Register(bitDef.Name, rawBitValue);
            }

            return convData;
        }

        public static byte[] ConvModelToBytes<T>(
            this T value,
            FieldValueHolder fieldValue,
            CharmapManager charmap)
        {

        }
    }
}
