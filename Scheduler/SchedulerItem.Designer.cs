namespace Scheduler
{
    partial class SchedulerItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulerItem));
            this.idLabel = new System.Windows.Forms.Label();
            this.binImage = new System.Windows.Forms.PictureBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.mainLabel = new System.Windows.Forms.Label();
            this.scheduleTypeTextBox = new System.Windows.Forms.ComboBox();
            this.testRunTimeText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.testFilePathTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timeTypeLabel = new System.Windows.Forms.Label();
            this.timeTypeTextBox = new System.Windows.Forms.TextBox();
            this.msLabel = new System.Windows.Forms.Label();
            this.loadTestButton = new System.Windows.Forms.Button();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.hintLabel = new System.Windows.Forms.Label();
            this.searchForFolderButton = new System.Windows.Forms.Button();
            this.folderIcon = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.peekButton = new System.Windows.Forms.Button();
            this.testRunTimeLabel = new System.Windows.Forms.Label();
            this.notReadyIcon = new System.Windows.Forms.PictureBox();
            this.readyIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.binImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folderIcon)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notReadyIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readyIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.idLabel.AutoSize = true;
            this.idLabel.BackColor = System.Drawing.Color.Transparent;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idLabel.ForeColor = System.Drawing.Color.White;
            this.idLabel.Location = new System.Drawing.Point(434, 5);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(47, 25);
            this.idLabel.TabIndex = 39;
            this.idLabel.Text = "UID:";
            // 
            // binImage
            // 
            this.binImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.binImage.Image = ((System.Drawing.Image)(resources.GetObject("binImage.Image")));
            this.binImage.Location = new System.Drawing.Point(484, 32);
            this.binImage.Name = "binImage";
            this.binImage.Size = new System.Drawing.Size(30, 30);
            this.binImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.binImage.TabIndex = 37;
            this.binImage.TabStop = false;
            this.binImage.Click += new System.EventHandler(this.binImage_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.idTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.idTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.idTextBox.Location = new System.Drawing.Point(479, 4);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(35, 25);
            this.idTextBox.TabIndex = 38;
            this.idTextBox.Text = "0";
            this.idTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnIdOverride);
            this.idTextBox.Leave += new System.EventHandler(this.OnUIdTextBoxFocusLeave);
            // 
            // mainLabel
            // 
            this.mainLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainLabel.AutoSize = true;
            this.mainLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.mainLabel.ForeColor = System.Drawing.Color.DimGray;
            this.mainLabel.Location = new System.Drawing.Point(3, 3);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(114, 28);
            this.mainLabel.TabIndex = 54;
            this.mainLabel.Text = "Teszt neve...";
            // 
            // scheduleTypeTextBox
            // 
            this.scheduleTypeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scheduleTypeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.scheduleTypeTextBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scheduleTypeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.scheduleTypeTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.scheduleTypeTextBox.FormattingEnabled = true;
            this.scheduleTypeTextBox.Items.AddRange(new object[] {
            "Az előző teszt után egyből...",
            "Az előző teszt után ennyi idővel..."});
            this.scheduleTypeTextBox.Location = new System.Drawing.Point(123, 68);
            this.scheduleTypeTextBox.Name = "scheduleTypeTextBox";
            this.scheduleTypeTextBox.Size = new System.Drawing.Size(192, 21);
            this.scheduleTypeTextBox.TabIndex = 76;
            this.scheduleTypeTextBox.Text = "Az előző teszt után egyből...";
            this.scheduleTypeTextBox.SelectedIndexChanged += new System.EventHandler(this.locatorTextBox_SelectedIndexChanged);
            // 
            // testRunTimeText
            // 
            this.testRunTimeText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.testRunTimeText.AutoSize = true;
            this.testRunTimeText.BackColor = System.Drawing.Color.Transparent;
            this.testRunTimeText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.testRunTimeText.ForeColor = System.Drawing.Color.DimGray;
            this.testRunTimeText.Location = new System.Drawing.Point(6, 67);
            this.testRunTimeText.Name = "testRunTimeText";
            this.testRunTimeText.Size = new System.Drawing.Size(114, 21);
            this.testRunTimeText.TabIndex = 77;
            this.testRunTimeText.Text = "Időzítés módja:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 78;
            this.label1.Text = "Időzítendő teszt:";
            // 
            // testFilePathTextBox
            // 
            this.testFilePathTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.testFilePathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.testFilePathTextBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.testFilePathTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.testFilePathTextBox.Location = new System.Drawing.Point(135, 39);
            this.testFilePathTextBox.Name = "testFilePathTextBox";
            this.testFilePathTextBox.PlaceholderText = "Tesztfájl (*.vstest) útja...";
            this.testFilePathTextBox.Size = new System.Drawing.Size(192, 22);
            this.testFilePathTextBox.TabIndex = 79;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(333, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 80;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(415, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 81;
            this.pictureBox1.TabStop = false;
            // 
            // timeTypeLabel
            // 
            this.timeTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeTypeLabel.AutoSize = true;
            this.timeTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeTypeLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.timeTypeLabel.ForeColor = System.Drawing.Color.DimGray;
            this.timeTypeLabel.Location = new System.Drawing.Point(321, 68);
            this.timeTypeLabel.Name = "timeTypeLabel";
            this.timeTypeLabel.Size = new System.Drawing.Size(32, 19);
            this.timeTypeLabel.TabIndex = 82;
            this.timeTypeLabel.Text = "Idő:";
            this.timeTypeLabel.Visible = false;
            // 
            // timeTypeTextBox
            // 
            this.timeTypeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeTypeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.timeTypeTextBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.timeTypeTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.timeTypeTextBox.Location = new System.Drawing.Point(356, 68);
            this.timeTypeTextBox.Name = "timeTypeTextBox";
            this.timeTypeTextBox.PlaceholderText = "Várakozási idő...";
            this.timeTypeTextBox.Size = new System.Drawing.Size(125, 22);
            this.timeTypeTextBox.TabIndex = 83;
            this.timeTypeTextBox.Text = "10";
            this.timeTypeTextBox.Visible = false;
            // 
            // msLabel
            // 
            this.msLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.msLabel.AutoSize = true;
            this.msLabel.BackColor = System.Drawing.Color.Transparent;
            this.msLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.msLabel.ForeColor = System.Drawing.Color.DimGray;
            this.msLabel.Location = new System.Drawing.Point(481, 69);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(15, 19);
            this.msLabel.TabIndex = 84;
            this.msLabel.Text = "s";
            this.msLabel.Visible = false;
            // 
            // loadTestButton
            // 
            this.loadTestButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadTestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.loadTestButton.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadTestButton.ForeColor = System.Drawing.Color.White;
            this.loadTestButton.Location = new System.Drawing.Point(356, 37);
            this.loadTestButton.Name = "loadTestButton";
            this.loadTestButton.Size = new System.Drawing.Size(58, 25);
            this.loadTestButton.TabIndex = 85;
            this.loadTestButton.Text = "Betöltés...";
            this.loadTestButton.UseVisualStyleBackColor = false;
            this.loadTestButton.Click += new System.EventHandler(this.loadTestButton_Click);
            // 
            // folderPath
            // 
            this.folderPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.folderPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.folderPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.folderPath.ForeColor = System.Drawing.Color.DarkGray;
            this.folderPath.Location = new System.Drawing.Point(8, 130);
            this.folderPath.Name = "folderPath";
            this.folderPath.PlaceholderText = "A könyvtár abszolút útvonala...";
            this.folderPath.Size = new System.Drawing.Size(502, 25);
            this.folderPath.TabIndex = 86;
            this.folderPath.Text = "./logs";
            this.folderPath.Click += new System.EventHandler(this.locatorTextBox_SelectedIndexChanged);
            this.folderPath.TextChanged += new System.EventHandler(this.timeTypeTextBox_TextChanged);
            // 
            // hintLabel
            // 
            this.hintLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hintLabel.AutoSize = true;
            this.hintLabel.BackColor = System.Drawing.Color.Transparent;
            this.hintLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.hintLabel.ForeColor = System.Drawing.Color.Silver;
            this.hintLabel.Location = new System.Drawing.Point(4, 107);
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(180, 20);
            this.hintLabel.TabIndex = 87;
            this.hintLabel.Text = "Gyökér log mappa helye:";
            // 
            // searchForFolderButton
            // 
            this.searchForFolderButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchForFolderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.searchForFolderButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchForFolderButton.ForeColor = System.Drawing.Color.White;
            this.searchForFolderButton.Location = new System.Drawing.Point(423, 102);
            this.searchForFolderButton.Name = "searchForFolderButton";
            this.searchForFolderButton.Size = new System.Drawing.Size(87, 25);
            this.searchForFolderButton.TabIndex = 88;
            this.searchForFolderButton.Text = "Kiválasztás...";
            this.searchForFolderButton.UseVisualStyleBackColor = false;
            this.searchForFolderButton.Click += new System.EventHandler(this.searchForFolderButton_Click);
            // 
            // folderIcon
            // 
            this.folderIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.folderIcon.Image = ((System.Drawing.Image)(resources.GetObject("folderIcon.Image")));
            this.folderIcon.Location = new System.Drawing.Point(393, 102);
            this.folderIcon.Name = "folderIcon";
            this.folderIcon.Size = new System.Drawing.Size(25, 25);
            this.folderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.folderIcon.TabIndex = 89;
            this.folderIcon.TabStop = false;
            this.folderIcon.Click += new System.EventHandler(this.searchForFolderButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.mainPanel.Controls.Add(this.peekButton);
            this.mainPanel.Controls.Add(this.testRunTimeLabel);
            this.mainPanel.Controls.Add(this.folderIcon);
            this.mainPanel.Controls.Add(this.searchForFolderButton);
            this.mainPanel.Controls.Add(this.hintLabel);
            this.mainPanel.Controls.Add(this.folderPath);
            this.mainPanel.Controls.Add(this.loadTestButton);
            this.mainPanel.Controls.Add(this.msLabel);
            this.mainPanel.Controls.Add(this.timeTypeTextBox);
            this.mainPanel.Controls.Add(this.timeTypeLabel);
            this.mainPanel.Controls.Add(this.pictureBox1);
            this.mainPanel.Controls.Add(this.pictureBox3);
            this.mainPanel.Controls.Add(this.testFilePathTextBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.testRunTimeText);
            this.mainPanel.Controls.Add(this.scheduleTypeTextBox);
            this.mainPanel.Controls.Add(this.mainLabel);
            this.mainPanel.Controls.Add(this.idTextBox);
            this.mainPanel.Controls.Add(this.binImage);
            this.mainPanel.Controls.Add(this.idLabel);
            this.mainPanel.Controls.Add(this.notReadyIcon);
            this.mainPanel.Controls.Add(this.readyIcon);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(567, 208);
            this.mainPanel.TabIndex = 12;
            // 
            // peekButton
            // 
            this.peekButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.peekButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.peekButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.peekButton.ForeColor = System.Drawing.Color.White;
            this.peekButton.Location = new System.Drawing.Point(266, 161);
            this.peekButton.Name = "peekButton";
            this.peekButton.Size = new System.Drawing.Size(244, 37);
            this.peekButton.TabIndex = 94;
            this.peekButton.Text = "Teszt eredményeinek vizsgálata...";
            this.peekButton.UseVisualStyleBackColor = false;
            this.peekButton.Visible = false;
            this.peekButton.Click += new System.EventHandler(this.firefoxlogbutton_Click);
            // 
            // testRunTimeLabel
            // 
            this.testRunTimeLabel.AutoSize = true;
            this.testRunTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.testRunTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.testRunTimeLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.testRunTimeLabel.Location = new System.Drawing.Point(6, 173);
            this.testRunTimeLabel.Name = "testRunTimeLabel";
            this.testRunTimeLabel.Size = new System.Drawing.Size(201, 15);
            this.testRunTimeLabel.TabIndex = 92;
            this.testRunTimeLabel.Text = "Előző tesztelés teljes futási ideje: 0 ms";
            this.testRunTimeLabel.Visible = false;
            // 
            // notReadyIcon
            // 
            this.notReadyIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notReadyIcon.Image = ((System.Drawing.Image)(resources.GetObject("notReadyIcon.Image")));
            this.notReadyIcon.Location = new System.Drawing.Point(534, 3);
            this.notReadyIcon.Name = "notReadyIcon";
            this.notReadyIcon.Size = new System.Drawing.Size(30, 30);
            this.notReadyIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.notReadyIcon.TabIndex = 91;
            this.notReadyIcon.TabStop = false;
            // 
            // readyIcon
            // 
            this.readyIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.readyIcon.Image = ((System.Drawing.Image)(resources.GetObject("readyIcon.Image")));
            this.readyIcon.Location = new System.Drawing.Point(534, 3);
            this.readyIcon.Name = "readyIcon";
            this.readyIcon.Size = new System.Drawing.Size(30, 30);
            this.readyIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.readyIcon.TabIndex = 90;
            this.readyIcon.TabStop = false;
            // 
            // SchedulerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.mainPanel);
            this.Name = "SchedulerItem";
            this.Size = new System.Drawing.Size(570, 208);
            ((System.ComponentModel.ISupportInitialize)(this.binImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folderIcon)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notReadyIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readyIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Label idLabel;
        private PictureBox binImage;
        private TextBox idTextBox;
        protected Label mainLabel;
        private ComboBox scheduleTypeTextBox;
        protected Label testRunTimeText;
        protected Label label1;
        private TextBox testFilePathTextBox;
        private PictureBox pictureBox3;
        private PictureBox pictureBox1;
        protected Label timeTypeLabel;
        private TextBox timeTypeTextBox;
        protected Label msLabel;
        private Button loadTestButton;
        private TextBox folderPath;
        private Label hintLabel;
        private Button searchForFolderButton;
        private PictureBox folderIcon;
        private Panel mainPanel;
        private PictureBox readyIcon;
        private PictureBox notReadyIcon;
        private Button peekButton;
        protected Label testRunTimeLabel;
    }
}
