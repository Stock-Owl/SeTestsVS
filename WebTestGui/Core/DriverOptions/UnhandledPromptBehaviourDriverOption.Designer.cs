namespace WebTestGui
{
    partial class UnhandledPromptBehaviourDriverOption
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
            mainLabel.Size = new Size(180, 25);
            mainLabel.TabIndex = 10;
            mainLabel.Text = "Kezeletlen kérelmek";
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(19, 27);
            label4.Name = "label4";
            label4.Size = new Size(285, 28);
            label4.TabIndex = 51;
            label4.Text = "A web-illesztőprogram hogyan kezeli a felugró,\r\nnem kezelt kérelmeket.";
            // 
            // mainComboBox
            // 
            mainComboBox.BackColor = Color.FromArgb(40, 40, 43);
            mainComboBox.FlatStyle = FlatStyle.Popup;
            mainComboBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            mainComboBox.ForeColor = Color.DarkGray;
            mainComboBox.FormattingEnabled = true;
            mainComboBox.Items.AddRange(new object[] { "dismiss", "accept", "dismiss and notify", "accept and notify", "ignore" });
            mainComboBox.Location = new Point(39, 58);
            mainComboBox.Name = "mainComboBox";
            mainComboBox.Size = new Size(221, 29);
            mainComboBox.TabIndex = 52;
            mainComboBox.Text = "dismiss and notify";
            // 
            // UnhandledPromptBehaviourDriverOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(mainComboBox);
            Controls.Add(label4);
            Controls.Add(mainLabel);
            Name = "UnhandledPromptBehaviourDriverOption";
            Size = new Size(295, 99);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        protected Label label4;
        private ComboBox mainComboBox;
    }
}
