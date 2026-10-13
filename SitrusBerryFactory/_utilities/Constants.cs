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
}
