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
            console = new RichTextBox();
            chromeCheckBox = new CheckBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            firefoxCheckBox = new CheckBox();
            testStartButton = new Button();
            actionText = new Label();
            actionHeaderPanel = new Panel();
            label1 = new Label();
            addActionComboBox = new ComboBox();
            actionsPanelInfo = new PictureBox();
            optionHeaderPanel = new Panel();
            optionLabel = new Label();
            optionInfo = new PictureBox();
            optionsPanel = new FlowLayoutPanel();
            actionsPanel = new FlowLayoutPanel();
            switchToOptionsButton = new Button();
            switchToJsLogButton = new Button();
            jsConsole = new RichTextBox();
            browserLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox3 = new PictureBox();
            vsLogo = new PictureBox();
            saveTestButton = new Button();
            loadTestButton = new Button();
            currentlyEditedLabel = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            pictureBox4 = new PictureBox();
            currentlyEditedText = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            actionHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)actionsPanelInfo).BeginInit();
            optionHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)optionInfo).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vsLogo).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // console
            // 
            console.AcceptsTab = true;
            console.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            console.BackColor = Color.Black;
            console.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            console.ForeColor = Color.LightBlue;
            console.HideSelection = false;
            console.Location = new Point(-2, -2);
            console.Name = "console";
            console.ReadOnly = true;
            console.Size = new Size(240, 520);
            console.TabIndex = 0;
            console.Text = "";
            // 
            // chromeCheckBox
            // 
            chromeCheckBox.Anchor = AnchorStyles.Top;
            chromeCheckBox.AutoSize = true;
            chromeCheckBox.BackColor = Color.FromArgb(60, 60, 65);
            chromeCheckBox.Checked = true;
            chromeCheckBox.CheckState = CheckState.Checked;
            chromeCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            chromeCheckBox.ForeColor = Color.White;
            chromeCheckBox.Location = new Point(528, 10);
            chromeCheckBox.Name = "chromeCheckBox";
            chromeCheckBox.Size = new Size(89, 25);
            chromeCheckBox.TabIndex = 3;
            chromeCheckBox.Text = "Chrome";
            chromeCheckBox.UseVisualStyleBackColor = false;
            chromeCheckBox.CheckedChanged += chromeCheckBox_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackColor = Color.FromArgb(60, 60, 65);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(616, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Resize += pictureBox1_Resize;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top;
            pictureBox2.BackColor = Color.FromArgb(60, 60, 65);
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(753, 10);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Resize += pictureBox2_Resize;
            // 
            // firefoxCheckBox
            // 
            firefoxCheckBox.Anchor = AnchorStyles.Top;
            firefoxCheckBox.AutoSize = true;
            firefoxCheckBox.BackColor = Color.FromArgb(60, 60, 65);
            firefoxCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firefoxCheckBox.ForeColor = Color.White;
            firefoxCheckBox.Location = new Point(670, 10);
            firefoxCheckBox.Name = "firefoxCheckBox";
            firefoxCheckBox.Size = new Size(76, 25);
            firefoxCheckBox.TabIndex = 5;
            firefoxCheckBox.Text = "Firefox";
            firefoxCheckBox.UseVisualStyleBackColor = false;
            firefoxCheckBox.CheckedChanged += firefoxCheckBox_CheckedChanged;
            // 
            // testStartButton
            // 
            testStartButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            testStartButton.BackColor = Color.FromArgb(45, 45, 48);
            testStartButton.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            testStartButton.ForeColor = Color.White;
            testStartButton.Location = new Point(645, 413);
            testStartButton.Name = "testStartButton";
            testStartButton.Size = new Size(327, 40);
            testStartButton.TabIndex = 7;
            testStartButton.Text = "Tesztelés...";
            testStartButton.UseVisualStyleBackColor = false;
            testStartButton.Click += testStartButton_Click;
            // 
            // actionText
            // 
            actionText.AutoSize = true;
            actionText.BackColor = Color.FromArgb(40, 40, 43);
            actionText.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            actionText.ForeColor = Color.White;
            actionText.Location = new Point(3, 2);
            actionText.Name = "actionText";
            actionText.Size = new Size(75, 25);
            actionText.TabIndex = 9;
            actionText.Text = "Akciók:";
            // 
            // actionHeaderPanel
            // 
            actionHeaderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            actionHeaderPanel.AutoScroll = true;
            actionHeaderPanel.BackColor = Color.FromArgb(40, 40, 45);
            actionHeaderPanel.Controls.Add(label1);
            actionHeaderPanel.Controls.Add(addActionComboBox);
            actionHeaderPanel.Controls.Add(actionsPanelInfo);
            actionHeaderPanel.Controls.Add(actionText);
            actionHeaderPanel.Location = new Point(243, 64);
            actionHeaderPanel.Name = "actionHeaderPanel";
            actionHeaderPanel.Size = new Size(383, 34);
            actionHeaderPanel.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(40, 40, 43);
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(212, 4);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 40;
            label1.Text = "Akció hozzáadása...";
            // 
            // addActionComboBox
            // 
            addActionComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addActionComboBox.BackColor = Color.FromArgb(40, 40, 43);
            addActionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            addActionComboBox.FlatStyle = FlatStyle.Popup;
            addActionComboBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            addActionComboBox.ForeColor = Color.Silver;
            addActionComboBox.FormattingEnabled = true;
            addActionComboBox.Location = new Point(208, 0);
            addActionComboBox.Name = "addActionComboBox";
            addActionComboBox.Size = new Size(175, 28);
            addActionComboBox.TabIndex = 43;
            addActionComboBox.SelectedIndexChanged += addActionComboBox_SelectedIndexChanged;
            // 
            // actionsPanelInfo
            // 
            actionsPanelInfo.Image = (Image)resources.GetObject("actionsPanelInfo.Image");
            actionsPanelInfo.Location = new Point(84, 8);
            actionsPanelInfo.Name = "actionsPanelInfo";
            actionsPanelInfo.Size = new Size(15, 15);
            actionsPanelInfo.SizeMode = PictureBoxSizeMode.StretchImage;
            actionsPanelInfo.TabIndex = 34;
            actionsPanelInfo.TabStop = false;
            actionsPanelInfo.Click += fieldPanelInfo_Click;
            // 
            // optionHeaderPanel
            // 
            optionHeaderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            optionHeaderPanel.AutoScroll = true;
            optionHeaderPanel.BackColor = Color.FromArgb(40, 40, 45);
            optionHeaderPanel.Controls.Add(optionLabel);
            optionHeaderPanel.Controls.Add(optionInfo);
            optionHeaderPanel.Location = new Point(645, 95);
            optionHeaderPanel.Name = "optionHeaderPanel";
            optionHeaderPanel.Size = new Size(327, 28);
            optionHeaderPanel.TabIndex = 37;
            // 
            // optionLabel
            // 
            optionLabel.AutoSize = true;
            optionLabel.BackColor = Color.FromArgb(40, 40, 43);
            optionLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            optionLabel.ForeColor = Color.White;
            optionLabel.Location = new Point(2, 2);
            optionLabel.Name = "optionLabel";
            optionLabel.Size = new Size(77, 25);
            optionLabel.TabIndex = 45;
            optionLabel.Text = "Opciók:";
            // 
            // optionInfo
            // 
            optionInfo.Image = (Image)resources.GetObject("optionInfo.Image");
            optionInfo.Location = new Point(86, 8);
            optionInfo.Name = "optionInfo";
            optionInfo.Size = new Size(15, 15);
            optionInfo.SizeMode = PictureBoxSizeMode.StretchImage;
            optionInfo.TabIndex = 38;
            optionInfo.TabStop = false;
            optionInfo.Click += optionInfo_Click;
            // 
            // optionsPanel
            // 
            optionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            optionsPanel.AutoScroll = true;
            optionsPanel.BackColor = Color.FromArgb(45, 45, 50);
            optionsPanel.Location = new Point(645, 123);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new Size(327, 284);
            optionsPanel.TabIndex = 38;
            // 
            // actionsPanel
            // 
            actionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            actionsPanel.AutoScroll = true;
            actionsPanel.BackColor = Color.FromArgb(45, 45, 50);
            actionsPanel.Location = new Point(243, 95);
            actionsPanel.Name = "actionsPanel";
            actionsPanel.Size = new Size(383, 358);
            actionsPanel.TabIndex = 39;
            // 
            // switchToOptionsButton
            // 
            switchToOptionsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            switchToOptionsButton.BackColor = Color.FromArgb(40, 40, 43);
            switchToOptionsButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            switchToOptionsButton.ForeColor = Color.White;
            switchToOptionsButton.Location = new Point(645, 64);
            switchToOptionsButton.Name = "switchToOptionsButton";
            switchToOptionsButton.Size = new Size(87, 25);
            switchToOptionsButton.TabIndex = 40;
            switchToOptionsButton.Text = "Opciók...";
            switchToOptionsButton.UseVisualStyleBackColor = false;
            switchToOptionsButton.Click += switchToOptionsButton_Click;
            // 
            // switchToJsLogButton
            // 
            switchToJsLogButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            switchToJsLogButton.BackColor = Color.FromArgb(40, 40, 43);
            switchToJsLogButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Italic, GraphicsUnit.Point);
            switchToJsLogButton.ForeColor = Color.Silver;
            switchToJsLogButton.Location = new Point(885, 64);
            switchToJsLogButton.Name = "switchToJsLogButton";
            switchToJsLogButton.Size = new Size(87, 25);
            switchToJsLogButton.TabIndex = 41;
            switchToJsLogButton.Text = "JS log...";
            switchToJsLogButton.UseVisualStyleBackColor = false;
            switchToJsLogButton.Click += switchToJsLogButton_Click;
            // 
            // jsConsole
            // 
            jsConsole.AcceptsTab = true;
            jsConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            jsConsole.BackColor = Color.Black;
            jsConsole.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            jsConsole.ForeColor = Color.LightBlue;
            jsConsole.HideSelection = false;
            jsConsole.Location = new Point(645, 95);
            jsConsole.Name = "jsConsole";
            jsConsole.ReadOnly = true;
            jsConsole.Size = new Size(327, 314);
            jsConsole.TabIndex = 44;
            jsConsole.Text = "";
            jsConsole.Visible = false;
            // 
            // browserLabel
            // 
            browserLabel.AutoSize = true;
            browserLabel.BackColor = Color.FromArgb(60, 60, 65);
            browserLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            browserLabel.ForeColor = Color.White;
            browserLabel.Location = new Point(250, 10);
            browserLabel.Name = "browserLabel";
            browserLabel.Size = new Size(100, 25);
            browserLabel.TabIndex = 45;
            browserLabel.Text = "Böngésző:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(60, 60, 65);
            flowLayoutPanel1.Controls.Add(pictureBox3);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(984, 46);
            flowLayoutPanel1.TabIndex = 46;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top;
            pictureBox3.BackColor = Color.FromArgb(60, 60, 65);
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(3, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(25, 25);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // vsLogo
            // 
            vsLogo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            vsLogo.BackColor = Color.FromArgb(60, 60, 65);
            vsLogo.Image = (Image)resources.GetObject("vsLogo.Image");
            vsLogo.Location = new Point(942, 6);
            vsLogo.Name = "vsLogo";
            vsLogo.Size = new Size(35, 35);
            vsLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            vsLogo.TabIndex = 47;
            vsLogo.TabStop = false;
            // 
            // saveTestButton
            // 
            saveTestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveTestButton.BackColor = Color.FromArgb(45, 45, 48);
            saveTestButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            saveTestButton.ForeColor = Color.White;
            saveTestButton.Location = new Point(645, 472);
            saveTestButton.Name = "saveTestButton";
            saveTestButton.Size = new Size(160, 31);
            saveTestButton.TabIndex = 48;
            saveTestButton.Text = "Teszt mentése...";
            saveTestButton.UseVisualStyleBackColor = false;
            saveTestButton.Click += saveTestButton_Click;
            // 
            // loadTestButton
            // 
            loadTestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            loadTestButton.BackColor = Color.FromArgb(45, 45, 48);
            loadTestButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            loadTestButton.ForeColor = Color.White;
            loadTestButton.Location = new Point(812, 472);
            loadTestButton.Name = "loadTestButton";
            loadTestButton.Size = new Size(160, 31);
            loadTestButton.TabIndex = 49;
            loadTestButton.Text = "Teszt betöltése...";
            loadTestButton.UseVisualStyleBackColor = false;
            loadTestButton.Click += loadTestButton_Click;
            // 
            // currentlyEditedLabel
            // 
            currentlyEditedLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentlyEditedLabel.AutoSize = true;
            currentlyEditedLabel.BackColor = Color.FromArgb(60, 60, 65);
            currentlyEditedLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            currentlyEditedLabel.ForeColor = Color.White;
            currentlyEditedLabel.Location = new Point(243, 468);
            currentlyEditedLabel.Name = "currentlyEditedLabel";
            currentlyEditedLabel.Size = new Size(169, 19);
            currentlyEditedLabel.TabIndex = 50;
            currentlyEditedLabel.Text = "Jelenleg szerkeztett teszt:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.BackColor = Color.FromArgb(60, 60, 65);
            flowLayoutPanel2.Controls.Add(pictureBox4);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(0, 465);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(984, 46);
            flowLayoutPanel2.TabIndex = 51;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top;
            pictureBox4.BackColor = Color.FromArgb(60, 60, 65);
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(3, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(25, 25);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // currentlyEditedText
            // 
            currentlyEditedText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentlyEditedText.AutoSize = true;
            currentlyEditedText.BackColor = Color.FromArgb(60, 60, 65);
            currentlyEditedText.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            currentlyEditedText.ForeColor = Color.DarkGray;
            currentlyEditedText.Location = new Point(243, 487);
            currentlyEditedText.Name = "currentlyEditedText";
            currentlyEditedText.Size = new Size(38, 12);
            currentlyEditedText.TabIndex = 52;
            currentlyEditedText.Text = "filepath";
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(50, 50, 53);
            ClientSize = new Size(984, 511);
            Controls.Add(currentlyEditedLabel);
            Controls.Add(loadTestButton);
            Controls.Add(saveTestButton);
            Controls.Add(vsLogo);
            Controls.Add(browserLabel);
            Controls.Add(switchToJsLogButton);
            Controls.Add(switchToOptionsButton);
            Controls.Add(actionsPanel);
            Controls.Add(optionsPanel);
            Controls.Add(testStartButton);
            Controls.Add(pictureBox2);
            Controls.Add(firefoxCheckBox);
            Controls.Add(pictureBox1);
            Controls.Add(chromeCheckBox);
            Controls.Add(console);
            Controls.Add(actionHeaderPanel);
            Controls.Add(optionHeaderPanel);
            Controls.Add(jsConsole);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(currentlyEditedText);
            Controls.Add(flowLayoutPanel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 550);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VS WebTeszt";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            actionHeaderPanel.ResumeLayout(false);
            actionHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)actionsPanelInfo).EndInit();
            optionHeaderPanel.ResumeLayout(false);
            optionHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)optionInfo).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)vsLogo).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox console;
        private CheckBox chromeCheckBox;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private CheckBox firefoxCheckBox;
        private Button testStartButton;
        private Label actionText;
        private Panel actionHeaderPanel;
        private PictureBox actionsPanelInfo;
        private Panel optionHeaderPanel;
        private PictureBox optionInfo;
        private FlowLayoutPanel optionsPanel;
        private FlowLayoutPanel actionsPanel;
        private ComboBox addActionComboBox;
        private Label label1;
        private Button switchToOptionsButton;
        private Button switchToJsLogButton;
        private RichTextBox jsConsole;
        private Label optionLabel;
        private Label browserLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox3;
        private PictureBox vsLogo;
        private Button saveTestButton;
        private Button loadTestButton;
        private Label currentlyEditedLabel;
        private FlowLayoutPanel flowLayoutPanel2;
        private PictureBox pictureBox4;
        private Label currentlyEditedText;
    }
}