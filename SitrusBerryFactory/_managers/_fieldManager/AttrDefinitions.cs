using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._fieldManager
{
    public enum AttrKind
    {
        String,
        Pointer,
        Bit,
        Unknown,
    }

    public enum StringAttrArgs
    {
        EntryLengthArg,
        AllowedLengthArg,
    }

    public sealed class BitAttrDefinition
    {
        public int StartBit { get; }
        public int EndBit { get; }

        public BitAttrDefinition(int startBit, int endBit)
        {
            StartBit = startBit;
            EndBit = endBit;
        }
    }

    public sealed class BitAttrMapiing : DynamicAccessor<BitAttrDefinition> { }
}
