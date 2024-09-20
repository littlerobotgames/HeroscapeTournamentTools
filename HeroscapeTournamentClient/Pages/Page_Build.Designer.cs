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
            this.cardIconPanel1 = new HeroscapeTournamentClient.Buttons.CardIconPanel();
            this.currentCardPanelSmall1 = new HeroscapeTournamentClient.Buttons.CurrentCardPanelSmall();
            this.SuspendLayout();
            // 
            // cardIconPanel1
            // 
            this.cardIconPanel1.AllCards = null;
            this.cardIconPanel1.AutoScroll = true;
            this.cardIconPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cardIconPanel1.isBrowse = false;
            this.cardIconPanel1.Location = new System.Drawing.Point(910, 35);
            this.cardIconPanel1.Name = "cardIconPanel1";
            this.cardIconPanel1.Padding = new System.Windows.Forms.Padding(50);
            this.cardIconPanel1.Size = new System.Drawing.Size(950, 980);
            this.cardIconPanel1.TabIndex = 0;
            // 
            // currentCardPanelSmall1
            // 
            this.currentCardPanelSmall1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.currentCardPanelSmall1.Location = new System.Drawing.Point(31, 35);
            this.currentCardPanelSmall1.Name = "currentCardPanelSmall1";
            this.currentCardPanelSmall1.Size = new System.Drawing.Size(850, 600);
            this.currentCardPanelSmall1.TabIndex = 1;
            // 
            // Page_Build
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currentCardPanelSmall1);
            this.Controls.Add(this.cardIconPanel1);
            this.Name = "Page_Build";
            this.Size = new System.Drawing.Size(1900, 1060);
            this.ResumeLayout(false);

        }

        #endregion

        private Buttons.CardIconPanel cardIconPanel1;
        private Buttons.CurrentCardPanelSmall currentCardPanelSmall1;
    }
}
