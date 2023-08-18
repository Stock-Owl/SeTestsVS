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
            this.console = new System.Windows.Forms.RichTextBox();
            this.chromeCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.firefoxCheckBox = new System.Windows.Forms.CheckBox();
            this.testStartButton = new System.Windows.Forms.Button();
            this.actionText = new System.Windows.Forms.Label();
            this.actionHeaderPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.optionHeaderPanel = new System.Windows.Forms.Panel();
            this.optionLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.unitsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.switchToOptionsButton = new System.Windows.Forms.Button();
            this.switchToJsLogButton = new System.Windows.Forms.Button();
            this.jsConsole = new System.Windows.Forms.RichTextBox();
            this.browserLabel = new System.Windows.Forms.Label();
            this.vsLogo = new System.Windows.Forms.PictureBox();
            this.saveTestButton = new System.Windows.Forms.Button();
            this.loadTestButton = new System.Windows.Forms.Button();
            this.currentlyEditedLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.currentlyEditedText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.actionHeaderPanel.SuspendLayout();
            this.optionHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vsLogo)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.AcceptsTab = true;
            this.console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.console.BackColor = System.Drawing.Color.Black;
            this.console.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.console.ForeColor = System.Drawing.Color.LightBlue;
            this.console.HideSelection = false;
            this.console.Location = new System.Drawing.Point(-2, -2);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(240, 520);
            this.console.TabIndex = 0;
            this.console.Text = "";
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
            this.chromeCheckBox.Location = new System.Drawing.Point(757, 73);
            this.chromeCheckBox.Name = "chromeCheckBox";
            this.chromeCheckBox.Size = new System.Drawing.Size(83, 24);
            this.chromeCheckBox.TabIndex = 3;
            this.chromeCheckBox.Text = "Chrome";
            this.chromeCheckBox.UseVisualStyleBackColor = false;
            this.chromeCheckBox.CheckedChanged += new System.EventHandler(this.OnChromeCheckBoxChecked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(839, 73);
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
            this.pictureBox2.Location = new System.Drawing.Point(947, 72);
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
            this.firefoxCheckBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firefoxCheckBox.ForeColor = System.Drawing.Color.White;
            this.firefoxCheckBox.Location = new System.Drawing.Point(875, 73);
            this.firefoxCheckBox.Name = "firefoxCheckBox";
            this.firefoxCheckBox.Size = new System.Drawing.Size(73, 24);
            this.firefoxCheckBox.TabIndex = 5;
            this.firefoxCheckBox.Text = "Firefox";
            this.firefoxCheckBox.UseVisualStyleBackColor = false;
            this.firefoxCheckBox.CheckedChanged += new System.EventHandler(this.OnFirefoxCheckBoxChecked);
            // 
            // testStartButton
            // 
            this.testStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.testStartButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.testStartButton.ForeColor = System.Drawing.Color.White;
            this.testStartButton.Location = new System.Drawing.Point(645, 413);
            this.testStartButton.Name = "testStartButton";
            this.testStartButton.Size = new System.Drawing.Size(327, 40);
            this.testStartButton.TabIndex = 7;
            this.testStartButton.Text = "Tesztelés...";
            this.testStartButton.UseVisualStyleBackColor = false;
            this.testStartButton.Click += new System.EventHandler(this.OnStartTestButtonPressed);
            // 
            // actionText
            // 
            this.actionText.AutoSize = true;
            this.actionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.actionText.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.actionText.ForeColor = System.Drawing.Color.White;
            this.actionText.Location = new System.Drawing.Point(3, 2);
            this.actionText.Name = "actionText";
            this.actionText.Size = new System.Drawing.Size(74, 25);
            this.actionText.TabIndex = 9;
            this.actionText.Text = "Unitok:";
            // 
            // actionHeaderPanel
            // 
            this.actionHeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionHeaderPanel.AutoScroll = true;
            this.actionHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.actionHeaderPanel.Controls.Add(this.button1);
            this.actionHeaderPanel.Controls.Add(this.actionText);
            this.actionHeaderPanel.Location = new System.Drawing.Point(243, 64);
            this.actionHeaderPanel.Name = "actionHeaderPanel";
            this.actionHeaderPanel.Size = new System.Drawing.Size(383, 34);
            this.actionHeaderPanel.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(263, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 25);
            this.button1.TabIndex = 41;
            this.button1.Text = "Unit hozzáadása:";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OnAddUnitButtonPressed);
            // 
            // optionHeaderPanel
            // 
            this.optionHeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionHeaderPanel.AutoScroll = true;
            this.optionHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.optionHeaderPanel.Controls.Add(this.optionLabel);
            this.optionHeaderPanel.Location = new System.Drawing.Point(645, 142);
            this.optionHeaderPanel.Name = "optionHeaderPanel";
            this.optionHeaderPanel.Size = new System.Drawing.Size(327, 36);
            this.optionHeaderPanel.TabIndex = 37;
            // 
            // optionLabel
            // 
            this.optionLabel.AutoSize = true;
            this.optionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.optionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.optionLabel.ForeColor = System.Drawing.Color.White;
            this.optionLabel.Location = new System.Drawing.Point(3, 5);
            this.optionLabel.Name = "optionLabel";
            this.optionLabel.Size = new System.Drawing.Size(77, 25);
            this.optionLabel.TabIndex = 45;
            this.optionLabel.Text = "Opciók:";
            // 
            // optionsPanel
            // 
            this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsPanel.AutoScroll = true;
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.optionsPanel.Location = new System.Drawing.Point(645, 175);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(327, 234);
            this.optionsPanel.TabIndex = 38;
            // 
            // unitsPanel
            // 
            this.unitsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitsPanel.AutoScroll = true;
            this.unitsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.unitsPanel.Location = new System.Drawing.Point(243, 95);
            this.unitsPanel.Name = "unitsPanel";
            this.unitsPanel.Size = new System.Drawing.Size(383, 358);
            this.unitsPanel.TabIndex = 39;
            // 
            // switchToOptionsButton
            // 
            this.switchToOptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchToOptionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.switchToOptionsButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.switchToOptionsButton.ForeColor = System.Drawing.Color.White;
            this.switchToOptionsButton.Location = new System.Drawing.Point(645, 111);
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
            this.switchToJsLogButton.Location = new System.Drawing.Point(885, 111);
            this.switchToJsLogButton.Name = "switchToJsLogButton";
            this.switchToJsLogButton.Size = new System.Drawing.Size(87, 25);
            this.switchToJsLogButton.TabIndex = 41;
            this.switchToJsLogButton.Text = "JS log...";
            this.switchToJsLogButton.UseVisualStyleBackColor = false;
            this.switchToJsLogButton.Click += new System.EventHandler(this.OnSwitchToJsLogButtonPressed);
            // 
            // jsConsole
            // 
            this.jsConsole.AcceptsTab = true;
            this.jsConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsConsole.BackColor = System.Drawing.Color.Black;
            this.jsConsole.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.jsConsole.ForeColor = System.Drawing.Color.LightBlue;
            this.jsConsole.HideSelection = false;
            this.jsConsole.Location = new System.Drawing.Point(645, 142);
            this.jsConsole.Name = "jsConsole";
            this.jsConsole.ReadOnly = true;
            this.jsConsole.Size = new System.Drawing.Size(327, 267);
            this.jsConsole.TabIndex = 44;
            this.jsConsole.Text = "";
            this.jsConsole.Visible = false;
            // 
            // browserLabel
            // 
            this.browserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browserLabel.AutoSize = true;
            this.browserLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.browserLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.browserLabel.ForeColor = System.Drawing.Color.White;
            this.browserLabel.Location = new System.Drawing.Point(645, 72);
            this.browserLabel.Name = "browserLabel";
            this.browserLabel.Size = new System.Drawing.Size(100, 25);
            this.browserLabel.TabIndex = 45;
            this.browserLabel.Text = "Böngésző:";
            // 
            // vsLogo
            // 
            this.vsLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vsLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.vsLogo.Image = ((System.Drawing.Image)(resources.GetObject("vsLogo.Image")));
            this.vsLogo.Location = new System.Drawing.Point(944, 471);
            this.vsLogo.Name = "vsLogo";
            this.vsLogo.Size = new System.Drawing.Size(35, 35);
            this.vsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.vsLogo.TabIndex = 47;
            this.vsLogo.TabStop = false;
            // 
            // saveTestButton
            // 
            this.saveTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.saveTestButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.saveTestButton.ForeColor = System.Drawing.Color.White;
            this.saveTestButton.Location = new System.Drawing.Point(645, 472);
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
            this.loadTestButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.loadTestButton.ForeColor = System.Drawing.Color.White;
            this.loadTestButton.Location = new System.Drawing.Point(802, 472);
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
            this.currentlyEditedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.currentlyEditedLabel.ForeColor = System.Drawing.Color.White;
            this.currentlyEditedLabel.Location = new System.Drawing.Point(243, 468);
            this.currentlyEditedLabel.Name = "currentlyEditedLabel";
            this.currentlyEditedLabel.Size = new System.Drawing.Size(169, 19);
            this.currentlyEditedLabel.TabIndex = 50;
            this.currentlyEditedLabel.Text = "Jelenleg szerkeztett teszt:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.flowLayoutPanel2.Controls.Add(this.pictureBox4);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 465);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(984, 46);
            this.flowLayoutPanel2.TabIndex = 51;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(25, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // currentlyEditedText
            // 
            this.currentlyEditedText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentlyEditedText.AutoSize = true;
            this.currentlyEditedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.currentlyEditedText.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.currentlyEditedText.ForeColor = System.Drawing.Color.DarkGray;
            this.currentlyEditedText.Location = new System.Drawing.Point(243, 487);
            this.currentlyEditedText.Name = "currentlyEditedText";
            this.currentlyEditedText.Size = new System.Drawing.Size(38, 12);
            this.currentlyEditedText.TabIndex = 52;
            this.currentlyEditedText.Text = "filepath";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(984, 511);
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
            this.Controls.Add(this.console);
            this.Controls.Add(this.actionHeaderPanel);
            this.Controls.Add(this.jsConsole);
            this.Controls.Add(this.currentlyEditedText);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VS WebTeszt";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.actionHeaderPanel.ResumeLayout(false);
            this.actionHeaderPanel.PerformLayout();
            this.optionHeaderPanel.ResumeLayout(false);
            this.optionHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vsLogo)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Panel optionHeaderPanel;
        private FlowLayoutPanel optionsPanel;
        private FlowLayoutPanel unitsPanel;
        private Button switchToOptionsButton;
        private Button switchToJsLogButton;
        private RichTextBox jsConsole;
        private Label optionLabel;
        private Label browserLabel;
        private PictureBox vsLogo;
        private Button saveTestButton;
        private Button loadTestButton;
        private Label currentlyEditedLabel;
        private FlowLayoutPanel flowLayoutPanel2;
        private PictureBox pictureBox4;
        private Label currentlyEditedText;
        private Button button1;
    }
}