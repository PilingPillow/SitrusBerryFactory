
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
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadRom = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiClearRom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveOver = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFreeSpaceFinder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTilesetNoCalculator = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.GripMargin = new System.Windows.Forms.Padding(0);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoad,
            this.tsmiSave,
            this.tsmiEdit,
            this.tsmiTools});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(0);
            this.msMain.Size = new System.Drawing.Size(933, 24);
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
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUndo,
            this.tsmiRedo});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiEdit.Size = new System.Drawing.Size(31, 24);
            this.tsmiEdit.Text = "Edit";
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
            // tsmiLoadRom
            // 
            this.tsmiLoadRom.Name = "tsmiLoadRom";
            this.tsmiLoadRom.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiLoadRom.Size = new System.Drawing.Size(180, 20);
            this.tsmiLoadRom.Text = "Load ROM";
            // 
            // TsmiClearRom
            // 
            this.TsmiClearRom.Name = "TsmiClearRom";
            this.TsmiClearRom.Padding = new System.Windows.Forms.Padding(0);
            this.TsmiClearRom.Size = new System.Drawing.Size(180, 20);
            this.TsmiClearRom.Text = "Clear ROM";
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiSaveAs.Size = new System.Drawing.Size(180, 20);
            this.tsmiSaveAs.Text = "Save As";
            // 
            // tsmiSaveOver
            // 
            this.tsmiSaveOver.Name = "tsmiSaveOver";
            this.tsmiSaveOver.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiSaveOver.Size = new System.Drawing.Size(180, 20);
            this.tsmiSaveOver.Text = "Save Over";
            // 
            // tsmiUndo
            // 
            this.tsmiUndo.Name = "tsmiUndo";
            this.tsmiUndo.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiUndo.Size = new System.Drawing.Size(180, 20);
            this.tsmiUndo.Text = "Undo";
            // 
            // tsmiRedo
            // 
            this.tsmiRedo.Name = "tsmiRedo";
            this.tsmiRedo.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiRedo.Size = new System.Drawing.Size(180, 20);
            this.tsmiRedo.Text = "Redo";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmiRedo;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiFreeSpaceFinder;
        private System.Windows.Forms.ToolStripMenuItem tsmiTilesetNoCalculator;
    }
}