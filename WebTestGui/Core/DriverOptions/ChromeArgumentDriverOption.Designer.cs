namespace WebTestGui
{
    partial class ChromeArgumentDriverOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChromeArgumentDriverOption));
            mainLabel = new Label();
            label4 = new Label();
            paramTextBox = new TextBox();
            hintLabel = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(1, 4);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(241, 21);
            mainLabel.TabIndex = 10;
            mainLabel.Text = "Chrome böngésző paraméterek";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(8, 29);
            label4.Name = "label4";
            label4.Size = new Size(285, 13);
            label4.TabIndex = 51;
            label4.Text = "Chrome böngésző elindításakor átadott extra paraméterek.";
            // 
            // paramTextBox
            // 
            paramTextBox.BackColor = Color.FromArgb(40, 40, 43);
            paramTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            paramTextBox.ForeColor = Color.DarkGray;
            paramTextBox.Location = new Point(44, 79);
            paramTextBox.Name = "paramTextBox";
            paramTextBox.PlaceholderText = "Extra böngésző paraméterek...";
            paramTextBox.Size = new Size(248, 25);
            paramTextBox.TabIndex = 52;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.BackColor = Color.Transparent;
            hintLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            hintLabel.ForeColor = Color.Silver;
            hintLabel.Location = new Point(3, 57);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(146, 20);
            hintLabel.TabIndex = 53;
            hintLabel.Text = "Paraméterek: (args)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(40, 40, 43);
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(44, 107);
            label1.Name = "label1";
            label1.Size = new Size(107, 13);
            label1.TabIndex = 54;
            label1.Text = "Szóközzel elválasztva";
            label1.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(267, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 55;
            pictureBox1.TabStop = false;
            // 
            // ChromeArgumentDriverOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(hintLabel);
            Controls.Add(paramTextBox);
            Controls.Add(label4);
            Controls.Add(mainLabel);
            Name = "ChromeArgumentDriverOption";
            Size = new Size(295, 139);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        protected Label label4;
        private TextBox paramTextBox;
        private Label hintLabel;
        private Label label1;
        private PictureBox pictureBox1;
    }
}
