
namespace SitrusBerryFactory._forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadRom = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiClearRom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveOver = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFreeSpaceFinder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTilesetNoCalculator = new System.Windows.Forms.ToolStripMenuItem();
            this.grpEditors = new System.Windows.Forms.GroupBox();
            this.btnOpenEditor = new System.Windows.Forms.Button();
            this.rbTrainer = new System.Windows.Forms.RadioButton();
            this.cmbTrainer = new System.Windows.Forms.ComboBox();
            this.rbBattle = new System.Windows.Forms.RadioButton();
            this.cmbBattle = new System.Windows.Forms.ComboBox();
            this.rbBag = new System.Windows.Forms.RadioButton();
            this.cmbBag = new System.Windows.Forms.ComboBox();
            this.rbField = new System.Windows.Forms.RadioButton();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.rbPokedex = new System.Windows.Forms.RadioButton();
            this.cmbPokedex = new System.Windows.Forms.ComboBox();
            this.rbStats = new System.Windows.Forms.RadioButton();
            this.cmbStats = new System.Windows.Forms.ComboBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.msMain.SuspendLayout();
            this.grpEditors.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoad,
            this.tsmiSave,
            this.tsmiHistory,
            this.tsmiTools});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(0);
            this.msMain.Size = new System.Drawing.Size(314, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "MainMenu";
            // 
            // tsmiLoad
            // 
            this.tsmiLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadRom,
            this.TsmiClearRom});
            this.tsmiLoad.Name = "tsmiLoad";
            this.tsmiLoad.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiLoad.Size = new System.Drawing.Size(37, 24);
            this.tsmiLoad.Text = "Load";
            // 
            // tsmiLoadRom
            // 
            this.tsmiLoadRom.Name = "tsmiLoadRom";
            this.tsmiLoadRom.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiLoadRom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiLoadRom.Size = new System.Drawing.Size(172, 20);
            this.tsmiLoadRom.Text = "Load ROM";
            // 
            // TsmiClearRom
            // 
            this.TsmiClearRom.Name = "TsmiClearRom";
            this.TsmiClearRom.Padding = new System.Windows.Forms.Padding(0);
            this.TsmiClearRom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.TsmiClearRom.Size = new System.Drawing.Size(172, 20);
            this.TsmiClearRom.Text = "Clear ROM";
            // 
            // tsmiSave
            // 
            this.tsmiSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveAs,
            this.tsmiSaveOver});
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiSave.Size = new System.Drawing.Size(35, 24);
            this.tsmiSave.Text = "Save";
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveAs.Size = new System.Drawing.Size(197, 20);
            this.tsmiSaveAs.Text = "Save As";
            // 
            // tsmiSaveOver
            // 
            this.tsmiSaveOver.Name = "tsmiSaveOver";
            this.tsmiSaveOver.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiSaveOver.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiSaveOver.Size = new System.Drawing.Size(197, 20);
            this.tsmiSaveOver.Text = "Save Over";
            // 
            // tsmiHistory
            // 
            this.tsmiHistory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUndo,
            this.tsmiRedo});
            this.tsmiHistory.Name = "tsmiHistory";
            this.tsmiHistory.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiHistory.Size = new System.Drawing.Size(49, 24);
            this.tsmiHistory.Text = "History";
            // 
            // tsmiUndo
            // 
            this.tsmiUndo.Name = "tsmiUndo";
            this.tsmiUndo.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmiUndo.Size = new System.Drawing.Size(143, 20);
            this.tsmiUndo.Text = "Undo";
            // 
            // tsmiRedo
            // 
            this.tsmiRedo.Name = "tsmiRedo";
            this.tsmiRedo.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmiRedo.Size = new System.Drawing.Size(143, 20);
            this.tsmiRedo.Text = "Redo";
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFreeSpaceFinder,
            this.tsmiTilesetNoCalculator});
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiTools.Size = new System.Drawing.Size(38, 24);
            this.tsmiTools.Text = "Tools";
            // 
            // tsmiFreeSpaceFinder
            // 
            this.tsmiFreeSpaceFinder.Name = "tsmiFreeSpaceFinder";
            this.tsmiFreeSpaceFinder.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiFreeSpaceFinder.Size = new System.Drawing.Size(182, 20);
            this.tsmiFreeSpaceFinder.Text = "Free Space Finder";
            // 
            // tsmiTilesetNoCalculator
            // 
            this.tsmiTilesetNoCalculator.Name = "tsmiTilesetNoCalculator";
            this.tsmiTilesetNoCalculator.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiTilesetNoCalculator.Size = new System.Drawing.Size(182, 20);
            this.tsmiTilesetNoCalculator.Text = "Tileset No Calculator";
            // 
            // grpEditors
            // 
            this.grpEditors.Controls.Add(this.btnOpenEditor);
            this.grpEditors.Controls.Add(this.rbTrainer);
            this.grpEditors.Controls.Add(this.cmbTrainer);
            this.grpEditors.Controls.Add(this.rbBattle);
            this.grpEditors.Controls.Add(this.cmbBattle);
            this.grpEditors.Controls.Add(this.rbBag);
            this.grpEditors.Controls.Add(this.cmbBag);
            this.grpEditors.Controls.Add(this.rbField);
            this.grpEditors.Controls.Add(this.cmbField);
            this.grpEditors.Controls.Add(this.rbPokedex);
            this.grpEditors.Controls.Add(this.cmbPokedex);
            this.grpEditors.Controls.Add(this.rbStats);
            this.grpEditors.Controls.Add(this.cmbStats);
            this.grpEditors.Location = new System.Drawing.Point(20, 32);
            this.grpEditors.Margin = new System.Windows.Forms.Padding(0);
            this.grpEditors.Name = "grpEditors";
            this.grpEditors.Padding = new System.Windows.Forms.Padding(0);
            this.grpEditors.Size = new System.Drawing.Size(272, 256);
            this.grpEditors.TabIndex = 1;
            this.grpEditors.TabStop = false;
            this.grpEditors.Text = "Editors";
            // 
            // btnOpenEditor
            // 
            this.btnOpenEditor.Location = new System.Drawing.Point(20, 212);
            this.btnOpenEditor.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpenEditor.Name = "btnOpenEditor";
            this.btnOpenEditor.Size = new System.Drawing.Size(228, 23);
            this.btnOpenEditor.TabIndex = 12;
            this.btnOpenEditor.Text = "Open Selected Editor";
            this.btnOpenEditor.UseVisualStyleBackColor = true;
            // 
            // rbTrainer
            // 
            this.rbTrainer.AutoSize = true;
            this.rbTrainer.Location = new System.Drawing.Point(20, 148);
            this.rbTrainer.Margin = new System.Windows.Forms.Padding(0);
            this.rbTrainer.Name = "rbTrainer";
            this.rbTrainer.Size = new System.Drawing.Size(66, 19);
            this.rbTrainer.TabIndex = 11;
            this.rbTrainer.TabStop = true;
            this.rbTrainer.Text = "Trainer :";
            this.rbTrainer.UseVisualStyleBackColor = true;
            // 
            // cmbTrainer
            // 
            this.cmbTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrainer.FormattingEnabled = true;
            this.cmbTrainer.Location = new System.Drawing.Point(120, 146);
            this.cmbTrainer.Margin = new System.Windows.Forms.Padding(0);
            this.cmbTrainer.Name = "cmbTrainer";
            this.cmbTrainer.Size = new System.Drawing.Size(128, 23);
            this.cmbTrainer.TabIndex = 10;
            // 
            // rbBattle
            // 
            this.rbBattle.AutoSize = true;
            this.rbBattle.Location = new System.Drawing.Point(20, 178);
            this.rbBattle.Margin = new System.Windows.Forms.Padding(0);
            this.rbBattle.Name = "rbBattle";
            this.rbBattle.Size = new System.Drawing.Size(61, 19);
            this.rbBattle.TabIndex = 5;
            this.rbBattle.TabStop = true;
            this.rbBattle.Text = "Battle :";
            this.rbBattle.UseVisualStyleBackColor = true;
            // 
            // cmbBattle
            // 
            this.cmbBattle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBattle.FormattingEnabled = true;
            this.cmbBattle.Location = new System.Drawing.Point(120, 176);
            this.cmbBattle.Margin = new System.Windows.Forms.Padding(0);
            this.cmbBattle.Name = "cmbBattle";
            this.cmbBattle.Size = new System.Drawing.Size(128, 23);
            this.cmbBattle.TabIndex = 4;
            // 
            // rbBag
            // 
            this.rbBag.AutoSize = true;
            this.rbBag.Location = new System.Drawing.Point(20, 118);
            this.rbBag.Margin = new System.Windows.Forms.Padding(0);
            this.rbBag.Name = "rbBag";
            this.rbBag.Size = new System.Drawing.Size(51, 19);
            this.rbBag.TabIndex = 9;
            this.rbBag.TabStop = true;
            this.rbBag.Text = "Bag :";
            this.rbBag.UseVisualStyleBackColor = true;
            // 
            // cmbBag
            // 
            this.cmbBag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBag.FormattingEnabled = true;
            this.cmbBag.Location = new System.Drawing.Point(120, 116);
            this.cmbBag.Margin = new System.Windows.Forms.Padding(0);
            this.cmbBag.Name = "cmbBag";
            this.cmbBag.Size = new System.Drawing.Size(128, 23);
            this.cmbBag.TabIndex = 8;
            // 
            // rbField
            // 
            this.rbField.AutoSize = true;
            this.rbField.Location = new System.Drawing.Point(20, 88);
            this.rbField.Margin = new System.Windows.Forms.Padding(0);
            this.rbField.Name = "rbField";
            this.rbField.Size = new System.Drawing.Size(56, 19);
            this.rbField.TabIndex = 7;
            this.rbField.TabStop = true;
            this.rbField.Text = "Field :";
            this.rbField.UseVisualStyleBackColor = true;
            // 
            // cmbField
            // 
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(120, 86);
            this.cmbField.Margin = new System.Windows.Forms.Padding(0);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(128, 23);
            this.cmbField.TabIndex = 6;
            // 
            // rbPokedex
            // 
            this.rbPokedex.AutoSize = true;
            this.rbPokedex.Location = new System.Drawing.Point(20, 58);
            this.rbPokedex.Margin = new System.Windows.Forms.Padding(0);
            this.rbPokedex.Name = "rbPokedex";
            this.rbPokedex.Size = new System.Drawing.Size(76, 19);
            this.rbPokedex.TabIndex = 3;
            this.rbPokedex.TabStop = true;
            this.rbPokedex.Text = "Pokedex :";
            this.rbPokedex.UseVisualStyleBackColor = true;
            // 
            // cmbPokedex
            // 
            this.cmbPokedex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPokedex.FormattingEnabled = true;
            this.cmbPokedex.Location = new System.Drawing.Point(120, 56);
            this.cmbPokedex.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPokedex.Name = "cmbPokedex";
            this.cmbPokedex.Size = new System.Drawing.Size(128, 23);
            this.cmbPokedex.TabIndex = 2;
            // 
            // rbStats
            // 
            this.rbStats.AutoSize = true;
            this.rbStats.Location = new System.Drawing.Point(20, 28);
            this.rbStats.Margin = new System.Windows.Forms.Padding(0);
            this.rbStats.Name = "rbStats";
            this.rbStats.Size = new System.Drawing.Size(56, 19);
            this.rbStats.TabIndex = 1;
            this.rbStats.TabStop = true;
            this.rbStats.Text = "Stats :";
            this.rbStats.UseVisualStyleBackColor = true;
            // 
            // cmbStats
            // 
            this.cmbStats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStats.FormattingEnabled = true;
            this.cmbStats.Location = new System.Drawing.Point(120, 26);
            this.cmbStats.Margin = new System.Windows.Forms.Padding(0);
            this.cmbStats.Name = "cmbStats";
            this.cmbStats.Size = new System.Drawing.Size(128, 23);
            this.cmbStats.TabIndex = 0;
            // 
            // lstHistory
            // 
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 15;
            this.lstHistory.Location = new System.Drawing.Point(20, 304);
            this.lstHistory.Margin = new System.Windows.Forms.Padding(0);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.ScrollAlwaysVisible = true;
            this.lstHistory.Size = new System.Drawing.Size(272, 124);
            this.lstHistory.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 447);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.grpEditors);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MainForm";
            this.Text = "Main";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.grpEditors.ResumeLayout(false);
            this.grpEditors.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadRom;
        private System.Windows.Forms.ToolStripMenuItem TsmiClearRom;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveOver;
        private System.Windows.Forms.ToolStripMenuItem tsmiHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmiRedo;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiFreeSpaceFinder;
        private System.Windows.Forms.ToolStripMenuItem tsmiTilesetNoCalculator;
        private System.Windows.Forms.GroupBox grpEditors;
        private System.Windows.Forms.RadioButton rbTrainer;
        private System.Windows.Forms.ComboBox cmbTrainer;
        private System.Windows.Forms.RadioButton rbBag;
        private System.Windows.Forms.ComboBox cmbBag;
        private System.Windows.Forms.RadioButton rbField;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.RadioButton rbBattle;
        private System.Windows.Forms.ComboBox cmbBattle;
        private System.Windows.Forms.RadioButton rbPokedex;
        private System.Windows.Forms.ComboBox cmbPokedex;
        private System.Windows.Forms.RadioButton rbStats;
        private System.Windows.Forms.ComboBox cmbStats;
        private System.Windows.Forms.Button btnOpenEditor;
        private System.Windows.Forms.ListBox lstHistory;
    }
}