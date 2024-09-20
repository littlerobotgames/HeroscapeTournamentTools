namespace HeroscapeTournamentClient.Buttons
{
    partial class TournamentCard
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
            this.labelParticipants = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(12, 11);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(320, 50);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "TournamentName";
            this.labelName.Click += new System.EventHandler(this.CardClicked);
            // 
            // labelParticipants
            // 
            this.labelParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelParticipants.AutoSize = true;
            this.labelParticipants.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelParticipants.ForeColor = System.Drawing.Color.White;
            this.labelParticipants.Location = new System.Drawing.Point(664, 108);
            this.labelParticipants.Name = "labelParticipants";
            this.labelParticipants.Size = new System.Drawing.Size(123, 28);
            this.labelParticipants.TabIndex = 1;
            this.labelParticipants.Text = "Participants";
            this.labelParticipants.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelParticipants.Click += new System.EventHandler(this.CardClicked);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Location = new System.Drawing.Point(12, 108);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(54, 28);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Date";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelDate.Click += new System.EventHandler(this.CardClicked);
            // 
            // TournamentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelParticipants);
            this.Controls.Add(this.labelName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "TournamentCard";
            this.Size = new System.Drawing.Size(800, 150);
            this.Click += new System.EventHandler(this.CardClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label labelName;
        public Label labelParticipants;
        public Label labelDate;
    }
}
