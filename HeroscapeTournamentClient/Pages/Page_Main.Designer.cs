namespace HeroscapeTournamentClient.Pages
{
    partial class Page_Main
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonMenu_Browse = new HeroscapeTournamentClient.Pages.ButtonMenu(this);
            this.buttonMenu_Build = new HeroscapeTournamentClient.Pages.ButtonMenu(this);
            this.buttonMenu_Join = new HeroscapeTournamentClient.Pages.ButtonMenu(this);
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("HelveticaNeue MediumCond", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUsername.Location = new System.Drawing.Point(22, 24);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(210, 56);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            this.labelUsername.VisibleChanged += new System.EventHandler(this.PageMain_VisibleChanged);
            // 
            // buttonMenu_Browse
            // 
            this.buttonMenu_Browse.Location = new System.Drawing.Point(48, 727);
            this.buttonMenu_Browse.Name = "buttonMenu_Browse";
            this.buttonMenu_Browse.Size = new System.Drawing.Size(900, 150);
            this.buttonMenu_Browse.TabIndex = 1;
            // 
            // buttonMenu_Build
            // 
            this.buttonMenu_Build.Location = new System.Drawing.Point(48, 501);
            this.buttonMenu_Build.Name = "buttonMenu_Build";
            this.buttonMenu_Build.Size = new System.Drawing.Size(900, 150);
            this.buttonMenu_Build.TabIndex = 2;
            // 
            // buttonMenu_Join
            // 
            this.buttonMenu_Join.Location = new System.Drawing.Point(48, 265);
            this.buttonMenu_Join.Name = "buttonMenu_Join";
            this.buttonMenu_Join.Size = new System.Drawing.Size(900, 150);
            this.buttonMenu_Join.TabIndex = 3;
            // 
            // Page_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonMenu_Join);
            this.Controls.Add(this.buttonMenu_Build);
            this.Controls.Add(this.buttonMenu_Browse);
            this.Controls.Add(this.labelUsername);
            this.Name = "Page_Main";
            this.Size = new System.Drawing.Size(1900, 1060);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label labelUsername;
        private ButtonMenu buttonMenu_Browse;
        private ButtonMenu buttonMenu_Build;
        private ButtonMenu buttonMenu_Join;
    }
}
