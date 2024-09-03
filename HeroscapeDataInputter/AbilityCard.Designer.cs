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
            textBox_name = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox_description = new TextBox();
            button_x = new Button();
            labelNumber = new Label();
            SuspendLayout();
            // 
            // textBox_name
            // 
            textBox_name.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_name.Location = new Point(19, 23);
            textBox_name.Margin = new Padding(2, 1, 2, 1);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(275, 23);
            textBox_name.TabIndex = 0;
            textBox_name.TextChanged += textBox_ab_name_changed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(19, 7);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(2, 47);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Description";
            // 
            // textBox_description
            // 
            textBox_description.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_description.Location = new Point(2, 63);
            textBox_description.Margin = new Padding(2, 1, 2, 1);
            textBox_description.Multiline = true;
            textBox_description.Name = "textBox_description";
            textBox_description.ScrollBars = ScrollBars.Vertical;
            textBox_description.Size = new Size(292, 72);
            textBox_description.TabIndex = 3;
            textBox_description.TextChanged += textBox_ab_desc_changed;
            // 
            // button_x
            // 
            button_x.BackColor = Color.Transparent;
            button_x.Location = new Point(269, 0);
            button_x.Margin = new Padding(2, 1, 2, 1);
            button_x.Name = "button_x";
            button_x.Size = new Size(25, 22);
            button_x.TabIndex = 4;
            button_x.Text = "X";
            button_x.UseVisualStyleBackColor = false;
            button_x.Click += button_x_clicked;
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.ForeColor = Color.Silver;
            labelNumber.Location = new Point(2, 7);
            labelNumber.Margin = new Padding(2, 0, 2, 0);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(13, 15);
            labelNumber.TabIndex = 5;
            labelNumber.Text = "0";
            // 
            // AbilityCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(labelNumber);
            Controls.Add(button_x);
            Controls.Add(textBox_description);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_name);
            Margin = new Padding(2, 1, 2, 1);
            Name = "AbilityCard";
            Size = new Size(296, 140);
            ResumeLayout(false);
            PerformLayout();
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
