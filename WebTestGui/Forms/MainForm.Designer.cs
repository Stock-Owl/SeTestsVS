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
            urlTextField = new TextBox();
            webSearchButton = new Button();
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
            logPathBox = new TextBox();
            searchForFolderButton = new Button();
            logPathInfo = new PictureBox();
            pictureBox3 = new PictureBox();
            folderIcon = new PictureBox();
            urlTextFieldInfo = new PictureBox();
            optionText = new Label();
            optionHeaderPanel = new Panel();
            panel1 = new Panel();
            optionInfo = new PictureBox();
            button1 = new Button();
            optionsPanel = new FlowLayoutPanel();
            actionsPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            actionHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)actionsPanelInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logPathInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)folderIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)urlTextFieldInfo).BeginInit();
            optionHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)optionInfo).BeginInit();
            SuspendLayout();
            // 
            // console
            // 
            console.AcceptsTab = true;
            console.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            console.BackColor = Color.Black;
            console.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            console.ForeColor = Color.LightBlue;
            console.Location = new Point(-2, -2);
            console.Name = "console";
            console.ReadOnly = true;
            console.Size = new Size(240, 520);
            console.TabIndex = 0;
            console.Text = "";
            // 
            // urlTextField
            // 
            urlTextField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlTextField.BackColor = Color.FromArgb(40, 40, 43);
            urlTextField.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            urlTextField.ForeColor = Color.DarkGray;
            urlTextField.Location = new Point(368, 9);
            urlTextField.Name = "urlTextField";
            urlTextField.PlaceholderText = "Weboldal URL tesztelésre...";
            urlTextField.Size = new Size(604, 27);
            urlTextField.TabIndex = 1;
            // 
            // webSearchButton
            // 
            webSearchButton.BackColor = Color.FromArgb(40, 40, 43);
            webSearchButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            webSearchButton.ForeColor = Color.White;
            webSearchButton.Location = new Point(275, 10);
            webSearchButton.Name = "webSearchButton";
            webSearchButton.Size = new Size(87, 25);
            webSearchButton.TabIndex = 2;
            webSearchButton.Text = "Böngészés...";
            webSearchButton.UseVisualStyleBackColor = false;
            webSearchButton.Click += webSearchButton_Click;
            // 
            // chromeCheckBox
            // 
            chromeCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chromeCheckBox.AutoSize = true;
            chromeCheckBox.BackColor = Color.Transparent;
            chromeCheckBox.Checked = true;
            chromeCheckBox.CheckState = CheckState.Checked;
            chromeCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            chromeCheckBox.ForeColor = Color.White;
            chromeCheckBox.Location = new Point(398, 46);
            chromeCheckBox.Name = "chromeCheckBox";
            chromeCheckBox.Size = new Size(89, 25);
            chromeCheckBox.TabIndex = 3;
            chromeCheckBox.Text = "Chrome";
            chromeCheckBox.UseVisualStyleBackColor = false;
            chromeCheckBox.CheckedChanged += chromeCheckBox_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(486, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Resize += pictureBox1_Resize;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(623, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Resize += pictureBox2_Resize;
            // 
            // firefoxCheckBox
            // 
            firefoxCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            firefoxCheckBox.AutoSize = true;
            firefoxCheckBox.BackColor = Color.Transparent;
            firefoxCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firefoxCheckBox.ForeColor = Color.White;
            firefoxCheckBox.Location = new Point(540, 46);
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
            testStartButton.BackColor = Color.FromArgb(40, 40, 43);
            testStartButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            testStartButton.ForeColor = Color.White;
            testStartButton.Location = new Point(834, 459);
            testStartButton.Name = "testStartButton";
            testStartButton.Size = new Size(138, 40);
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
            actionHeaderPanel.Location = new Point(243, 106);
            actionHeaderPanel.Name = "actionHeaderPanel";
            actionHeaderPanel.Size = new Size(386, 96);
            actionHeaderPanel.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(40, 40, 43);
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(213, 6);
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
            addActionComboBox.Location = new Point(208, 2);
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
            // logPathBox
            // 
            logPathBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logPathBox.BackColor = Color.FromArgb(40, 40, 43);
            logPathBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            logPathBox.ForeColor = Color.DarkGray;
            logPathBox.Location = new Point(676, 42);
            logPathBox.Name = "logPathBox";
            logPathBox.PlaceholderText = "Log fájl helye...";
            logPathBox.Size = new Size(296, 23);
            logPathBox.TabIndex = 19;
            // 
            // searchForFolderButton
            // 
            searchForFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchForFolderButton.BackColor = Color.FromArgb(40, 40, 43);
            searchForFolderButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchForFolderButton.ForeColor = Color.White;
            searchForFolderButton.Location = new Point(885, 71);
            searchForFolderButton.Name = "searchForFolderButton";
            searchForFolderButton.Size = new Size(87, 25);
            searchForFolderButton.TabIndex = 20;
            searchForFolderButton.Text = "Kiválasztás...";
            searchForFolderButton.UseVisualStyleBackColor = false;
            searchForFolderButton.Click += searchForFolderButton_Click;
            // 
            // logPathInfo
            // 
            logPathInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logPathInfo.Image = (Image)resources.GetObject("logPathInfo.Image");
            logPathInfo.Location = new Point(680, 69);
            logPathInfo.Name = "logPathInfo";
            logPathInfo.Size = new Size(15, 15);
            logPathInfo.SizeMode = PictureBoxSizeMode.StretchImage;
            logPathInfo.TabIndex = 30;
            logPathInfo.TabStop = false;
            logPathInfo.Click += logPathInfo_Click;
            logPathInfo.Resize += logPathInfo_Resize;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(245, 10);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(25, 25);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 32;
            pictureBox3.TabStop = false;
            // 
            // folderIcon
            // 
            folderIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            folderIcon.Image = (Image)resources.GetObject("folderIcon.Image");
            folderIcon.Location = new Point(855, 71);
            folderIcon.Name = "folderIcon";
            folderIcon.Size = new Size(25, 25);
            folderIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            folderIcon.TabIndex = 33;
            folderIcon.TabStop = false;
            // 
            // urlTextFieldInfo
            // 
            urlTextFieldInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            urlTextFieldInfo.Image = (Image)resources.GetObject("urlTextFieldInfo.Image");
            urlTextFieldInfo.Location = new Point(343, 38);
            urlTextFieldInfo.Name = "urlTextFieldInfo";
            urlTextFieldInfo.Size = new Size(15, 15);
            urlTextFieldInfo.SizeMode = PictureBoxSizeMode.StretchImage;
            urlTextFieldInfo.TabIndex = 35;
            urlTextFieldInfo.TabStop = false;
            urlTextFieldInfo.Click += urlTextFieldInfo_Click;
            urlTextFieldInfo.Resize += urlTextFieldInfo_Resize;
            // 
            // optionText
            // 
            optionText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            optionText.AutoSize = true;
            optionText.BackColor = Color.FromArgb(40, 40, 43);
            optionText.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            optionText.ForeColor = Color.White;
            optionText.Location = new Point(3, 2);
            optionText.Name = "optionText";
            optionText.Size = new Size(77, 25);
            optionText.TabIndex = 9;
            optionText.Text = "Opciók:";
            // 
            // optionHeaderPanel
            // 
            optionHeaderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            optionHeaderPanel.AutoScroll = true;
            optionHeaderPanel.BackColor = Color.FromArgb(40, 40, 45);
            optionHeaderPanel.Controls.Add(panel1);
            optionHeaderPanel.Controls.Add(optionInfo);
            optionHeaderPanel.Controls.Add(button1);
            optionHeaderPanel.Controls.Add(optionText);
            optionHeaderPanel.Location = new Point(645, 108);
            optionHeaderPanel.Name = "optionHeaderPanel";
            optionHeaderPanel.Size = new Size(327, 28);
            optionHeaderPanel.TabIndex = 37;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(45, 45, 50);
            panel1.Location = new Point(0, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(327, 316);
            panel1.TabIndex = 38;
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
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(40, 40, 43);
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button1.ForeColor = Color.DarkGray;
            button1.Location = new Point(405, 0);
            button1.Name = "button1";
            button1.Size = new Size(108, 28);
            button1.TabIndex = 10;
            button1.Text = "Hozzáadás...";
            button1.UseVisualStyleBackColor = false;
            // 
            // optionsPanel
            // 
            optionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            optionsPanel.AutoScroll = true;
            optionsPanel.BackColor = Color.FromArgb(45, 45, 50);
            optionsPanel.Location = new Point(645, 137);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new Size(327, 316);
            optionsPanel.TabIndex = 38;
            // 
            // actionsPanel
            // 
            actionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            actionsPanel.AutoScroll = true;
            actionsPanel.BackColor = Color.FromArgb(45, 45, 50);
            actionsPanel.Location = new Point(243, 137);
            actionsPanel.Name = "actionsPanel";
            actionsPanel.Size = new Size(386, 316);
            actionsPanel.TabIndex = 39;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(50, 50, 53);
            ClientSize = new Size(984, 511);
            Controls.Add(actionsPanel);
            Controls.Add(optionsPanel);
            Controls.Add(urlTextFieldInfo);
            Controls.Add(folderIcon);
            Controls.Add(pictureBox3);
            Controls.Add(logPathInfo);
            Controls.Add(searchForFolderButton);
            Controls.Add(logPathBox);
            Controls.Add(testStartButton);
            Controls.Add(pictureBox2);
            Controls.Add(firefoxCheckBox);
            Controls.Add(pictureBox1);
            Controls.Add(chromeCheckBox);
            Controls.Add(webSearchButton);
            Controls.Add(urlTextField);
            Controls.Add(console);
            Controls.Add(actionHeaderPanel);
            Controls.Add(optionHeaderPanel);
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
            ((System.ComponentModel.ISupportInitialize)logPathInfo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)folderIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)urlTextFieldInfo).EndInit();
            optionHeaderPanel.ResumeLayout(false);
            optionHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)optionInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox console;
        private TextBox urlTextField;
        private Button webSearchButton;
        private CheckBox chromeCheckBox;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private CheckBox firefoxCheckBox;
        private Button testStartButton;
        private Label actionText;
        private Panel actionHeaderPanel;
        private TextBox logPathBox;
        private Button searchForFolderButton;
        private PictureBox logPathInfo;
        private PictureBox pictureBox3;
        private PictureBox folderIcon;
        private PictureBox actionsPanelInfo;
        private PictureBox urlTextFieldInfo;
        private Label optionText;
        private Panel optionHeaderPanel;
        private Button button1;
        private PictureBox optionInfo;
        private Panel panel1;
        private FlowLayoutPanel optionsPanel;
        private FlowLayoutPanel actionsPanel;
        private ComboBox addActionComboBox;
        private Label label1;
    }
}