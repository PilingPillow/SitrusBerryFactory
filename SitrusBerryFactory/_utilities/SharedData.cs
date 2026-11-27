using SitrusBerryFactory._managers;
using SitrusBerryFactory._managers._historyManager;

namespace SitrusBerryFactory._utilities
{
    public static class SharedData
    {
        public static byte[] RomData { get; set; }
        public static CharmapManager Charmap { get; set; }
        public static ConfigManager Config { get; set; }
        public static HistoryManager History { get; set; }
    }
}
