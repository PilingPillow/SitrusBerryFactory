using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._managers;
using SitrusBerryFactory._managers._formGroupManager;
using SitrusBerryFactory._managers._historyManager;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory
{
    public partial class MainForm : Form
    {
        private FormGroupRegister _formGroupManager = null;
        private EventBinder _eventBinder = null;
        private Dictionary<ToolStripMenuItem, Form> _openToolForms = null;

        // Shared data
        private SharedData _sharedData = null;
        private ConfigManager _configManager = null;
        private CharmapManager _charmapManager = null;
        private HistoryManager _commandManager = null;

        // File paths
        private string _romPath = string.Empty;
        private string _iniFolder = Path.Combine(Application.StartupPath, ExtConstants.IniExt);
        private string _tblPath = Path.Combine(Application.StartupPath, "charmap.tbl");

        public MainForm()
        {
            InitializeComponent();

            // Initialize shared data
            _configManager = new ConfigManager(_iniFolder);
            _charmapManager = new CharmapManager(_tblPath);
            _commandManager = new HistoryManager();
            _sharedData = new SharedData(_configManager, _charmapManager, _commandManager);

            // Initialize other data
            _eventBinder = new EventBinder();
            _openToolForms = new Dictionary<ToolStripMenuItem, Form>();

            InitializeEventHandlers();
            InitializeControls();

            UpdateMainFormUI();
        }

        private void InitializeControls()
        {
            lstChangeLog.DrawMode = DrawMode.OwnerDrawFixed;
            CtrlHelper.EnableDoubleBuffering(lstChangeLog);

            tsmiSaveOver.Tag = SaveMode.SaveOver;
            tsmiSaveAs.Tag = SaveMode.SaveAs;
        }

        private void InitializeEventHandlers()
        {
            _eventBinder.BindCtrl(
                h => tsmiLoadRom.Click += h,
                h => tsmiLoadRom.Click -= h,
                (_, __) =>
                {
                    using (var ofd = new OpenFileDialog())
                    {
                        var configKeys = _sharedData.Config.Dict.Keys.ToList();

                        // Build the file filter
                        ofd.Filter = string.Join(
                            "|",
                            configKeys.Select(key => $"{key}|*.{ExtConstants.GbaExt}"));

                        if (ofd.ShowDialog() != DialogResult.OK) return;
                        _romPath = ofd.FileName;
                        _sharedData.LoadRom(File.ReadAllBytes(_romPath));

                        // Get the selected configurations
                        int selectedIndex = ofd.FilterIndex - 1;
                        string selectedKey = configKeys[selectedIndex];
                        _sharedData.Config.LoadConfig(selectedKey, _sharedData.RomData);

                        UpdateMainFormUI();
                    }
                });
            _eventBinder.BindCtrl(
                h => tsmiClearRom.Click += h,
                h => tsmiClearRom.Click -= h,
                (_, __) =>
                {
                    // Close open tool forms
                    foreach (var form in _openToolForms.Values.ToList())
                    {
                        form.Close();
                    }

                    _romPath = string.Empty;
                    _sharedData.ClearRom();
                    _sharedData.History.Clear();

                    UpdateMainFormUI();
                });

            _eventBinder.BindCtrl(
                h => tsmiSaveOver.Click += h,
                h => tsmiSaveOver.Click -= h,
                SaveFunc_Click);
            _eventBinder.BindCtrl(
                h => tsmiSaveAs.Click += h,
                h => tsmiSaveAs.Click -= h,
                SaveFunc_Click);

            // Editor buttons
            foreach (Button btn in grpEditors.Controls)
            {
                _eventBinder.BindCtrl(
                    h => btn.Click += h,
                    h => btn.Click -= h,
                    EditorButton_Click);
            }

            // Change Log
            _eventBinder.BindCtrl(
                h => _sharedData.History.StateChanged += h,
                h => _sharedData.History.StateChanged -= h,
                (_, __) =>
                {
                    UpdateMainFormUI();
                    UpdateHistoryList();
                    _formGroupManager?.RefreshForms();
                });
            _eventBinder.BindCtrl(
                h => tsmiUndo.Click += h,
                h => tsmiUndo.Click -= h,
                (_, __) =>
                {
                    _sharedData.History.Undo();
                });
            _eventBinder.BindCtrl(
                h => tsmiRedo.Click += h,
                h => tsmiRedo.Click -= h,
                (_, __) =>
                {
                    _sharedData.History.Redo();
                });
            _eventBinder.BindCustom(
                () => lstChangeLog.DrawItem += lstChangeLog_DrawItem,
                () => lstChangeLog.DrawItem -= lstChangeLog_DrawItem);
            _eventBinder.BindCtrl(
                h => lstChangeLog.SelectedIndexChanged += h,
                h => lstChangeLog.SelectedIndexChanged -= h,
                (_, __) =>
                {
                    int index = lstChangeLog.SelectedIndex;

                    if (index < 0) return;
                    _sharedData.History.MoveTo(index + 1);
                });

            // Tools
            foreach (ToolStripItem item in tsmiTools.DropDownItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    _eventBinder.BindCtrl(
                        h => menuItem.Click += h,
                        h => menuItem.Click -= h,
                        ToolMenuItem_Click);
                }
            }

            _eventBinder.BindCtrl(
                h => this.Disposed += h,
                h => this.Disposed -= h);
        }

        private void UpdateMainFormUI()
        {
            bool isRomLoaded = _sharedData.IsRomLoaded;
            bool isEditorOpen = _formGroupManager != null;

            // Before ROM load and editor launch
            bool canLoadConfig = !isRomLoaded && !isEditorOpen;
            tsmiLoadRom.Enabled = canLoadConfig;

            // After ROM load, before editor launch
            bool canOpenEditor = isRomLoaded && !isEditorOpen;
            tsmiClearRom.Enabled = canOpenEditor;
            CtrlHelper.SetControlsEnabled(grpEditors, canOpenEditor);
            tsmiSave.Enabled = canOpenEditor;

            // After ROM load and editor launch
            CtrlHelper.SetControlsEnabled(grpChangeLog, isRomLoaded);
            tsmiEdit.Enabled = isRomLoaded;
            tsmiTools.Enabled = isRomLoaded;

            // Update undo/redo state
            tsmiUndo.Enabled = _sharedData.History.CanUndo;
            tsmiRedo.Enabled = _sharedData.History.CanRedo;
        }

        private void EditorButton_Click(object sender, EventArgs e)
        {
            if (!(sender is Button button)) return;

            // Remove the "btn" prefix
            string groupName = button.Name.Substring(PrefixConstants.ButtonPrefix.Length);

            // Get the group name
            if (!Enum.TryParse(groupName, out FormGroup group)) return;

            // Create the form group
            _formGroupManager = new FormGroupRegister(this, group, _sharedData);
            _formGroupManager.Closed += (_, __) =>
            {
                _formGroupManager = null;
                UpdateMainFormUI();
            };
            _formGroupManager.ShowFormGroup();

            UpdateMainFormUI();
        }

        private void SaveFunc_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem item) || !(item.Tag is SaveMode mode)) return;

            if (mode == SaveMode.SaveOver)
            {
                SaveRom(_romPath);
            }
            else if (mode == SaveMode.SaveAs)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = FilterConstants.RomFileFilter;
                    saveFileDialog.FileName = Path.GetFileName(_romPath);

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveRom(saveFileDialog.FileName);
                        _romPath = saveFileDialog.FileName;
                    }
                }
            }

            void SaveRom(string path)
            {
                try
                {
                    File.WriteAllBytes(path, _sharedData.RomData);
                    MessageBox.Show(
                        "Saved successfully.",
                        "Save Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Save Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateHistoryList()
        {
            try
            {
                lstChangeLog.BeginUpdate();
                lstChangeLog.Items.Clear();

                foreach (var command in _sharedData.History.History)
                {
                    lstChangeLog.Items.Add(command);
                }
            }
            finally
            {
                lstChangeLog.EndUpdate();
                lstChangeLog.Invalidate();
            }
        }

        private void lstChangeLog_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstChangeLog.Items.Count) return;
            if (!(lstChangeLog.Items[e.Index] is ICommand command)) return;

            bool isFuture = e.Index >= _sharedData.History.CurrentIndex;
            e.DrawBackground();
            Color textColor = GetHistoryTextColor();

            using (var brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(
                    command.Desc,
                    e.Font,
                    brush,
                    e.Bounds);
            }

            e.DrawFocusRectangle();

            // Get the history text color
            Color GetHistoryTextColor()
            {
                if (!isFuture) return lstChangeLog.ForeColor;

                Color baseColor = lstChangeLog.ForeColor;
                Color backColor = lstChangeLog.BackColor;

                // Blend toward the background
                return Color.FromArgb(
                    (baseColor.R + backColor.R) / 2,
                    (baseColor.G + backColor.G) / 2,
                    (baseColor.B + backColor.B) / 2);
            }
        }

        private void ToolMenuItem_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem item)) return;

            // If the tool is already open
            if (_openToolForms.TryGetValue(item, out Form existingForm))
            {
                existingForm.Activate();
                return;
            }

            // Remove the "tsmi" prefix
            string toolName = item.Name.Substring(PrefixConstants.MenuItemPrefix.Length);

            Type formType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == toolName);
            if (formType == null) return;
            var toolForm = (Form)Activator.CreateInstance(formType, _sharedData);
            _openToolForms[item] = toolForm;
            item.Checked = true;

            // Clear the checked state when the form closes
            toolForm.FormClosed += (_, __) =>
            {
                _openToolForms.Remove(item);
                item.Checked = false;
            };

            toolForm.Show(this);
        }
    }
}
