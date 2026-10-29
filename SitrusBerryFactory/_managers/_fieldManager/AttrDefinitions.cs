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
        public string Name { get; }
        public int Length { get; }

        public BitAttrDefinition(string name, int length)
        {
            Name = name;
            Length = length;
        }
    }
}
