namespace HeroscapeTournamentClient.Pages
{
    partial class Page_Battle
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
            this.tourneyList1 = new HeroscapeTournamentClient.Buttons.TourneyList();
            this.tournamentDetailPanel1 = new HeroscapeTournamentClient.Buttons.TournamentDetailPanel();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tourneyList1
            // 
            this.tourneyList1.AutoScroll = true;
            this.tourneyList1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tourneyList1.Location = new System.Drawing.Point(911, 25);
            this.tourneyList1.MyTournamentDetailPanel = this.tournamentDetailPanel1;
            this.tourneyList1.Name = "tourneyList1";
            this.tourneyList1.Size = new System.Drawing.Size(950, 980);
            this.tourneyList1.TabIndex = 0;
            // 
            // tournamentDetailPanel1
            // 
            this.tournamentDetailPanel1.BackColor = System.Drawing.Color.Silver;
            this.tournamentDetailPanel1.Location = new System.Drawing.Point(26, 76);
            this.tournamentDetailPanel1.Name = "tournamentDetailPanel1";
            this.tournamentDetailPanel1.Size = new System.Drawing.Size(850, 450);
            this.tournamentDetailPanel1.TabIndex = 1;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEnter.Location = new System.Drawing.Point(726, 532);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(150, 46);
            this.buttonEnter.TabIndex = 2;
            this.buttonEnter.Text = "Enter";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBack.Location = new System.Drawing.Point(25, 25);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(150, 46);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // Page_Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.tournamentDetailPanel1);
            this.Controls.Add(this.tourneyList1);
            this.Name = "Page_Battle";
            this.Size = new System.Drawing.Size(1900, 1060);
            this.VisibleChanged += new System.EventHandler(this.Page_Battle_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion
        public Buttons.TournamentDetailPanel tournamentDetailPanel1;
        public Button buttonEnter;
        public Button buttonBack;
        public Buttons.TourneyList tourneyList1;
    }
}
