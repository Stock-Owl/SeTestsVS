namespace WebTestGui
{
    partial class LogJSRetryTimeoutOption
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
            label1 = new Label();
            label3 = new Label();
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
            // timeoutTextBox
            // 
            timeoutTextBox.BackColor = Color.FromArgb(40, 40, 43);
            timeoutTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            timeoutTextBox.ForeColor = Color.DarkGray;
            timeoutTextBox.Location = new Point(58, 71);
            timeoutTextBox.Name = "timeoutTextBox";
            timeoutTextBox.PlaceholderText = "Mennyiség miliszekundumban...";
            timeoutTextBox.Size = new Size(184, 22);
            timeoutTextBox.TabIndex = 12;
            timeoutTextBox.Text = "1000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(11, 49);
            label1.Name = "label1";
            label1.Size = new Size(81, 19);
            label1.TabIndex = 46;
            label1.Text = "Időtúllépés:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(242, 73);
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
            label4.Size = new Size(202, 12);
            label4.TabIndex = 51;
            label4.Text = "Beállítja a vezérlőjének a JavaScript logolását.";
            // 
            // LogJSRetryTimeoutOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(timeoutTextBox);
            Controls.Add(mainLabel);
            Name = "LogJSRetryTimeoutOption";
            Size = new Size(278, 106);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        private TextBox timeoutTextBox;
        private Label label1;
        private Label label3;
        protected Label label4;
    }
}
