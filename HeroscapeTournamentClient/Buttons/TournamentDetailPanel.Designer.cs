namespace HeroscapeTournamentClient.Buttons
{
    partial class TournamentDetailPanel
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelParticipants = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelHexes = new System.Windows.Forms.Label();
            this.labelPublicity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(15, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(320, 50);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "TournamentName";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDate.Location = new System.Drawing.Point(15, 399);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(74, 37);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date";
            // 
            // labelParticipants
            // 
            this.labelParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelParticipants.AutoSize = true;
            this.labelParticipants.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelParticipants.Location = new System.Drawing.Point(771, 399);
            this.labelParticipants.Name = "labelParticipants";
            this.labelParticipants.Size = new System.Drawing.Size(163, 37);
            this.labelParticipants.TabIndex = 2;
            this.labelParticipants.Text = "Participants";
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFormat.Location = new System.Drawing.Point(15, 115);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(105, 37);
            this.labelFormat.TabIndex = 3;
            this.labelFormat.Text = "Format";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPoints.Location = new System.Drawing.Point(15, 165);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(93, 37);
            this.labelPoints.TabIndex = 4;
            this.labelPoints.Text = "Points";
            // 
            // labelHexes
            // 
            this.labelHexes.AutoSize = true;
            this.labelHexes.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHexes.Location = new System.Drawing.Point(15, 215);
            this.labelHexes.Name = "labelHexes";
            this.labelHexes.Size = new System.Drawing.Size(93, 37);
            this.labelHexes.TabIndex = 5;
            this.labelHexes.Text = "Hexes";
            // 
            // labelPublicity
            // 
            this.labelPublicity.AutoSize = true;
            this.labelPublicity.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPublicity.Location = new System.Drawing.Point(15, 265);
            this.labelPublicity.Name = "labelPublicity";
            this.labelPublicity.Size = new System.Drawing.Size(79, 37);
            this.labelPublicity.TabIndex = 6;
            this.labelPublicity.Text = "Code";
            // 
            // TournamentDetailPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.labelPublicity);
            this.Controls.Add(this.labelHexes);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.labelFormat);
            this.Controls.Add(this.labelParticipants);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelName);
            this.Name = "TournamentDetailPanel";
            this.Size = new System.Drawing.Size(950, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label labelName;
        public Label labelDate;
        public Label labelParticipants;
        public Label labelFormat;
        public Label labelPoints;
        public Label labelHexes;
        public Label labelPublicity;
    }
}
