using System;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers
{
    public static class IoHelper
    {
        /// <summary>
        /// Reads an integer from a byte array.
        /// Only lengths of 1 to 4 bytes are supported.
        /// </summary>
        public static int ReadAsInt(
            this byte[] source,
            int offset,
            int length,
            bool isLittleEndian = true,
            bool isSigned = false)
        {
            var valid = source ?? Array.Empty<byte>();
            int result = 0;

            for (int i = 0; i < length; i++)
            {
                result = isLittleEndian
                    ? result | (valid[offset + i] << (BinaryConstant.BitsPerByte * i))
                    : (result << BinaryConstant.BitsPerByte) | valid[offset + i];
            }

            if (isSigned)
            {
                int shift = (sizeof(int) * BinaryConstant.BitsPerByte) - (length * BinaryConstant.BitsPerByte);
                result = (result << shift) >> shift;
            }

            return result;
        }

        /// <summary>
        /// Writes an integer into a byte array.
        /// Only lengths of 1 to 4 bytes are supported.
        /// </summary>
        public static void WriteInt(
            this byte[] source,
            int offset,
            int length,
            int value,
            bool isLittleEndian = true)
        {
            var valid = source ?? Array.Empty<byte>();
            for (int i = 0; i < length; i++)
            {
                int shift = BinaryConstant.BitsPerByte * (isLittleEndian ? i : length - 1 - i);
                valid[offset + i] = (byte)((value >> shift) & MaskConstant.Byte);
            }
        }

        /// <summary>
        /// Reads the target pointer offset as an integer.
        /// Returns <see langword="true"/> and <see cref="InvalidConstant.Val"/> for a null pointer.
        /// Returns <see langword="false"/> and <see cref="InvalidConstant.Val"/> for an invalid pointer.
        /// </summary>
        public static bool TryReadPointer(
            this byte[] source,
            int pointerOffset,
            out int resultOffset)
        {
            int addr = ReadAsInt(
                source,
                pointerOffset,
                sizeof(int));

            // Null pointer
            if (addr == 0)
            {
                resultOffset = InvalidConstant.Val;
                return true;
            }

            // Out of range
            if (addr < BinaryConstant.BaseAddr || BinaryConstant.EndAddr < addr)
            {
                resultOffset = InvalidConstant.Val;
                return false;
            }

            resultOffset = addr - BinaryConstant.BaseAddr;
            return true;
        }
    }
}
