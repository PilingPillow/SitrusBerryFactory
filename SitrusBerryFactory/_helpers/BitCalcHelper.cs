using SitrusBerryFactory._utilities;

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
        public static long GetBits(
            byte[] source,
            int offset,
            int byteLength,
            BitDefinition definition)
        {
            // Combine bytes into a single value
            ulong value = 0;
            for (int i = 0; i < byteLength; i++)
            {
                value = (value << BinaryConstants.BitsPerByte) | source[offset + i];
            }

            ulong mask = (1UL << definition.BitLength) - 1;
            return (long)((value >> definition.StartBit) & mask);
        }
    }
}
