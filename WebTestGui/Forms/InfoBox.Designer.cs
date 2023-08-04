namespace WebTestGui
{
    partial class InfoBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoBox));
            okButton = new Button();
            mainLabel = new Label();
            descriptionLabel = new Label();
            informationPicture = new PictureBox();
            warningIcon = new PictureBox();
            errorIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)informationPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)warningIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorIcon).BeginInit();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.BackColor = Color.FromArgb(40, 40, 43);
            okButton.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            okButton.ForeColor = Color.White;
            okButton.Location = new Point(157, 159);
            okButton.Name = "okButton";
            okButton.Size = new Size(120, 40);
            okButton.TabIndex = 10;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += okButton_Click;
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(12, 9);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(142, 37);
            mainLabel.TabIndex = 11;
            mainLabel.Text = "mainLabel";
            // 
            // descriptionLabel
            // 
            descriptionLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            descriptionLabel.ForeColor = Color.DarkGray;
            descriptionLabel.Location = new Point(18, 61);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(346, 95);
            descriptionLabel.TabIndex = 12;
            descriptionLabel.Text = "subLabel";
            // 
            // informationPicture
            // 
            informationPicture.BackColor = Color.Transparent;
            informationPicture.Image = (Image)resources.GetObject("informationPicture.Image");
            informationPicture.InitialImage = (Image)resources.GetObject("informationPicture.InitialImage");
            informationPicture.Location = new Point(372, 6);
            informationPicture.Name = "informationPicture";
            informationPicture.Size = new Size(50, 50);
            informationPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            informationPicture.TabIndex = 13;
            informationPicture.TabStop = false;
            informationPicture.Visible = false;
            // 
            // warningIcon
            // 
            warningIcon.BackColor = Color.Transparent;
            warningIcon.Image = (Image)resources.GetObject("warningIcon.Image");
            warningIcon.InitialImage = (Image)resources.GetObject("warningIcon.InitialImage");
            warningIcon.Location = new Point(372, 5);
            warningIcon.Name = "warningIcon";
            warningIcon.Size = new Size(50, 50);
            warningIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            warningIcon.TabIndex = 14;
            warningIcon.TabStop = false;
            warningIcon.Visible = false;
            // 
            // errorIcon
            // 
            errorIcon.BackColor = Color.Transparent;
            errorIcon.Image = (Image)resources.GetObject("errorIcon.Image");
            errorIcon.InitialImage = null;
            errorIcon.Location = new Point(372, 5);
            errorIcon.Name = "errorIcon";
            errorIcon.Size = new Size(50, 50);
            errorIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            errorIcon.TabIndex = 15;
            errorIcon.TabStop = false;
            errorIcon.Visible = false;
            // 
            // InfoBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 53);
            ClientSize = new Size(434, 211);
            Controls.Add(errorIcon);
            Controls.Add(warningIcon);
            Controls.Add(informationPicture);
            Controls.Add(descriptionLabel);
            Controls.Add(okButton);
            Controls.Add(mainLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(450, 250);
            MinimumSize = new Size(450, 250);
            Name = "InfoBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InfoBox";
            ((System.ComponentModel.ISupportInitialize)informationPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)warningIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button okButton;
        private Label mainLabel;
        private Label descriptionLabel;
        private PictureBox informationPicture;
        private PictureBox warningIcon;
        private PictureBox errorIcon;
    }
}