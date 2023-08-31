namespace WebTestGui
{
    partial class MaximizeWindowOnStartOption
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
            this.mainLabel = new System.Windows.Forms.Label();
            this.mainCheckbox = new System.Windows.Forms.CheckBox();
            this.subLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.mainLabel.ForeColor = System.Drawing.Color.White;
            this.mainLabel.Location = new System.Drawing.Point(3, 2);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(176, 25);
            this.mainLabel.TabIndex = 10;
            this.mainLabel.Text = "Ablak maximalizálás";
            // 
            // mainCheckbox
            // 
            this.mainCheckbox.AutoSize = true;
            this.mainCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.mainCheckbox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainCheckbox.ForeColor = System.Drawing.Color.Silver;
            this.mainCheckbox.Location = new System.Drawing.Point(139, 55);
            this.mainCheckbox.Name = "mainCheckbox";
            this.mainCheckbox.Size = new System.Drawing.Size(73, 29);
            this.mainCheckbox.TabIndex = 49;
            this.mainCheckbox.Text = "Nem";
            this.mainCheckbox.UseVisualStyleBackColor = false;
            // 
            // subLabel
            // 
            this.subLabel.AutoSize = true;
            this.subLabel.BackColor = System.Drawing.Color.Transparent;
            this.subLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.subLabel.ForeColor = System.Drawing.Color.White;
            this.subLabel.Location = new System.Drawing.Point(81, 58);
            this.subLabel.Name = "subLabel";
            this.subLabel.Size = new System.Drawing.Size(52, 21);
            this.subLabel.TabIndex = 50;
            this.subLabel.Text = "Aktív:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(19, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Böngésző ablak automatikus maximálázása indításkor.";
            // 
            // MaximizeWindowOnStartOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.subLabel);
            this.Controls.Add(this.mainCheckbox);
            this.Controls.Add(this.mainLabel);
            this.Name = "MaximizeWindowOnStartOption";
            this.Size = new System.Drawing.Size(295, 96);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label mainLabel;
        private CheckBox mainCheckbox;
        private Label subLabel;
        protected Label label4;
    }
}
