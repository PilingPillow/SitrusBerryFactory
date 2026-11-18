namespace SitrusBerryFactory._utilities
{
    public static class BinaryConstant
    {
        // Radix
        public const int HexBase = 16;
        public const int BitsPerByte = 8;
        public const int NibbleShift = 4;

        // Digits
        public const int HexCharsPerByte = BitsPerByte / NibbleShift;
        public const int OffsetDigits = HexCharsPerByte * sizeof(uint);

        // Address range
        public const int BaseAddr = 0x08000000;
        public const int EndAddr = 0x0FFFFFFF;
    }

    public static class MaskConstant
    {
        public const int Nibble = 0x0F;
        public const int Byte = 0xFF;
    }

    public static class CharConstant
    {
        public const byte Padding = 0x0;
        public const byte FreeSpace = 0xFF;
        public const byte Newline = 0xFE;
        public const byte Terminator = 0xFF;
    }

    public static class PrefixConstant
    {
        public const string Hex = "0x";
        public const string Button = "btn";
        public const string MenuItem = "tsmi";
    }

    public static class ExtConstant
    {
        public const string Gba = "gba";
        public const string Bmp = "bmp";
        public const string Def = "def";
        public const string Ini = "ini";
    }

    public static class InvalidConstant
    {
        public const int Val = -1;
        public const string Str = "Invalid";
    }

    public static class FilterConstant
    {
        public const string RomFile = "ROM Files|*.gba";
        public const string BinImportExport = "BIN Files (*.bin)|*.bin";
        public const string ImageImport = "Image Files (*.png;*.bmp)|*.png;*.bmp";
        public const string ImageExport = "PNG Image (*.png)|*.png|BMP Image (*.bmp)|*.bmp";
    }

    public static class KvpConstant
    {
        public const int Key = 0;
        public const int Val = 1;
        public const int PartsCount = 2;
    }
}
