namespace WebTestGui
{
    partial class SwitchToAction
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
        protected void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwitchToAction));
            breakpointOnPicture = new PictureBox();
            breakpointOffPicture = new PictureBox();
            mainLabel = new Label();
            binImage = new PictureBox();
            idTextBox = new TextBox();
            mainPanel = new Panel();
            testRunTimeText = new Label();
            testRunTimeLabel = new Label();
            locatorTextBox = new ComboBox();
            valueLabel = new Label();
            locatorLabel = new Label();
            valueTextBox = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)breakpointOnPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOffPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // breakpointOnPicture
            // 
            breakpointOnPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            breakpointOnPicture.Image = Properties.Resources.BreakpointOnIcon;
            breakpointOnPicture.Location = new Point(636, 41);
            breakpointOnPicture.Name = "breakpointOnPicture";
            breakpointOnPicture.Size = new Size(25, 25);
            breakpointOnPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointOnPicture.TabIndex = 40;
            breakpointOnPicture.TabStop = false;
            breakpointOnPicture.Click += breakpointOnPicture_Click;
            // 
            // breakpointOffPicture
            // 
            breakpointOffPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            breakpointOffPicture.Image = (Image)resources.GetObject("breakpointOffPicture.Image");
            breakpointOffPicture.Location = new Point(636, 41);
            breakpointOffPicture.Name = "breakpointOffPicture";
            breakpointOffPicture.Size = new Size(25, 25);
            breakpointOffPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointOffPicture.TabIndex = 41;
            breakpointOffPicture.TabStop = false;
            breakpointOffPicture.Click += breakpointOffPicture_Click;
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(5, 4);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(91, 25);
            mainLabel.TabIndex = 11;
            mainLabel.Text = "Switch-to";
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(672, 36);
            binImage.Name = "binImage";
            binImage.Size = new Size(35, 35);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 37;
            binImage.TabStop = false;
            binImage.Click += binImage_Click;
            // 
            // idTextBox
            // 
            idTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            idTextBox.BackColor = Color.FromArgb(40, 40, 43);
            idTextBox.BorderStyle = BorderStyle.FixedSingle;
            idTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(672, 7);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(35, 25);
            idTextBox.TabIndex = 38;
            idTextBox.Text = "0";
            idTextBox.Leave += OnUIdTextBoxFocusLeave;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 45, 50);
            mainPanel.Controls.Add(pictureBox1);
            mainPanel.Controls.Add(testRunTimeText);
            mainPanel.Controls.Add(testRunTimeLabel);
            mainPanel.Controls.Add(locatorTextBox);
            mainPanel.Controls.Add(valueLabel);
            mainPanel.Controls.Add(locatorLabel);
            mainPanel.Controls.Add(valueTextBox);
            mainPanel.Controls.Add(idTextBox);
            mainPanel.Controls.Add(binImage);
            mainPanel.Controls.Add(mainLabel);
            mainPanel.Controls.Add(breakpointOffPicture);
            mainPanel.Controls.Add(breakpointOnPicture);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(717, 75);
            mainPanel.TabIndex = 12;
            // 
            // testRunTimeText
            // 
            testRunTimeText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(160, 59);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(48, 15);
            testRunTimeText.TabIndex = 81;
            testRunTimeText.Text = "0 / 0 ms";
            // 
            // testRunTimeLabel
            // 
            testRunTimeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testRunTimeLabel.AutoSize = true;
            testRunTimeLabel.BackColor = Color.Transparent;
            testRunTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeLabel.ForeColor = Color.Gray;
            testRunTimeLabel.Location = new Point(3, 59);
            testRunTimeLabel.Name = "testRunTimeLabel";
            testRunTimeLabel.Size = new Size(157, 15);
            testRunTimeLabel.TabIndex = 80;
            testRunTimeLabel.Text = "Előző tesztelésen futási ideje:";
            // 
            // locatorTextBox
            // 
            locatorTextBox.BackColor = Color.FromArgb(40, 40, 43);
            locatorTextBox.FlatStyle = FlatStyle.Popup;
            locatorTextBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            locatorTextBox.ForeColor = Color.DarkGray;
            locatorTextBox.FormattingEnabled = true;
            locatorTextBox.Items.AddRange(new object[] { "xpath", "css_selector" });
            locatorTextBox.Location = new Point(196, 14);
            locatorTextBox.Name = "locatorTextBox";
            locatorTextBox.Size = new Size(192, 21);
            locatorTextBox.TabIndex = 79;
            locatorTextBox.Text = "xpath";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.BackColor = Color.Transparent;
            valueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            valueLabel.ForeColor = Color.White;
            valueLabel.Location = new Point(401, 13);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(48, 21);
            valueLabel.TabIndex = 78;
            valueLabel.Text = "Érték:";
            // 
            // locatorLabel
            // 
            locatorLabel.AutoSize = true;
            locatorLabel.BackColor = Color.Transparent;
            locatorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            locatorLabel.ForeColor = Color.White;
            locatorLabel.Location = new Point(124, 14);
            locatorLabel.Name = "locatorLabel";
            locatorLabel.Size = new Size(66, 21);
            locatorLabel.TabIndex = 77;
            locatorLabel.Text = "Lokátor:";
            // 
            // valueTextBox
            // 
            valueTextBox.BackColor = Color.FromArgb(40, 40, 43);
            valueTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            valueTextBox.ForeColor = Color.DarkGray;
            valueTextBox.Location = new Point(473, 13);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.PlaceholderText = "Érték...";
            valueTextBox.Size = new Size(192, 22);
            valueTextBox.TabIndex = 76;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(11, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 82;
            pictureBox1.TabStop = false;
            // 
            // SwitchToAction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(mainPanel);
            Name = "SwitchToAction";
            Size = new Size(717, 75);
            ((System.ComponentModel.ISupportInitialize)breakpointOnPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOffPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox breakpointOnPicture;
        private PictureBox breakpointOffPicture;
        protected Label mainLabel;
        private PictureBox binImage;
        private TextBox idTextBox;
        private Panel mainPanel;
        protected Label valueLabel;
        protected Label locatorLabel;
        private TextBox valueTextBox;
        private ComboBox locatorTextBox;
        protected Label testRunTimeText;
        protected Label testRunTimeLabel;
        private PictureBox pictureBox1;
    }
}
