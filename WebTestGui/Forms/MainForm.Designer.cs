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
            this.chromeCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.firefoxCheckBox = new System.Windows.Forms.CheckBox();
            this.testStartButton = new System.Windows.Forms.Button();
            this.unitLabel = new System.Windows.Forms.Label();
            this.unitHeaderPanel = new System.Windows.Forms.Panel();
            this.gotoUnitLabel = new System.Windows.Forms.Label();
            this.gotoUnitComboBox = new System.Windows.Forms.ComboBox();
            this.addUnitButton = new System.Windows.Forms.PictureBox();
            this.optionHeaderPanel = new System.Windows.Forms.Panel();
            this.importOptionsLabel = new System.Windows.Forms.Label();
            this.importOptionTemplate = new System.Windows.Forms.PictureBox();
            this.exportOptionsLabel = new System.Windows.Forms.Label();
            this.exportOptionTemplate = new System.Windows.Forms.PictureBox();
            this.optionLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.unitsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.switchToOptionsButton = new System.Windows.Forms.Button();
            this.switchToJsLogButton = new System.Windows.Forms.Button();
            this.browserLabel = new System.Windows.Forms.Label();
            this.vsLogo = new System.Windows.Forms.PictureBox();
            this.saveTestButton = new System.Windows.Forms.Button();
            this.loadTestButton = new System.Windows.Forms.Button();
            this.currentlyEditedLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.currentlyEditedText = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.rootLogDirectoryButton = new System.Windows.Forms.Button();
            this.testNameLabel = new System.Windows.Forms.Label();
            this.breakpointIcon = new System.Windows.Forms.PictureBox();
            this.testRunTimeText = new System.Windows.Forms.Label();
            this.ignoreBreakpointsLabel = new System.Windows.Forms.Label();
            this.ignoreBreakpointsCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.unitHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addUnitButton)).BeginInit();
            this.optionHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importOptionTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportOptionTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vsLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakpointIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // chromeCheckBox
            // 
            this.chromeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chromeCheckBox.AutoSize = true;
            this.chromeCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.chromeCheckBox.Checked = true;
            this.chromeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chromeCheckBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chromeCheckBox.ForeColor = System.Drawing.Color.White;
            this.chromeCheckBox.Location = new System.Drawing.Point(907, 77);
            this.chromeCheckBox.Name = "chromeCheckBox";
            this.chromeCheckBox.Size = new System.Drawing.Size(83, 24);
            this.chromeCheckBox.TabIndex = 3;
            this.chromeCheckBox.Text = "Chrome";
            this.chromeCheckBox.UseVisualStyleBackColor = false;
            this.chromeCheckBox.Click += new System.EventHandler(this.OnChromeCheckBoxChecked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(989, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1097, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // firefoxCheckBox
            // 
            this.firefoxCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.firefoxCheckBox.AutoSize = true;
            this.firefoxCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.firefoxCheckBox.Checked = true;
            this.firefoxCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.firefoxCheckBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firefoxCheckBox.ForeColor = System.Drawing.Color.White;
            this.firefoxCheckBox.Location = new System.Drawing.Point(1025, 77);
            this.firefoxCheckBox.Name = "firefoxCheckBox";
            this.firefoxCheckBox.Size = new System.Drawing.Size(73, 24);
            this.firefoxCheckBox.TabIndex = 5;
            this.firefoxCheckBox.Text = "Firefox";
            this.firefoxCheckBox.UseVisualStyleBackColor = false;
            this.firefoxCheckBox.Click += new System.EventHandler(this.OnFirefoxCheckBoxChecked);
            // 
            // testStartButton
            // 
            this.testStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.testStartButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.testStartButton.ForeColor = System.Drawing.Color.White;
            this.testStartButton.Location = new System.Drawing.Point(795, 513);
            this.testStartButton.Name = "testStartButton";
            this.testStartButton.Size = new System.Drawing.Size(327, 40);
            this.testStartButton.TabIndex = 7;
            this.testStartButton.Text = "TESZT INDITÁSA...";
            this.testStartButton.UseVisualStyleBackColor = false;
            this.testStartButton.Click += new System.EventHandler(this.OnStartTestButtonPressed);
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.unitLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.unitLabel.ForeColor = System.Drawing.Color.White;
            this.unitLabel.Location = new System.Drawing.Point(3, 3);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(54, 19);
            this.unitLabel.TabIndex = 9;
            this.unitLabel.Text = "Unitok:";
            // 
            // unitHeaderPanel
            // 
            this.unitHeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.unitHeaderPanel.Controls.Add(this.gotoUnitLabel);
            this.unitHeaderPanel.Controls.Add(this.gotoUnitComboBox);
            this.unitHeaderPanel.Controls.Add(this.addUnitButton);
            this.unitHeaderPanel.Controls.Add(this.unitLabel);
            this.unitHeaderPanel.Location = new System.Drawing.Point(412, 77);
            this.unitHeaderPanel.Name = "unitHeaderPanel";
            this.unitHeaderPanel.Size = new System.Drawing.Size(364, 30);
            this.unitHeaderPanel.TabIndex = 9;
            // 
            // gotoUnitLabel
            // 
            this.gotoUnitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gotoUnitLabel.AutoSize = true;
            this.gotoUnitLabel.BackColor = System.Drawing.Color.Transparent;
            this.gotoUnitLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.gotoUnitLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.gotoUnitLabel.Location = new System.Drawing.Point(123, 6);
            this.gotoUnitLabel.Name = "gotoUnitLabel";
            this.gotoUnitLabel.Size = new System.Drawing.Size(79, 15);
            this.gotoUnitLabel.TabIndex = 63;
            this.gotoUnitLabel.Text = "Unit keresése:";
            // 
            // gotoUnitComboBox
            // 
            this.gotoUnitComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gotoUnitComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.gotoUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gotoUnitComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gotoUnitComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.gotoUnitComboBox.ForeColor = System.Drawing.Color.Silver;
            this.gotoUnitComboBox.FormattingEnabled = true;
            this.gotoUnitComboBox.Location = new System.Drawing.Point(208, 3);
            this.gotoUnitComboBox.Name = "gotoUnitComboBox";
            this.gotoUnitComboBox.Size = new System.Drawing.Size(126, 21);
            this.gotoUnitComboBox.TabIndex = 62;
            this.gotoUnitComboBox.DropDown += new System.EventHandler(this.gotoUnitComboBox_DropDown);
            this.gotoUnitComboBox.SelectedIndexChanged += new System.EventHandler(this.gotoUnitComboBox_SelectedIndexChanged);
            // 
            // addUnitButton
            // 
            this.addUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addUnitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.addUnitButton.Image = ((System.Drawing.Image)(resources.GetObject("addUnitButton.Image")));
            this.addUnitButton.Location = new System.Drawing.Point(340, 3);
            this.addUnitButton.Name = "addUnitButton";
            this.addUnitButton.Size = new System.Drawing.Size(20, 20);
            this.addUnitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addUnitButton.TabIndex = 57;
            this.addUnitButton.TabStop = false;
            this.addUnitButton.Click += new System.EventHandler(this.OnAddUnitButtonPressed);
            // 
            // optionHeaderPanel
            // 
            this.optionHeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.optionHeaderPanel.Controls.Add(this.importOptionsLabel);
            this.optionHeaderPanel.Controls.Add(this.importOptionTemplate);
            this.optionHeaderPanel.Controls.Add(this.exportOptionsLabel);
            this.optionHeaderPanel.Controls.Add(this.exportOptionTemplate);
            this.optionHeaderPanel.Controls.Add(this.optionLabel);
            this.optionHeaderPanel.Location = new System.Drawing.Point(795, 136);
            this.optionHeaderPanel.Name = "optionHeaderPanel";
            this.optionHeaderPanel.Size = new System.Drawing.Size(327, 42);
            this.optionHeaderPanel.TabIndex = 37;
            // 
            // importOptionsLabel
            // 
            this.importOptionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importOptionsLabel.AutoSize = true;
            this.importOptionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.importOptionsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.importOptionsLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.importOptionsLabel.Location = new System.Drawing.Point(172, 24);
            this.importOptionsLabel.Name = "importOptionsLabel";
            this.importOptionsLabel.Size = new System.Drawing.Size(134, 15);
            this.importOptionsLabel.TabIndex = 66;
            this.importOptionsLabel.Text = "Opciók sablon betöltése:";
            // 
            // importOptionTemplate
            // 
            this.importOptionTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importOptionTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.importOptionTemplate.Image = ((System.Drawing.Image)(resources.GetObject("importOptionTemplate.Image")));
            this.importOptionTemplate.Location = new System.Drawing.Point(305, 22);
            this.importOptionTemplate.Name = "importOptionTemplate";
            this.importOptionTemplate.Size = new System.Drawing.Size(20, 20);
            this.importOptionTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.importOptionTemplate.TabIndex = 65;
            this.importOptionTemplate.TabStop = false;
            this.importOptionTemplate.Click += new System.EventHandler(this.importOptionTemplate_Click);
            // 
            // exportOptionsLabel
            // 
            this.exportOptionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportOptionsLabel.AutoSize = true;
            this.exportOptionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.exportOptionsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.exportOptionsLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.exportOptionsLabel.Location = new System.Drawing.Point(172, 4);
            this.exportOptionsLabel.Name = "exportOptionsLabel";
            this.exportOptionsLabel.Size = new System.Drawing.Size(131, 15);
            this.exportOptionsLabel.TabIndex = 64;
            this.exportOptionsLabel.Text = "Opciók sablon mentése:";
            // 
            // exportOptionTemplate
            // 
            this.exportOptionTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportOptionTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.exportOptionTemplate.Image = ((System.Drawing.Image)(resources.GetObject("exportOptionTemplate.Image")));
            this.exportOptionTemplate.Location = new System.Drawing.Point(305, 2);
            this.exportOptionTemplate.Name = "exportOptionTemplate";
            this.exportOptionTemplate.Size = new System.Drawing.Size(20, 20);
            this.exportOptionTemplate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exportOptionTemplate.TabIndex = 62;
            this.exportOptionTemplate.TabStop = false;
            this.exportOptionTemplate.Click += new System.EventHandler(this.exportOptionTemplate_Click);
            // 
            // optionLabel
            // 
            this.optionLabel.AutoSize = true;
            this.optionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.optionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.optionLabel.ForeColor = System.Drawing.Color.White;
            this.optionLabel.Location = new System.Drawing.Point(3, 11);
            this.optionLabel.Name = "optionLabel";
            this.optionLabel.Size = new System.Drawing.Size(56, 19);
            this.optionLabel.TabIndex = 45;
            this.optionLabel.Text = "Opciók:";
            // 
            // optionsPanel
            // 
            this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsPanel.AutoScroll = true;
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.optionsPanel.Location = new System.Drawing.Point(795, 178);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(327, 330);
            this.optionsPanel.TabIndex = 38;
            // 
            // unitsPanel
            // 
            this.unitsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitsPanel.AutoScroll = true;
            this.unitsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.unitsPanel.Location = new System.Drawing.Point(412, 103);
            this.unitsPanel.Name = "unitsPanel";
            this.unitsPanel.Size = new System.Drawing.Size(364, 438);
            this.unitsPanel.TabIndex = 39;
            // 
            // switchToOptionsButton
            // 
            this.switchToOptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchToOptionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.switchToOptionsButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.switchToOptionsButton.ForeColor = System.Drawing.Color.White;
            this.switchToOptionsButton.Location = new System.Drawing.Point(794, 105);
            this.switchToOptionsButton.Name = "switchToOptionsButton";
            this.switchToOptionsButton.Size = new System.Drawing.Size(87, 25);
            this.switchToOptionsButton.TabIndex = 40;
            this.switchToOptionsButton.Text = "Opciók...";
            this.switchToOptionsButton.UseVisualStyleBackColor = false;
            this.switchToOptionsButton.Click += new System.EventHandler(this.OnSwitchToOptionsButtonPressed);
            // 
            // switchToJsLogButton
            // 
            this.switchToJsLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchToJsLogButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.switchToJsLogButton.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.switchToJsLogButton.ForeColor = System.Drawing.Color.Silver;
            this.switchToJsLogButton.Location = new System.Drawing.Point(1035, 105);
            this.switchToJsLogButton.Name = "switchToJsLogButton";
            this.switchToJsLogButton.Size = new System.Drawing.Size(87, 25);
            this.switchToJsLogButton.TabIndex = 41;
            this.switchToJsLogButton.Text = "JS log...";
            this.switchToJsLogButton.UseVisualStyleBackColor = false;
            this.switchToJsLogButton.Click += new System.EventHandler(this.OnSwitchToJsLogButtonPressed);
            // 
            // browserLabel
            // 
            this.browserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browserLabel.AutoSize = true;
            this.browserLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.browserLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.browserLabel.ForeColor = System.Drawing.Color.White;
            this.browserLabel.Location = new System.Drawing.Point(795, 76);
            this.browserLabel.Name = "browserLabel";
            this.browserLabel.Size = new System.Drawing.Size(99, 25);
            this.browserLabel.TabIndex = 45;
            this.browserLabel.Text = "Böngésző:";
            // 
            // vsLogo
            // 
            this.vsLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vsLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.vsLogo.Image = ((System.Drawing.Image)(resources.GetObject("vsLogo.Image")));
            this.vsLogo.Location = new System.Drawing.Point(1090, 566);
            this.vsLogo.Name = "vsLogo";
            this.vsLogo.Size = new System.Drawing.Size(48, 48);
            this.vsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.vsLogo.TabIndex = 47;
            this.vsLogo.TabStop = false;
            // 
            // saveTestButton
            // 
            this.saveTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.saveTestButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveTestButton.ForeColor = System.Drawing.Color.White;
            this.saveTestButton.Location = new System.Drawing.Point(795, 572);
            this.saveTestButton.Name = "saveTestButton";
            this.saveTestButton.Size = new System.Drawing.Size(117, 31);
            this.saveTestButton.TabIndex = 48;
            this.saveTestButton.Text = "Teszt mentése...";
            this.saveTestButton.UseVisualStyleBackColor = false;
            this.saveTestButton.Click += new System.EventHandler(this.OnSaveTestButtonPressed);
            // 
            // loadTestButton
            // 
            this.loadTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadTestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.loadTestButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loadTestButton.ForeColor = System.Drawing.Color.White;
            this.loadTestButton.Location = new System.Drawing.Point(952, 572);
            this.loadTestButton.Name = "loadTestButton";
            this.loadTestButton.Size = new System.Drawing.Size(122, 31);
            this.loadTestButton.TabIndex = 49;
            this.loadTestButton.Text = "Teszt betöltése...";
            this.loadTestButton.UseVisualStyleBackColor = false;
            this.loadTestButton.Click += new System.EventHandler(this.OnLoadTestButtonPressed);
            // 
            // currentlyEditedLabel
            // 
            this.currentlyEditedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentlyEditedLabel.AutoSize = true;
            this.currentlyEditedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.currentlyEditedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentlyEditedLabel.ForeColor = System.Drawing.Color.White;
            this.currentlyEditedLabel.Location = new System.Drawing.Point(416, 568);
            this.currentlyEditedLabel.Name = "currentlyEditedLabel";
            this.currentlyEditedLabel.Size = new System.Drawing.Size(169, 19);
            this.currentlyEditedLabel.TabIndex = 50;
            this.currentlyEditedLabel.Text = "Jelenleg szerkeztett teszt:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(412, 565);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(722, 46);
            this.flowLayoutPanel2.TabIndex = 51;
            // 
            // currentlyEditedText
            // 
            this.currentlyEditedText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentlyEditedText.AutoSize = true;
            this.currentlyEditedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.currentlyEditedText.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.currentlyEditedText.ForeColor = System.Drawing.Color.DarkGray;
            this.currentlyEditedText.Location = new System.Drawing.Point(416, 587);
            this.currentlyEditedText.Name = "currentlyEditedText";
            this.currentlyEditedText.Size = new System.Drawing.Size(38, 12);
            this.currentlyEditedText.TabIndex = 52;
            this.currentlyEditedText.Text = "filepath";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(745, 573);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 53;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // rootLogDirectoryButton
            // 
            this.rootLogDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rootLogDirectoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.rootLogDirectoryButton.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rootLogDirectoryButton.ForeColor = System.Drawing.Color.White;
            this.rootLogDirectoryButton.Location = new System.Drawing.Point(620, 572);
            this.rootLogDirectoryButton.Name = "rootLogDirectoryButton";
            this.rootLogDirectoryButton.Size = new System.Drawing.Size(120, 31);
            this.rootLogDirectoryButton.TabIndex = 54;
            this.rootLogDirectoryButton.Text = "Gyökér log mappa...";
            this.rootLogDirectoryButton.UseVisualStyleBackColor = false;
            this.rootLogDirectoryButton.Click += new System.EventHandler(this.rootLogDirectoryButton_Click);
            // 
            // testNameLabel
            // 
            this.testNameLabel.AutoSize = true;
            this.testNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.testNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.testNameLabel.ForeColor = System.Drawing.Color.White;
            this.testNameLabel.Location = new System.Drawing.Point(408, 37);
            this.testNameLabel.Name = "testNameLabel";
            this.testNameLabel.Size = new System.Drawing.Size(136, 37);
            this.testNameLabel.TabIndex = 55;
            this.testNameLabel.Text = "testName";
            // 
            // breakpointIcon
            // 
            this.breakpointIcon.Image = ((System.Drawing.Image)(resources.GetObject("breakpointIcon.Image")));
            this.breakpointIcon.Location = new System.Drawing.Point(544, 47);
            this.breakpointIcon.Name = "breakpointIcon";
            this.breakpointIcon.Size = new System.Drawing.Size(25, 25);
            this.breakpointIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.breakpointIcon.TabIndex = 56;
            this.breakpointIcon.TabStop = false;
            this.breakpointIcon.Visible = false;
            // 
            // testRunTimeText
            // 
            this.testRunTimeText.AutoSize = true;
            this.testRunTimeText.BackColor = System.Drawing.Color.Transparent;
            this.testRunTimeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.testRunTimeText.ForeColor = System.Drawing.Color.DarkGray;
            this.testRunTimeText.Location = new System.Drawing.Point(544, 52);
            this.testRunTimeText.Name = "testRunTimeText";
            this.testRunTimeText.Size = new System.Drawing.Size(218, 15);
            this.testRunTimeText.TabIndex = 61;
            this.testRunTimeText.Text = "Előző tesztelés teljes futási ideje: 0 / 0 ms";
            // 
            // ignoreBreakpointsLabel
            // 
            this.ignoreBreakpointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ignoreBreakpointsLabel.AutoSize = true;
            this.ignoreBreakpointsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.ignoreBreakpointsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ignoreBreakpointsLabel.ForeColor = System.Drawing.Color.White;
            this.ignoreBreakpointsLabel.Location = new System.Drawing.Point(412, 544);
            this.ignoreBreakpointsLabel.Name = "ignoreBreakpointsLabel";
            this.ignoreBreakpointsLabel.Size = new System.Drawing.Size(218, 15);
            this.ignoreBreakpointsLabel.TabIndex = 63;
            this.ignoreBreakpointsLabel.Text = "Breakpoint-ok figyelmen kívűl  hagyása:";
            // 
            // ignoreBreakpointsCheckbox
            // 
            this.ignoreBreakpointsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ignoreBreakpointsCheckbox.AutoSize = true;
            this.ignoreBreakpointsCheckbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.ignoreBreakpointsCheckbox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ignoreBreakpointsCheckbox.ForeColor = System.Drawing.Color.White;
            this.ignoreBreakpointsCheckbox.Location = new System.Drawing.Point(641, 546);
            this.ignoreBreakpointsCheckbox.Name = "ignoreBreakpointsCheckbox";
            this.ignoreBreakpointsCheckbox.Size = new System.Drawing.Size(15, 14);
            this.ignoreBreakpointsCheckbox.TabIndex = 62;
            this.ignoreBreakpointsCheckbox.UseVisualStyleBackColor = false;
            this.ignoreBreakpointsCheckbox.CheckedChanged += new System.EventHandler(this.ignoreBreakpointsCheckbox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1134, 611);
            this.Controls.Add(this.ignoreBreakpointsLabel);
            this.Controls.Add(this.ignoreBreakpointsCheckbox);
            this.Controls.Add(this.testRunTimeText);
            this.Controls.Add(this.breakpointIcon);
            this.Controls.Add(this.rootLogDirectoryButton);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.optionHeaderPanel);
            this.Controls.Add(this.currentlyEditedLabel);
            this.Controls.Add(this.loadTestButton);
            this.Controls.Add(this.saveTestButton);
            this.Controls.Add(this.vsLogo);
            this.Controls.Add(this.browserLabel);
            this.Controls.Add(this.switchToJsLogButton);
            this.Controls.Add(this.switchToOptionsButton);
            this.Controls.Add(this.unitsPanel);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.testStartButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.firefoxCheckBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chromeCheckBox);
            this.Controls.Add(this.unitHeaderPanel);
            this.Controls.Add(this.currentlyEditedText);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.testNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VS WebTeszt";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.unitHeaderPanel.ResumeLayout(false);
            this.unitHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addUnitButton)).EndInit();
            this.optionHeaderPanel.ResumeLayout(false);
            this.optionHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.importOptionTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportOptionTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vsLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakpointIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        protected Label testRunTimeText;
        private ComboBox gotoUnitComboBox;
        protected Label gotoUnitLabel;
        private PictureBox exportOptionTemplate;
        protected Label exportOptionsLabel;
        protected Label importOptionsLabel;
        private PictureBox importOptionTemplate;
        private Label ignoreBreakpointsLabel;
        private CheckBox ignoreBreakpointsCheckbox;
    }
}