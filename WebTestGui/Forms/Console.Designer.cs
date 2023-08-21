namespace WebTestGui
{
    partial class Console
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            consoleTextBox = new RichTextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            chromeButton = new Button();
            firefoxButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // consoleTextBox
            // 
            consoleTextBox.AcceptsTab = true;
            consoleTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            consoleTextBox.BackColor = Color.Black;
            consoleTextBox.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            consoleTextBox.ForeColor = Color.LightBlue;
            consoleTextBox.HideSelection = false;
            consoleTextBox.Location = new Point(0, 0);
            consoleTextBox.Name = "consoleTextBox";
            consoleTextBox.ReadOnly = true;
            consoleTextBox.Size = new Size(342, 323);
            consoleTextBox.TabIndex = 1;
            consoleTextBox.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.BackColor = Color.FromArgb(50, 50, 53);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 329);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox2.BackColor = Color.FromArgb(50, 50, 53);
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(300, 329);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // chromeButton
            // 
            chromeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            chromeButton.BackColor = Color.FromArgb(45, 45, 48);
            chromeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            chromeButton.ForeColor = Color.White;
            chromeButton.Location = new Point(12, 364);
            chromeButton.Name = "chromeButton";
            chromeButton.Size = new Size(95, 31);
            chromeButton.TabIndex = 49;
            chromeButton.Text = "Chrome log...";
            chromeButton.UseVisualStyleBackColor = false;
            chromeButton.Click += chromeButton_Click;
            // 
            // firefoxButton
            // 
            firefoxButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            firefoxButton.BackColor = Color.FromArgb(45, 45, 48);
            firefoxButton.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            firefoxButton.ForeColor = Color.White;
            firefoxButton.Location = new Point(235, 364);
            firefoxButton.Name = "firefoxButton";
            firefoxButton.Size = new Size(95, 31);
            firefoxButton.TabIndex = 50;
            firefoxButton.Text = "Firefox log...";
            firefoxButton.UseVisualStyleBackColor = false;
            firefoxButton.Click += firefoxButton_Click;
            // 
            // Console
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 53);
            Controls.Add(firefoxButton);
            Controls.Add(chromeButton);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(consoleTextBox);
            Name = "Console";
            Size = new Size(342, 403);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public RichTextBox consoleTextBox;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button chromeButton;
        private Button firefoxButton;
    }
}
