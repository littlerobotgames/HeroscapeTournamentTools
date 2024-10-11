namespace HeroscapeTournamentClient.Pages
{
    partial class Page_BuildMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelArmyList1 = new HeroscapeTournamentClient.Buttons.PanelArmyList();
            this.button1 = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1314, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "My Armies";
            // 
            // panelArmyList1
            // 
            this.panelArmyList1.AutoScroll = true;
            this.panelArmyList1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelArmyList1.Location = new System.Drawing.Point(923, 77);
            this.panelArmyList1.Name = "panelArmyList1";
            this.panelArmyList1.Size = new System.Drawing.Size(950, 960);
            this.panelArmyList1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(751, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "New Army";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Page_BuildMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelArmyList1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBack);
            this.Name = "Page_BuildMenu";
            this.Size = new System.Drawing.Size(1900, 1060);
            this.Load += new System.EventHandler(this.PageBuildMenu_Load);
            this.VisibleChanged += new System.EventHandler(this.BuildMenuVisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonBack;
        private Label label1;
        public Buttons.PanelArmyList panelArmyList1;
        private Button button1;
    }
}
