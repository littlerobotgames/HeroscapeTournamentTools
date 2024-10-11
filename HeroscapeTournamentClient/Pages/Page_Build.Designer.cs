namespace HeroscapeTournamentClient.Pages
{
    partial class Page_Build
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            HeroscapeTournamentServer.Classes.FigureCollection figureCollection1 = new HeroscapeTournamentServer.Classes.FigureCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page_Build));
            this.cardIconPanel1 = new HeroscapeTournamentClient.Buttons.CardIconPanel();
            this.currentCardPanelSmall1 = new HeroscapeTournamentClient.Buttons.CurrentCardPanelSmall();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxTournament = new System.Windows.Forms.ComboBox();
            this.labelRuleset = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelHexes = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panelCards = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cardIconPanel1
            // 
            this.cardIconPanel1.AllCards = null;
            this.cardIconPanel1.AutoScroll = true;
            figureCollection1.playerId = 0;
            this.cardIconPanel1.AvailableUnits = figureCollection1;
            this.cardIconPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardIconPanel1.isBrowse = false;
            this.cardIconPanel1.Location = new System.Drawing.Point(911, 25);
            this.cardIconPanel1.MasterPage = null;
            this.cardIconPanel1.Name = "cardIconPanel1";
            this.cardIconPanel1.Padding = new System.Windows.Forms.Padding(50);
            this.cardIconPanel1.showPanelSmall = this.currentCardPanelSmall1;
            this.cardIconPanel1.Size = new System.Drawing.Size(950, 980);
            this.cardIconPanel1.TabIndex = 0;
            // 
            // currentCardPanelSmall1
            // 
            this.currentCardPanelSmall1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.currentCardPanelSmall1.Location = new System.Drawing.Point(25, 405);
            this.currentCardPanelSmall1.Name = "currentCardPanelSmall1";
            this.currentCardPanelSmall1.Size = new System.Drawing.Size(850, 600);
            this.currentCardPanelSmall1.TabIndex = 1;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBack.Location = new System.Drawing.Point(25, 25);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(150, 46);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.Location = new System.Drawing.Point(25, 77);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(672, 36);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.ArmyNameChanged);
            // 
            // comboBoxTournament
            // 
            this.comboBoxTournament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTournament.FormattingEnabled = true;
            this.comboBoxTournament.Location = new System.Drawing.Point(284, 25);
            this.comboBoxTournament.Name = "comboBoxTournament";
            this.comboBoxTournament.Size = new System.Drawing.Size(591, 40);
            this.comboBoxTournament.TabIndex = 4;
            this.comboBoxTournament.SelectedIndexChanged += new System.EventHandler(this.TournamentPicked);
            // 
            // labelRuleset
            // 
            this.labelRuleset.AutoSize = true;
            this.labelRuleset.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRuleset.Location = new System.Drawing.Point(191, 31);
            this.labelRuleset.Name = "labelRuleset";
            this.labelRuleset.Size = new System.Drawing.Size(87, 28);
            this.labelRuleset.TabIndex = 5;
            this.labelRuleset.Text = "Ruleset:";
            this.labelRuleset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPoints.Location = new System.Drawing.Point(33, 123);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(112, 28);
            this.labelPoints.TabIndex = 6;
            this.labelPoints.Text = "Points: 0/0";
            // 
            // labelHexes
            // 
            this.labelHexes.AutoSize = true;
            this.labelHexes.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHexes.Location = new System.Drawing.Point(328, 123);
            this.labelHexes.Name = "labelHexes";
            this.labelHexes.Size = new System.Drawing.Size(110, 28);
            this.labelHexes.TabIndex = 7;
            this.labelHexes.Text = "Hexes: 0/0";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(725, 71);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 46);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save Army";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panelCards
            // 
            this.panelCards.AutoScroll = true;
            this.panelCards.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelCards.Location = new System.Drawing.Point(25, 164);
            this.panelCards.Name = "panelCards";
            this.panelCards.Size = new System.Drawing.Size(850, 200);
            this.panelCards.TabIndex = 9;
            // 
            // Page_Build
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCards);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelHexes);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.labelRuleset);
            this.Controls.Add(this.comboBoxTournament);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.currentCardPanelSmall1);
            this.Controls.Add(this.cardIconPanel1);
            this.Name = "Page_Build";
            this.Size = new System.Drawing.Size(1900, 1060);
            this.Load += new System.EventHandler(this.LoadPageBuild);
            this.VisibleChanged += new System.EventHandler(this.PageBuildVisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Buttons.CurrentCardPanelSmall currentCardPanelSmall1;
        private Button buttonBack;
        private TextBox textBoxName;
        public Buttons.CardIconPanel cardIconPanel1;
        private ComboBox comboBoxTournament;
        private Label labelRuleset;
        private Label labelPoints;
        private Label labelHexes;
        private Button buttonSave;
        private Panel panelCards;
    }
}
