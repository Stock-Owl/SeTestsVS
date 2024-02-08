namespace WebTestGui
{
    partial class Url_ContainsWaitForCondition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Url_ContainsWaitForCondition));
            mainLabel = new Label();
            urlLabel = new Label();
            urlTextBox = new TextBox();
            binImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(9, 9);
            mainLabel.Margin = new Padding(6, 0, 6, 0);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(199, 45);
            mainLabel.TabIndex = 12;
            mainLabel.Text = "Url_contains";
            // 
            // urlLabel
            // 
            urlLabel.AutoSize = true;
            urlLabel.BackColor = Color.Transparent;
            urlLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            urlLabel.ForeColor = Color.White;
            urlLabel.Location = new Point(94, 75);
            urlLabel.Margin = new Padding(6, 0, 6, 0);
            urlLabel.Name = "urlLabel";
            urlLabel.Size = new Size(46, 30);
            urlLabel.TabIndex = 82;
            urlLabel.Text = "Url:";
            // 
            // urlTextBox
            // 
            urlTextBox.BackColor = Color.FromArgb(40, 40, 43);
            urlTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            urlTextBox.ForeColor = Color.DarkGray;
            urlTextBox.Location = new Point(158, 73);
            urlTextBox.Margin = new Padding(6);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.PlaceholderText = "Url címe része..";
            urlTextBox.Size = new Size(320, 36);
            urlTextBox.TabIndex = 80;
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(9, 75);
            binImage.Margin = new Padding(6);
            binImage.Name = "binImage";
            binImage.Size = new Size(37, 43);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 84;
            binImage.TabStop = false;
            binImage.Click += binImage_Click;
            // 
            // Url_ContainsWaitForCondition
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(binImage);
            Controls.Add(urlLabel);
            Controls.Add(urlTextBox);
            Controls.Add(mainLabel);
            Margin = new Padding(6);
            Name = "Url_ContainsWaitForCondition";
            Size = new Size(509, 128);
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label mainLabel;
        protected Label urlLabel;
        private TextBox urlTextBox;
        private PictureBox binImage;
    }
}
