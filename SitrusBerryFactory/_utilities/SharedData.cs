using System;
using SitrusBerryFactory._managers;

namespace SitrusBerryFactory._utilities
{
    public static class SharedData
    {
        public static byte[] RomData { get; set; }
        public static string RomPath { get; set; }
        public static bool IsRomLoaded { get; set; }
        public static ConfigManager Config { get; set; }
        public static CharmapManager Charmap { get; set; }

        public static void LoadRom(byte[] romData, string romPath)
        {
            RomData = romData;
            RomPath = romPath;
            IsRomLoaded = true;
        }

        public static void ClearRom()
        {
            RomData = Array.Empty<byte>();
            RomPath = string.Empty;
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
