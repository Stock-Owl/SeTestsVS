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
            testStartButton = new Button();
            unitLabel = new Label();
            unitHeaderPanel = new Panel();
            gotoUnitLabel = new Label();
            gotoUnitComboBox = new ComboBox();
            addUnitButton = new PictureBox();
            optionHeaderPanel = new Panel();
            importOptionsLabel = new Label();
            importOptionTemplate = new PictureBox();
            exportOptionsLabel = new Label();
            exportOptionTemplate = new PictureBox();
            optionLabel = new Label();
            optionsPanel = new FlowLayoutPanel();
            unitsPanel = new FlowLayoutPanel();
            switchToOptionsButton = new Button();
            switchToJsLogButton = new Button();
            saveTestButton = new Button();
            currentlyEditedLabel = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            currentlyEditedText = new Label();
            pictureBox3 = new PictureBox();
            rootLogDirectoryButton = new Button();
            testNameLabel = new Label();
            breakpointIcon = new PictureBox();
            testRunTimeText = new Label();
            ignoreBreakpointsLabel = new Label();
            ignoreBreakpointsCheckbox = new CheckBox();
            testDateLabel = new Label();
            unitHierarchyButton = new Button();
            unitHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)addUnitButton).BeginInit();
            optionHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)importOptionTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exportOptionTemplate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)breakpointIcon).BeginInit();
            SuspendLayout();
            // 
            // testStartButton
            // 
            testStartButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            testStartButton.BackColor = Color.FromArgb(45, 45, 48);
            testStartButton.FlatStyle = FlatStyle.Popup;
            testStartButton.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point);
            testStartButton.ForeColor = Color.White;
            testStartButton.Location = new Point(795, 486);
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
            unitHeaderPanel.Controls.Add(gotoUnitLabel);
            unitHeaderPanel.Controls.Add(gotoUnitComboBox);
            unitHeaderPanel.Controls.Add(addUnitButton);
            unitHeaderPanel.Controls.Add(unitLabel);
            unitHeaderPanel.Location = new Point(551, 77);
            unitHeaderPanel.MaximumSize = new Size(950, 30);
            unitHeaderPanel.Name = "unitHeaderPanel";
            unitHeaderPanel.Size = new Size(240, 30);
            unitHeaderPanel.TabIndex = 9;
            // 
            // gotoUnitLabel
            // 
            gotoUnitLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gotoUnitLabel.AutoSize = true;
            gotoUnitLabel.BackColor = Color.Transparent;
            gotoUnitLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            gotoUnitLabel.ForeColor = Color.DarkGray;
            gotoUnitLabel.Location = new Point(-1, 6);
            gotoUnitLabel.Name = "gotoUnitLabel";
            gotoUnitLabel.Size = new Size(79, 15);
            gotoUnitLabel.TabIndex = 63;
            gotoUnitLabel.Text = "Unit keresése:";
            // 
            // gotoUnitComboBox
            // 
            gotoUnitComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gotoUnitComboBox.BackColor = Color.FromArgb(40, 40, 43);
            gotoUnitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            gotoUnitComboBox.FlatStyle = FlatStyle.Popup;
            gotoUnitComboBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            gotoUnitComboBox.ForeColor = Color.Silver;
            gotoUnitComboBox.FormattingEnabled = true;
            gotoUnitComboBox.Location = new Point(84, 3);
            gotoUnitComboBox.Name = "gotoUnitComboBox";
            gotoUnitComboBox.Size = new Size(126, 21);
            gotoUnitComboBox.TabIndex = 62;
            gotoUnitComboBox.DropDown += gotoUnitComboBox_DropDown;
            gotoUnitComboBox.SelectedIndexChanged += gotoUnitComboBox_SelectedIndexChanged;
            // 
            // addUnitButton
            // 
            addUnitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addUnitButton.BackColor = Color.FromArgb(50, 50, 53);
            addUnitButton.Image = (Image)resources.GetObject("addUnitButton.Image");
            addUnitButton.Location = new Point(216, 3);
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
            optionHeaderPanel.Controls.Add(importOptionsLabel);
            optionHeaderPanel.Controls.Add(importOptionTemplate);
            optionHeaderPanel.Controls.Add(exportOptionsLabel);
            optionHeaderPanel.Controls.Add(exportOptionTemplate);
            optionHeaderPanel.Controls.Add(optionLabel);
            optionHeaderPanel.Location = new Point(795, 40);
            optionHeaderPanel.Name = "optionHeaderPanel";
            optionHeaderPanel.Size = new Size(327, 40);
            optionHeaderPanel.TabIndex = 37;
            // 
            // importOptionsLabel
            // 
            importOptionsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            importOptionsLabel.AutoSize = true;
            importOptionsLabel.BackColor = Color.Transparent;
            importOptionsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            importOptionsLabel.ForeColor = Color.DarkGray;
            importOptionsLabel.Location = new Point(172, 20);
            importOptionsLabel.Name = "importOptionsLabel";
            importOptionsLabel.Size = new Size(134, 15);
            importOptionsLabel.TabIndex = 66;
            importOptionsLabel.Text = "Opciók sablon betöltése:";
            // 
            // importOptionTemplate
            // 
            importOptionTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            importOptionTemplate.BackColor = Color.FromArgb(40, 40, 45);
            importOptionTemplate.Image = (Image)resources.GetObject("importOptionTemplate.Image");
            importOptionTemplate.Location = new Point(305, 18);
            importOptionTemplate.Name = "importOptionTemplate";
            importOptionTemplate.Size = new Size(20, 20);
            importOptionTemplate.SizeMode = PictureBoxSizeMode.StretchImage;
            importOptionTemplate.TabIndex = 65;
            importOptionTemplate.TabStop = false;
            importOptionTemplate.Click += importOptionTemplate_Click;
            // 
            // exportOptionsLabel
            // 
            exportOptionsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exportOptionsLabel.AutoSize = true;
            exportOptionsLabel.BackColor = Color.Transparent;
            exportOptionsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            exportOptionsLabel.ForeColor = Color.DarkGray;
            exportOptionsLabel.Location = new Point(172, 2);
            exportOptionsLabel.Name = "exportOptionsLabel";
            exportOptionsLabel.Size = new Size(131, 15);
            exportOptionsLabel.TabIndex = 64;
            exportOptionsLabel.Text = "Opciók sablon mentése:";
            // 
            // exportOptionTemplate
            // 
            exportOptionTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exportOptionTemplate.BackColor = Color.FromArgb(40, 40, 45);
            exportOptionTemplate.Image = (Image)resources.GetObject("exportOptionTemplate.Image");
            exportOptionTemplate.Location = new Point(307, -1);
            exportOptionTemplate.Name = "exportOptionTemplate";
            exportOptionTemplate.Size = new Size(20, 20);
            exportOptionTemplate.SizeMode = PictureBoxSizeMode.StretchImage;
            exportOptionTemplate.TabIndex = 62;
            exportOptionTemplate.TabStop = false;
            exportOptionTemplate.Click += exportOptionTemplate_Click;
            // 
            // optionLabel
            // 
            optionLabel.AutoSize = true;
            optionLabel.BackColor = Color.FromArgb(40, 40, 43);
            optionLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            optionLabel.ForeColor = Color.White;
            optionLabel.Location = new Point(3, 8);
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
            optionsPanel.Location = new Point(795, 77);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new Size(327, 388);
            optionsPanel.TabIndex = 38;
            // 
            // unitsPanel
            // 
            unitsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            unitsPanel.AutoScroll = true;
            unitsPanel.BackColor = Color.FromArgb(45, 45, 50);
            unitsPanel.Location = new Point(551, 103);
            unitsPanel.MaximumSize = new Size(950, 10000000);
            unitsPanel.Name = "unitsPanel";
            unitsPanel.Size = new Size(240, 456);
            unitsPanel.TabIndex = 39;
            // 
            // switchToOptionsButton
            // 
            switchToOptionsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            switchToOptionsButton.BackColor = Color.FromArgb(40, 40, 43);
            switchToOptionsButton.FlatStyle = FlatStyle.Popup;
            switchToOptionsButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            switchToOptionsButton.ForeColor = Color.White;
            switchToOptionsButton.Location = new Point(944, 12);
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
            switchToJsLogButton.FlatStyle = FlatStyle.Popup;
            switchToJsLogButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Italic, GraphicsUnit.Point);
            switchToJsLogButton.ForeColor = Color.Silver;
            switchToJsLogButton.Location = new Point(1035, 12);
            switchToJsLogButton.Name = "switchToJsLogButton";
            switchToJsLogButton.Size = new Size(87, 25);
            switchToJsLogButton.TabIndex = 41;
            switchToJsLogButton.Text = "JS log...";
            switchToJsLogButton.UseVisualStyleBackColor = false;
            switchToJsLogButton.Click += OnSwitchToJsLogButtonPressed;
            // 
            // saveTestButton
            // 
            saveTestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveTestButton.BackColor = Color.FromArgb(45, 45, 48);
            saveTestButton.FlatStyle = FlatStyle.Popup;
            saveTestButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            saveTestButton.ForeColor = Color.White;
            saveTestButton.Location = new Point(938, 529);
            saveTestButton.Name = "saveTestButton";
            saveTestButton.Size = new Size(184, 31);
            saveTestButton.TabIndex = 48;
            saveTestButton.Text = "Teszt mentése...";
            saveTestButton.UseVisualStyleBackColor = false;
            saveTestButton.Click += OnSaveTestButtonPressed;
            // 
            // currentlyEditedLabel
            // 
            currentlyEditedLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentlyEditedLabel.AutoSize = true;
            currentlyEditedLabel.BackColor = Color.FromArgb(60, 60, 65);
            currentlyEditedLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            currentlyEditedLabel.ForeColor = Color.White;
            currentlyEditedLabel.Location = new Point(2, 568);
            currentlyEditedLabel.Name = "currentlyEditedLabel";
            currentlyEditedLabel.Size = new Size(169, 19);
            currentlyEditedLabel.TabIndex = 50;
            currentlyEditedLabel.Text = "Jelenleg szerkeztett teszt:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.BackColor = Color.FromArgb(60, 60, 65);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(0, 565);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1134, 46);
            flowLayoutPanel2.TabIndex = 51;
            // 
            // currentlyEditedText
            // 
            currentlyEditedText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            currentlyEditedText.AutoSize = true;
            currentlyEditedText.BackColor = Color.FromArgb(60, 60, 65);
            currentlyEditedText.Font = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point);
            currentlyEditedText.ForeColor = Color.DarkGray;
            currentlyEditedText.Location = new Point(5, 590);
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
            pictureBox3.Location = new Point(1089, 573);
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
            rootLogDirectoryButton.FlatStyle = FlatStyle.Popup;
            rootLogDirectoryButton.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point);
            rootLogDirectoryButton.ForeColor = Color.White;
            rootLogDirectoryButton.Location = new Point(964, 572);
            rootLogDirectoryButton.Name = "rootLogDirectoryButton";
            rootLogDirectoryButton.Size = new Size(120, 31);
            rootLogDirectoryButton.TabIndex = 54;
            rootLogDirectoryButton.Text = "Gyökér log mappa...";
            rootLogDirectoryButton.UseVisualStyleBackColor = false;
            rootLogDirectoryButton.Click += rootLogDirectoryButton_Click;
            // 
            // testNameLabel
            // 
            testNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            testNameLabel.AutoSize = true;
            testNameLabel.BackColor = Color.FromArgb(50, 50, 53);
            testNameLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            testNameLabel.ForeColor = Color.White;
            testNameLabel.Location = new Point(547, 6);
            testNameLabel.Name = "testNameLabel";
            testNameLabel.Size = new Size(136, 37);
            testNameLabel.TabIndex = 55;
            testNameLabel.Text = "testName";
            // 
            // breakpointIcon
            // 
            breakpointIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            breakpointIcon.Image = (Image)resources.GetObject("breakpointIcon.Image");
            breakpointIcon.Location = new Point(767, 17);
            breakpointIcon.Name = "breakpointIcon";
            breakpointIcon.Size = new Size(20, 20);
            breakpointIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointIcon.TabIndex = 56;
            breakpointIcon.TabStop = false;
            breakpointIcon.Visible = false;
            // 
            // testRunTimeText
            // 
            testRunTimeText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DarkGray;
            testRunTimeText.Location = new Point(553, 43);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(174, 30);
            testRunTimeText.TabIndex = 61;
            testRunTimeText.Text = "Előző tesztelés teljes futási ideje:\r\n0 / 0 ms";
            // 
            // ignoreBreakpointsLabel
            // 
            ignoreBreakpointsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ignoreBreakpointsLabel.AutoSize = true;
            ignoreBreakpointsLabel.BackColor = Color.FromArgb(50, 50, 53);
            ignoreBreakpointsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ignoreBreakpointsLabel.ForeColor = Color.White;
            ignoreBreakpointsLabel.Location = new Point(794, 529);
            ignoreBreakpointsLabel.Name = "ignoreBreakpointsLabel";
            ignoreBreakpointsLabel.Size = new Size(138, 30);
            ignoreBreakpointsLabel.TabIndex = 63;
            ignoreBreakpointsLabel.Text = "Breakpoint-ok figyelmen\r\nkívűl hagyása:";
            // 
            // ignoreBreakpointsCheckbox
            // 
            ignoreBreakpointsCheckbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ignoreBreakpointsCheckbox.AutoSize = true;
            ignoreBreakpointsCheckbox.BackColor = Color.FromArgb(50, 50, 53);
            ignoreBreakpointsCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            ignoreBreakpointsCheckbox.ForeColor = Color.White;
            ignoreBreakpointsCheckbox.Location = new Point(880, 546);
            ignoreBreakpointsCheckbox.Name = "ignoreBreakpointsCheckbox";
            ignoreBreakpointsCheckbox.Size = new Size(15, 14);
            ignoreBreakpointsCheckbox.TabIndex = 62;
            ignoreBreakpointsCheckbox.UseVisualStyleBackColor = false;
            ignoreBreakpointsCheckbox.CheckedChanged += ignoreBreakpointsCheckbox_CheckedChanged;
            // 
            // testDateLabel
            // 
            testDateLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            testDateLabel.AutoSize = true;
            testDateLabel.BackColor = Color.Transparent;
            testDateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testDateLabel.ForeColor = Color.DarkGray;
            testDateLabel.Location = new Point(795, 468);
            testDateLabel.Name = "testDateLabel";
            testDateLabel.Size = new Size(155, 15);
            testDateLabel.TabIndex = 64;
            testDateLabel.Text = "Teszt indításának időpontja:";
            // 
            // unitHierarchyButton
            // 
            unitHierarchyButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            unitHierarchyButton.BackColor = Color.FromArgb(40, 40, 43);
            unitHierarchyButton.FlatStyle = FlatStyle.Popup;
            unitHierarchyButton.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Italic, GraphicsUnit.Point);
            unitHierarchyButton.ForeColor = Color.Silver;
            unitHierarchyButton.Location = new Point(795, 12);
            unitHierarchyButton.Name = "unitHierarchyButton";
            unitHierarchyButton.Size = new Size(143, 25);
            unitHierarchyButton.TabIndex = 66;
            unitHierarchyButton.Text = "Unit hierarchia...";
            unitHierarchyButton.UseVisualStyleBackColor = false;
            unitHierarchyButton.Click += unitHierarchyButton_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(50, 50, 53);
            ClientSize = new Size(1134, 611);
            Controls.Add(currentlyEditedLabel);
            Controls.Add(ignoreBreakpointsCheckbox);
            Controls.Add(currentlyEditedText);
            Controls.Add(saveTestButton);
            Controls.Add(unitHierarchyButton);
            Controls.Add(switchToOptionsButton);
            Controls.Add(testDateLabel);
            Controls.Add(ignoreBreakpointsLabel);
            Controls.Add(testRunTimeText);
            Controls.Add(breakpointIcon);
            Controls.Add(rootLogDirectoryButton);
            Controls.Add(pictureBox3);
            Controls.Add(optionHeaderPanel);
            Controls.Add(switchToJsLogButton);
            Controls.Add(unitsPanel);
            Controls.Add(optionsPanel);
            Controls.Add(testStartButton);
            Controls.Add(unitHeaderPanel);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(testNameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 550);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "webSquid Editor";
            Resize += MainForm_Resize;
            unitHeaderPanel.ResumeLayout(false);
            unitHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)addUnitButton).EndInit();
            optionHeaderPanel.ResumeLayout(false);
            optionHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)importOptionTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)exportOptionTemplate).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)breakpointIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button testStartButton;
        private Label unitLabel;
        private Panel unitHeaderPanel;
        private Panel optionHeaderPanel;
        private FlowLayoutPanel optionsPanel;
        private FlowLayoutPanel unitsPanel;
        private Button switchToOptionsButton;
        private Button switchToJsLogButton;
        private Label optionLabel;
        private Button saveTestButton;
        private Label currentlyEditedLabel;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label currentlyEditedText;
        private PictureBox pictureBox3;
        private Button rootLogDirectoryButton;
        private Label testNameLabel;
        private PictureBox addUnitButton;
        private PictureBox breakpointIcon;
        protected Label testRunTimeText;
        private ComboBox gotoUnitComboBox;
        protected Label gotoUnitLabel;
        private PictureBox exportOptionTemplate;
        protected Label exportOptionsLabel;
        protected Label importOptionsLabel;
        private PictureBox importOptionTemplate;
        private Label ignoreBreakpointsLabel;
        private CheckBox ignoreBreakpointsCheckbox;
        protected Label testDateLabel;
        private Button unitHierarchyButton;
    }
}