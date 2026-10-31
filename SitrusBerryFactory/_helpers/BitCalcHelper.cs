using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers
{
    public sealed class BitMapping : DynamicAccessor<BitDefinition> { }

    public sealed class BitDefinition
    {
        public int StartBit { get; }
        public int BitLength { get; }

        public BitDefinition(int startBit, int bitLength)
        {
            StartBit = startBit;
            BitLength = bitLength;
        }
    }

    public static class BitCalcHelper
    {
        public static long GetBitValue(
            this byte[] source,
            int offset,
            int byteLength,
            BitDefinition definition)
        {
            // Read as long to inclule signed values
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long mask = (1L << definition.BitLength) - 1L;
            return (packedValue >> definition.StartBit) & mask;
        }

        public static void SetBitValue(
            this byte[] source,
            int offset,
            int byteLength,
            BitDefinition definition,
            long value)
        {
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long originalMask = (1L << definition.BitLength) - 1L;
            long shiftedMask = originalMask << definition.StartBit;

            // Clear target bits and apply the new value
            packedValue = (packedValue & ~shiftedMask)
                       | ((value & originalMask) << definition.StartBit);

            source.WriteLongAsBytes(
                offset,
                byteLength,
                packedValue,
                isLittleEndian: false);
        }
    }
}
