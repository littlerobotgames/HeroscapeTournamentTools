namespace Heroscape_Collection_Maker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCardlist = new System.Windows.Forms.Panel();
            this.textBoxCollectionName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelCardlist
            // 
            this.panelCardlist.AutoScroll = true;
            this.panelCardlist.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelCardlist.Location = new System.Drawing.Point(16, 140);
            this.panelCardlist.Name = "panelCardlist";
            this.panelCardlist.Size = new System.Drawing.Size(602, 857);
            this.panelCardlist.TabIndex = 0;
            // 
            // textBoxCollectionName
            // 
            this.textBoxCollectionName.Location = new System.Drawing.Point(16, 43);
            this.textBoxCollectionName.Name = "textBoxCollectionName";
            this.textBoxCollectionName.Size = new System.Drawing.Size(602, 39);
            this.textBoxCollectionName.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(172, 88);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 46);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSaveClick);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(16, 88);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(150, 46);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.LoadClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 1009);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCollectionName);
            this.Controls.Add(this.panelCardlist);
            this.Name = "Form1";
            this.Text = "Heroscape Collection Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelCardlist;
        private TextBox textBoxCollectionName;
        private Button buttonSave;
        private Button buttonLoad;
    }
}