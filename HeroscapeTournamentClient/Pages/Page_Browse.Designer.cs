namespace HeroscapeTournamentClient.Pages
{
    partial class Page_Browse
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
            this.cardIconPanel1 = new HeroscapeTournamentClient.Buttons.CardIconPanel();
            this.currentCardPanel1 = new HeroscapeTournamentClient.Buttons.CurrentCardPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cardIconPanel1
            // 
            this.cardIconPanel1.AllCards = null;
            this.cardIconPanel1.AutoScroll = true;
            this.cardIconPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardIconPanel1.isBrowse = true;
            this.cardIconPanel1.Location = new System.Drawing.Point(908, 25);
            this.cardIconPanel1.Name = "cardIconPanel1";
            this.cardIconPanel1.Padding = new System.Windows.Forms.Padding(50);
            this.cardIconPanel1.Size = new System.Drawing.Size(950, 1000);
            this.cardIconPanel1.TabIndex = 0;
            // 
            // currentCardPanel1
            // 
            this.currentCardPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.currentCardPanel1.Location = new System.Drawing.Point(25, 77);
            this.currentCardPanel1.Name = "currentCardPanel1";
            this.currentCardPanel1.Size = new System.Drawing.Size(850, 950);
            this.currentCardPanel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(25, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Page_Browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentCardPanel1);
            this.Controls.Add(this.cardIconPanel1);
            this.Name = "Page_Browse";
            this.Size = new System.Drawing.Size(1900, 1060);
            this.ResumeLayout(false);

        }

        #endregion

        private Buttons.CardIconPanel cardIconPanel1;
        private Buttons.CurrentCardPanel currentCardPanel1;
        private Button button1;
    }
}
