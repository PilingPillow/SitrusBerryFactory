namespace SitrusBerryFactory._utilities
{
    public static class BinaryConstants
    {
        // Radix
        public const int HexBase = 16;
        public const int BitsPerByte = 8;
        public const int NibbleShift = 4;

        // Digits
        public const int HexCharsPerByte = BitsPerByte / NibbleShift;
        public const int OffsetDigits = sizeof(uint) * HexCharsPerByte;

        // Bit masks
        public const int NibbleMask = 0x0F;
        public const int ByteMask = 0xFF;

        // Address range
        public const uint BaseAddr = 0x08000000U;
        public const uint EndAddr = 0x0FFFFFFFU;

        // Invalid value
        public const int InvalidValue = -1;

        // String bytes
        public const byte PaddingByte = 0x0;
        public const byte FreeSpaceByte = 0xFF;
        public const byte StrNewlineByte = 0xFE;
        public const byte StrTerminatorByte = 0xFF;
    }

    public static class PrefixConstants
    {
        public const string HexPrefix = "0x";
        public const string ButtonPrefix = "btn";
        public const string MenuItemPrefix = "tsmi";
    }

    public static class ExtConstants
    {
        public const string GbaExt = "gba";
        public const string BmpExt = "bmp";
        public const string DefExt = "def";
        public const string IniExt = "ini";
    }

    public enum PartName
    {
        Key = 0,
        Value = 1,
    }
}
