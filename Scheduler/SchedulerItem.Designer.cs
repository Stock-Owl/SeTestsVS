namespace WebTestGui
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
            idLabel = new Label();
            binImage = new PictureBox();
            idTextBox = new TextBox();
            mainLabel = new Label();
            locatorTextBox = new ComboBox();
            testRunTimeText = new Label();
            label1 = new Label();
            testFilePathTextBox = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            timeTypeLabel = new Label();
            timeTypeTextBox = new TextBox();
            msLabel = new Label();
            loadTestButton = new Button();
            folderPath = new TextBox();
            hintLabel = new Label();
            searchForFolderButton = new Button();
            folderIcon = new PictureBox();
            mainPanel = new Panel();
            notReadyIcon = new PictureBox();
            readyIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)folderIcon).BeginInit();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notReadyIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)readyIcon).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.Anchor = AnchorStyles.None;
            idLabel.AutoSize = true;
            idLabel.BackColor = Color.Transparent;
            idLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            idLabel.ForeColor = Color.White;
            idLabel.Location = new Point(434, 5);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(47, 25);
            idLabel.TabIndex = 39;
            idLabel.Text = "UID:";
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.None;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(484, 32);
            binImage.Name = "binImage";
            binImage.Size = new Size(30, 30);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 37;
            binImage.TabStop = false;
            // 
            // idTextBox
            // 
            idTextBox.Anchor = AnchorStyles.None;
            idTextBox.BackColor = Color.FromArgb(40, 40, 43);
            idTextBox.BorderStyle = BorderStyle.FixedSingle;
            idTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(479, 4);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(35, 25);
            idTextBox.TabIndex = 38;
            idTextBox.Text = "0";
            idTextBox.KeyPress += OnIdOverride;
            idTextBox.Leave += OnUIdTextBoxFocusLeave;
            // 
            // mainLabel
            // 
            mainLabel.Anchor = AnchorStyles.None;
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI", 15F, FontStyle.Italic, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.DimGray;
            mainLabel.Location = new Point(3, 3);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(114, 28);
            mainLabel.TabIndex = 54;
            mainLabel.Text = "Teszt neve...";
            // 
            // locatorTextBox
            // 
            locatorTextBox.Anchor = AnchorStyles.None;
            locatorTextBox.BackColor = Color.FromArgb(40, 40, 43);
            locatorTextBox.FlatStyle = FlatStyle.Popup;
            locatorTextBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            locatorTextBox.ForeColor = Color.DarkGray;
            locatorTextBox.FormattingEnabled = true;
            locatorTextBox.Items.AddRange(new object[] { "Az előző teszt után egyből...", "Az előző teszt után ennyi idővel..." });
            locatorTextBox.Location = new Point(123, 75);
            locatorTextBox.Name = "locatorTextBox";
            locatorTextBox.Size = new Size(192, 21);
            locatorTextBox.TabIndex = 76;
            locatorTextBox.Text = "Az előző teszt után egyből...";
            locatorTextBox.SelectedIndexChanged += locatorTextBox_SelectedIndexChanged;
            // 
            // testRunTimeText
            // 
            testRunTimeText.Anchor = AnchorStyles.None;
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(6, 74);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(114, 21);
            testRunTimeText.TabIndex = 77;
            testRunTimeText.Text = "Időzítés módja:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(8, 38);
            label1.Name = "label1";
            label1.Size = new Size(121, 21);
            label1.TabIndex = 78;
            label1.Text = "Időzítendő teszt:";
            // 
            // testFilePathTextBox
            // 
            testFilePathTextBox.Anchor = AnchorStyles.None;
            testFilePathTextBox.BackColor = Color.FromArgb(40, 40, 43);
            testFilePathTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            testFilePathTextBox.ForeColor = Color.DarkGray;
            testFilePathTextBox.Location = new Point(135, 39);
            testFilePathTextBox.Name = "testFilePathTextBox";
            testFilePathTextBox.PlaceholderText = "Tesztfájl (*.vstest) útja...";
            testFilePathTextBox.Size = new Size(192, 22);
            testFilePathTextBox.TabIndex = 79;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(333, 39);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(20, 20);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 80;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(415, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(20, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 81;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // timeTypeLabel
            // 
            timeTypeLabel.Anchor = AnchorStyles.None;
            timeTypeLabel.AutoSize = true;
            timeTypeLabel.BackColor = Color.Transparent;
            timeTypeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            timeTypeLabel.ForeColor = Color.DimGray;
            timeTypeLabel.Location = new Point(321, 75);
            timeTypeLabel.Name = "timeTypeLabel";
            timeTypeLabel.Size = new Size(32, 19);
            timeTypeLabel.TabIndex = 82;
            timeTypeLabel.Text = "Idő:";
            timeTypeLabel.Visible = false;
            // 
            // timeTypeTextBox
            // 
            timeTypeTextBox.Anchor = AnchorStyles.None;
            timeTypeTextBox.BackColor = Color.FromArgb(40, 40, 43);
            timeTypeTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            timeTypeTextBox.ForeColor = Color.DarkGray;
            timeTypeTextBox.Location = new Point(356, 75);
            timeTypeTextBox.Name = "timeTypeTextBox";
            timeTypeTextBox.PlaceholderText = "Várakozási idő...";
            timeTypeTextBox.Size = new Size(125, 22);
            timeTypeTextBox.TabIndex = 83;
            timeTypeTextBox.Text = "10000";
            timeTypeTextBox.Visible = false;
            timeTypeTextBox.TextChanged += timeTypeTextBox_TextChanged;
            // 
            // msLabel
            // 
            msLabel.Anchor = AnchorStyles.None;
            msLabel.AutoSize = true;
            msLabel.BackColor = Color.Transparent;
            msLabel.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            msLabel.ForeColor = Color.DimGray;
            msLabel.Location = new Point(481, 76);
            msLabel.Name = "msLabel";
            msLabel.Size = new Size(27, 19);
            msLabel.TabIndex = 84;
            msLabel.Text = "ms";
            msLabel.Visible = false;
            // 
            // loadTestButton
            // 
            loadTestButton.Anchor = AnchorStyles.None;
            loadTestButton.BackColor = Color.FromArgb(40, 40, 43);
            loadTestButton.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            loadTestButton.ForeColor = Color.White;
            loadTestButton.Location = new Point(356, 37);
            loadTestButton.Name = "loadTestButton";
            loadTestButton.Size = new Size(58, 25);
            loadTestButton.TabIndex = 85;
            loadTestButton.Text = "Betöltés...";
            loadTestButton.UseVisualStyleBackColor = false;
            loadTestButton.Click += loadTestButton_Click;
            // 
            // folderPath
            // 
            folderPath.Anchor = AnchorStyles.None;
            folderPath.BackColor = Color.FromArgb(40, 40, 43);
            folderPath.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            folderPath.ForeColor = Color.DarkGray;
            folderPath.Location = new Point(8, 130);
            folderPath.Name = "folderPath";
            folderPath.PlaceholderText = "A könyvtár abszolút útvonala...";
            folderPath.Size = new Size(378, 25);
            folderPath.TabIndex = 86;
            folderPath.Text = "./logs";
            folderPath.TextChanged += folderPath_TextChanged;
            // 
            // hintLabel
            // 
            hintLabel.Anchor = AnchorStyles.None;
            hintLabel.AutoSize = true;
            hintLabel.BackColor = Color.Transparent;
            hintLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            hintLabel.ForeColor = Color.Silver;
            hintLabel.Location = new Point(4, 107);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(180, 20);
            hintLabel.TabIndex = 87;
            hintLabel.Text = "Gyökér log mappa helye:";
            // 
            // searchForFolderButton
            // 
            searchForFolderButton.Anchor = AnchorStyles.None;
            searchForFolderButton.BackColor = Color.FromArgb(40, 40, 43);
            searchForFolderButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchForFolderButton.ForeColor = Color.White;
            searchForFolderButton.Location = new Point(423, 129);
            searchForFolderButton.Name = "searchForFolderButton";
            searchForFolderButton.Size = new Size(87, 25);
            searchForFolderButton.TabIndex = 88;
            searchForFolderButton.Text = "Kiválasztás...";
            searchForFolderButton.UseVisualStyleBackColor = false;
            searchForFolderButton.Click += folderIcon_Click;
            // 
            // folderIcon
            // 
            folderIcon.Anchor = AnchorStyles.None;
            folderIcon.Image = (Image)resources.GetObject("folderIcon.Image");
            folderIcon.Location = new Point(393, 129);
            folderIcon.Name = "folderIcon";
            folderIcon.Size = new Size(25, 25);
            folderIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            folderIcon.TabIndex = 89;
            folderIcon.TabStop = false;
            folderIcon.Click += folderPath_TextChanged;
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.None;
            mainPanel.BackColor = Color.FromArgb(40, 40, 45);
            mainPanel.Controls.Add(folderIcon);
            mainPanel.Controls.Add(searchForFolderButton);
            mainPanel.Controls.Add(hintLabel);
            mainPanel.Controls.Add(folderPath);
            mainPanel.Controls.Add(loadTestButton);
            mainPanel.Controls.Add(msLabel);
            mainPanel.Controls.Add(timeTypeTextBox);
            mainPanel.Controls.Add(timeTypeLabel);
            mainPanel.Controls.Add(pictureBox1);
            mainPanel.Controls.Add(pictureBox3);
            mainPanel.Controls.Add(testFilePathTextBox);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(testRunTimeText);
            mainPanel.Controls.Add(locatorTextBox);
            mainPanel.Controls.Add(mainLabel);
            mainPanel.Controls.Add(idTextBox);
            mainPanel.Controls.Add(binImage);
            mainPanel.Controls.Add(idLabel);
            mainPanel.Controls.Add(notReadyIcon);
            mainPanel.Controls.Add(readyIcon);
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(567, 164);
            mainPanel.TabIndex = 12;
            // 
            // notReadyIcon
            // 
            notReadyIcon.Anchor = AnchorStyles.None;
            notReadyIcon.Image = (Image)resources.GetObject("notReadyIcon.Image");
            notReadyIcon.Location = new Point(534, 3);
            notReadyIcon.Name = "notReadyIcon";
            notReadyIcon.Size = new Size(30, 30);
            notReadyIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            notReadyIcon.TabIndex = 91;
            notReadyIcon.TabStop = false;
            notReadyIcon.Click += notReadyIcon_Click;
            // 
            // readyIcon
            // 
            readyIcon.Anchor = AnchorStyles.None;
            readyIcon.Image = (Image)resources.GetObject("readyIcon.Image");
            readyIcon.Location = new Point(534, 3);
            readyIcon.Name = "readyIcon";
            readyIcon.Size = new Size(30, 30);
            readyIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            readyIcon.TabIndex = 90;
            readyIcon.TabStop = false;
            // 
            // SchedulerItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 45);
            Controls.Add(mainPanel);
            Name = "SchedulerItem";
            Size = new Size(570, 164);
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)folderIcon).EndInit();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)notReadyIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)readyIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        protected Label idLabel;
        private PictureBox binImage;
        private TextBox idTextBox;
        protected Label mainLabel;
        private ComboBox locatorTextBox;
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
    }
}
