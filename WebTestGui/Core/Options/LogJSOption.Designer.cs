namespace WebTestGui
{
    partial class LogJSOption
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
            refreshRateTextBox = new TextBox();
            timeoutTextBox = new TextBox();
            hintLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            mainCheckbox = new CheckBox();
            subLabel = new Label();
            label4 = new Label();
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
            mainLabel.Size = new Size(172, 25);
            mainLabel.TabIndex = 10;
            mainLabel.Text = "JavaScript logolása:";
            // 
            // refreshRateTextBox
            // 
            refreshRateTextBox.BackColor = Color.FromArgb(40, 40, 43);
            refreshRateTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            refreshRateTextBox.ForeColor = Color.DarkGray;
            refreshRateTextBox.Location = new Point(74, 101);
            refreshRateTextBox.Name = "refreshRateTextBox";
            refreshRateTextBox.PlaceholderText = "Mennyiség miliszekundumban...";
            refreshRateTextBox.Size = new Size(184, 22);
            refreshRateTextBox.TabIndex = 11;
            refreshRateTextBox.Text = "1000";
            // 
            // timeoutTextBox
            // 
            timeoutTextBox.BackColor = Color.FromArgb(40, 40, 43);
            timeoutTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            timeoutTextBox.ForeColor = Color.DarkGray;
            timeoutTextBox.Location = new Point(74, 146);
            timeoutTextBox.Name = "timeoutTextBox";
            timeoutTextBox.PlaceholderText = "Mennyiség miliszekundumban...";
            timeoutTextBox.Size = new Size(184, 22);
            timeoutTextBox.TabIndex = 12;
            timeoutTextBox.Text = "1000";
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.BackColor = Color.Transparent;
            hintLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            hintLabel.ForeColor = Color.Silver;
            hintLabel.Location = new Point(27, 79);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(139, 19);
            hintLabel.TabIndex = 45;
            hintLabel.Text = "Frissítési gyakoriság:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(27, 124);
            label1.Name = "label1";
            label1.Size = new Size(81, 19);
            label1.TabIndex = 46;
            label1.Text = "Időtúllépés:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(258, 104);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 47;
            label2.Text = "ms";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(258, 148);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 48;
            label3.Text = "ms";
            // 
            // mainCheckbox
            // 
            mainCheckbox.AutoSize = true;
            mainCheckbox.BackColor = Color.Transparent;
            mainCheckbox.Checked = true;
            mainCheckbox.CheckState = CheckState.Checked;
            mainCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            mainCheckbox.ForeColor = Color.Silver;
            mainCheckbox.Location = new Point(61, 50);
            mainCheckbox.Name = "mainCheckbox";
            mainCheckbox.Size = new Size(63, 25);
            mainCheckbox.TabIndex = 49;
            mainCheckbox.Text = "Igen";
            mainCheckbox.UseVisualStyleBackColor = false;
            mainCheckbox.CheckedChanged += mainCheckbox_CheckedChanged;
            // 
            // subLabel
            // 
            subLabel.AutoSize = true;
            subLabel.BackColor = Color.Transparent;
            subLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            subLabel.ForeColor = Color.White;
            subLabel.Location = new Point(3, 51);
            subLabel.Name = "subLabel";
            subLabel.Size = new Size(52, 21);
            subLabel.TabIndex = 50;
            subLabel.Text = "Aktív:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(27, 27);
            label4.Name = "label4";
            label4.Size = new Size(202, 12);
            label4.TabIndex = 51;
            label4.Text = "Beállítja a vezérlőjének a JavaScript logolását.";
            // 
            // LogJSOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(label4);
            Controls.Add(subLabel);
            Controls.Add(mainCheckbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hintLabel);
            Controls.Add(timeoutTextBox);
            Controls.Add(refreshRateTextBox);
            Controls.Add(mainLabel);
            Name = "LogJSOption";
            Size = new Size(295, 178);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        private TextBox refreshRateTextBox;
        private TextBox timeoutTextBox;
        private Label hintLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox mainCheckbox;
        private Label subLabel;
        protected Label label4;
    }
}
