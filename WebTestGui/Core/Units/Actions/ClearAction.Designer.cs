namespace WebTestGui
{
    partial class ClearAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClearAction));
            breakpointOnPicture = new PictureBox();
            breakpointOffPicture = new PictureBox();
            mainLabel = new Label();
            binImage = new PictureBox();
            idTextBox = new TextBox();
            singleCheckbox = new CheckBox();
            singleLabel = new Label();
            label2 = new Label();
            mainPanel = new Panel();
            pictureBox1 = new PictureBox();
            testRunTimeText = new Label();
            testRunTimeLabel = new Label();
            locatorTextBox = new ComboBox();
            valueLabel = new Label();
            locatorLabel = new Label();
            valueTextBox = new TextBox();
            label8 = new Label();
            selectedCheckBox = new CheckBox();
            label7 = new Label();
            enabledCheckBox = new CheckBox();
            label6 = new Label();
            displayedCheckbox = new CheckBox();
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
            breakpointOnPicture.Location = new Point(814, 64);
            breakpointOnPicture.Name = "breakpointOnPicture";
            breakpointOnPicture.Size = new Size(20, 20);
            breakpointOnPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointOnPicture.TabIndex = 40;
            breakpointOnPicture.TabStop = false;
            breakpointOnPicture.Click += breakpointOnPicture_Click;
            // 
            // breakpointOffPicture
            // 
            breakpointOffPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            breakpointOffPicture.Image = (Image)resources.GetObject("breakpointOffPicture.Image");
            breakpointOffPicture.Location = new Point(814, 64);
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
            mainLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(70, 21);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(63, 28);
            mainLabel.TabIndex = 11;
            mainLabel.Text = "Clear:";
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(839, 64);
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
            idTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(814, 6);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(46, 25);
            idTextBox.TabIndex = 38;
            idTextBox.Text = "0";
            idTextBox.Leave += OnUIdTextBoxFocusLeave;
            // 
            // singleCheckbox
            // 
            singleCheckbox.AutoSize = true;
            singleCheckbox.BackColor = Color.Transparent;
            singleCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            singleCheckbox.ForeColor = Color.Silver;
            singleCheckbox.Location = new Point(629, 13);
            singleCheckbox.Name = "singleCheckbox";
            singleCheckbox.Size = new Size(15, 14);
            singleCheckbox.TabIndex = 44;
            singleCheckbox.UseVisualStyleBackColor = false;
            singleCheckbox.CheckedChanged += singleCheckbox_CheckedChanged;
            // 
            // singleLabel
            // 
            singleLabel.AutoSize = true;
            singleLabel.BackColor = Color.Transparent;
            singleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            singleLabel.ForeColor = Color.White;
            singleLabel.Location = new Point(571, 8);
            singleLabel.Name = "singleLabel";
            singleLabel.Size = new Size(44, 21);
            singleLabel.TabIndex = 45;
            singleLabel.Text = "Elem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(650, 12);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 46;
            label2.Text = "Scope selektor";
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
            mainPanel.Controls.Add(label8);
            mainPanel.Controls.Add(selectedCheckBox);
            mainPanel.Controls.Add(label7);
            mainPanel.Controls.Add(enabledCheckBox);
            mainPanel.Controls.Add(label6);
            mainPanel.Controls.Add(displayedCheckbox);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(singleLabel);
            mainPanel.Controls.Add(singleCheckbox);
            mainPanel.Controls.Add(idTextBox);
            mainPanel.Controls.Add(binImage);
            mainPanel.Controls.Add(mainLabel);
            mainPanel.Controls.Add(breakpointOffPicture);
            mainPanel.Controls.Add(breakpointOnPicture);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(870, 90);
            mainPanel.TabIndex = 12;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 78;
            pictureBox1.TabStop = false;
            // 
            // testRunTimeText
            // 
            testRunTimeText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(239, 69);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(48, 15);
            testRunTimeText.TabIndex = 77;
            testRunTimeText.Text = "0 / 0 ms";
            // 
            // testRunTimeLabel
            // 
            testRunTimeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testRunTimeLabel.AutoSize = true;
            testRunTimeLabel.BackColor = Color.Transparent;
            testRunTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeLabel.ForeColor = Color.Gray;
            testRunTimeLabel.Location = new Point(80, 69);
            testRunTimeLabel.Name = "testRunTimeLabel";
            testRunTimeLabel.Size = new Size(157, 15);
            testRunTimeLabel.TabIndex = 76;
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
            locatorTextBox.Location = new Point(373, 21);
            locatorTextBox.Name = "locatorTextBox";
            locatorTextBox.Size = new Size(192, 21);
            locatorTextBox.TabIndex = 75;
            locatorTextBox.Text = "xpath";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.BackColor = Color.Transparent;
            valueLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            valueLabel.ForeColor = Color.White;
            valueLabel.Location = new Point(324, 48);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(43, 19);
            valueLabel.TabIndex = 74;
            valueLabel.Text = "Érték:";
            // 
            // locatorLabel
            // 
            locatorLabel.AutoSize = true;
            locatorLabel.BackColor = Color.Transparent;
            locatorLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            locatorLabel.ForeColor = Color.White;
            locatorLabel.Location = new Point(308, 21);
            locatorLabel.Name = "locatorLabel";
            locatorLabel.Size = new Size(59, 19);
            locatorLabel.TabIndex = 73;
            locatorLabel.Text = "Lokátor:";
            // 
            // valueTextBox
            // 
            valueTextBox.BackColor = Color.FromArgb(40, 40, 43);
            valueTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            valueTextBox.ForeColor = Color.DarkGray;
            valueTextBox.Location = new Point(373, 48);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.PlaceholderText = "Érték...";
            valueTextBox.Size = new Size(192, 22);
            valueTextBox.TabIndex = 72;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(579, 64);
            label8.Name = "label8";
            label8.Size = new Size(45, 13);
            label8.TabIndex = 70;
            label8.Text = "Kijelölt:";
            // 
            // selectedCheckBox
            // 
            selectedCheckBox.AutoSize = true;
            selectedCheckBox.BackColor = Color.Transparent;
            selectedCheckBox.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            selectedCheckBox.ForeColor = Color.Silver;
            selectedCheckBox.Location = new Point(661, 64);
            selectedCheckBox.Name = "selectedCheckBox";
            selectedCheckBox.Size = new Size(15, 14);
            selectedCheckBox.TabIndex = 69;
            selectedCheckBox.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(579, 49);
            label7.Name = "label7";
            label7.Size = new Size(65, 13);
            label7.TabIndex = 68;
            label7.Text = "Bekapcsolt:";
            // 
            // enabledCheckBox
            // 
            enabledCheckBox.AutoSize = true;
            enabledCheckBox.BackColor = Color.Transparent;
            enabledCheckBox.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            enabledCheckBox.ForeColor = Color.Silver;
            enabledCheckBox.Location = new Point(661, 49);
            enabledCheckBox.Name = "enabledCheckBox";
            enabledCheckBox.Size = new Size(15, 14);
            enabledCheckBox.TabIndex = 67;
            enabledCheckBox.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(579, 33);
            label6.Name = "label6";
            label6.Size = new Size(76, 13);
            label6.TabIndex = 66;
            label6.Text = "Megjelenítve:";
            // 
            // displayedCheckbox
            // 
            displayedCheckbox.AutoSize = true;
            displayedCheckbox.BackColor = Color.Transparent;
            displayedCheckbox.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            displayedCheckbox.ForeColor = Color.Silver;
            displayedCheckbox.Location = new Point(661, 34);
            displayedCheckbox.Name = "displayedCheckbox";
            displayedCheckbox.Size = new Size(15, 14);
            displayedCheckbox.TabIndex = 65;
            displayedCheckbox.UseVisualStyleBackColor = false;
            // 
            // ClearAction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(mainPanel);
            Name = "ClearAction";
            Size = new Size(870, 90);
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
        private CheckBox singleCheckbox;
        protected Label singleLabel;
        protected Label label2;
        private Panel mainPanel;
        protected Label label8;
        private CheckBox selectedCheckBox;
        protected Label label7;
        private CheckBox enabledCheckBox;
        protected Label label6;
        private CheckBox displayedCheckbox;
        protected Label valueLabel;
        protected Label locatorLabel;
        private TextBox valueTextBox;
        private ComboBox locatorTextBox;
        protected Label testRunTimeText;
        protected Label testRunTimeLabel;
        private PictureBox pictureBox1;
    }
}
