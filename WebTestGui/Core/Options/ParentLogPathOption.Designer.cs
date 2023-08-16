namespace WebTestGui
{
    partial class ParentLogPathOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentLogPathOption));
            mainLabel = new Label();
            label4 = new Label();
            folderPath = new TextBox();
            hintLabel = new Label();
            folderIcon = new PictureBox();
            searchForFolderButton = new Button();
            ((System.ComponentModel.ISupportInitialize)folderIcon).BeginInit();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(3, 2);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(218, 25);
            mainLabel.TabIndex = 10;
            mainLabel.Text = "Gyökér logolási könyvtár";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(27, 29);
            label4.Name = "label4";
            label4.Size = new Size(197, 13);
            label4.TabIndex = 51;
            label4.Text = "Ebbe a mappába kerül bele az összes log";
            // 
            // folderPath
            // 
            folderPath.BackColor = Color.FromArgb(40, 40, 43);
            folderPath.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            folderPath.ForeColor = Color.DarkGray;
            folderPath.Location = new Point(44, 79);
            folderPath.Name = "folderPath";
            folderPath.PlaceholderText = "A könyvtár abszolút útvonala...";
            folderPath.Size = new Size(248, 25);
            folderPath.TabIndex = 52;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.BackColor = Color.Transparent;
            hintLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            hintLabel.ForeColor = Color.Silver;
            hintLabel.Location = new Point(3, 57);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(103, 20);
            hintLabel.TabIndex = 53;
            hintLabel.Text = "Mappa helye:";
            // 
            // folderIcon
            // 
            folderIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            folderIcon.Image = (Image)resources.GetObject("folderIcon.Image");
            folderIcon.Location = new Point(175, 108);
            folderIcon.Name = "folderIcon";
            folderIcon.Size = new Size(25, 25);
            folderIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            folderIcon.TabIndex = 55;
            folderIcon.TabStop = false;
            folderIcon.Click += folderIcon_Click;
            // 
            // searchForFolderButton
            // 
            searchForFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchForFolderButton.BackColor = Color.FromArgb(40, 40, 43);
            searchForFolderButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchForFolderButton.ForeColor = Color.White;
            searchForFolderButton.Location = new Point(205, 108);
            searchForFolderButton.Name = "searchForFolderButton";
            searchForFolderButton.Size = new Size(87, 25);
            searchForFolderButton.TabIndex = 54;
            searchForFolderButton.Text = "Kiválasztás...";
            searchForFolderButton.UseVisualStyleBackColor = false;
            searchForFolderButton.Click += searchForFolderButton_Click;
            // 
            // ParentLogPathOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(folderIcon);
            Controls.Add(searchForFolderButton);
            Controls.Add(hintLabel);
            Controls.Add(folderPath);
            Controls.Add(label4);
            Controls.Add(mainLabel);
            Name = "ParentLogPathOption";
            Size = new Size(295, 139);
            ((System.ComponentModel.ISupportInitialize)folderIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        protected Label label4;
        private TextBox folderPath;
        private Label hintLabel;
        private PictureBox folderIcon;
        private Button searchForFolderButton;
    }
}
