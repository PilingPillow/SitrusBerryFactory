using System;
using System.Text;
using SitrusBerryFactory._managers;
using SitrusBerryFactory._managers._fieldManager;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers
{
    public static class ConvHelper
    {
        public static string RemoveSpace(this string str)
        {
            if (str == null)
            {
                return str;
            }

            var sb = new StringBuilder(str.Length);

            foreach (char c in str)
            {
                if (!char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public static int ParseStringToInt(this string str)
        {
            // Check for null or empty
            if (string.IsNullOrWhiteSpace(str))
            {
                return InvalidConstants.InvalidValue;
            }

            return Convert.ToInt32(str.RemoveSpace(), BinaryConstants.HexBase);
        }

        public static string ParseIntToString(
            this int value,
            int digits = BinaryConstants.OffsetDigits)
        {
            return value != InvalidConstants.InvalidValue
                ? value.ToString($"X{digits}")
                : string.Empty;
        }

        /// <summary>
        /// Returns a byte array aligned to a multiple of 4 bytes.
        /// </summary>
        public static byte[] AlignBytes(
            this byte[] source,
            byte alignPaddingByte = BinaryConstants.PaddingByte)
        {
            int alignment = sizeof(uint);

            // Create the aligned array
            int paddingCount = (alignment - (source.Length % alignment)) % alignment;
            byte[] result = new byte[source.Length + paddingCount];

            Array.Copy(source, result, source.Length);

            // Fill the padding bytes
            for (int i = source.Length; i < result.Length; i++)
            {
                result[i] = alignPaddingByte;
            }

            return result;
        }

        public static T BytesToModelConv<T>(
            FieldValueHolder fieldValue,
            ValueInterpretations interp,
            CharmapManager charmap,
            string bitKey = InvalidConstants.InvalidStr)
        {
            var entryLength = fieldValue.Lengths.EntryLength;
            var binaryData = fieldValue.BinaryData;

            // string
            if (fieldValue.Lengths.AllowedLength > 0)
            {
                return (T)Convert.ChangeType
                    (charmap.BytesToString(binaryData, 0, entryLength),
                    typeof(T));
            }

            long rawValue = IoHelper.ReadBytesAsLong(
                binaryData,
                0,
                entryLength,
                isLittleEndian: true,
                isSigned: interp.IsSigned);

            // pointer
            if (interp.IsPointer)
            {
                return rawValue == 0L
                    ? (T)Convert.ChangeType(InvalidConstants.InvalidValue, typeof(T))
                    : (T)Convert.ChangeType(rawValue - BinaryConstants.BaseAddr, typeof(T));
            }

            // add the fake to the list
            if (bitKey == InvalidConstants.InvalidStr)
            {
                interp.BitSequence.Register(bitKey, new BitAttrDefinition(0, ));
            }
        }
    }
}
