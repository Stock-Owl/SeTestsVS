namespace WebTestGui
{
    partial class TestTabItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestTabItem));
            testNameLabel = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // testNameLabel
            // 
            testNameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testNameLabel.AutoSize = true;
            testNameLabel.BackColor = Color.FromArgb(60, 60, 65);
            testNameLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            testNameLabel.ForeColor = Color.White;
            testNameLabel.Location = new Point(0, 8);
            testNameLabel.Name = "testNameLabel";
            testNameLabel.Size = new Size(58, 13);
            testNameLabel.TabIndex = 51;
            testNameLabel.Text = "testName";
            testNameLabel.Click += testNameLabel_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top;
            pictureBox2.BackColor = Color.FromArgb(50, 50, 53);
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(92, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 52;
            pictureBox2.TabStop = false;
            pictureBox2.Click += DeleteTabItem;
            // 
            // TestTabItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 65);
            Controls.Add(pictureBox2);
            Controls.Add(testNameLabel);
            Name = "TestTabItem";
            Size = new Size(120, 30);
            Click += TestTabItem_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label testNameLabel;
        private PictureBox pictureBox2;
    }
}
