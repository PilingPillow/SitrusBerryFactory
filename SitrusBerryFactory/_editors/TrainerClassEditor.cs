using System.Collections.Generic;
using System.Windows.Forms;
using SitrusBerryFactory._helpers._matchHelper;
using SitrusBerryFactory._managers._formGroupManager;
using SitrusBerryFactory._managers._historyManager;
using SitrusBerryFactory._managers._recordManager;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._editors
{
    [FormGroup(FormGroup.TrainerClass)]
    public partial class TrainerClassEditor : Form, IEditorRefresh
    {
        private SharedData _sharedData = null;
        private EventBinder _eventBinder = null;

        private dynamic _classNameEntry = null;
        private dynamic _prizeMultiEntry = null;
        private dynamic _encMusicEntry = null;
        private dynamic _battleMusicEntry = null;
        private dynamic _pokeBallEntry = null;
        private dynamic _baseIvEntry = null;

        private int _currentClassNameIndex = 0;
        private int _classNameEntryLength = 0;

        private bool _isEncMusicEnabled = false;
        private bool _isBattleMusicEnabled = false;
        private bool _isPokeBallEnabled = false;
        private bool _isBaseIvEnabled = false;

        public TrainerClassEditor(SharedData sharedData)
        {
            InitializeComponent();
            _sharedData = sharedData;
            _eventBinder = new EventBinder();

            InitializeEntries();
            InitializeControls();
            InitializeEventHandlers();

            RefreshUI();
        }

        private void InitializeEntries()
        {
            _classNameEntryLength = _sharedData.Config.AsDynamic().TrainerClassNameEntryLength;

            // Create trainer class name table
            var tableOffset = _sharedData.Config.AsDynamic().TrainerClassNameTableOffset;
            var entryCount = PatternMatcher.TryCountByTerminator(_sharedData.RomData, _classNameEntryLength, tableOffset);
            _classNameEntry = new EntryManager("TrainerClassNameEntry", tableOffset, entryCount, _sharedData);

            // Check which additional data features are enabled
            _isEncMusicEnabled = _sharedData.Config.AsDynamic().EnableTrainerClassEncMusic;
            _isBattleMusicEnabled = _sharedData.Config.AsDynamic().EnableTrainerClassBattleMusic;
            _isPokeBallEnabled = _sharedData.Config.AsDynamic().EnableTrainerClassPokeBall;
            _isBaseIvEnabled = _sharedData.Config.AsDynamic().EnableTrainerClassBaseIV;

            if (_isEncMusicEnabled)
            {
                tableOffset = _sharedData.Config.AsDynamic().TrainerClassEncMusicTableOffset;
                _encMusicEntry = new EntryManager("TrainerClassEncMusicEntry", tableOffset, entryCount, _sharedData);
            }

            if (_isBattleMusicEnabled)
            {
                tableOffset = _sharedData.Config.AsDynamic().TrainerClassBattleMusicTableOffset;
                _battleMusicEntry = new EntryManager("TrainerClassBattleMusicEntry", tableOffset, entryCount, _sharedData);
            }

            if (_isPokeBallEnabled)
            {
                tableOffset = _sharedData.Config.AsDynamic().TrainerClassPokeBallTableOffset;
                _pokeBallEntry = new EntryManager("TrainerClassPokeBallEntry", tableOffset, entryCount, _sharedData);
            }

            if (_isBaseIvEnabled)
            {
                tableOffset = _sharedData.Config.AsDynamic().TrainerClassBaseIVTableOffset;
                _baseIvEntry = new EntryManager("TrainerClassBaseIvEntry", tableOffset, entryCount, _sharedData);
            }

            // Create prize multi table
            tableOffset = _sharedData.Config.AsDynamic().TrainerClassPrizeMultiTableOffset;
            // Calculate the number of entries
            var pattern = new List<TokenData>()
            {
                TokenData.Wildcard(2),
                TokenData.Exact(sizeof(byte), exactValues: 0x0),
                TokenData.Exact(sizeof(byte), exactValues: 0x0)
            };
            entryCount = PatternMatcher.TryCountByPattern(pattern, _sharedData.RomData, tableOffset);
            _prizeMultiEntry = new EntryManager("TrainerClassPrizeMultiEntry", tableOffset, entryCount, _sharedData);
        }
    }
}
