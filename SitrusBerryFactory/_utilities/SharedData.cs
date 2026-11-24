using System;
using SitrusBerryFactory._managers;

namespace SitrusBerryFactory._utilities
{
    public static class SharedData
    {
        public static byte[] RomData { get; set; }
        public static ConfigManager Config { get; set; }
        public static CharmapManager Charmap { get; set; }

        public static void ClearAll()
        {
            RomData = Array.Empty<byte>();
            Config.ClearCurrentConfig();
            Charmap.ClearCharmap();
        }
    }
}
