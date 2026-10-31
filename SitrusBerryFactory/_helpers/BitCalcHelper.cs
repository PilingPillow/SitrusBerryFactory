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
        public static int GetBitValue(
            this byte[] source,
            int offset,
            int byteLength,
            BitDefinition definition)
        {
            int packedValue = (int)source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            int mask = (int)((1U << definition.BitLength) - 1);
            return (packedValue >> definition.StartBit) & mask;
        }

        public static void SetBitValue(
                    this byte[] source,
                    int offset,
                    int byteLength,
                    BitDefinition definition,
                    int value)
        {
            int packedValue = (int)source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            int originalMask = (int)((1U << definition.BitLength) - 1);
            int shiftedMask = originalMask << definition.StartBit;

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
