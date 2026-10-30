using System.Collections.Generic;
using System.Windows.Forms;
using SitrusBerryFactory._helpers;
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
            // InitializeEventHandlers();

            RefreshUI();
        }

        private void InitializeEntries()
        {
            _classNameEntryLength = _sharedData.Config.AsDynamic().TrainerClassNameEntryLength;

            // Create trainer class name table
            var tableOffset = _sharedData.Config.AsDynamic().TrainerClassNameTableOffset;
            var entryCount = PatternMatcher.TryCountByTerminator(_sharedData.RomData, _classNameEntryLength, tableOffset);
            _classNameEntry = new EntryTable("TrainerClassNameEntry", tableOffset, entryCount, _sharedData);

            // Check which additional data features are enabled
            _isEncMusicEnabled = _sharedData.Config.AsDynamic().EnableTrainerClassEncMusic;
            _isBattleMusicEnabled = _sharedData.Config.AsDynamic().EnableTrainerClassBattleMusic;
            _isPokeBallEnabled = _sharedData.Config.AsDynamic().EnableTrainerClassPokeBall;
            _isBaseIvEnabled = _sharedData.Config.AsDynamic().EnableTrainerClassBaseIV;

            if (_isEncMusicEnabled)
            {
                tableOffset = _sharedData.Config.AsDynamic().TrainerClassEncMusicTableOffset;
                _encMusicEntry = new EntryTable("TrainerClassEncMusicEntry", tableOffset, entryCount, _sharedData);
            }

            if (_isBattleMusicEnabled)
            {
                tableOffset = _sharedData.Config.AsDynamic().TrainerClassBattleMusicTableOffset;
                _battleMusicEntry = new EntryTable("TrainerClassBattleMusicEntry", tableOffset, entryCount, _sharedData);
            }

            if (_isPokeBallEnabled)
            {
                tableOffset = _sharedData.Config.AsDynamic().TrainerClassPokeBallTableOffset;
                _pokeBallEntry = new EntryTable("TrainerClassPokeBallEntry", tableOffset, entryCount, _sharedData);
            }

            if (_isBaseIvEnabled)
            {
                tableOffset = _sharedData.Config.AsDynamic().TrainerClassBaseIVTableOffset;
                _baseIvEntry = new EntryTable("TrainerClassBaseIvEntry", tableOffset, entryCount, _sharedData);
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
            _prizeMultiEntry = new EntryTable("TrainerClassPrizeMultiEntry", tableOffset, entryCount, _sharedData);
        }

        private void InitializeControls()
        {
            nudClassNameIndex.ReadOnly = true;
            nudClassNameIndex.Increment = 0;
            nudClassNameIndex.Maximum = (decimal)byte.MaxValue;

            // Just in case
            UpdateClassNameComboBox();

            // txtClassNameStr
            txtClassNameStr.CharmapManager = _sharedData.Charmap;
            txtClassNameStr.AllowedLength = _classNameEntryLength;
            txtClassNameStr.NeedTerminator = true;

            nudPrizeMulti.Maximum = (decimal)byte.MaxValue;

            // Extra data
            grpExtraData.SetControlsEnabled(false);
            if (!_isEncMusicEnabled &&
                !_isBattleMusicEnabled &&
                !_isPokeBallEnabled &&
                !_isBaseIvEnabled)
            {
                return;
            }

            grpExtraData.Enabled = true;
            if (_isEncMusicEnabled)
            {
                lblEncMusicIndex.Enabled = true;
                nudEncMusicIndex.Enabled = true;
                nudEncMusicIndex.Maximum = (decimal)ushort.MaxValue;
            }
            if (_isBattleMusicEnabled)
            {
                lblBattleMusicIndex.Enabled = true;
                nudBattleMusicIndex.Enabled = true;
                nudBattleMusicIndex.Maximum = (decimal)ushort.MaxValue;
            }
            if (_isPokeBallEnabled)
            {
                lblPokeBallIndex.Enabled = true;
                nudPokeBallIndex.Enabled = true;
                nudPokeBallIndex.Maximum = (decimal)byte.MaxValue;
            }
            if (_isBaseIvEnabled)
            {
                lblBaseIvValue.Enabled = true;
                nudBaseIvValue.Enabled = true;
                nudBaseIvValue.Maximum = (decimal)byte.MaxValue;
            }
        }

        public void RefreshUI()
        {
            LoadDataToUI(_currentClassNameIndex);
            UpdateClassNameComboBox();
        }

        private void LoadDataToUI(int index)
        {

        }

        private void UpdateClassNameComboBox()
        {

        }


    }
}
