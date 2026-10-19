
namespace SitrusBerryFactory
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLoadRom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUnloadRom = new System.Windows.Forms.ToolStripMenuItem();
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
            this.msMain.Text = "MenuBar";
            // 
            // tsmiLoad
            // 
            this.tsmiLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadRom,
            this.tsmiUnloadRom});
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
            this.tsmiLoadRom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiLoadRom.Size = new System.Drawing.Size(180, 20);
            this.tsmiLoadRom.Text = "LoadRom";
            // 
            // tsmiUnloadRom
            // 
            this.tsmiUnloadRom.Name = "tsmiUnloadRom";
            this.tsmiUnloadRom.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiUnloadRom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiUnloadRom.Size = new System.Drawing.Size(180, 20);
            this.tsmiUnloadRom.Text = "UnloadRom";
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveAs.Size = new System.Drawing.Size(194, 20);
            this.tsmiSaveAs.Text = "SaveAs";
            // 
            // tsmiSaveOver
            // 
            this.tsmiSaveOver.Name = "tsmiSaveOver";
            this.tsmiSaveOver.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiSaveOver.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiSaveOver.Size = new System.Drawing.Size(194, 20);
            this.tsmiSaveOver.Text = "SaveOver";
            // 
            // tsmiUndo
            // 
            this.tsmiUndo.Name = "tsmiUndo";
            this.tsmiUndo.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmiUndo.Size = new System.Drawing.Size(180, 20);
            this.tsmiUndo.Text = "Undo";
            // 
            // tsmiRedo
            // 
            this.tsmiRedo.Name = "tsmiRedo";
            this.tsmiRedo.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmiRedo.Size = new System.Drawing.Size(180, 20);
            this.tsmiRedo.Text = "Redo";
            // 
            // tsmiFreeSpaceFinder
            // 
            this.tsmiFreeSpaceFinder.Name = "tsmiFreeSpaceFinder";
            this.tsmiFreeSpaceFinder.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiFreeSpaceFinder.Size = new System.Drawing.Size(180, 20);
            this.tsmiFreeSpaceFinder.Text = "FreeSpaceFinder";
            // 
            // tsmiTilesetNoCalculator
            // 
            this.tsmiTilesetNoCalculator.Name = "tsmiTilesetNoCalculator";
            this.tsmiTilesetNoCalculator.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiTilesetNoCalculator.Size = new System.Drawing.Size(180, 20);
            this.tsmiTilesetNoCalculator.Text = "TilesetNoCalculator";
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
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Main";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadRom;
        private System.Windows.Forms.ToolStripMenuItem tsmiUnloadRom;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveOver;
        private System.Windows.Forms.ToolStripMenuItem tsmiUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmiRedo;
        private System.Windows.Forms.ToolStripMenuItem tsmiFreeSpaceFinder;
        private System.Windows.Forms.ToolStripMenuItem tsmiTilesetNoCalculator;
    }
}

