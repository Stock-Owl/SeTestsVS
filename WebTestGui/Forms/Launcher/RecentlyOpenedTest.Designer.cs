namespace WebTestGui
{
    partial class RecentlyOpenedTest
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
            testNameLabel = new Label();
            testFilePathLabel = new Label();
            lastOpenedLabel = new Label();
            SuspendLayout();
            // 
            // testNameLabel
            // 
            testNameLabel.AutoSize = true;
            testNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            testNameLabel.ForeColor = Color.White;
            testNameLabel.Location = new Point(3, 1);
            testNameLabel.Name = "testNameLabel";
            testNameLabel.Size = new Size(70, 19);
            testNameLabel.TabIndex = 1;
            testNameLabel.Text = "testname";
            testNameLabel.Click += testNameLabel_Click;
            // 
            // testFilePathLabel
            // 
            testFilePathLabel.AutoSize = true;
            testFilePathLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            testFilePathLabel.ForeColor = Color.FromArgb(150, 150, 155);
            testFilePathLabel.Location = new Point(6, 22);
            testFilePathLabel.Name = "testFilePathLabel";
            testFilePathLabel.Size = new Size(67, 13);
            testFilePathLabel.TabIndex = 3;
            testFilePathLabel.Text = "testFilePath";
            testFilePathLabel.Click += testFilePathLabel_Click;
            // 
            // lastOpenedLabel
            // 
            lastOpenedLabel.AutoSize = true;
            lastOpenedLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lastOpenedLabel.ForeColor = Color.FromArgb(150, 150, 155);
            lastOpenedLabel.Location = new Point(176, 7);
            lastOpenedLabel.Name = "lastOpenedLabel";
            lastOpenedLabel.Size = new Size(71, 13);
            lastOpenedLabel.TabIndex = 4;
            lastOpenedLabel.Text = "openedDate";
            lastOpenedLabel.Click += lastOpenedLabel_Click;
            // 
            // RecentlyOpenedTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 53);
            Controls.Add(lastOpenedLabel);
            Controls.Add(testFilePathLabel);
            Controls.Add(testNameLabel);
            Name = "RecentlyOpenedTest";
            Size = new Size(270, 40);
            Click += RecentlyOpenedTest_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label testNameLabel;
        private Label testFilePathLabel;
        private Label lastOpenedLabel;
    }
}
