namespace HeroscapeTournamentClient.Buttons
{
    partial class ArmyEntryCard
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
            this.labelCardName = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCardName
            // 
            this.labelCardName.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 5.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCardName.Location = new System.Drawing.Point(3, 71);
            this.labelCardName.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.labelCardName.Name = "labelCardName";
            this.labelCardName.Size = new System.Drawing.Size(114, 46);
            this.labelCardName.TabIndex = 0;
            this.labelCardName.Text = "Name";
            this.labelCardName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelAmount
            // 
            this.labelAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAmount.Location = new System.Drawing.Point(90, 8);
            this.labelAmount.Margin = new System.Windows.Forms.Padding(8);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(22, 25);
            this.labelAmount.TabIndex = 1;
            this.labelAmount.Text = "0";
            // 
            // ArmyEntryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelCardName);
            this.Name = "ArmyEntryCard";
            this.Size = new System.Drawing.Size(120, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label labelCardName;
        public Label labelAmount;
    }
}
