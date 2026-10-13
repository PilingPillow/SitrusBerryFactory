using System;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers
{
    public static class IoHelper
    {
        /// <summary>
        /// Uses long to support signed.
        /// </summary>
        public static long ReadBytesAsLong(
            byte[] buffer,
            int offset,
            int byteCount,
            bool isLittleEndian = true,
            bool isSigned = false)
        {
            long result = 0;

            // Convert bytes to long
            for (int i = 0; i < byteCount; i++)
            {
                result = isLittleEndian
                    ? result | ((long)buffer[offset + i] << (BinaryConstants.BitsPerByte * i))
                    : (result << BinaryConstants.BitsPerByte) | buffer[offset + i];
            }

            if (isSigned)
            {
                // Get the sign bit
                int bits = byteCount * BinaryConstants.BitsPerByte;
                long signBit = 1L << (bits - 1);

                if ((result & signBit) != 0)
                {
                    // Create a mask
                    long mask = (1L << bits) - 1;

                    // Set all higher bits to 1
                    result |= ~mask;
                }
            }

            return result;
        }

        public static void WriteLongAsBytes(
            byte[] buffer,
            int offset,
            int byteCount,
            long value,
            bool isLittleEndian = true)
        {
            for (int i = 0; i < byteCount; i++)
            {
                // Calculate the bit shift
                int shift = BinaryConstants.BitsPerByte * (isLittleEndian ? i : byteCount - 1 - i);

                buffer[offset + i] = (byte)((value >> shift) & BinaryConstants.ByteMask);
            }
        }

    }
}
