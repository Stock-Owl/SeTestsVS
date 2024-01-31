namespace WebTestGui
{
    partial class LoadedWaitForCondition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadedWaitForCondition));
            mainLabel = new Label();
            locatorTextBox = new ComboBox();
            valueLabel = new Label();
            locatorLabel = new Label();
            valueTextBox = new TextBox();
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
            mainLabel.Location = new Point(5, 4);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(65, 21);
            mainLabel.TabIndex = 12;
            mainLabel.Text = "Loaded";
            // 
            // locatorTextBox
            // 
            locatorTextBox.BackColor = Color.FromArgb(40, 40, 43);
            locatorTextBox.FlatStyle = FlatStyle.Popup;
            locatorTextBox.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            locatorTextBox.ForeColor = Color.DarkGray;
            locatorTextBox.FormattingEnabled = true;
            locatorTextBox.Items.AddRange(new object[] { "xpath", "css_selector" });
            locatorTextBox.Location = new Point(168, 5);
            locatorTextBox.Name = "locatorTextBox";
            locatorTextBox.Size = new Size(91, 20);
            locatorTextBox.TabIndex = 83;
            locatorTextBox.Text = "xpath";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.BackColor = Color.Transparent;
            valueLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            valueLabel.ForeColor = Color.White;
            valueLabel.Location = new Point(89, 35);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(36, 13);
            valueLabel.TabIndex = 82;
            valueLabel.Text = "Érték:";
            // 
            // locatorLabel
            // 
            locatorLabel.AutoSize = true;
            locatorLabel.BackColor = Color.Transparent;
            locatorLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            locatorLabel.ForeColor = Color.White;
            locatorLabel.Location = new Point(114, 9);
            locatorLabel.Name = "locatorLabel";
            locatorLabel.Size = new Size(49, 13);
            locatorLabel.TabIndex = 81;
            locatorLabel.Text = "Lokátor:";
            // 
            // valueTextBox
            // 
            valueTextBox.BackColor = Color.FromArgb(40, 40, 43);
            valueTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            valueTextBox.ForeColor = Color.DarkGray;
            valueTextBox.Location = new Point(130, 31);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.PlaceholderText = "Érték...";
            valueTextBox.Size = new Size(129, 22);
            valueTextBox.TabIndex = 80;
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(5, 35);
            binImage.Name = "binImage";
            binImage.Size = new Size(20, 20);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 84;
            binImage.TabStop = false;
            binImage.Click += binImage_Click;
            // 
            // LoadedWaitForCondition
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(binImage);
            Controls.Add(locatorTextBox);
            Controls.Add(valueLabel);
            Controls.Add(locatorLabel);
            Controls.Add(valueTextBox);
            Controls.Add(mainLabel);
            Name = "LoadedWaitForCondition";
            Size = new Size(274, 60);
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label mainLabel;
        private ComboBox locatorTextBox;
        protected Label valueLabel;
        protected Label locatorLabel;
        private TextBox valueTextBox;
        private PictureBox binImage;
    }
}
