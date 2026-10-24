namespace SitrusBerryFactory._managers._fieldManager
{
    /// <summary>
    /// Defines the order of separated values by colons in each def line.
    /// </summary>
    public enum DefName
    {
        FieldName,
        KindName,
        AttrName,
    }

    /// <summary>
    /// Defines the field kinds in a def file.
    /// </summary>
    public enum FieldKind
    {
        Byte,
        SByte,
        UInt16,
        Int16,
        UInt32,
        Int32,

        Pointer,
        String,
        Divided,
    }

    public enum StringLength
    {
        EntryLength,
        AllowedLength,
    }

    /// <summary>
    /// Stores the metadata of a def file line.
    /// </summary>
    public sealed class FieldMetaData
    {
        public string Name { get; }
        public FieldKind Field { get; }
        public string Attr { get; }

        public FieldMetaData(
            string name,
            FieldKind kind,
            string attr)
        {
            Name = name;
            Field = kind;
            Attr = attr;
        }
    }
}
