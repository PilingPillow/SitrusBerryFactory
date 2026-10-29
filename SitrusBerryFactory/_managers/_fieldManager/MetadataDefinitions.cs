using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._fieldManager
{
    public enum FieldKind
    {
        Byte,
        SByte,
        UInt16,
        Int16,
        UInt32,
        Int32,
        Variable,
    }

    public static class FieldExtensions
    {
        /// <summary>
        /// Gets the length of the field type.
        /// </summary>
        public static int GetFieldSize(this FieldKind kind)
        {
            switch (kind)
            {
                case FieldKind.Byte:
                case FieldKind.SByte:
                    return sizeof(byte);

                case FieldKind.UInt16:
                case FieldKind.Int16:
                    return sizeof(ushort);

                case FieldKind.UInt32:
                case FieldKind.Int32:
                    return sizeof(uint);

                default:
                    return InvalidConstants.InvalidValue;
            }
        }

        /// <summary>
        /// Checks whether the field type is signed.
        /// </summary>
        public static bool IsSigned(this FieldKind kind) =>
            kind is FieldKind.SByte ||
            kind is FieldKind.Int16 ||
            kind is FieldKind.Int32;
    }

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
}
