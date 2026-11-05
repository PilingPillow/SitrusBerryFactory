using System.Dynamic;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    public sealed class BitThreshold
    {
        public int StartBit { get; }
        public int BitLength { get; }

        public BitThreshold(int startBit, int bitLength)
        {
            StartBit = startBit;
            BitLength = bitLength;
        }
    }

    public sealed class BitValueMapping : DynamicAccessor<BitThreshold>
    {
        private readonly FieldValueHolder _owner = null;

        public BitValueMapping(FieldValueHolder owner)
        {
            _owner = owner;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_values.TryGetValue(binder.Name, out var threshold))
            {
                byte[] binary = _owner.BinaryData;
                result = binary.GetBitValue(0, binary.Length, threshold);
                return true;
            }

            return base.TryGetMember(binder, out result);
        }
    }

    public static class BitValueAnalyzer
    {
        public static long GetBitValue(
            this byte[] source,
            int offset,
            int byteLength,
            BitThreshold threshold)
        {
            // Read as long to inclule signed values
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long mask = (1L << threshold.BitLength) - 1;
            return (packedValue >> threshold.StartBit) & mask;
        }

        public static void SetBitValue(
            this byte[] source,
            int offset,
            int byteLength,
            BitThreshold threshold,
            long value)
        {
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long originalMask = (1L << threshold.BitLength) - 1;
            long shiftedMask = originalMask << threshold.StartBit;

            // Clear target bits and apply the new value
            packedValue = (packedValue & ~shiftedMask)
                       | ((value & originalMask) << threshold.StartBit);

            source.WriteLongAsBytes(
                offset,
                byteLength,
                packedValue,
                isLittleEndian: false);
        }
    }
}
