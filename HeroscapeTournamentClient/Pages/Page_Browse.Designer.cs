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
            this.SuspendLayout();
            // 
            // cardIconPanel1
            // 
            this.cardIconPanel1.AllCards = null;
            this.cardIconPanel1.AutoScroll = true;
            this.cardIconPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardIconPanel1.isBrowse = true;
            this.cardIconPanel1.Location = new System.Drawing.Point(910, 35);
            this.cardIconPanel1.Name = "cardIconPanel1";
            this.cardIconPanel1.Padding = new System.Windows.Forms.Padding(50);
            this.cardIconPanel1.Size = new System.Drawing.Size(950, 1000);
            this.cardIconPanel1.TabIndex = 0;
            // 
            // currentCardPanel1
            // 
            this.currentCardPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.currentCardPanel1.Location = new System.Drawing.Point(22, 35);
            this.currentCardPanel1.Name = "currentCardPanel1";
            this.currentCardPanel1.Size = new System.Drawing.Size(850, 1000);
            this.currentCardPanel1.TabIndex = 1;
            // 
            // Page_Browse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currentCardPanel1);
            this.Controls.Add(this.cardIconPanel1);
            this.Name = "Page_Browse";
            this.Size = new System.Drawing.Size(1900, 1060);
            this.ResumeLayout(false);

        }

        #endregion

        private Buttons.CardIconPanel cardIconPanel1;
        private Buttons.CurrentCardPanel currentCardPanel1;
    }
}
