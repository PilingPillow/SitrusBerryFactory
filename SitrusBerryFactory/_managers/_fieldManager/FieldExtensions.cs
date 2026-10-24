using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._fieldManager
{
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
                case FieldKind.Pointer:
                    return sizeof(uint);

                // String has variable length
                default:
                    return BinaryConstants.InvalidValue;
            }
        }

        /// <summary>
        /// Checks whether the field type is signed.
        /// </summary>
        public static bool IsSigned(this FieldKind kind) =>
            kind is FieldKind.SByte ||
            kind is FieldKind.Int16 ||
            kind is FieldKind.Int32;

        /// <summary>
        /// Checks whether the field type is a pointer.
        /// </summary>
        public static bool IsPointer(this FieldKind kind) =>
            kind is FieldKind.Pointer;
    }
}
