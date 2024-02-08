namespace WebTestGui
{
    partial class Title_IsWaitForCondition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Title_IsWaitForCondition));
            mainLabel = new Label();
            valueLabel = new Label();
            valueTextBox = new TextBox();
            binImage = new PictureBox();
            caseSensitiveLabel = new Label();
            caseSensitiveCheckbox = new CheckBox();
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
            mainLabel.Size = new Size(118, 45);
            mainLabel.TabIndex = 12;
            mainLabel.Text = "Title_is";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.BackColor = Color.Transparent;
            valueLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            valueLabel.ForeColor = Color.White;
            valueLabel.Location = new Point(83, 75);
            valueLabel.Margin = new Padding(6, 0, 6, 0);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(67, 30);
            valueLabel.TabIndex = 82;
            valueLabel.Text = "Érték:";
            // 
            // valueTextBox
            // 
            valueTextBox.BackColor = Color.FromArgb(40, 40, 43);
            valueTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            valueTextBox.ForeColor = Color.DarkGray;
            valueTextBox.Location = new Point(158, 73);
            valueTextBox.Margin = new Padding(6);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.PlaceholderText = "Érték...";
            valueTextBox.Size = new Size(320, 36);
            valueTextBox.TabIndex = 80;
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
            // caseSensitiveLabel
            // 
            caseSensitiveLabel.AutoSize = true;
            caseSensitiveLabel.BackColor = Color.Transparent;
            caseSensitiveLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            caseSensitiveLabel.ForeColor = Color.White;
            caseSensitiveLabel.Location = new Point(205, 20);
            caseSensitiveLabel.Margin = new Padding(6, 0, 6, 0);
            caseSensitiveLabel.Name = "caseSensitiveLabel";
            caseSensitiveLabel.Size = new Size(239, 30);
            caseSensitiveLabel.TabIndex = 86;
            caseSensitiveLabel.Text = "Kis-nagybetű érzékeny:";
            // 
            // caseSensitiveCheckbox
            // 
            caseSensitiveCheckbox.AutoSize = true;
            caseSensitiveCheckbox.BackColor = Color.Transparent;
            caseSensitiveCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            caseSensitiveCheckbox.ForeColor = Color.Silver;
            caseSensitiveCheckbox.Location = new Point(451, 23);
            caseSensitiveCheckbox.Margin = new Padding(6);
            caseSensitiveCheckbox.Name = "caseSensitiveCheckbox";
            caseSensitiveCheckbox.Size = new Size(28, 27);
            caseSensitiveCheckbox.TabIndex = 85;
            caseSensitiveCheckbox.UseVisualStyleBackColor = false;
            // 
            // Title_IsWaitForCondition
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(caseSensitiveLabel);
            Controls.Add(caseSensitiveCheckbox);
            Controls.Add(binImage);
            Controls.Add(valueLabel);
            Controls.Add(valueTextBox);
            Controls.Add(mainLabel);
            Margin = new Padding(6);
            Name = "Title_IsWaitForCondition";
            Size = new Size(509, 128);
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label mainLabel;
        protected Label valueLabel;
        private TextBox valueTextBox;
        private PictureBox binImage;
        protected Label caseSensitiveLabel;
        private CheckBox caseSensitiveCheckbox;
    }
}
