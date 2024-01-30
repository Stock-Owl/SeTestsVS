namespace WebTestGui
{
    partial class WaitForAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForAction));
            breakpointOnPicture = new PictureBox();
            breakpointOffPicture = new PictureBox();
            mainLabel = new Label();
            binImage = new PictureBox();
            idTextBox = new TextBox();
            mainPanel = new Panel();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            logicModifierComboBox = new ComboBox();
            label2 = new Label();
            testRunTimeText = new Label();
            testRunTimeLabel = new Label();
            locatorTextBox = new ComboBox();
            valueLabel = new Label();
            locatorLabel = new Label();
            valueTextBox = new TextBox();
            timeOutTextBox = new TextBox();
            label5 = new Label();
            frequencyTextField = new TextBox();
            label4 = new Label();
            conditionComboBox = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)breakpointOnPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOffPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // breakpointOnPicture
            // 
            breakpointOnPicture.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            breakpointOnPicture.Image = Properties.Resources.BreakpointOnIcon;
            breakpointOnPicture.Location = new Point(818, 92);
            breakpointOnPicture.Name = "breakpointOnPicture";
            breakpointOnPicture.Size = new Size(20, 20);
            breakpointOnPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointOnPicture.TabIndex = 40;
            breakpointOnPicture.TabStop = false;
            breakpointOnPicture.Click += breakpointOnPicture_Click;
            // 
            // breakpointOffPicture
            // 
            breakpointOffPicture.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            breakpointOffPicture.Image = (Image)resources.GetObject("breakpointOffPicture.Image");
            breakpointOffPicture.Location = new Point(818, 92);
            breakpointOffPicture.Name = "breakpointOffPicture";
            breakpointOffPicture.Size = new Size(20, 20);
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
            mainLabel.Location = new Point(80, 25);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(87, 25);
            mainLabel.TabIndex = 11;
            mainLabel.Text = "Wait-For:";
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(844, 92);
            binImage.Name = "binImage";
            binImage.Size = new Size(20, 20);
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
            idTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(818, 9);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(46, 23);
            idTextBox.TabIndex = 38;
            idTextBox.Text = "0";
            idTextBox.Leave += OnUIdTextBoxFocusLeave;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 45, 50);
            mainPanel.Controls.Add(pictureBox1);
            mainPanel.Controls.Add(label6);
            mainPanel.Controls.Add(logicModifierComboBox);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(testRunTimeText);
            mainPanel.Controls.Add(testRunTimeLabel);
            mainPanel.Controls.Add(locatorTextBox);
            mainPanel.Controls.Add(valueLabel);
            mainPanel.Controls.Add(locatorLabel);
            mainPanel.Controls.Add(valueTextBox);
            mainPanel.Controls.Add(timeOutTextBox);
            mainPanel.Controls.Add(label5);
            mainPanel.Controls.Add(frequencyTextField);
            mainPanel.Controls.Add(label4);
            mainPanel.Controls.Add(conditionComboBox);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(idTextBox);
            mainPanel.Controls.Add(binImage);
            mainPanel.Controls.Add(mainLabel);
            mainPanel.Controls.Add(breakpointOffPicture);
            mainPanel.Controls.Add(breakpointOnPicture);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(870, 118);
            mainPanel.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 93;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(200, 10);
            label6.Name = "label6";
            label6.Size = new Size(139, 19);
            label6.TabIndex = 92;
            label6.Text = "Várakozási kondíció:";
            // 
            // logicModifierComboBox
            // 
            logicModifierComboBox.BackColor = Color.FromArgb(40, 40, 43);
            logicModifierComboBox.FlatStyle = FlatStyle.Popup;
            logicModifierComboBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            logicModifierComboBox.ForeColor = Color.DarkGray;
            logicModifierComboBox.FormattingEnabled = true;
            logicModifierComboBox.Items.AddRange(new object[] { "?", "!" });
            logicModifierComboBox.Location = new Point(705, 14);
            logicModifierComboBox.Name = "logicModifierComboBox";
            logicModifierComboBox.Size = new Size(76, 21);
            logicModifierComboBox.TabIndex = 91;
            logicModifierComboBox.Text = "?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(573, 16);
            label2.Name = "label2";
            label2.Size = new Size(112, 19);
            label2.TabIndex = 90;
            label2.Text = "Logikai kapcsoló:";
            // 
            // testRunTimeText
            // 
            testRunTimeText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(160, 100);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(48, 15);
            testRunTimeText.TabIndex = 89;
            testRunTimeText.Text = "0 / 0 ms";
            // 
            // testRunTimeLabel
            // 
            testRunTimeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testRunTimeLabel.AutoSize = true;
            testRunTimeLabel.BackColor = Color.Transparent;
            testRunTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeLabel.ForeColor = Color.Gray;
            testRunTimeLabel.Location = new Point(3, 100);
            testRunTimeLabel.Name = "testRunTimeLabel";
            testRunTimeLabel.Size = new Size(157, 15);
            testRunTimeLabel.TabIndex = 88;
            testRunTimeLabel.Text = "Előző tesztelésen futási ideje:";
            // 
            // locatorTextBox
            // 
            locatorTextBox.BackColor = Color.FromArgb(40, 40, 43);
            locatorTextBox.FlatStyle = FlatStyle.Popup;
            locatorTextBox.Font = new Font("Segoe UI Semibold", 6F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            locatorTextBox.ForeColor = Color.DarkGray;
            locatorTextBox.FormattingEnabled = true;
            locatorTextBox.Items.AddRange(new object[] { "xpath", "css_selector" });
            locatorTextBox.Location = new Point(283, 58);
            locatorTextBox.Name = "locatorTextBox";
            locatorTextBox.Size = new Size(192, 19);
            locatorTextBox.TabIndex = 87;
            locatorTextBox.Text = "xpath";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.BackColor = Color.Transparent;
            valueLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            valueLabel.ForeColor = Color.White;
            valueLabel.Location = new Point(219, 81);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(43, 19);
            valueLabel.TabIndex = 86;
            valueLabel.Text = "Érték:";
            // 
            // locatorLabel
            // 
            locatorLabel.AutoSize = true;
            locatorLabel.BackColor = Color.Transparent;
            locatorLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            locatorLabel.ForeColor = Color.White;
            locatorLabel.Location = new Point(219, 57);
            locatorLabel.Name = "locatorLabel";
            locatorLabel.Size = new Size(59, 19);
            locatorLabel.TabIndex = 85;
            locatorLabel.Text = "Lokátor:";
            // 
            // valueTextBox
            // 
            valueTextBox.BackColor = Color.FromArgb(40, 40, 43);
            valueTextBox.Font = new Font("Segoe UI", 6F, FontStyle.Italic, GraphicsUnit.Point);
            valueTextBox.ForeColor = Color.DarkGray;
            valueTextBox.Location = new Point(283, 83);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.PlaceholderText = "Érték...";
            valueTextBox.Size = new Size(192, 18);
            valueTextBox.TabIndex = 84;
            // 
            // timeOutTextBox
            // 
            timeOutTextBox.BackColor = Color.FromArgb(40, 40, 43);
            timeOutTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            timeOutTextBox.ForeColor = Color.DarkGray;
            timeOutTextBox.Location = new Point(611, 68);
            timeOutTextBox.Name = "timeOutTextBox";
            timeOutTextBox.PlaceholderText = "Időtúllépés értéke...";
            timeOutTextBox.Size = new Size(171, 23);
            timeOutTextBox.TabIndex = 58;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(510, 70);
            label5.Name = "label5";
            label5.Size = new Size(95, 15);
            label5.TabIndex = 57;
            label5.Text = "Időtúllépés (ms):";
            // 
            // frequencyTextField
            // 
            frequencyTextField.BackColor = Color.FromArgb(40, 40, 43);
            frequencyTextField.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            frequencyTextField.ForeColor = Color.DarkGray;
            frequencyTextField.Location = new Point(611, 41);
            frequencyTextField.Name = "frequencyTextField";
            frequencyTextField.PlaceholderText = "Várakozás gyakorisága...";
            frequencyTextField.Size = new Size(171, 23);
            frequencyTextField.TabIndex = 56;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(510, 46);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 55;
            label4.Text = "Gyakoriság (ms):";
            // 
            // conditionComboBox
            // 
            conditionComboBox.BackColor = Color.FromArgb(40, 40, 43);
            conditionComboBox.FlatStyle = FlatStyle.Popup;
            conditionComboBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            conditionComboBox.ForeColor = Color.DarkGray;
            conditionComboBox.FormattingEnabled = true;
            conditionComboBox.Location = new Point(343, 31);
            conditionComboBox.Name = "conditionComboBox";
            conditionComboBox.Size = new Size(132, 21);
            conditionComboBox.TabIndex = 54;
            conditionComboBox.Text = "loaded";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(219, 31);
            label3.Name = "label3";
            label3.Size = new Size(105, 19);
            label3.TabIndex = 53;
            label3.Text = "Kondíció típusa:";
            // 
            // WaitForAction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(mainPanel);
            Name = "WaitForAction";
            Size = new Size(870, 118);
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
        private ComboBox conditionComboBox;
        protected Label label3;
        protected Label label4;
        private TextBox frequencyTextField;
        private TextBox timeOutTextBox;
        protected Label label5;
        protected Label valueLabel;
        protected Label locatorLabel;
        private TextBox valueTextBox;
        private ComboBox locatorTextBox;
        protected Label testRunTimeText;
        protected Label testRunTimeLabel;
        private ComboBox logicModifierComboBox;
        protected Label label2;
        protected Label label6;
        private PictureBox pictureBox1;
    }
}
