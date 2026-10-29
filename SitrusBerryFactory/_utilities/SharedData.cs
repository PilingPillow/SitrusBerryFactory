using System;
using SitrusBerryFactory._managers;
using SitrusBerryFactory._managers._historyManager;

namespace SitrusBerryFactory._utilities
{
    public sealed class SharedData
    {
        public byte[] RomData { get; set; }
        public bool IsRomLoaded { get; set; }
        public ConfigManager Config { get; }
        public CharmapManager Charmap { get; }
        public HistoryManager History { get; }

        public SharedData(
            ConfigManager config,
            CharmapManager charmap,
            HistoryManager history)
        {
            Config = config;
            Charmap = charmap;
            History = history;

            IsRomLoaded = false;
        }

        public void LoadRom(byte[] romData)
        {
            RomData = romData;
            IsRomLoaded = true;
        }

        public void ClearRom()
        {
            RomData = Array.Empty<byte>();
            IsRomLoaded = false;
        }
    }
}
