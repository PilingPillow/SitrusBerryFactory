using System;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
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
                isLittleEndian: false,
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

            // Adding bit values
            foreach (var bitDef in fieldValue.Interps.BitMapping)
            {
                long rawBitValue = binaryData.GetBitValue(0, entryLength, bitDef);
                convData.Register(bitDef.Name, rawBitValue);
            }

            return convData;
        }

        public static byte[] ConvModelToBytes<T>(
            this ConvData<T> convData,
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
                    Convert.ToString(convData.PrimaryData),
                    appendTerminator: true,
                    targetLength: fieldValue.Lengths.AllowedLength);

                // EntryLength
                Array.Copy(bytes, result, Math.Min(bytes.Length, entryLength));

                return result;
            }

            long rawValue = Convert.ToInt64(convData.PrimaryData);

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

            // Change bit values
            foreach (var bitDef in fieldValue.Interps.BitMapping)
            {
                BitCalcHelper.SetBitValue(
                    result,
                    0,
                    entryLength,
                    bitDef,
                    convData.AsDynamic());
            }

            return result;
        }
    }
}
