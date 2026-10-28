using System;
using System.Globalization;
using System.Text;
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
                return BinaryConstants.InvalidValue;
            }

            return int.TryParse(str.RemoveSpace(), NumberStyles.HexNumber, null, out int value)
                    ? value
                    : BinaryConstants.InvalidValue;
        }

        public static string ParseIntToString(
            this int value,
            int digits = BinaryConstants.OffsetDigits)
        {
            return value != BinaryConstants.InvalidValue
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
    }
}
