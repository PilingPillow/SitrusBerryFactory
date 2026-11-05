using System.Dynamic;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._recordManager
{
    public sealed class BitthreshHold
    {
        public int StartBit { get; }
        public int BitLength { get; }

        public BitthreshHold(int startBit, int bitLength)
        {
            StartBit = startBit;
            BitLength = bitLength;
        }
    }

    public sealed class BitValueMapping : DynamicAccessor<BitthreshHold>
    {
        private readonly FieldValueHolder _owner = null;

        public BitValueMapping(FieldValueHolder owner)
        {
            _owner = owner;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_values.TryGetValue(binder.Name, out var threshhold))
            {
                byte[] binary = _owner.BinaryData;
                result = binary.GetBitValue(0, binary.Length, threshhold);
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
            BitthreshHold bitthreshHold)
        {
            // Read as long to inclule signed values
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long mask = (1L << bitthreshHold.BitLength) - 1;
            return (packedValue >> bitthreshHold.StartBit) & mask;
        }

        public static void SetBitValue(
            this byte[] source,
            int offset,
            int byteLength,
            BitthreshHold bitthreshHold,
            long value)
        {
            long packedValue = source.ReadBytesAsLong(
                offset,
                byteLength,
                isLittleEndian: false);

            long originalMask = (1L << bitthreshHold.BitLength) - 1;
            long shiftedMask = originalMask << bitthreshHold.StartBit;

            // Clear target bits and apply the new value
            packedValue = (packedValue & ~shiftedMask)
                       | ((value & originalMask) << bitthreshHold.StartBit);

            source.WriteLongAsBytes(
                offset,
                byteLength,
                packedValue,
                isLittleEndian: false);
        }
    }
}
