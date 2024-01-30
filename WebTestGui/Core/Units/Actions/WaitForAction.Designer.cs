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
            msLabel2 = new Label();
            timeoutLabel = new Label();
            timeoutTextBox = new TextBox();
            msLabel1 = new Label();
            frequencyLabel = new Label();
            frequencyTextBox = new TextBox();
            oppOperatorLabel = new Label();
            oppOperatorCheckbox = new CheckBox();
            pictureBox1 = new PictureBox();
            logicOperatorComboBox = new ComboBox();
            label2 = new Label();
            testRunTimeText = new Label();
            testRunTimeLabel = new Label();
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
            mainLabel.Location = new Point(80, 4);
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
            mainPanel.Controls.Add(msLabel2);
            mainPanel.Controls.Add(timeoutLabel);
            mainPanel.Controls.Add(timeoutTextBox);
            mainPanel.Controls.Add(msLabel1);
            mainPanel.Controls.Add(frequencyLabel);
            mainPanel.Controls.Add(frequencyTextBox);
            mainPanel.Controls.Add(oppOperatorLabel);
            mainPanel.Controls.Add(oppOperatorCheckbox);
            mainPanel.Controls.Add(pictureBox1);
            mainPanel.Controls.Add(logicOperatorComboBox);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(testRunTimeText);
            mainPanel.Controls.Add(testRunTimeLabel);
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
            // msLabel2
            // 
            msLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            msLabel2.AutoSize = true;
            msLabel2.BackColor = Color.Transparent;
            msLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            msLabel2.ForeColor = Color.DimGray;
            msLabel2.Location = new Point(619, 14);
            msLabel2.Name = "msLabel2";
            msLabel2.Size = new Size(30, 15);
            msLabel2.TabIndex = 101;
            msLabel2.Text = "(ms)";
            // 
            // timeoutLabel
            // 
            timeoutLabel.AutoSize = true;
            timeoutLabel.BackColor = Color.Transparent;
            timeoutLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            timeoutLabel.ForeColor = Color.White;
            timeoutLabel.Location = new Point(455, 10);
            timeoutLabel.Name = "timeoutLabel";
            timeoutLabel.Size = new Size(79, 19);
            timeoutLabel.TabIndex = 100;
            timeoutLabel.Text = "Időtúllépés:";
            // 
            // timeoutTextBox
            // 
            timeoutTextBox.BackColor = Color.FromArgb(40, 40, 43);
            timeoutTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            timeoutTextBox.ForeColor = Color.DarkGray;
            timeoutTextBox.Location = new Point(537, 10);
            timeoutTextBox.Name = "timeoutTextBox";
            timeoutTextBox.PlaceholderText = "Érték...";
            timeoutTextBox.Size = new Size(80, 22);
            timeoutTextBox.TabIndex = 99;
            timeoutTextBox.Text = "10000";
            // 
            // msLabel1
            // 
            msLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            msLabel1.AutoSize = true;
            msLabel1.BackColor = Color.Transparent;
            msLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            msLabel1.ForeColor = Color.DimGray;
            msLabel1.Location = new Point(409, 14);
            msLabel1.Name = "msLabel1";
            msLabel1.Size = new Size(30, 15);
            msLabel1.TabIndex = 98;
            msLabel1.Text = "(ms)";
            // 
            // frequencyLabel
            // 
            frequencyLabel.AutoSize = true;
            frequencyLabel.BackColor = Color.Transparent;
            frequencyLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            frequencyLabel.ForeColor = Color.White;
            frequencyLabel.Location = new Point(245, 10);
            frequencyLabel.Name = "frequencyLabel";
            frequencyLabel.Size = new Size(80, 19);
            frequencyLabel.TabIndex = 97;
            frequencyLabel.Text = "Gyakoriság:";
            // 
            // frequencyTextBox
            // 
            frequencyTextBox.BackColor = Color.FromArgb(40, 40, 43);
            frequencyTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            frequencyTextBox.ForeColor = Color.DarkGray;
            frequencyTextBox.Location = new Point(327, 10);
            frequencyTextBox.Name = "frequencyTextBox";
            frequencyTextBox.PlaceholderText = "Érték...";
            frequencyTextBox.Size = new Size(80, 22);
            frequencyTextBox.TabIndex = 96;
            frequencyTextBox.Text = "1000";
            // 
            // oppOperatorLabel
            // 
            oppOperatorLabel.AutoSize = true;
            oppOperatorLabel.BackColor = Color.Transparent;
            oppOperatorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            oppOperatorLabel.ForeColor = Color.White;
            oppOperatorLabel.Location = new Point(128, 75);
            oppOperatorLabel.Name = "oppOperatorLabel";
            oppOperatorLabel.Size = new Size(15, 21);
            oppOperatorLabel.TabIndex = 95;
            oppOperatorLabel.Text = "!";
            // 
            // oppOperatorCheckbox
            // 
            oppOperatorCheckbox.AutoSize = true;
            oppOperatorCheckbox.BackColor = Color.Transparent;
            oppOperatorCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            oppOperatorCheckbox.ForeColor = Color.Silver;
            oppOperatorCheckbox.Location = new Point(149, 79);
            oppOperatorCheckbox.Name = "oppOperatorCheckbox";
            oppOperatorCheckbox.Size = new Size(15, 14);
            oppOperatorCheckbox.TabIndex = 94;
            oppOperatorCheckbox.UseVisualStyleBackColor = false;
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
            // logicOperatorComboBox
            // 
            logicOperatorComboBox.BackColor = Color.FromArgb(40, 40, 43);
            logicOperatorComboBox.FlatStyle = FlatStyle.Popup;
            logicOperatorComboBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            logicOperatorComboBox.ForeColor = Color.DarkGray;
            logicOperatorComboBox.FormattingEnabled = true;
            logicOperatorComboBox.Location = new Point(120, 53);
            logicOperatorComboBox.Name = "logicOperatorComboBox";
            logicOperatorComboBox.Size = new Size(76, 21);
            logicOperatorComboBox.TabIndex = 91;
            logicOperatorComboBox.Text = "?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(84, 31);
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
        protected Label testRunTimeText;
        protected Label testRunTimeLabel;
        private ComboBox logicOperatorComboBox;
        protected Label label2;
        private PictureBox pictureBox1;
        protected Label oppOperatorLabel;
        private CheckBox oppOperatorCheckbox;
        protected Label frequencyLabel;
        private TextBox frequencyTextBox;
        protected Label msLabel1;
        protected Label msLabel2;
        protected Label timeoutLabel;
        private TextBox timeoutTextBox;
    }
}
