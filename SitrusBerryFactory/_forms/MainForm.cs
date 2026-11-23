using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SitrusBerryFactory._helpers;
using SitrusBerryFactory._managers;
using SitrusBerryFactory._managers._formGroup;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._forms
{
    public partial class MainForm : Form
    {
        private EventBinder _eventBinder = null;
        private Dictionary<ToolStripMenuItem, Form> _openToolForms = null;
        private FormGroupManager _formGroupManager = null;

        // File paths
        private string _romPath = string.Empty;
        private readonly string _iniFolder = Path.Combine(Application.StartupPath, ExtConstant.Ini);
        private readonly string _tblPath = Path.Combine(Application.StartupPath, "charmap.tbl");

        private enum SaveMode
        {
            SaveAs,
            SaveOver,
        }

        public MainForm()
        {
            InitializeComponent();

            // Initialize shared data
            SharedData.Config = new ConfigManager(_iniFolder);
            SharedData.Charmap = new CharmapManager();
            SharedData.Charmap.LoadCharmap(_tblPath);

            _eventBinder = new EventBinder();
            _openToolForms = new Dictionary<ToolStripMenuItem, Form>();

            InitializeControls();
            InitializeEventHandlers();

            UpdateMainFormUI();
        }

        private void InitializeControls()
        {
            lstHistory.DrawMode = DrawMode.OwnerDrawFixed;
            CtrlHelper.EnableDoubleBuffering(lstHistory);

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
                        var configKeys = SharedData.Config.NamesToPaths.Keys.ToList();

                        // Build the file filter
                        ofd.Filter = string.Join(
                            "|",
                            configKeys.Select(key => $"{key}|*.{ExtConstant.Gba}"));

                        if (ofd.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                        _romPath = ofd.FileName;
                        SharedData.LoadRom(File.ReadAllBytes(_romPath));

                        // Get the selected configurations
                        int selectedIndex = ofd.FilterIndex - 1;
                        string selectedKey = configKeys[selectedIndex];
                        SharedData.Config.LoadConfig(selectedKey, SharedData.RomData);

                        UpdateMainFormUI();
                    }
                });
            _eventBinder.BindCtrl(
                h => tsmiClearRom.Click += h,
                h => tsmiClearRom.Click -= h,
                (_, __) =>
                {
                    // Close opened tool forms
                    foreach (var form in _openToolForms.Values.ToList())
                    {
                        form.Close();
                    }

                    _romPath = string.Empty;
                    SharedData.ClearAll();
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

            // Editors


            // History


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
            bool isRomLoaded = SharedData.IsRomLoaded;
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
    }
}
