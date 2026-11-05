using System.Dynamic;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    public sealed class BitValueDefinition
    {
        public int StartBit { get; }
        public int BitLength { get; }

        public BitValueDefinition(int startBit, int bitLength)
        {
            StartBit = startBit;
            BitLength = bitLength;
        }
    }

    public sealed class BitValueMapping : DynamicAccessor<BitValueDefinition>
    {

    }

    public static class BitValueAnalyzer
    {
        public static long GetBitValue(
            this byte[] source,
            int offset,
            int byteLength,
            BitValueDefinition definition)
        {
            // Read as long to inclule signed values
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long mask = (1L << definition.BitLength) - 1;
            return (packedValue >> definition.StartBit) & mask;
        }

        public static void SetBitValue(
            this byte[] source,
            int offset,
            int byteLength,
            BitValueDefinition definition,
            long value)
        {
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long originalMask = (1L << definition.BitLength) - 1;
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
