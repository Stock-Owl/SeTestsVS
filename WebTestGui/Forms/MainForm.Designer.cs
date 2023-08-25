namespace WebTestGui
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            chromeCheckBox = new CheckBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            firefoxCheckBox = new CheckBox();
            testStartButton = new Button();
            unitLabel = new Label();
            unitHeaderPanel = new Panel();
            addUnitButton = new PictureBox();
            optionHeaderPanel = new Panel();
            optionLabel = new Label();
            optionsPanel = new FlowLayoutPanel();
            unitsPanel = new FlowLayoutPanel();
            switchToOptionsButton = new Button();
            switchToJsLogButton = new Button();
            browserLabel = new Label();
            vsLogo = new PictureBox();
            saveTestButton = new Button();
            loadTestButton = new Button();
            currentlyEditedLabel = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            currentlyEditedText = new Label();
            pictureBox3 = new PictureBox();
            rootLogDirectoryButton = new Button();
            testNameLabel = new Label();
            breakpointIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            unitHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)addUnitButton).BeginInit();
            optionHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vsLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)breakpointIcon).BeginInit();
            SuspendLayout();
            // 
            // chromeCheckBox
            // 
            chromeCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chromeCheckBox.AutoSize = true;
            chromeCheckBox.BackColor = Color.FromArgb(50, 50, 53);
            chromeCheckBox.Checked = true;
            chromeCheckBox.CheckState = CheckState.Checked;
            chromeCheckBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            chromeCheckBox.ForeColor = Color.White;
            chromeCheckBox.Location = new Point(907, 82);
            chromeCheckBox.Name = "chromeCheckBox";
            chromeCheckBox.Size = new Size(83, 24);
            chromeCheckBox.TabIndex = 3;
            chromeCheckBox.Text = "Chrome";
            chromeCheckBox.UseVisualStyleBackColor = false;
            chromeCheckBox.CheckedChanged += OnChromeCheckBoxChecked;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = Color.FromArgb(50, 50, 53);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(989, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackColor = Color.FromArgb(50, 50, 53);
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1097, 81);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // firefoxCheckBox
            // 
            firefoxCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            firefoxCheckBox.AutoSize = true;
            firefoxCheckBox.BackColor = Color.FromArgb(50, 50, 53);
            firefoxCheckBox.Checked = true;
            firefoxCheckBox.CheckState = CheckState.Checked;
            firefoxCheckBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            firefoxCheckBox.ForeColor = Color.White;
            firefoxCheckBox.Location = new Point(1025, 82);
            firefoxCheckBox.Name = "firefoxCheckBox";
            firefoxCheckBox.Size = new Size(73, 24);
            firefoxCheckBox.TabIndex = 5;
            firefoxCheckBox.Text = "Firefox";
            firefoxCheckBox.UseVisualStyleBackColor = false;
            firefoxCheckBox.CheckedChanged += OnFirefoxCheckBoxChecked;
            // 
            // testStartButton
            // 
            testStartButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            testStartButton.BackColor = Color.FromArgb(45, 45, 48);
            testStartButton.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point);
            testStartButton.ForeColor = Color.White;
            testStartButton.Location = new Point(795, 513);
            testStartButton.Name = "testStartButton";
            testStartButton.Size = new Size(327, 40);
            testStartButton.TabIndex = 7;
            testStartButton.Text = "TESZT INDITÁSA...";
            testStartButton.UseVisualStyleBackColor = false;
            testStartButton.Click += OnStartTestButtonPressed;
            // 
            // unitLabel
            // 
            unitLabel.AutoSize = true;
            unitLabel.BackColor = Color.FromArgb(40, 40, 43);
            unitLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            unitLabel.ForeColor = Color.White;
            unitLabel.Location = new Point(3, 3);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new Size(54, 19);
            unitLabel.TabIndex = 9;
            unitLabel.Text = "Unitok:";
            // 
            // unitHeaderPanel
            // 
            unitHeaderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            unitHeaderPanel.BackColor = Color.FromArgb(40, 40, 45);
            unitHeaderPanel.Controls.Add(addUnitButton);
            unitHeaderPanel.Controls.Add(unitLabel);
            unitHeaderPanel.Location = new Point(412, 77);
            unitHeaderPanel.Name = "unitHeaderPanel";
            unitHeaderPanel.Size = new Size(364, 30);
            unitHeaderPanel.TabIndex = 9;
            // 
            // addUnitButton
            // 
            addUnitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addUnitButton.BackColor = Color.FromArgb(50, 50, 53);
            addUnitButton.Image = (Image)resources.GetObject("addUnitButton.Image");
            addUnitButton.Location = new Point(340, 3);
            addUnitButton.Name = "addUnitButton";
            addUnitButton.Size = new Size(20, 20);
            addUnitButton.SizeMode = PictureBoxSizeMode.StretchImage;
            addUnitButton.TabIndex = 57;
            addUnitButton.TabStop = false;
            addUnitButton.Click += OnAddUnitButtonPressed;
            // 
            // optionHeaderPanel
            // 
            optionHeaderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            optionHeaderPanel.BackColor = Color.FromArgb(40, 40, 45);
            optionHeaderPanel.Controls.Add(optionLabel);
            optionHeaderPanel.Location = new Point(795, 155);
            optionHeaderPanel.Name = "optionHeaderPanel";
            optionHeaderPanel.Size = new Size(327, 23);
            optionHeaderPanel.TabIndex = 37;
            // 
            // optionLabel
            // 
            optionLabel.AutoSize = true;
            optionLabel.BackColor = Color.FromArgb(40, 40, 43);
            optionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            optionLabel.ForeColor = Color.White;
            optionLabel.Location = new Point(3, 2);
            optionLabel.Name = "optionLabel";
            optionLabel.Size = new Size(56, 19);
            optionLabel.TabIndex = 45;
            optionLabel.Text = "Opciók:";
            // 
            // optionsPanel
            // 
            optionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            optionsPanel.AutoScroll = true;
            optionsPanel.BackColor = Color.FromArgb(45, 45, 50);
            optionsPanel.Location = new Point(795, 178);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new Size(327, 330);
            optionsPanel.TabIndex = 38;
            // 
            // unitsPanel
            // 
            unitsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            unitsPanel.AutoScroll = true;
            unitsPanel.BackColor = Color.FromArgb(45, 45, 50);
            unitsPanel.Location = new Point(412, 103);
            unitsPanel.Name = "unitsPanel";
            unitsPanel.Size = new Size(364, 450);
            unitsPanel.TabIndex = 39;
            // 
            // switchToOptionsButton
            // 
            switchToOptionsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            switchToOptionsButton.BackColor = Color.FromArgb(40, 40, 43);
            switchToOptionsButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            switchToOptionsButton.ForeColor = Color.White;
            switchToOptionsButton.Location = new Point(794, 120);
            switchToOptionsButton.Name = "switchToOptionsButton";
            switchToOptionsButton.Size = new Size(87, 25);
            switchToOptionsButton.TabIndex = 40;
            switchToOptionsButton.Text = "Opciók...";
            switchToOptionsButton.UseVisualStyleBackColor = false;
            switchToOptionsButton.Click += OnSwitchToOptionsButtonPressed;
            // 
            // switchToJsLogButton
            // 
            switchToJsLogButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            switchToJsLogButton.BackColor = Color.FromArgb(40, 40, 43);
            switchToJsLogButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Italic, GraphicsUnit.Point);
            switchToJsLogButton.ForeColor = Color.Silver;
            switchToJsLogButton.Location = new Point(1035, 120);
            switchToJsLogButton.Name = "switchToJsLogButton";
            switchToJsLogButton.Size = new Size(87, 25);
            switchToJsLogButton.TabIndex = 41;
            switchToJsLogButton.Text = "JS log...";
            switchToJsLogButton.UseVisualStyleBackColor = false;
            switchToJsLogButton.Click += OnSwitchToJsLogButtonPressed;
            // 
            // browserLabel
            // 
            browserLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browserLabel.AutoSize = true;
            browserLabel.BackColor = Color.FromArgb(50, 50, 53);
            browserLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            browserLabel.ForeColor = Color.White;
            browserLabel.Location = new Point(795, 81);
            browserLabel.Name = "browserLabel";
            browserLabel.Size = new Size(99, 25);
            browserLabel.TabIndex = 45;
            browserLabel.Text = "Böngésző:";
            // 
            // vsLogo
            // 
            vsLogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            vsLogo.BackColor = Color.FromArgb(60, 60, 65);
            vsLogo.Image = (Image)resources.GetObject("vsLogo.Image");
            vsLogo.Location = new Point(1090, 566);
            vsLogo.Name = "vsLogo";
            vsLogo.Size = new Size(48, 48);
            vsLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            vsLogo.TabIndex = 47;
            vsLogo.TabStop = false;
            // 
            // saveTestButton
            // 
            saveTestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveTestButton.BackColor = Color.FromArgb(45, 45, 48);
            saveTestButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            saveTestButton.ForeColor = Color.White;
            saveTestButton.Location = new Point(795, 572);
            saveTestButton.Name = "saveTestButton";
            saveTestButton.Size = new Size(117, 31);
            saveTestButton.TabIndex = 48;
            saveTestButton.Text = "Teszt mentése...";
            saveTestButton.UseVisualStyleBackColor = false;
            saveTestButton.Click += OnSaveTestButtonPressed;
            // 
            // loadTestButton
            // 
            loadTestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            loadTestButton.BackColor = Color.FromArgb(45, 45, 48);
            loadTestButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            loadTestButton.ForeColor = Color.White;
            loadTestButton.Location = new Point(952, 572);
            loadTestButton.Name = "loadTestButton";
            loadTestButton.Size = new Size(122, 31);
            loadTestButton.TabIndex = 49;
            loadTestButton.Text = "Teszt betöltése...";
            loadTestButton.UseVisualStyleBackColor = false;
            loadTestButton.Click += OnLoadTestButtonPressed;
            // 
            // currentlyEditedLabel
            // 
            currentlyEditedLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentlyEditedLabel.AutoSize = true;
            currentlyEditedLabel.BackColor = Color.FromArgb(60, 60, 65);
            currentlyEditedLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            currentlyEditedLabel.ForeColor = Color.White;
            currentlyEditedLabel.Location = new Point(416, 568);
            currentlyEditedLabel.Name = "currentlyEditedLabel";
            currentlyEditedLabel.Size = new Size(169, 19);
            currentlyEditedLabel.TabIndex = 50;
            currentlyEditedLabel.Text = "Jelenleg szerkeztett teszt:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.BackColor = Color.FromArgb(60, 60, 65);
            flowLayoutPanel2.Location = new Point(412, 565);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(722, 46);
            flowLayoutPanel2.TabIndex = 51;
            // 
            // currentlyEditedText
            // 
            currentlyEditedText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentlyEditedText.AutoSize = true;
            currentlyEditedText.BackColor = Color.FromArgb(60, 60, 65);
            currentlyEditedText.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            currentlyEditedText.ForeColor = Color.DarkGray;
            currentlyEditedText.Location = new Point(416, 587);
            currentlyEditedText.Name = "currentlyEditedText";
            currentlyEditedText.Size = new Size(38, 12);
            currentlyEditedText.TabIndex = 52;
            currentlyEditedText.Text = "filepath";
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox3.BackColor = Color.FromArgb(60, 60, 65);
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(745, 573);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 53;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // rootLogDirectoryButton
            // 
            rootLogDirectoryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            rootLogDirectoryButton.BackColor = Color.FromArgb(45, 45, 48);
            rootLogDirectoryButton.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            rootLogDirectoryButton.ForeColor = Color.White;
            rootLogDirectoryButton.Location = new Point(620, 572);
            rootLogDirectoryButton.Name = "rootLogDirectoryButton";
            rootLogDirectoryButton.Size = new Size(120, 31);
            rootLogDirectoryButton.TabIndex = 54;
            rootLogDirectoryButton.Text = "Gyökér log mappa...";
            rootLogDirectoryButton.UseVisualStyleBackColor = false;
            rootLogDirectoryButton.Click += rootLogDirectoryButton_Click;
            // 
            // testNameLabel
            // 
            testNameLabel.AutoSize = true;
            testNameLabel.BackColor = Color.FromArgb(50, 50, 53);
            testNameLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            testNameLabel.ForeColor = Color.White;
            testNameLabel.Location = new Point(408, 37);
            testNameLabel.Name = "testNameLabel";
            testNameLabel.Size = new Size(136, 37);
            testNameLabel.TabIndex = 55;
            testNameLabel.Text = "testName";
            // 
            // breakpointIcon
            // 
            breakpointIcon.Image = (Image)resources.GetObject("breakpointIcon.Image");
            breakpointIcon.Location = new Point(544, 47);
            breakpointIcon.Name = "breakpointIcon";
            breakpointIcon.Size = new Size(25, 25);
            breakpointIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointIcon.TabIndex = 56;
            breakpointIcon.TabStop = false;
            breakpointIcon.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(50, 50, 53);
            ClientSize = new Size(1134, 611);
            Controls.Add(breakpointIcon);
            Controls.Add(rootLogDirectoryButton);
            Controls.Add(pictureBox3);
            Controls.Add(optionHeaderPanel);
            Controls.Add(currentlyEditedLabel);
            Controls.Add(loadTestButton);
            Controls.Add(saveTestButton);
            Controls.Add(vsLogo);
            Controls.Add(browserLabel);
            Controls.Add(switchToJsLogButton);
            Controls.Add(switchToOptionsButton);
            Controls.Add(unitsPanel);
            Controls.Add(optionsPanel);
            Controls.Add(testStartButton);
            Controls.Add(pictureBox2);
            Controls.Add(firefoxCheckBox);
            Controls.Add(pictureBox1);
            Controls.Add(chromeCheckBox);
            Controls.Add(unitHeaderPanel);
            Controls.Add(currentlyEditedText);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(testNameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 550);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VS WebTeszt";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            unitHeaderPanel.ResumeLayout(false);
            unitHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)addUnitButton).EndInit();
            optionHeaderPanel.ResumeLayout(false);
            optionHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)vsLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)breakpointIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox chromeCheckBox;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private CheckBox firefoxCheckBox;
        private Button testStartButton;
        private Label unitLabel;
        private Panel unitHeaderPanel;
        private Panel optionHeaderPanel;
        private FlowLayoutPanel optionsPanel;
        private FlowLayoutPanel unitsPanel;
        private Button switchToOptionsButton;
        private Button switchToJsLogButton;
        private Label optionLabel;
        private Label browserLabel;
        private PictureBox vsLogo;
        private Button saveTestButton;
        private Button loadTestButton;
        private Label currentlyEditedLabel;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label currentlyEditedText;
        private PictureBox pictureBox3;
        private Button rootLogDirectoryButton;
        private Label testNameLabel;
        private PictureBox addUnitButton;
        private PictureBox breakpointIcon;
    }
}