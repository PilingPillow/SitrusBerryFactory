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
using SitrusBerryFactory._managers._historyManager;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._forms
{
    public partial class MainForm : Form
    {
        private EventBinder _eventBinder = null;
        private Dictionary<ToolStripMenuItem, Form> _openToolForms = null;
        private FormGroupManager _formGroupManager = null;

        // Rom
        private string _romPath = string.Empty;
        private bool _isRomLoaded = false;

        // Paths
        private readonly string _configPath = Path.Combine(Application.StartupPath, "settings", "Config.cs");
        private readonly string _charmapPath = Path.Combine(Application.StartupPath, "settings", "charmap.tbl");

        private enum SaveMode
        {
            SaveAs,
            SaveOver,
        }

        public MainForm()
        {
            InitializeComponent();
            SharedData.History = new HistoryManager(); // for controls

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
                    using (var ofd = new OpenFileDialog() { Filter = FilterConstant.RomFile })
                    {
                        // Read the byte array
                        if (ofd.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                        _romPath = ofd.FileName;
                        SharedData.RomData = File.ReadAllBytes(_romPath);
                        _isRomLoaded = true;

                        // Initialize other data
                        SharedData.Config = new ConfigManager(_configPath);
                        SharedData.Charmap = new CharmapManager(_charmapPath);

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
                    _isRomLoaded = false;
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

            // History
            _eventBinder.BindCtrl(
                h => SharedData.History.StateChanged += h,
                h => SharedData.History.StateChanged -= h,
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
                    SharedData.History.Undo();
                });
            _eventBinder.BindCtrl(
                h => tsmiRedo.Click += h,
                h => tsmiRedo.Click -= h,
                (_, __) =>
                {
                    SharedData.History.Redo();
                });
            _eventBinder.BindCustom(
                () => lstHistory.DrawItem += lstHistory_DrawItem,
                () => lstHistory.DrawItem -= lstHistory_DrawItem);
            _eventBinder.BindCtrl(
                h => lstHistory.SelectedIndexChanged += h,
                h => lstHistory.SelectedIndexChanged -= h,
                (_, __) =>
                {
                    int index = lstHistory.SelectedIndex;
                    if (index < 0)
                    {
                        return;
                    }
                    SharedData.History.MoveTo(index + 1);
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
            bool isRomLoaded = _isRomLoaded;
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
            lstHistory.Enabled = isRomLoaded;
            tsmiHistory.Enabled = isRomLoaded;
            tsmiTools.Enabled = isRomLoaded;

            // Update undo/redo state
            tsmiUndo.Enabled = SharedData.History.CanUndo;
            tsmiRedo.Enabled = SharedData.History.CanRedo;
        }

        private void EditorButton_Click(object sender, EventArgs e)
        {
            if (!(sender is Button button))
            {
                return;
            }

            // Remove the "btn" prefix
            string groupName = button.Name.Substring(PrefixConstant.Button.Length);

            // Get the group name
            if (!Enum.TryParse(groupName, out FormGroup group))
            {
                return;
            }

            // Create the form group
            _formGroupManager = new FormGroupManager(this, group);
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
            if (!(sender is ToolStripMenuItem item) || !(item.Tag is SaveMode mode))
            {
                return;
            }

            if (mode == SaveMode.SaveOver)
            {
                SaveRom(_romPath);
            }
            else if (mode == SaveMode.SaveAs)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = FilterConstant.RomFile;
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
                    File.WriteAllBytes(path, SharedData.RomData);
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
                lstHistory.BeginUpdate();
                lstHistory.Items.Clear();

                foreach (var command in SharedData.History.CommandList)
                {
                    lstHistory.Items.Add(command);
                }
            }
            finally
            {
                lstHistory.EndUpdate();
                lstHistory.Invalidate();
            }
        }

        private void lstHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstHistory.Items.Count)
            {
                return;
            }
            if (!(lstHistory.Items[e.Index] is ICommand command))
            {
                return;
            }

            bool isFuture = e.Index >= SharedData.History.CurrentIndex;
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
                if (!isFuture)
                {
                    return lstHistory.ForeColor;
                }

                Color baseColor = lstHistory.ForeColor;
                Color backColor = lstHistory.BackColor;

                // Blend toward the background
                return Color.FromArgb(
                    (baseColor.R + backColor.R) / 2,
                    (baseColor.G + backColor.G) / 2,
                    (baseColor.B + backColor.B) / 2);
            }
        }

        private void ToolMenuItem_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem item))
            {
                return;
            }

            // If the tool is already open
            if (_openToolForms.TryGetValue(item, out Form existingForm))
            {
                existingForm.Activate();
                return;
            }

            // Remove the "tsmi" prefix
            string toolName = item.Name.Substring(PrefixConstant.MenuItem.Length);

            Type formType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == toolName);
            if (formType == null)
            {
                return;
            }
            var toolForm = (Form)Activator.CreateInstance(formType);
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
