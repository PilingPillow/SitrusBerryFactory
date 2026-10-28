namespace SitrusBerryFactory._managers._fieldManager
{
    /// <summary>
    /// The order of separated values in each line.
    /// </summary>
    public enum MetadataOrder
    {
        Key,
        Field,
        Attr,
    }

    public sealed class FieldMetadata
    {
        public string Key { get; }
        public FieldKind Field { get; }
        public AttrKind Attr { get; }

        public FieldMetadata(
            string key,
            FieldKind kind,
            AttrKind attr)
        {
            Key = key;
            Field = kind;
            Attr = attr;
        }
    }
}
