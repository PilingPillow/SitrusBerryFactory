
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
            this.tsmiClearRom = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.btnPokemon = new System.Windows.Forms.Button();
            this.btnNatDex = new System.Windows.Forms.Button();
            this.btnRegDex = new System.Windows.Forms.Button();
            this.btnDexHabitat = new System.Windows.Forms.Button();
            this.btnDexSort = new System.Windows.Forms.Button();
            this.btnEggMove = new System.Windows.Forms.Button();
            this.btnTmHmTutor = new System.Windows.Forms.Button();
            this.btnRoaming = new System.Windows.Forms.Button();
            this.btnSwarm = new System.Windows.Forms.Button();
            this.btnWildEnc = new System.Windows.Forms.Button();
            this.btnAtlas = new System.Windows.Forms.Button();
            this.btnOverworld = new System.Windows.Forms.Button();
            this.btnTileset = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnMailTxt = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnBattleBg = new System.Windows.Forms.Button();
            this.btnTrade = new System.Windows.Forms.Button();
            this.btnTrainerList = new System.Windows.Forms.Button();
            this.btnTrainerSprite = new System.Windows.Forms.Button();
            this.btnTrainerClass = new System.Windows.Forms.Button();
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
            this.msMain.Size = new System.Drawing.Size(490, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "MainMenu";
            // 
            // tsmiLoad
            // 
            this.tsmiLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadRom,
            this.tsmiClearRom});
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
            // tsmiClearRom
            // 
            this.tsmiClearRom.Name = "tsmiClearRom";
            this.tsmiClearRom.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiClearRom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiClearRom.Size = new System.Drawing.Size(172, 20);
            this.tsmiClearRom.Text = "Clear ROM";
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
            this.grpEditors.Controls.Add(this.btnBattleBg);
            this.grpEditors.Controls.Add(this.btnTrade);
            this.grpEditors.Controls.Add(this.btnTrainerList);
            this.grpEditors.Controls.Add(this.btnTrainerSprite);
            this.grpEditors.Controls.Add(this.btnTrainerClass);
            this.grpEditors.Controls.Add(this.btnMailTxt);
            this.grpEditors.Controls.Add(this.btnItem);
            this.grpEditors.Controls.Add(this.btnAtlas);
            this.grpEditors.Controls.Add(this.btnOverworld);
            this.grpEditors.Controls.Add(this.btnTileset);
            this.grpEditors.Controls.Add(this.btnMap);
            this.grpEditors.Controls.Add(this.btnRoaming);
            this.grpEditors.Controls.Add(this.btnSwarm);
            this.grpEditors.Controls.Add(this.btnWildEnc);
            this.grpEditors.Controls.Add(this.btnEggMove);
            this.grpEditors.Controls.Add(this.btnTmHmTutor);
            this.grpEditors.Controls.Add(this.btnDexSort);
            this.grpEditors.Controls.Add(this.btnDexHabitat);
            this.grpEditors.Controls.Add(this.btnRegDex);
            this.grpEditors.Controls.Add(this.btnNatDex);
            this.grpEditors.Controls.Add(this.btnPokemon);
            this.grpEditors.Location = new System.Drawing.Point(20, 32);
            this.grpEditors.Margin = new System.Windows.Forms.Padding(0);
            this.grpEditors.Name = "grpEditors";
            this.grpEditors.Padding = new System.Windows.Forms.Padding(0);
            this.grpEditors.Size = new System.Drawing.Size(448, 282);
            this.grpEditors.TabIndex = 1;
            this.grpEditors.TabStop = false;
            this.grpEditors.Text = "Editors";
            // 
            // lstHistory
            // 
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 15;
            this.lstHistory.Location = new System.Drawing.Point(20, 332);
            this.lstHistory.Margin = new System.Windows.Forms.Padding(0);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.ScrollAlwaysVisible = true;
            this.lstHistory.Size = new System.Drawing.Size(448, 124);
            this.lstHistory.TabIndex = 2;
            // 
            // btnPokemon
            // 
            this.btnPokemon.Location = new System.Drawing.Point(20, 28);
            this.btnPokemon.Margin = new System.Windows.Forms.Padding(0);
            this.btnPokemon.Name = "btnPokemon";
            this.btnPokemon.Size = new System.Drawing.Size(128, 23);
            this.btnPokemon.TabIndex = 0;
            this.btnPokemon.Text = "Pokemon";
            this.btnPokemon.UseVisualStyleBackColor = true;
            // 
            // btnNatDex
            // 
            this.btnNatDex.Location = new System.Drawing.Point(20, 58);
            this.btnNatDex.Margin = new System.Windows.Forms.Padding(0);
            this.btnNatDex.Name = "btnNatDex";
            this.btnNatDex.Size = new System.Drawing.Size(128, 23);
            this.btnNatDex.TabIndex = 0;
            this.btnNatDex.Text = "National Pokedex";
            this.btnNatDex.UseVisualStyleBackColor = true;
            // 
            // btnRegDex
            // 
            this.btnRegDex.Location = new System.Drawing.Point(20, 88);
            this.btnRegDex.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegDex.Name = "btnRegDex";
            this.btnRegDex.Size = new System.Drawing.Size(128, 23);
            this.btnRegDex.TabIndex = 0;
            this.btnRegDex.Text = "Regional Pokedex";
            this.btnRegDex.UseVisualStyleBackColor = true;
            // 
            // btnDexHabitat
            // 
            this.btnDexHabitat.Location = new System.Drawing.Point(20, 118);
            this.btnDexHabitat.Margin = new System.Windows.Forms.Padding(0);
            this.btnDexHabitat.Name = "btnDexHabitat";
            this.btnDexHabitat.Size = new System.Drawing.Size(128, 23);
            this.btnDexHabitat.TabIndex = 0;
            this.btnDexHabitat.Text = "Pokedex Habitat";
            this.btnDexHabitat.UseVisualStyleBackColor = true;
            // 
            // btnDexSort
            // 
            this.btnDexSort.Location = new System.Drawing.Point(20, 148);
            this.btnDexSort.Margin = new System.Windows.Forms.Padding(0);
            this.btnDexSort.Name = "btnDexSort";
            this.btnDexSort.Size = new System.Drawing.Size(128, 23);
            this.btnDexSort.TabIndex = 0;
            this.btnDexSort.Text = "Pokedex Sort";
            this.btnDexSort.UseVisualStyleBackColor = true;
            // 
            // btnEggMove
            // 
            this.btnEggMove.Location = new System.Drawing.Point(20, 238);
            this.btnEggMove.Margin = new System.Windows.Forms.Padding(0);
            this.btnEggMove.Name = "btnEggMove";
            this.btnEggMove.Size = new System.Drawing.Size(128, 23);
            this.btnEggMove.TabIndex = 1;
            this.btnEggMove.Text = "Egg Move";
            this.btnEggMove.UseVisualStyleBackColor = true;
            // 
            // btnTmHmTutor
            // 
            this.btnTmHmTutor.Location = new System.Drawing.Point(20, 208);
            this.btnTmHmTutor.Margin = new System.Windows.Forms.Padding(0);
            this.btnTmHmTutor.Name = "btnTmHmTutor";
            this.btnTmHmTutor.Size = new System.Drawing.Size(128, 23);
            this.btnTmHmTutor.TabIndex = 2;
            this.btnTmHmTutor.Text = "TM, HM, Tutor";
            this.btnTmHmTutor.UseVisualStyleBackColor = true;
            // 
            // btnRoaming
            // 
            this.btnRoaming.Location = new System.Drawing.Point(160, 88);
            this.btnRoaming.Margin = new System.Windows.Forms.Padding(0);
            this.btnRoaming.Name = "btnRoaming";
            this.btnRoaming.Size = new System.Drawing.Size(128, 23);
            this.btnRoaming.TabIndex = 3;
            this.btnRoaming.Text = "Roaming";
            this.btnRoaming.UseVisualStyleBackColor = true;
            // 
            // btnSwarm
            // 
            this.btnSwarm.Location = new System.Drawing.Point(160, 58);
            this.btnSwarm.Margin = new System.Windows.Forms.Padding(0);
            this.btnSwarm.Name = "btnSwarm";
            this.btnSwarm.Size = new System.Drawing.Size(128, 23);
            this.btnSwarm.TabIndex = 4;
            this.btnSwarm.Text = "Swarm";
            this.btnSwarm.UseVisualStyleBackColor = true;
            // 
            // btnWildEnc
            // 
            this.btnWildEnc.Location = new System.Drawing.Point(160, 28);
            this.btnWildEnc.Margin = new System.Windows.Forms.Padding(0);
            this.btnWildEnc.Name = "btnWildEnc";
            this.btnWildEnc.Size = new System.Drawing.Size(128, 23);
            this.btnWildEnc.TabIndex = 5;
            this.btnWildEnc.Text = "Wild Encounter";
            this.btnWildEnc.UseVisualStyleBackColor = true;
            // 
            // btnAtlas
            // 
            this.btnAtlas.Location = new System.Drawing.Point(160, 238);
            this.btnAtlas.Margin = new System.Windows.Forms.Padding(0);
            this.btnAtlas.Name = "btnAtlas";
            this.btnAtlas.Size = new System.Drawing.Size(128, 23);
            this.btnAtlas.TabIndex = 6;
            this.btnAtlas.Text = "Atlas";
            this.btnAtlas.UseVisualStyleBackColor = true;
            // 
            // btnOverworld
            // 
            this.btnOverworld.Location = new System.Drawing.Point(160, 208);
            this.btnOverworld.Margin = new System.Windows.Forms.Padding(0);
            this.btnOverworld.Name = "btnOverworld";
            this.btnOverworld.Size = new System.Drawing.Size(128, 23);
            this.btnOverworld.TabIndex = 7;
            this.btnOverworld.Text = "Overworld";
            this.btnOverworld.UseVisualStyleBackColor = true;
            // 
            // btnTileset
            // 
            this.btnTileset.Location = new System.Drawing.Point(160, 178);
            this.btnTileset.Margin = new System.Windows.Forms.Padding(0);
            this.btnTileset.Name = "btnTileset";
            this.btnTileset.Size = new System.Drawing.Size(128, 23);
            this.btnTileset.TabIndex = 8;
            this.btnTileset.Text = "Tileset";
            this.btnTileset.UseVisualStyleBackColor = true;
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(160, 148);
            this.btnMap.Margin = new System.Windows.Forms.Padding(0);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(128, 23);
            this.btnMap.TabIndex = 9;
            this.btnMap.Text = "Map";
            this.btnMap.UseVisualStyleBackColor = true;
            // 
            // btnMailTxt
            // 
            this.btnMailTxt.Location = new System.Drawing.Point(300, 58);
            this.btnMailTxt.Margin = new System.Windows.Forms.Padding(0);
            this.btnMailTxt.Name = "btnMailTxt";
            this.btnMailTxt.Size = new System.Drawing.Size(128, 23);
            this.btnMailTxt.TabIndex = 10;
            this.btnMailTxt.Text = "Mail Text";
            this.btnMailTxt.UseVisualStyleBackColor = true;
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(300, 28);
            this.btnItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(128, 23);
            this.btnItem.TabIndex = 11;
            this.btnItem.Text = "Item";
            this.btnItem.UseVisualStyleBackColor = true;
            // 
            // btnBattleBg
            // 
            this.btnBattleBg.Location = new System.Drawing.Point(300, 238);
            this.btnBattleBg.Margin = new System.Windows.Forms.Padding(0);
            this.btnBattleBg.Name = "btnBattleBg";
            this.btnBattleBg.Size = new System.Drawing.Size(128, 23);
            this.btnBattleBg.TabIndex = 12;
            this.btnBattleBg.Text = "Battle Background";
            this.btnBattleBg.UseVisualStyleBackColor = true;
            // 
            // btnTrade
            // 
            this.btnTrade.Location = new System.Drawing.Point(300, 208);
            this.btnTrade.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(128, 23);
            this.btnTrade.TabIndex = 13;
            this.btnTrade.Text = "Trade";
            this.btnTrade.UseVisualStyleBackColor = true;
            // 
            // btnTrainerList
            // 
            this.btnTrainerList.Location = new System.Drawing.Point(300, 178);
            this.btnTrainerList.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrainerList.Name = "btnTrainerList";
            this.btnTrainerList.Size = new System.Drawing.Size(128, 23);
            this.btnTrainerList.TabIndex = 14;
            this.btnTrainerList.Text = "Trainer List";
            this.btnTrainerList.UseVisualStyleBackColor = true;
            // 
            // btnTrainerSprite
            // 
            this.btnTrainerSprite.Location = new System.Drawing.Point(300, 148);
            this.btnTrainerSprite.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrainerSprite.Name = "btnTrainerSprite";
            this.btnTrainerSprite.Size = new System.Drawing.Size(128, 23);
            this.btnTrainerSprite.TabIndex = 15;
            this.btnTrainerSprite.Text = "Trainer Sprite";
            this.btnTrainerSprite.UseVisualStyleBackColor = true;
            // 
            // btnTrainerClass
            // 
            this.btnTrainerClass.Location = new System.Drawing.Point(300, 118);
            this.btnTrainerClass.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrainerClass.Name = "btnTrainerClass";
            this.btnTrainerClass.Size = new System.Drawing.Size(128, 23);
            this.btnTrainerClass.TabIndex = 16;
            this.btnTrainerClass.Text = "Trainer Class";
            this.btnTrainerClass.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 475);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadRom;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearRom;
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
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Button btnEggMove;
        private System.Windows.Forms.Button btnTmHmTutor;
        private System.Windows.Forms.Button btnDexSort;
        private System.Windows.Forms.Button btnDexHabitat;
        private System.Windows.Forms.Button btnRegDex;
        private System.Windows.Forms.Button btnNatDex;
        private System.Windows.Forms.Button btnPokemon;
        private System.Windows.Forms.Button btnRoaming;
        private System.Windows.Forms.Button btnSwarm;
        private System.Windows.Forms.Button btnWildEnc;
        private System.Windows.Forms.Button btnAtlas;
        private System.Windows.Forms.Button btnOverworld;
        private System.Windows.Forms.Button btnTileset;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnBattleBg;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.Button btnTrainerList;
        private System.Windows.Forms.Button btnTrainerSprite;
        private System.Windows.Forms.Button btnTrainerClass;
        private System.Windows.Forms.Button btnMailTxt;
        private System.Windows.Forms.Button btnItem;
    }
}