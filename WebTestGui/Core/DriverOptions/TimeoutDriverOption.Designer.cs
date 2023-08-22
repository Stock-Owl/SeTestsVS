namespace WebTestGui
{
    partial class TimeoutDriverOption
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
            timeoutTextBox = new TextBox();
            hintLabel = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            mainComboBox = new ComboBox();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(3, 2);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(162, 25);
            mainLabel.TabIndex = 10;
            mainLabel.Text = "Driver időtúllépés";
            // 
            // timeoutTextBox
            // 
            timeoutTextBox.BackColor = Color.FromArgb(40, 40, 43);
            timeoutTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            timeoutTextBox.ForeColor = Color.DarkGray;
            timeoutTextBox.Location = new Point(67, 116);
            timeoutTextBox.Name = "timeoutTextBox";
            timeoutTextBox.PlaceholderText = "Mennyiség miliszekundumban...";
            timeoutTextBox.Size = new Size(184, 22);
            timeoutTextBox.TabIndex = 12;
            timeoutTextBox.Text = "300000";
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.BackColor = Color.Transparent;
            hintLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            hintLabel.ForeColor = Color.Silver;
            hintLabel.Location = new Point(20, 49);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(120, 19);
            hintLabel.TabIndex = 45;
            hintLabel.Text = "Időtúllépésí típus:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(20, 94);
            label1.Name = "label1";
            label1.Size = new Size(123, 19);
            label1.TabIndex = 46;
            label1.Text = "Időtúllépés értéke:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(251, 118);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 48;
            label3.Text = "ms";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(27, 27);
            label4.Name = "label4";
            label4.Size = new Size(212, 12);
            label4.TabIndex = 51;
            label4.Text = "Betöltésekkor előforduló időtúllépések kezelése.";
            // 
            // mainComboBox
            // 
            mainComboBox.BackColor = Color.FromArgb(40, 40, 43);
            mainComboBox.FlatStyle = FlatStyle.Popup;
            mainComboBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            mainComboBox.ForeColor = Color.DarkGray;
            mainComboBox.FormattingEnabled = true;
            mainComboBox.Items.AddRange(new object[] { "pageLoad", "script", "implicit" });
            mainComboBox.Location = new Point(67, 71);
            mainComboBox.Name = "mainComboBox";
            mainComboBox.Size = new Size(184, 21);
            mainComboBox.TabIndex = 52;
            mainComboBox.Text = "pageLoad";
            mainComboBox.SelectedIndexChanged += mainComboBox_SelectedIndexChanged;
            // 
            // TimeoutDriverOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(mainComboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(hintLabel);
            Controls.Add(timeoutTextBox);
            Controls.Add(mainLabel);
            Name = "TimeoutDriverOption";
            Size = new Size(295, 141);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        private TextBox timeoutTextBox;
        private Label hintLabel;
        private Label label1;
        private Label label3;
        protected Label label4;
        private ComboBox mainComboBox;
    }
}
