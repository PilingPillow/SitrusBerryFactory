using System;
using System.Text;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers
{
    public static class ConvHelper
    {
        /// <summary>
        /// Removes all whitespace from the string.
        /// If the result is empty, can return a single space.
        /// </summary>
        public static string RemoveSpace(this string str, bool spaceIfEmpty = false)
        {
            string validStr = str ?? "";

            var sb = new StringBuilder(validStr.Length);
            foreach (char c in validStr)
            {
                if (!char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                }
            }

            return sb.Length == 0 && spaceIfEmpty
                ? " "
                : sb.ToString();
        }

        /// <summary>
        /// Parses the string as a hex. 
        /// Returns <see cref="InvalidConstant.Val"/> if the string is null or whitespace.
        /// </summary>
        public static int ParseHexToInt(this string str) =>
            string.IsNullOrWhiteSpace(str)
                ? InvalidConstant.Val
                : Convert.ToInt32(str.RemoveSpace(), BinaryConstant.HexBase);

        /// <summary>
        /// Converts the integer to a hex string padded to the number of digits.
        /// Returns an empty string if the value equals <see cref="InvalidConstant.Val"/>.
        /// </summary>
        public static string ToHexString(this int val, int digits = BinaryConstant.OffsetDigits) =>
            val == InvalidConstant.Val
                ? string.Empty
                : val.ToString($"X{digits}");

        /// <summary>
        /// Returns a new byte array aligned to a multiple of 4 bytes.
        /// </summary>
        public static byte[] Align(this byte[] source, byte pad = CharConstant.Padding)
        {
            byte[] vaildArray = source ?? Array.Empty<byte>();

            int padCount = -vaildArray.Length & (sizeof(int) - 1);
            if (padCount == 0)
            {
                return vaildArray;
            }

            int newLength = vaildArray.Length + padCount;
            byte[] dest = new byte[newLength];
            Buffer.BlockCopy(vaildArray, 0, dest, 0, vaildArray.Length);

            // If padding char is not default
            if (pad != CharConstant.Padding)
            {
                for (int i = vaildArray.Length; i < newLength; i++)
                {
                    dest[i] = pad;
                }
            }

            return dest;
        }
    }
}
