
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
            this.grpEditors = new System.Windows.Forms.GroupBox();
            this.btnPokemon = new System.Windows.Forms.Button();
            this.btnNationalPokedex = new System.Windows.Forms.Button();
            this.btnRegionalPokedex = new System.Windows.Forms.Button();
            this.btnPokedexHabitat = new System.Windows.Forms.Button();
            this.btnPokedexSort = new System.Windows.Forms.Button();
            this.btnEggMove = new System.Windows.Forms.Button();
            this.btnTmHmTutor = new System.Windows.Forms.Button();
            this.btnRoaming = new System.Windows.Forms.Button();
            this.btnSwarm = new System.Windows.Forms.Button();
            this.btnWildEncounter = new System.Windows.Forms.Button();
            this.btnAtlas = new System.Windows.Forms.Button();
            this.btnTileset = new System.Windows.Forms.Button();
            this.btnOverworld = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.btnMailText = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.btnBattleBackground = new System.Windows.Forms.Button();
            this.btnTrainerList = new System.Windows.Forms.Button();
            this.btnTrade = new System.Windows.Forms.Button();
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
            this.tsmiLoadRom.Size = new System.Drawing.Size(182, 20);
            this.tsmiLoadRom.Text = "Load ROM";
            // 
            // tsmiUnloadRom
            // 
            this.tsmiUnloadRom.Name = "tsmiUnloadRom";
            this.tsmiUnloadRom.Padding = new System.Windows.Forms.Padding(0);
            this.tsmiUnloadRom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiUnloadRom.Size = new System.Drawing.Size(182, 20);
            this.tsmiUnloadRom.Text = "Unload ROM";
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
            this.grpEditors.Controls.Add(this.btnBattleBackground);
            this.grpEditors.Controls.Add(this.btnTrainerList);
            this.grpEditors.Controls.Add(this.btnTrade);
            this.grpEditors.Controls.Add(this.btnTrainerSprite);
            this.grpEditors.Controls.Add(this.btnTrainerClass);
            this.grpEditors.Controls.Add(this.btnMailText);
            this.grpEditors.Controls.Add(this.btnItem);
            this.grpEditors.Controls.Add(this.btnAtlas);
            this.grpEditors.Controls.Add(this.btnTileset);
            this.grpEditors.Controls.Add(this.btnOverworld);
            this.grpEditors.Controls.Add(this.btnMap);
            this.grpEditors.Controls.Add(this.btnRoaming);
            this.grpEditors.Controls.Add(this.btnSwarm);
            this.grpEditors.Controls.Add(this.btnWildEncounter);
            this.grpEditors.Controls.Add(this.btnEggMove);
            this.grpEditors.Controls.Add(this.btnTmHmTutor);
            this.grpEditors.Controls.Add(this.btnPokedexSort);
            this.grpEditors.Controls.Add(this.btnRegionalPokedex);
            this.grpEditors.Controls.Add(this.btnPokedexHabitat);
            this.grpEditors.Controls.Add(this.btnNationalPokedex);
            this.grpEditors.Controls.Add(this.btnPokemon);
            this.grpEditors.Location = new System.Drawing.Point(20, 34);
            this.grpEditors.Margin = new System.Windows.Forms.Padding(0);
            this.grpEditors.Name = "grpEditors";
            this.grpEditors.Padding = new System.Windows.Forms.Padding(0);
            this.grpEditors.Size = new System.Drawing.Size(450, 282);
            this.grpEditors.TabIndex = 1;
            this.grpEditors.TabStop = false;
            this.grpEditors.Text = "Editors";
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
            // btnNationalPokedex
            // 
            this.btnNationalPokedex.Location = new System.Drawing.Point(20, 58);
            this.btnNationalPokedex.Margin = new System.Windows.Forms.Padding(0);
            this.btnNationalPokedex.Name = "btnNationalPokedex";
            this.btnNationalPokedex.Size = new System.Drawing.Size(128, 23);
            this.btnNationalPokedex.TabIndex = 0;
            this.btnNationalPokedex.Text = "National Pokedex";
            this.btnNationalPokedex.UseVisualStyleBackColor = true;
            // 
            // btnRegionalPokedex
            // 
            this.btnRegionalPokedex.Location = new System.Drawing.Point(20, 88);
            this.btnRegionalPokedex.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegionalPokedex.Name = "btnRegionalPokedex";
            this.btnRegionalPokedex.Size = new System.Drawing.Size(128, 23);
            this.btnRegionalPokedex.TabIndex = 0;
            this.btnRegionalPokedex.Text = "Regional Pokedex";
            this.btnRegionalPokedex.UseVisualStyleBackColor = true;
            // 
            // btnPokedexHabitat
            // 
            this.btnPokedexHabitat.Location = new System.Drawing.Point(20, 118);
            this.btnPokedexHabitat.Margin = new System.Windows.Forms.Padding(0);
            this.btnPokedexHabitat.Name = "btnPokedexHabitat";
            this.btnPokedexHabitat.Size = new System.Drawing.Size(128, 23);
            this.btnPokedexHabitat.TabIndex = 0;
            this.btnPokedexHabitat.Text = "Pokedex Habitat";
            this.btnPokedexHabitat.UseVisualStyleBackColor = true;
            // 
            // btnPokedexSort
            // 
            this.btnPokedexSort.Location = new System.Drawing.Point(20, 148);
            this.btnPokedexSort.Margin = new System.Windows.Forms.Padding(0);
            this.btnPokedexSort.Name = "btnPokedexSort";
            this.btnPokedexSort.Size = new System.Drawing.Size(128, 23);
            this.btnPokedexSort.TabIndex = 0;
            this.btnPokedexSort.Text = "Pokedex Sort";
            this.btnPokedexSort.UseVisualStyleBackColor = true;
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
            // btnWildEncounter
            // 
            this.btnWildEncounter.Location = new System.Drawing.Point(160, 28);
            this.btnWildEncounter.Margin = new System.Windows.Forms.Padding(0);
            this.btnWildEncounter.Name = "btnWildEncounter";
            this.btnWildEncounter.Size = new System.Drawing.Size(128, 23);
            this.btnWildEncounter.TabIndex = 5;
            this.btnWildEncounter.Text = "Wild Encounter";
            this.btnWildEncounter.UseVisualStyleBackColor = true;
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
            // btnTileset
            // 
            this.btnTileset.Location = new System.Drawing.Point(160, 178);
            this.btnTileset.Margin = new System.Windows.Forms.Padding(0);
            this.btnTileset.Name = "btnTileset";
            this.btnTileset.Size = new System.Drawing.Size(128, 23);
            this.btnTileset.TabIndex = 7;
            this.btnTileset.Text = "Tileset";
            this.btnTileset.UseVisualStyleBackColor = true;
            // 
            // btnOverworld
            // 
            this.btnOverworld.Location = new System.Drawing.Point(160, 208);
            this.btnOverworld.Margin = new System.Windows.Forms.Padding(0);
            this.btnOverworld.Name = "btnOverworld";
            this.btnOverworld.Size = new System.Drawing.Size(128, 23);
            this.btnOverworld.TabIndex = 8;
            this.btnOverworld.Text = "Overworld";
            this.btnOverworld.UseVisualStyleBackColor = true;
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
            // btnMailText
            // 
            this.btnMailText.Location = new System.Drawing.Point(300, 58);
            this.btnMailText.Margin = new System.Windows.Forms.Padding(0);
            this.btnMailText.Name = "btnMailText";
            this.btnMailText.Size = new System.Drawing.Size(128, 23);
            this.btnMailText.TabIndex = 10;
            this.btnMailText.Text = "Mail Text";
            this.btnMailText.UseVisualStyleBackColor = true;
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
            // btnBattleBackground
            // 
            this.btnBattleBackground.Location = new System.Drawing.Point(300, 238);
            this.btnBattleBackground.Margin = new System.Windows.Forms.Padding(0);
            this.btnBattleBackground.Name = "btnBattleBackground";
            this.btnBattleBackground.Size = new System.Drawing.Size(128, 23);
            this.btnBattleBackground.TabIndex = 12;
            this.btnBattleBackground.Text = "Battle Background";
            this.btnBattleBackground.UseVisualStyleBackColor = true;
            // 
            // btnTrainerList
            // 
            this.btnTrainerList.Location = new System.Drawing.Point(300, 178);
            this.btnTrainerList.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrainerList.Name = "btnTrainerList";
            this.btnTrainerList.Size = new System.Drawing.Size(128, 23);
            this.btnTrainerList.TabIndex = 13;
            this.btnTrainerList.Text = "Trainer List";
            this.btnTrainerList.UseVisualStyleBackColor = true;
            // 
            // btnTrade
            // 
            this.btnTrade.Location = new System.Drawing.Point(300, 208);
            this.btnTrade.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(128, 23);
            this.btnTrade.TabIndex = 14;
            this.btnTrade.Text = "Trade";
            this.btnTrade.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.grpEditors);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.GroupBox grpEditors;
        private System.Windows.Forms.Button btnPokedexSort;
        private System.Windows.Forms.Button btnRegionalPokedex;
        private System.Windows.Forms.Button btnPokedexHabitat;
        private System.Windows.Forms.Button btnNationalPokedex;
        private System.Windows.Forms.Button btnPokemon;
        private System.Windows.Forms.Button btnEggMove;
        private System.Windows.Forms.Button btnTmHmTutor;
        private System.Windows.Forms.Button btnRoaming;
        private System.Windows.Forms.Button btnSwarm;
        private System.Windows.Forms.Button btnWildEncounter;
        private System.Windows.Forms.Button btnAtlas;
        private System.Windows.Forms.Button btnTileset;
        private System.Windows.Forms.Button btnOverworld;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnMailText;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Button btnBattleBackground;
        private System.Windows.Forms.Button btnTrainerList;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.Button btnTrainerSprite;
        private System.Windows.Forms.Button btnTrainerClass;
    }
}

