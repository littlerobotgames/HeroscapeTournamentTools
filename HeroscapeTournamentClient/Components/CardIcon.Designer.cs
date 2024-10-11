namespace HeroscapeTournamentClient.Buttons
{
    partial class CardIcon
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
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.buttonSubtract = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCardName
            // 
            this.labelCardName.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCardName.Location = new System.Drawing.Point(3, 0);
            this.labelCardName.Name = "labelCardName";
            this.labelCardName.Size = new System.Drawing.Size(174, 64);
            this.labelCardName.TabIndex = 0;
            this.labelCardName.Text = "Card Name";
            this.labelCardName.Click += new System.EventHandler(this.CardClicked);
            // 
            // labelPoints
            // 
            this.labelPoints.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPoints.Location = new System.Drawing.Point(127, 121);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(53, 29);
            this.labelPoints.TabIndex = 1;
            this.labelPoints.Text = "10";
            this.labelPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPoints.Click += new System.EventHandler(this.CardClicked);
            // 
            // labelAmount
            // 
            this.labelAmount.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAmount.Location = new System.Drawing.Point(3, 121);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(71, 31);
            this.labelAmount.TabIndex = 2;
            this.labelAmount.Text = "0/0";
            this.labelAmount.Click += new System.EventHandler(this.CardClicked);
            // 
            // buttonSubtract
            // 
            this.buttonSubtract.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubtract.Location = new System.Drawing.Point(3, 83);
            this.buttonSubtract.Name = "buttonSubtract";
            this.buttonSubtract.Size = new System.Drawing.Size(35, 35);
            this.buttonSubtract.TabIndex = 3;
            this.buttonSubtract.Text = "-";
            this.buttonSubtract.UseVisualStyleBackColor = true;
            this.buttonSubtract.Click += new System.EventHandler(this.buttonSubtract_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(142, 83);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(35, 35);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // CardIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonSubtract);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.labelCardName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "CardIcon";
            this.Size = new System.Drawing.Size(180, 150);
            this.Click += new System.EventHandler(this.CardClicked);
            this.ResumeLayout(false);

        }

        #endregion

        public Label labelCardName;
        public Label labelPoints;
        public Label labelAmount;
        public Button buttonSubtract;
        public Button buttonAdd;
    }
}
