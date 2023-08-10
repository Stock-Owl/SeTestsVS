namespace WebTestGui
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            mainLabel = new Label();
            mainTextBox = new TextBox();
            infoBox = new PictureBox();
            subLabel = new Label();
            subTextBox = new TextBox();
            mainComboBox = new ComboBox();
            mainCheckbox = new CheckBox();
            hintLabel = new Label();
            folderIcon = new PictureBox();
            searchForFolderButton = new Button();
            ((System.ComponentModel.ISupportInitialize)infoBox).BeginInit();
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
            mainLabel.Size = new Size(97, 25);
            mainLabel.TabIndex = 10;
            mainLabel.Text = "mainLabel";
            // 
            // mainTextBox
            // 
            mainTextBox.BackColor = Color.FromArgb(40, 40, 43);
            mainTextBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            mainTextBox.ForeColor = Color.DarkGray;
            mainTextBox.Location = new Point(25, 30);
            mainTextBox.Name = "mainTextBox";
            mainTextBox.PlaceholderText = "mainTextBox...";
            mainTextBox.Size = new Size(230, 27);
            mainTextBox.TabIndex = 2;
            // 
            // infoBox
            // 
            infoBox.Image = (Image)resources.GetObject("infoBox.Image");
            infoBox.Location = new Point(261, 37);
            infoBox.Name = "infoBox";
            infoBox.Size = new Size(15, 15);
            infoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            infoBox.TabIndex = 39;
            infoBox.TabStop = false;
            infoBox.Click += infoBox_Click;
            // 
            // subLabel
            // 
            subLabel.AutoSize = true;
            subLabel.BackColor = Color.FromArgb(40, 40, 43);
            subLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            subLabel.ForeColor = Color.White;
            subLabel.Location = new Point(45, 64);
            subLabel.Name = "subLabel";
            subLabel.Size = new Size(74, 21);
            subLabel.TabIndex = 40;
            subLabel.Text = "subLabel";
            // 
            // subTextBox
            // 
            subTextBox.BackColor = Color.FromArgb(40, 40, 43);
            subTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            subTextBox.ForeColor = Color.DarkGray;
            subTextBox.Location = new Point(121, 63);
            subTextBox.Name = "subTextBox";
            subTextBox.PlaceholderText = "subTextBox...";
            subTextBox.Size = new Size(168, 23);
            subTextBox.TabIndex = 41;
            // 
            // mainComboBox
            // 
            mainComboBox.BackColor = Color.FromArgb(40, 40, 43);
            mainComboBox.FlatStyle = FlatStyle.Popup;
            mainComboBox.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            mainComboBox.ForeColor = Color.DarkGray;
            mainComboBox.FormattingEnabled = true;
            mainComboBox.Location = new Point(25, 32);
            mainComboBox.Name = "mainComboBox";
            mainComboBox.Size = new Size(163, 25);
            mainComboBox.TabIndex = 42;
            mainComboBox.Text = "mainComboBox...";
            // 
            // mainCheckbox
            // 
            mainCheckbox.AutoSize = true;
            mainCheckbox.BackColor = Color.Transparent;
            mainCheckbox.Checked = true;
            mainCheckbox.CheckState = CheckState.Checked;
            mainCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            mainCheckbox.ForeColor = Color.Silver;
            mainCheckbox.Location = new Point(25, 31);
            mainCheckbox.Name = "mainCheckbox";
            mainCheckbox.Size = new Size(63, 25);
            mainCheckbox.TabIndex = 43;
            mainCheckbox.Text = "Igen";
            mainCheckbox.UseVisualStyleBackColor = false;
            mainCheckbox.CheckedChanged += mainCheckbox_CheckedChanged;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.BackColor = Color.FromArgb(40, 40, 43);
            hintLabel.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            hintLabel.ForeColor = Color.Silver;
            hintLabel.Location = new Point(35, 60);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(36, 13);
            hintLabel.TabIndex = 44;
            hintLabel.Text = "label1";
            hintLabel.Visible = false;
            // 
            // folderIcon
            // 
            folderIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            folderIcon.Image = (Image)resources.GetObject("folderIcon.Image");
            folderIcon.Location = new Point(138, 61);
            folderIcon.Name = "folderIcon";
            folderIcon.Size = new Size(25, 25);
            folderIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            folderIcon.TabIndex = 46;
            folderIcon.TabStop = false;
            folderIcon.Visible = false;
            // 
            // searchForFolderButton
            // 
            searchForFolderButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchForFolderButton.BackColor = Color.FromArgb(40, 40, 43);
            searchForFolderButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchForFolderButton.ForeColor = Color.White;
            searchForFolderButton.Location = new Point(168, 61);
            searchForFolderButton.Name = "searchForFolderButton";
            searchForFolderButton.Size = new Size(87, 25);
            searchForFolderButton.TabIndex = 45;
            searchForFolderButton.Text = "Kiválasztás...";
            searchForFolderButton.UseVisualStyleBackColor = false;
            searchForFolderButton.Visible = false;
            searchForFolderButton.Click += searchForFolderButton_Click;
            // 
            // OptionPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(folderIcon);
            Controls.Add(searchForFolderButton);
            Controls.Add(hintLabel);
            Controls.Add(mainCheckbox);
            Controls.Add(mainComboBox);
            Controls.Add(subTextBox);
            Controls.Add(subLabel);
            Controls.Add(infoBox);
            Controls.Add(mainLabel);
            Controls.Add(mainTextBox);
            Name = "OptionPanel";
            Size = new Size(295, 92);
            ((System.ComponentModel.ISupportInitialize)infoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)folderIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label mainLabel;
        private TextBox mainTextBox;
        private PictureBox infoBox;
        private Label subLabel;
        private TextBox subTextBox;
        private ComboBox mainComboBox;
        private CheckBox mainCheckbox;
        private Label hintLabel;
        private PictureBox folderIcon;
        private Button searchForFolderButton;
    }
}
