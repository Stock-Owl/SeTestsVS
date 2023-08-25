namespace WebTestGui
{
    partial class AutoExitIFramesOption
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
            mainLabel.Size = new Size(174, 25);
            mainLabel.TabIndex = 10;
            mainLabel.Text = "Auto iframe kilépés";
            // 
            // mainCheckbox
            // 
            mainCheckbox.AutoSize = true;
            mainCheckbox.BackColor = Color.Transparent;
            mainCheckbox.Checked = true;
            mainCheckbox.CheckState = CheckState.Checked;
            mainCheckbox.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            mainCheckbox.ForeColor = Color.Silver;
            mainCheckbox.Location = new Point(139, 55);
            mainCheckbox.Name = "mainCheckbox";
            mainCheckbox.Size = new Size(71, 29);
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
            subLabel.Location = new Point(81, 58);
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
            label4.Location = new Point(19, 29);
            label4.Name = "label4";
            label4.Size = new Size(273, 12);
            label4.TabIndex = 51;
            label4.Text = "Action végrehajtások után automatikusan kilép az iFrame-ből";
            // 
            // AutoExitIFramesOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(label4);
            Controls.Add(subLabel);
            Controls.Add(mainCheckbox);
            Controls.Add(mainLabel);
            Name = "AutoExitIFramesOption";
            Size = new Size(295, 96);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        private CheckBox mainCheckbox;
        private Label subLabel;
        protected Label label4;
    }
}
