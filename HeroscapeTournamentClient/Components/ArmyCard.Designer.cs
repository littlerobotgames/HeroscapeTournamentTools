namespace HeroscapeTournamentClient.Buttons
{
    partial class ArmyCard
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
            this.labelHexesPoints = new System.Windows.Forms.Label();
            this.panelEntryCards = new System.Windows.Forms.Panel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(14, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(154, 37);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "ArmyName";
            this.labelName.Click += new System.EventHandler(this.CardClicked);
            // 
            // labelHexesPoints
            // 
            this.labelHexesPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHexesPoints.AutoSize = true;
            this.labelHexesPoints.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHexesPoints.Location = new System.Drawing.Point(646, 23);
            this.labelHexesPoints.Name = "labelHexesPoints";
            this.labelHexesPoints.Size = new System.Drawing.Size(141, 28);
            this.labelHexesPoints.TabIndex = 1;
            this.labelHexesPoints.Text = "Hexes | Points";
            this.labelHexesPoints.Click += new System.EventHandler(this.CardClicked);
            // 
            // panelEntryCards
            // 
            this.panelEntryCards.AutoScroll = true;
            this.panelEntryCards.Location = new System.Drawing.Point(14, 52);
            this.panelEntryCards.Name = "panelEntryCards";
            this.panelEntryCards.Size = new System.Drawing.Size(714, 136);
            this.panelEntryCards.TabIndex = 2;
            this.panelEntryCards.Click += new System.EventHandler(this.CardClicked);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(744, 54);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(43, 46);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "E";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(744, 106);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(43, 46);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "X";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // ArmyCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.panelEntryCards);
            this.Controls.Add(this.labelHexesPoints);
            this.Controls.Add(this.labelName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ArmyCard";
            this.Size = new System.Drawing.Size(800, 200);
            this.Click += new System.EventHandler(this.CardClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label labelName;
        public Label labelHexesPoints;
        public Panel panelEntryCards;
        public Button buttonEdit;
        public Button buttonDelete;
    }
}
