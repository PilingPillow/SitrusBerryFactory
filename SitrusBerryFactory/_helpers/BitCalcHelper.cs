namespace SitrusBerryFactory._helpers
{
    public sealed class BitDefinition
    {
        public string Name { get; }
        public int StartBit { get; }
        public int BitLength { get; }

        public BitDefinition(string name, int startBit, int bitLength)
        {
            Name = name;
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
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long mask = (1L << definition.BitLength) - 1;
            return (packedValue >> definition.StartBit) & mask;
        }

        public static void SetBits(
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

            long originalMask = (1L << definition.BitLength) - 1;
            long shiftedMask = originalMask << definition.StartBit;

            // Clear the target bits and set the new value
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
