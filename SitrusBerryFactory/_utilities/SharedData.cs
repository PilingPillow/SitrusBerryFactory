using System;
using SitrusBerryFactory._managers;

namespace SitrusBerryFactory._utilities
{
    public static class SharedData
    {
        public static byte[] RomData { get; set; }
        public static bool IsRomLoaded { get; set; }
        public static ConfigManager Config { get; set; }
        public static CharmapManager Charmap { get; set; }

        public static void LoadRom(byte[] romData)
        {
            RomData = romData;
            IsRomLoaded = true;
        }

        public static void ClearRom()
        {
            RomData = Array.Empty<byte>();
            IsRomLoaded = false;
        }

        public static void ClearAll()
        {
            ClearRom();
            Config.ClearCurrentConfig();
            Charmap.ClearCharmap();
        }
    }
}
