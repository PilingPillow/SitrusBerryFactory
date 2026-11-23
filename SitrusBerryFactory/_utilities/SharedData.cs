using System;
using SitrusBerryFactory._managers;

namespace SitrusBerryFactory._utilities
{
    public static class SharedData
    {
        public static byte[] RomData { get; private set; }
        public static bool IsRomLoaded { get; private set; }
        public static ConfigManager Config { get; private set; }
        public static CharmapManager Charmap { get; private set; }

        public static void Load(
            byte[] romData,
            string configFolderPath,
            string charmapFilePath)
        {
            RomData = romData;
            IsRomLoaded = true;
            Config = new ConfigManager(configFolderPath);
            Charmap = new CharmapManager(charmapFilePath);
        }

        public static void Unload()
        {
            RomData = Array.Empty<byte>();
            IsRomLoaded = false;
        }
    }
}
