using SitrusBerryFactory._managers;

namespace SitrusBerryFactory._utilities
{
    public sealed class SharedData
    {
        private static SharedData _romData = new SharedData();
        private static ConfigManager _config = null;
        private static CharmapManager _charmap = null;
        private SharedData() { }

        public static SharedData RomData => _romData;
        public static ConfigManager Config => _config;
        public static CharmapManager Charmap => _charmap;

        public void InitializeConfig(string folderPath)
        {
            _config = new ConfigManager(folderPath);
        }

        public void InitializecharMap(string filePath)
        {
            _charmap = new CharmapManager(filePath);
        }
    }
}
