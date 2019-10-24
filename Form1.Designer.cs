namespace ProxyEngine
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.generateUsingBasicLandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateWithoutBasicLandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleSidedCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mPCGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DiffDeckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractDecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.importSingletonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.manaCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.priceDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.installNewPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cardImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.displayCardRemove = new System.Windows.Forms.Button();
            this.displayCardUpdate = new System.Windows.Forms.Button();
            this.displayCardNameBox = new System.Windows.Forms.TextBox();
            this.DisplayCardQtyBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.scriptLogger = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.CommandBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayCardQtyBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.decksToolStripMenuItem,
            this.PluginToolStripMenuItem,
            this.scriptToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.doubleSidedCardsToolStripMenuItem,
            this.mPCGeneratorToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.fileToolStripMenuItem.Text = "Generate";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.generateUsingBasicLandsToolStripMenuItem,
            this.generateWithoutBasicLandsToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem3.Text = "Generate PDF";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem4.Text = "Generate Using Ice Age through LEA Lands";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem5.Text = "Generate Using Full Art Lands";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Enabled = false;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem6.Text = "Generate Using Unstable Lands";
            // 
            // generateUsingBasicLandsToolStripMenuItem
            // 
            this.generateUsingBasicLandsToolStripMenuItem.Enabled = false;
            this.generateUsingBasicLandsToolStripMenuItem.Name = "generateUsingBasicLandsToolStripMenuItem";
            this.generateUsingBasicLandsToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.generateUsingBasicLandsToolStripMenuItem.Text = "Generate Using Basic Lands";
            this.generateUsingBasicLandsToolStripMenuItem.Click += new System.EventHandler(this.generateUsingBasicLandsToolStripMenuItem_Click);
            // 
            // generateWithoutBasicLandsToolStripMenuItem
            // 
            this.generateWithoutBasicLandsToolStripMenuItem.Name = "generateWithoutBasicLandsToolStripMenuItem";
            this.generateWithoutBasicLandsToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.generateWithoutBasicLandsToolStripMenuItem.Text = "Generate without Basic Lands";
            this.generateWithoutBasicLandsToolStripMenuItem.Click += new System.EventHandler(this.generateWithoutBasicLandsToolStripMenuItem_Click);
            // 
            // doubleSidedCardsToolStripMenuItem
            // 
            this.doubleSidedCardsToolStripMenuItem.Name = "doubleSidedCardsToolStripMenuItem";
            this.doubleSidedCardsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.doubleSidedCardsToolStripMenuItem.Text = "Double Sided Cards";
            this.doubleSidedCardsToolStripMenuItem.Click += new System.EventHandler(this.doubleSidedCardsToolStripMenuItem_Click);
            // 
            // mPCGeneratorToolStripMenuItem
            // 
            this.mPCGeneratorToolStripMenuItem.Name = "mPCGeneratorToolStripMenuItem";
            this.mPCGeneratorToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mPCGeneratorToolStripMenuItem.Text = "Generate for MPC";
            this.mPCGeneratorToolStripMenuItem.Click += new System.EventHandler(this.mPCGeneratorToolStripMenuItem_Click);
            // 
            // decksToolStripMenuItem
            // 
            this.decksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDeckToolStripMenuItem,
            this.toolStripMenuItem7,
            this.saveDeckToolStripMenuItem,
            this.toolStripSeparator1,
            this.DiffDeckMenu,
            this.subtractDecksToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator5,
            this.importSingletonToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem2});
            this.decksToolStripMenuItem.Name = "decksToolStripMenuItem";
            this.decksToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.decksToolStripMenuItem.Text = "Deck";
            // 
            // loadDeckToolStripMenuItem
            // 
            this.loadDeckToolStripMenuItem.Name = "loadDeckToolStripMenuItem";
            this.loadDeckToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.loadDeckToolStripMenuItem.Text = "Load Deck";
            this.loadDeckToolStripMenuItem.Click += new System.EventHandler(this.loadDeck);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem7.Text = "Add Deck";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.addToDeck);
            // 
            // saveDeckToolStripMenuItem
            // 
            this.saveDeckToolStripMenuItem.Name = "saveDeckToolStripMenuItem";
            this.saveDeckToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveDeckToolStripMenuItem.Text = "Save Deck";
            this.saveDeckToolStripMenuItem.Click += new System.EventHandler(this.saveDeckToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // DiffDeckMenu
            // 
            this.DiffDeckMenu.Name = "DiffDeckMenu";
            this.DiffDeckMenu.Size = new System.Drawing.Size(163, 22);
            this.DiffDeckMenu.Text = "Diff Decks";
            this.DiffDeckMenu.Click += new System.EventHandler(this.diffDecks);
            // 
            // subtractDecksToolStripMenuItem
            // 
            this.subtractDecksToolStripMenuItem.Name = "subtractDecksToolStripMenuItem";
            this.subtractDecksToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.subtractDecksToolStripMenuItem.Text = "Subtract Decks";
            this.subtractDecksToolStripMenuItem.Click += new System.EventHandler(this.subtractDecks);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem1.Text = "Clear Deck";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.clearDeck);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(160, 6);
            // 
            // importSingletonToolStripMenuItem
            // 
            this.importSingletonToolStripMenuItem.Name = "importSingletonToolStripMenuItem";
            this.importSingletonToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.importSingletonToolStripMenuItem.Text = "Import Singleton";
            this.importSingletonToolStripMenuItem.Click += new System.EventHandler(this.importSingletonDeck);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manaCurveToolStripMenuItem,
            this.cardTypesToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.toolStripSeparator3,
            this.priceDumpToolStripMenuItem,
            this.toolStripTextBox1});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem2.Text = "Analytics";
            // 
            // manaCurveToolStripMenuItem
            // 
            this.manaCurveToolStripMenuItem.Name = "manaCurveToolStripMenuItem";
            this.manaCurveToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.manaCurveToolStripMenuItem.Text = "Mana Curve";
            // 
            // cardTypesToolStripMenuItem
            // 
            this.cardTypesToolStripMenuItem.Name = "cardTypesToolStripMenuItem";
            this.cardTypesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cardTypesToolStripMenuItem.Text = "Card Types";
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.colorsToolStripMenuItem.Text = "Colors";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // priceDumpToolStripMenuItem
            // 
            this.priceDumpToolStripMenuItem.Name = "priceDumpToolStripMenuItem";
            this.priceDumpToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.priceDumpToolStripMenuItem.Text = "Price Dump";
            this.priceDumpToolStripMenuItem.Click += new System.EventHandler(this.priceDumpToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "0.10";
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executScriptToolStripMenuItem,
            this.newScriptToolStripMenuItem,
            this.saveScriptToolStripMenuItem,
            this.exitScriptToolStripMenuItem});
            this.scriptToolStripMenuItem.Enabled = false;
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.scriptToolStripMenuItem.Text = "Script";
            this.scriptToolStripMenuItem.Visible = false;
            // 
            // executScriptToolStripMenuItem
            // 
            this.executScriptToolStripMenuItem.Name = "executScriptToolStripMenuItem";
            this.executScriptToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.executScriptToolStripMenuItem.Text = "Execute Script";
            this.executScriptToolStripMenuItem.Click += new System.EventHandler(this.executScriptToolStripMenuItem_Click);
            // 
            // newScriptToolStripMenuItem
            // 
            this.newScriptToolStripMenuItem.Name = "newScriptToolStripMenuItem";
            this.newScriptToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newScriptToolStripMenuItem.Text = "New Script";
            // 
            // saveScriptToolStripMenuItem
            // 
            this.saveScriptToolStripMenuItem.Name = "saveScriptToolStripMenuItem";
            this.saveScriptToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveScriptToolStripMenuItem.Text = "Save Script";
            // 
            // exitScriptToolStripMenuItem
            // 
            this.exitScriptToolStripMenuItem.Name = "exitScriptToolStripMenuItem";
            this.exitScriptToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitScriptToolStripMenuItem.Text = "Exit Script";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installNewPluginToolStripMenuItem,
            this.uninstallPluginToolStripMenuItem});
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem8.Text = "Plugin Manager";
            // 
            // installNewPluginToolStripMenuItem
            // 
            this.installNewPluginToolStripMenuItem.Name = "installNewPluginToolStripMenuItem";
            this.installNewPluginToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.installNewPluginToolStripMenuItem.Text = "Install Plugin";
            // 
            // uninstallPluginToolStripMenuItem
            // 
            this.uninstallPluginToolStripMenuItem.Name = "uninstallPluginToolStripMenuItem";
            this.uninstallPluginToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.uninstallPluginToolStripMenuItem.Text = "Uninstall Plugin";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(184, 368);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cardImage
            // 
            this.cardImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cardImage.Location = new System.Drawing.Point(202, 27);
            this.cardImage.Name = "cardImage";
            this.cardImage.Size = new System.Drawing.Size(213, 287);
            this.cardImage.TabIndex = 2;
            this.cardImage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.displayCardRemove);
            this.groupBox1.Controls.Add(this.displayCardUpdate);
            this.groupBox1.Controls.Add(this.displayCardNameBox);
            this.groupBox1.Controls.Add(this.DisplayCardQtyBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(202, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Card Info";
            // 
            // displayCardRemove
            // 
            this.displayCardRemove.Location = new System.Drawing.Point(150, 68);
            this.displayCardRemove.Name = "displayCardRemove";
            this.displayCardRemove.Size = new System.Drawing.Size(57, 23);
            this.displayCardRemove.TabIndex = 5;
            this.displayCardRemove.Text = "Remove";
            this.displayCardRemove.UseVisualStyleBackColor = true;
            this.displayCardRemove.Click += new System.EventHandler(this.displayCardRemove_Click);
            // 
            // displayCardUpdate
            // 
            this.displayCardUpdate.Location = new System.Drawing.Point(87, 68);
            this.displayCardUpdate.Name = "displayCardUpdate";
            this.displayCardUpdate.Size = new System.Drawing.Size(57, 23);
            this.displayCardUpdate.TabIndex = 4;
            this.displayCardUpdate.Text = "Update";
            this.displayCardUpdate.UseVisualStyleBackColor = true;
            this.displayCardUpdate.Click += new System.EventHandler(this.displayCardUpdate_Click);
            // 
            // displayCardNameBox
            // 
            this.displayCardNameBox.Location = new System.Drawing.Point(6, 32);
            this.displayCardNameBox.Name = "displayCardNameBox";
            this.displayCardNameBox.ReadOnly = true;
            this.displayCardNameBox.Size = new System.Drawing.Size(201, 20);
            this.displayCardNameBox.TabIndex = 3;
            // 
            // DisplayCardQtyBox
            // 
            this.DisplayCardQtyBox.Location = new System.Drawing.Point(6, 71);
            this.DisplayCardQtyBox.Name = "DisplayCardQtyBox";
            this.DisplayCardQtyBox.Size = new System.Drawing.Size(75, 20);
            this.DisplayCardQtyBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Card:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // scriptLogger
            // 
            this.scriptLogger.BackColor = System.Drawing.Color.Black;
            this.scriptLogger.Font = new System.Drawing.Font("Source Code Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptLogger.ForeColor = System.Drawing.Color.White;
            this.scriptLogger.Location = new System.Drawing.Point(421, 27);
            this.scriptLogger.Name = "scriptLogger";
            this.scriptLogger.ReadOnly = true;
            this.scriptLogger.Size = new System.Drawing.Size(367, 370);
            this.scriptLogger.TabIndex = 4;
            this.scriptLogger.Text = "";
            // 
            // CommandBox
            // 
            this.CommandBox.Location = new System.Drawing.Point(421, 405);
            this.CommandBox.Name = "CommandBox";
            this.CommandBox.Size = new System.Drawing.Size(286, 20);
            this.CommandBox.TabIndex = 5;
            this.CommandBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommandBox_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add One";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddOneFromCommandBox);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 399);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(92, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 399);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Mass Import";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 434);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CommandBox);
            this.Controls.Add(this.scriptLogger);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cardImage);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.Text = "Proxy Engine v2.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayCardQtyBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox cardImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox displayCardNameBox;
        private System.Windows.Forms.NumericUpDown DisplayCardQtyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button displayCardRemove;
        private System.Windows.Forms.Button displayCardUpdate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox scriptLogger;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox CommandBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PluginToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem manaCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cardTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem generateUsingBasicLandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateWithoutBasicLandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem DiffDeckMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem installNewPluginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uninstallPluginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleSidedCardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSingletonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem priceDumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem subtractDecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mPCGeneratorToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}

