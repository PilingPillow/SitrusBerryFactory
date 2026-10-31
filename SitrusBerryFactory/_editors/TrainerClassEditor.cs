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

        private EntryTable _classNameEntry = null;
        private EntryTable _prizeMultiEntry = null;
        private EntryTable _encMusicEntry = null;
        private EntryTable _battleMusicEntry = null;
        private EntryTable _pokeBallEntry = null;
        private EntryTable _baseIvEntry = null;

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

            nudClassPrizeMultiValue.Maximum = (decimal)byte.MaxValue;

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

        private void InitializeEventHandlers()
        {
            // Class Name
            _eventBinder.BindCtrl(
                h => cmbClassNameIndex.SelectedIndexChanged += h,
                h => cmbClassNameIndex.SelectedIndexChanged -= h,
                (_, __) =>
                {
                    var newIndex = cmbClassNameIndex.SelectedIndex;
                    LoadDataToUI(newIndex);
                });
            _eventBinder.BindCtrl(
                h => txtClassNameStr.Validated += h,
                h => txtClassNameStr.Validated -= h,
                (sender, e) =>
                {
                    var ctrl = (TextBox)sender;
                    var text = ctrl.Text;
                    var desc = $"[{this.Text}]Class Name(ID:{_currentClassNameIndex:D4})";
                    _classNameEntry.Entries[_currentClassNameIndex].AsDynamic().ClassNameStr
                        .UpdateData(_sharedData.History, text, desc);
                });

            // Prize Multi
            _eventBinder.BindCtrl(
                h => nudClassPrizeMultiValue.ValueChanged += h,
                h => nudClassPrizeMultiValue.ValueChanged -= h,
                (sender, e) =>
                {
                    var ctrl = (NumericUpDown)sender;
                    var value = ctrl.Value;

                    // calculate the proper index
                    var calcIndex = CalcClassPrizeMultiIndex(_currentClassNameIndex);

                    var desc = $"[{this.Text}]Prize Multi(ID:{_currentClassNameIndex:D4})";
                    _prizeMultiEntry.Entries[calcIndex].AsDynamic().ClassPrizeMultiValue
                        .UpdateData(_sharedData.History, value, desc);
                });

            // Extra Data
            if (_isEncMusicEnabled)
            {
                _eventBinder.BindCtrl(
                    h => nudEncMusicIndex.ValueChanged += h,
                    h => nudEncMusicIndex.ValueChanged -= h,
                    (sender, e) =>
                    {
                        var ctrl = (NumericUpDown)sender;
                        var value = ctrl.Value;
                        var desc = $"[{this.Text}]Encoutner Music(ID:{_currentClassNameIndex:D4})";
                        _encMusicEntry.Entries[_currentClassNameIndex].AsDynamic().EncounterMusicIndex
                            .UpdateData(_sharedData.History, value, desc);
                    });
            }

            if (_isBattleMusicEnabled)
            {
                _eventBinder.BindCtrl(
                    h => nudBattleMusicIndex.ValueChanged += h,
                    h => nudBattleMusicIndex.ValueChanged -= h,
                    (sender, e) =>
                    {
                        var ctrl = (NumericUpDown)sender;
                        var value = ctrl.Value;
                        var desc = $"[{this.Text}]Battle Music(ID:{_currentClassNameIndex:D4})";
                        _battleMusicEntry.Entries[_currentClassNameIndex].AsDynamic().BattleMusicIndex
                            .UpdateData(_sharedData.History, value, desc);
                    });
            }

            if (_isPokeBallEnabled)
            {
                _eventBinder.BindCtrl(
                    h => nudPokeBallIndex.ValueChanged += h,
                    h => nudPokeBallIndex.ValueChanged -= h,
                    (sender, e) =>
                    {
                        var ctrl = (NumericUpDown)sender;
                        var value = ctrl.Value;
                        var desc = $"[{this.Text}]PokeBall ID(ID:{_currentClassNameIndex:D4})";
                        _pokeBallEntry.Entries[_currentClassNameIndex].AsDynamic().PokeBallIndex
                            .UpdateData(_sharedData.History, value, desc);
                    });
            }

            if (_isBaseIvEnabled)
            {
                _eventBinder.BindCtrl(
                    h => nudBaseIvValue.ValueChanged += h,
                    h => nudBaseIvValue.ValueChanged -= h,
                    (sender, e) =>
                    {
                        var ctrl = (NumericUpDown)sender;
                        var value = ctrl.Value;
                        var desc = $"[{this.Text}]Base IV(ID:{_currentClassNameIndex:D4})";
                        _baseIvEntry.Entries[_currentClassNameIndex].AsDynamic().BaseIvValue
                            .UpdateData(_sharedData.History, value, desc);
                    });
            }

            _eventBinder.BindCtrl(
                h => this.Disposed += h,
                h => this.Disposed -= h);
        }

        public void RefreshUI()
        {
            LoadDataToUI(_currentClassNameIndex);
            UpdateClassNameComboBox();
        }

        private void LoadDataToUI(int index)
        {
            // Update the current index
            _currentClassNameIndex = index;
            cmbClassNameIndex.SelectedIndex = index;
            nudClassNameIndex.Value = (decimal)index;

            // Class Name
            txtClassNameStr.Text =
                _classNameEntry.Entries[index].AsDynamic().ClassNameStr.GetData<string>();

            // Prize Multi, need to calculate the proper index
            int calcIndex = CalcClassPrizeMultiIndex(index);
            nudClassPrizeMultiValue.Value =
                (decimal)_prizeMultiEntry.Entries[calcIndex].AsDynamic().ClassPrizeMultiValue.GetData<int>();

            // Extra Data
            if (_isEncMusicEnabled)
            {
                nudEncMusicIndex.Value =
                    (decimal)_encMusicEntry.Entries[index].AsDynamic().EncounterMusicIndex.GetData<int>();
            }
            if (_isBattleMusicEnabled)
            {
                nudBattleMusicIndex.Value =
                    (decimal)_battleMusicEntry.Entries[index].AsDynamic().BattleMusicIndex.GetData<int>();
            }
            if (_isPokeBallEnabled)
            {
                nudPokeBallIndex.Value =
                    (decimal)_pokeBallEntry.Entries[index].AsDynamic().PokeBallIndex.GetData<int>();
            }
            if (_isBaseIvEnabled)
            {
                nudBaseIvValue.Value =
                    (decimal)_baseIvEntry.Entries[index].AsDynamic().BaseIvValue.GetData<int>();
            }
        }

        private void UpdateClassNameComboBox()
        {
            try
            {
                cmbClassNameIndex.BeginUpdate();
                cmbClassNameIndex.Items.Clear();

                foreach (var entry in _classNameEntry.Entries)
                {
                    string className = entry.AsDynamic().ClassNameStr.GetData<string>();
                    cmbClassNameIndex.Items.Add(className);
                }
            }
            finally
            {
                cmbClassNameIndex.EndUpdate();
            }

            // To reselect
            if (cmbClassNameIndex.Items.Count > 0)
            {
                cmbClassNameIndex.SelectedIndex = _currentClassNameIndex;
            }
        }

        private int CalcClassPrizeMultiIndex(int index)
        {
            int fallbackIndex = 0;
            var entries = _prizeMultiEntry.Entries;

            for (int i = 0; i < entries.Count; i++)
            {
                int currentClassNameIndex = entries[i].AsDynamic().ClassNameIndex.GetData<int>();

                // If exists
                if (currentClassNameIndex == index)
                {
                    return i;
                }

                // If ID_0xFF
                if (currentClassNameIndex == 0xFF)
                {
                    fallbackIndex = i;
                }
            }

            return fallbackIndex;
        }
    }
}
