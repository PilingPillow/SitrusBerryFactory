using System;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._fieldManager
{
    /// <summary>
    /// Includes Bit Values.
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
        public static ConvData<T> BytesToModelConv<T>(
            FieldValueHolder fieldValue,
            ValueInterpretations interp,
            CharmapManager charmap,
            string bitKey = InvalidConstants.InvalidStr)
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

            long rawFieldValue = IoHelper.ReadBytesAsLong(
                binaryData,
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

            // Add the fake BitDefinition to the list
            if (interp.BitMapping.Count == 0)
            {
                interp.BitMapping.Add(
                    new BitDefinition(bitKey, 0, entryLength * BinaryConstants.BitsPerByte));
            }

            // Temporary ConvData
            var convData = new ConvData<T>((T)Convert.ChangeType(rawFieldValue, typeof(T)));

            // Adding Bit Values
            foreach (var bitDef in interp.BitMapping)
            {
                long rawBitValue = BitCalcHelper.GetBits(binaryData, 0, entryLength, bitDef);
                convData.Register(bitDef.Name, rawBitValue);
            }

            return convData;
        }
    }
}
