using System;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    public static class FieldValueConv
    {
        public static T ConvBytesToModel<T>(
            this FieldValueHolder fieldValue,
            CharmapManager charmap)
        {
            var entryLength = fieldValue.Lengths.EntryLength;
            var binaryData = fieldValue.BinaryData;

            // String
            if (fieldValue.Lengths.AllowedLength > 0)
            {
                return (T)Convert.ChangeType(
                    charmap.BytesToString(binaryData, 0, entryLength),
                    typeof(T));
            }

            long rawFieldValue = binaryData.ReadBytesAsLong(
                0,
                entryLength,
                isLittleEndian: false,
                isSigned: fieldValue.Interps.IsSigned);

            // Pointer
            if (fieldValue.Interps.IsPointer)
            {
                return rawFieldValue == 0L
                    ? (T)Convert.ChangeType(InvalidConstants.InvalidValue, typeof(T))
                    : (T)Convert.ChangeType(rawFieldValue - BinaryConstants.BaseAddr, typeof(T));
            }

            return (T)Convert.ChangeType(rawFieldValue, typeof(T));
        }

        public static byte[] ConvModelToBytes<T>(
            this T value,
            FieldValueHolder fieldValue,
            CharmapManager charmap)
        {
            int entryLength = fieldValue.Lengths.EntryLength;

            // To merge
            byte[] result = new byte[entryLength];
            Array.Copy(fieldValue.BinaryData, result, entryLength);

            // String
            if (fieldValue.Lengths.AllowedLength > 0)
            {
                // AllowedLength
                byte[] bytes = charmap.StringToBytes(
                    Convert.ToString(value),
                    appendTerminator: true,
                    targetLength: fieldValue.Lengths.AllowedLength);

                // EntryLength
                Array.Copy(bytes, result, Math.Min(bytes.Length, entryLength));

                return result;
            }

            long rawValue = Convert.ToInt64(value);

            // Pointer
            if (fieldValue.Interps.IsPointer)
            {
                rawValue = rawValue == InvalidConstants.InvalidValue
                    ? 0L
                    : rawValue + BinaryConstants.BaseAddr;
            }

            result.WriteLongAsBytes(
                0,
                entryLength,
                rawValue,
                isLittleEndian: false);

            return result;
        }
    }
}
