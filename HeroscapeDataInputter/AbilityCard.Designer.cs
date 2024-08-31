namespace HeroscapeDataInputter
{
    partial class AbilityCard
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
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.button_x = new System.Windows.Forms.Button();
            this.labelNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_name.Location = new System.Drawing.Point(67, 38);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(428, 29);
            this.textBox_name.TabIndex = 0;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_ab_name_changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(67, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // textBox_description
            // 
            this.textBox_description.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_description.Location = new System.Drawing.Point(3, 99);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_description.Size = new System.Drawing.Size(544, 100);
            this.textBox_description.TabIndex = 3;
            this.textBox_description.TextChanged += new System.EventHandler(this.textBox_ab_desc_changed);
            // 
            // button_x
            // 
            this.button_x.BackColor = System.Drawing.Color.Transparent;
            this.button_x.Location = new System.Drawing.Point(501, 25);
            this.button_x.Name = "button_x";
            this.button_x.Size = new System.Drawing.Size(46, 46);
            this.button_x.TabIndex = 4;
            this.button_x.Text = "X";
            this.button_x.UseVisualStyleBackColor = false;
            this.button_x.Click += new System.EventHandler(this.button_x_clicked);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.ForeColor = System.Drawing.Color.Silver;
            this.labelNumber.Location = new System.Drawing.Point(16, 21);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(27, 32);
            this.labelNumber.TabIndex = 5;
            this.labelNumber.Text = "0";
            // 
            // AbilityCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.button_x);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_name);
            this.Name = "AbilityCard";
            this.Size = new System.Drawing.Size(550, 210);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox_name;
        private Label label1;
        private Label label2;
        private TextBox textBox_description;
        private Button button_x;
        private Label labelNumber;
    }
}
