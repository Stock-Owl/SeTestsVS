namespace WebTestGui
{
    partial class KeepBrowserOpenDriverOption
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
            mainLabel = new Label();
            label4 = new Label();
            mainCheckbox = new CheckBox();
            subLabel = new Label();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(3, 2);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(169, 21);
            mainLabel.TabIndex = 10;
            mainLabel.Text = "Böngésző terminálása";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(5, 25);
            label4.Name = "label4";
            label4.Size = new Size(272, 13);
            label4.TabIndex = 51;
            label4.Text = "A teszt elvégzése után a böngészőt bezárja-e a program.";
            // 
            // mainCheckbox
            // 
            mainCheckbox.AutoSize = true;
            mainCheckbox.BackColor = Color.Transparent;
            mainCheckbox.Checked = true;
            mainCheckbox.CheckState = CheckState.Checked;
            mainCheckbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            mainCheckbox.ForeColor = Color.Silver;
            mainCheckbox.Location = new Point(181, 66);
            mainCheckbox.Name = "mainCheckbox";
            mainCheckbox.Size = new Size(57, 23);
            mainCheckbox.TabIndex = 52;
            mainCheckbox.Text = "Igen";
            mainCheckbox.UseVisualStyleBackColor = false;
            mainCheckbox.CheckedChanged += mainCheckbox_CheckedChanged;
            // 
            // subLabel
            // 
            subLabel.BackColor = Color.Transparent;
            subLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            subLabel.ForeColor = Color.White;
            subLabel.Location = new Point(35, 51);
            subLabel.Name = "subLabel";
            subLabel.Size = new Size(200, 35);
            subLabel.TabIndex = 53;
            subLabel.Text = "Sikeres teszt esetén a megnyitott\r\nböngész(ők) megtartása:";
            // 
            // KeepBrowserOpenDriverOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(mainCheckbox);
            Controls.Add(label4);
            Controls.Add(mainLabel);
            Controls.Add(subLabel);
            Name = "KeepBrowserOpenDriverOption";
            Size = new Size(295, 99);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        protected Label label4;
        private CheckBox mainCheckbox;
        private Label subLabel;
    }
}
