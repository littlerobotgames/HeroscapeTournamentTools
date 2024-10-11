namespace HeroscapeTournamentClient.Pages
{
    partial class Page_BattlePickArmy
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.panelYourArmies = new System.Windows.Forms.Panel();
            this.panelTournyPresets = new System.Windows.Forms.Panel();
            this.labelYourArmies = new System.Windows.Forms.Label();
            this.labelPresets = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBack.Location = new System.Drawing.Point(25, 25);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(150, 46);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonEnter
            // 
            this.buttonEnter.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEnter.Location = new System.Drawing.Point(25, 946);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(197, 82);
            this.buttonEnter.TabIndex = 1;
            this.buttonEnter.Text = "Enter!";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // panelYourArmies
            // 
            this.panelYourArmies.AutoScroll = true;
            this.panelYourArmies.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelYourArmies.Location = new System.Drawing.Point(25, 139);
            this.panelYourArmies.Name = "panelYourArmies";
            this.panelYourArmies.Size = new System.Drawing.Size(900, 798);
            this.panelYourArmies.TabIndex = 2;
            // 
            // panelTournyPresets
            // 
            this.panelTournyPresets.AutoScroll = true;
            this.panelTournyPresets.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTournyPresets.Location = new System.Drawing.Point(972, 139);
            this.panelTournyPresets.Name = "panelTournyPresets";
            this.panelTournyPresets.Size = new System.Drawing.Size(900, 798);
            this.panelTournyPresets.TabIndex = 3;
            // 
            // labelYourArmies
            // 
            this.labelYourArmies.AutoSize = true;
            this.labelYourArmies.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelYourArmies.Location = new System.Drawing.Point(335, 74);
            this.labelYourArmies.Name = "labelYourArmies";
            this.labelYourArmies.Size = new System.Drawing.Size(276, 62);
            this.labelYourArmies.TabIndex = 4;
            this.labelYourArmies.Text = "Your Armies";
            // 
            // labelPresets
            // 
            this.labelPresets.AutoSize = true;
            this.labelPresets.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPresets.Location = new System.Drawing.Point(1196, 74);
            this.labelPresets.Name = "labelPresets";
            this.labelPresets.Size = new System.Drawing.Size(441, 62);
            this.labelPresets.TabIndex = 5;
            this.labelPresets.Text = "Tournament Presets";
            // 
            // Page_BattlePickArmy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPresets);
            this.Controls.Add(this.labelYourArmies);
            this.Controls.Add(this.panelTournyPresets);
            this.Controls.Add(this.panelYourArmies);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.buttonBack);
            this.Name = "Page_BattlePickArmy";
            this.Size = new System.Drawing.Size(1900, 1060);
            this.VisibleChanged += new System.EventHandler(this.Page_BattlePickArmy_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonBack;
        private Button buttonEnter;
        private Panel panelYourArmies;
        private Panel panelTournyPresets;
        private Label labelYourArmies;
        private Label labelPresets;
    }
}
