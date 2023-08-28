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
            binImage = new PictureBox();
            mainPanel = new Panel();
            msLabel = new Label();
            timeTypeTextBox = new TextBox();
            timeTypeLabel = new Label();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            testFilePathTextBox = new TextBox();
            label1 = new Label();
            testRunTimeText = new Label();
            locatorTextBox = new ComboBox();
            mainLabel = new Label();
            idTextBox = new TextBox();
            idLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(484, 31);
            binImage.Name = "binImage";
            binImage.Size = new Size(30, 30);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 37;
            binImage.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(40, 40, 45);
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
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(520, 100);
            mainPanel.TabIndex = 12;
            // 
            // msLabel
            // 
            msLabel.AutoSize = true;
            msLabel.BackColor = Color.Transparent;
            msLabel.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            msLabel.ForeColor = Color.DimGray;
            msLabel.Location = new Point(481, 69);
            msLabel.Name = "msLabel";
            msLabel.Size = new Size(27, 19);
            msLabel.TabIndex = 84;
            msLabel.Text = "ms";
            msLabel.Visible = false;
            // 
            // timeTypeTextBox
            // 
            timeTypeTextBox.BackColor = Color.FromArgb(40, 40, 43);
            timeTypeTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            timeTypeTextBox.ForeColor = Color.DarkGray;
            timeTypeTextBox.Location = new Point(356, 68);
            timeTypeTextBox.Name = "timeTypeTextBox";
            timeTypeTextBox.PlaceholderText = "Várakozási idő...";
            timeTypeTextBox.Size = new Size(125, 22);
            timeTypeTextBox.TabIndex = 83;
            timeTypeTextBox.Text = "10000";
            timeTypeTextBox.Visible = false;
            // 
            // timeTypeLabel
            // 
            timeTypeLabel.AutoSize = true;
            timeTypeLabel.BackColor = Color.Transparent;
            timeTypeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            timeTypeLabel.ForeColor = Color.DimGray;
            timeTypeLabel.Location = new Point(321, 68);
            timeTypeLabel.Name = "timeTypeLabel";
            timeTypeLabel.Size = new Size(32, 19);
            timeTypeLabel.TabIndex = 82;
            timeTypeLabel.Text = "Idő:";
            timeTypeLabel.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(356, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(20, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 81;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(330, 39);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(20, 20);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 80;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // testFilePathTextBox
            // 
            testFilePathTextBox.BackColor = Color.FromArgb(40, 40, 43);
            testFilePathTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            testFilePathTextBox.ForeColor = Color.DarkGray;
            testFilePathTextBox.Location = new Point(135, 40);
            testFilePathTextBox.Name = "testFilePathTextBox";
            testFilePathTextBox.PlaceholderText = "Tesztfájl (*.vstest) útja...";
            testFilePathTextBox.Size = new Size(192, 22);
            testFilePathTextBox.TabIndex = 79;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(8, 39);
            label1.Name = "label1";
            label1.Size = new Size(121, 21);
            label1.TabIndex = 78;
            label1.Text = "Időzítendő teszt:";
            // 
            // testRunTimeText
            // 
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(6, 67);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(114, 21);
            testRunTimeText.TabIndex = 77;
            testRunTimeText.Text = "Időzítés módja:";
            // 
            // locatorTextBox
            // 
            locatorTextBox.BackColor = Color.FromArgb(40, 40, 43);
            locatorTextBox.FlatStyle = FlatStyle.Popup;
            locatorTextBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            locatorTextBox.ForeColor = Color.DarkGray;
            locatorTextBox.FormattingEnabled = true;
            locatorTextBox.Items.AddRange(new object[] { "Az előző teszt után egyből...", "Az előző teszt után ennyi idővel..." });
            locatorTextBox.Location = new Point(123, 68);
            locatorTextBox.Name = "locatorTextBox";
            locatorTextBox.Size = new Size(192, 21);
            locatorTextBox.TabIndex = 76;
            locatorTextBox.Text = "Az előző teszt után egyből...";
            locatorTextBox.SelectedIndexChanged += locatorTextBox_SelectedIndexChanged;
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI", 15F, FontStyle.Italic, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.DimGray;
            mainLabel.Location = new Point(3, 4);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(114, 28);
            mainLabel.TabIndex = 54;
            mainLabel.Text = "Teszt neve...";
            // 
            // idTextBox
            // 
            idTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            idTextBox.BackColor = Color.FromArgb(40, 40, 43);
            idTextBox.BorderStyle = BorderStyle.FixedSingle;
            idTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(479, 5);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(35, 25);
            idTextBox.TabIndex = 38;
            idTextBox.Text = "0";
            idTextBox.KeyPress += OnIdOverride;
            idTextBox.Leave += OnUIdTextBoxFocusLeave;
            // 
            // idLabel
            // 
            idLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            idLabel.AutoSize = true;
            idLabel.BackColor = Color.Transparent;
            idLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            idLabel.ForeColor = Color.White;
            idLabel.Location = new Point(434, 6);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(47, 25);
            idLabel.TabIndex = 39;
            idLabel.Text = "UID:";
            // 
            // SchedulerItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(mainPanel);
            Name = "SchedulerItem";
            Size = new Size(520, 100);
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox binImage;
        private Panel mainPanel;
        private TextBox idTextBox;
        protected Label idLabel;
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
    }
}
