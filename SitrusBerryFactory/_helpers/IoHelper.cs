using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers
{
    public static class IoHelper
    {
        /// <summary>
        /// Uses long to support signed.
        /// </summary>
        public static long ReadBytesAsLong(
            this byte[] buffer,
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
            this byte[] buffer,
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

        /// <summary>
        /// Reads the target pointer offset as int.
        /// Returns true and BinaryConstants.InvalidValue for a null pointer.
        /// Returns false and BinaryConstants.InvalidValue for an invalid pointer.
        /// </summary>
        public static bool TryReadPointer(
            this byte[] source,
            int pointerOffset,
            out int resultOffset)
        {
            uint rawAddr = (uint)ReadBytesAsLong(
                source,
                pointerOffset,
                sizeof(uint));

            // Null pointer
            if (rawAddr == 0U)
            {
                resultOffset = BinaryConstants.InvalidValue;
                return true;
            }

            // Out of range
            if (rawAddr < BinaryConstants.BaseAddr || BinaryConstants.EndAddr < rawAddr )
            {
                resultOffset = BinaryConstants.InvalidValue;
                return false;
            }

            resultOffset = (int)(rawAddr - BinaryConstants.BaseAddr);
            return true;
        }
    }
}
