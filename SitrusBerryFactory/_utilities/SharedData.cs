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

        public static void ClearData()
        {
            RomData = Array.Empty<byte>();
            IsRomLoaded = false;
            Config.ClearCurrentConfig();
            Charmap.ClearCharmap();
        }
    }
}
