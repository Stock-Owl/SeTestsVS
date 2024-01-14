namespace WebTestGui
{
    partial class Launcher
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            panel1 = new Panel();
            vsLogo = new PictureBox();
            versionLabel = new Label();
            label2 = new Label();
            label1 = new Label();
            openTestButton = new Button();
            createTestButton = new Button();
            startQuickTestButton = new Button();
            scheduledTestLogLoadButton = new Button();
            label3 = new Label();
            lastOpenedTestsPanel = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vsLogo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(40, 40, 43);
            panel1.Controls.Add(vsLogo);
            panel1.Controls.Add(versionLabel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-8, -30);
            panel1.Name = "panel1";
            panel1.Size = new Size(719, 116);
            panel1.TabIndex = 0;
            // 
            // vsLogo
            // 
            vsLogo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            vsLogo.BackColor = Color.FromArgb(40, 40, 43);
            vsLogo.Image = (Image)resources.GetObject("vsLogo.Image");
            vsLogo.Location = new Point(619, 25);
            vsLogo.Name = "vsLogo";
            vsLogo.Size = new Size(90, 90);
            vsLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            vsLogo.TabIndex = 48;
            vsLogo.TabStop = false;
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            versionLabel.ForeColor = Color.FromArgb(150, 150, 155);
            versionLabel.Location = new Point(528, 46);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(95, 54);
            versionLabel.TabIndex = 2;
            versionLabel.Text = "v0.0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 35.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(299, 39);
            label2.Name = "label2";
            label2.Size = new Size(243, 62);
            label2.TabIndex = 1;
            label2.Text = "webSquid";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 45);
            label1.Name = "label1";
            label1.Size = new Size(297, 54);
            label1.TabIndex = 0;
            label1.Text = "Vision Software";
            // 
            // openTestButton
            // 
            openTestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            openTestButton.BackColor = Color.FromArgb(45, 45, 48);
            openTestButton.FlatStyle = FlatStyle.Popup;
            openTestButton.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            openTestButton.ForeColor = Color.White;
            openTestButton.Location = new Point(439, 140);
            openTestButton.Name = "openTestButton";
            openTestButton.Size = new Size(225, 47);
            openTestButton.TabIndex = 8;
            openTestButton.Text = "Teszt megnyitása";
            openTestButton.UseVisualStyleBackColor = false;
            openTestButton.Click += openTestButton_Click;
            // 
            // createTestButton
            // 
            createTestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            createTestButton.BackColor = Color.FromArgb(45, 45, 48);
            createTestButton.FlatStyle = FlatStyle.Popup;
            createTestButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            createTestButton.ForeColor = Color.White;
            createTestButton.Location = new Point(439, 203);
            createTestButton.Name = "createTestButton";
            createTestButton.Size = new Size(225, 47);
            createTestButton.TabIndex = 9;
            createTestButton.Text = "Teszt létrehozása";
            createTestButton.UseVisualStyleBackColor = false;
            createTestButton.Click += createTestButton_Click;
            // 
            // startQuickTestButton
            // 
            startQuickTestButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startQuickTestButton.BackColor = Color.FromArgb(45, 45, 48);
            startQuickTestButton.FlatStyle = FlatStyle.Popup;
            startQuickTestButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            startQuickTestButton.ForeColor = Color.White;
            startQuickTestButton.Location = new Point(439, 270);
            startQuickTestButton.Name = "startQuickTestButton";
            startQuickTestButton.Size = new Size(225, 38);
            startQuickTestButton.TabIndex = 10;
            startQuickTestButton.Text = "Gyorstesztelés...";
            startQuickTestButton.UseVisualStyleBackColor = false;
            startQuickTestButton.Click += startQuickTestButton_Click;
            // 
            // scheduledTestLogLoadButton
            // 
            scheduledTestLogLoadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            scheduledTestLogLoadButton.BackColor = Color.FromArgb(45, 45, 48);
            scheduledTestLogLoadButton.FlatStyle = FlatStyle.Popup;
            scheduledTestLogLoadButton.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            scheduledTestLogLoadButton.ForeColor = Color.White;
            scheduledTestLogLoadButton.Location = new Point(439, 325);
            scheduledTestLogLoadButton.Name = "scheduledTestLogLoadButton";
            scheduledTestLogLoadButton.Size = new Size(225, 34);
            scheduledTestLogLoadButton.TabIndex = 66;
            scheduledTestLogLoadButton.Text = "Időzített teszt betöltése...";
            scheduledTestLogLoadButton.UseVisualStyleBackColor = false;
            scheduledTestLogLoadButton.Click += scheduledTestLogLoadButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 98);
            label3.Name = "label3";
            label3.Size = new Size(189, 21);
            label3.TabIndex = 67;
            label3.Text = "Legutóbbiak megnyitása...";
            // 
            // lastOpenedTestsPanel
            // 
            lastOpenedTestsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lastOpenedTestsPanel.AutoScroll = true;
            lastOpenedTestsPanel.BackColor = Color.FromArgb(50, 50, 53);
            lastOpenedTestsPanel.Location = new Point(16, 122);
            lastOpenedTestsPanel.Name = "lastOpenedTestsPanel";
            lastOpenedTestsPanel.Size = new Size(280, 310);
            lastOpenedTestsPanel.TabIndex = 68;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 53);
            ClientSize = new Size(702, 450);
            Controls.Add(lastOpenedTestsPanel);
            Controls.Add(label3);
            Controls.Add(scheduledTestLogLoadButton);
            Controls.Add(startQuickTestButton);
            Controls.Add(createTestButton);
            Controls.Add(openTestButton);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Launcher";
            Text = "webSquid Launcher";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)vsLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label versionLabel;
        private PictureBox vsLogo;
        private Button openTestButton;
        private Button createTestButton;
        private Button startQuickTestButton;
        private Button scheduledTestLogLoadButton;
        private Label label3;
        private FlowLayoutPanel lastOpenedTestsPanel;
    }
}