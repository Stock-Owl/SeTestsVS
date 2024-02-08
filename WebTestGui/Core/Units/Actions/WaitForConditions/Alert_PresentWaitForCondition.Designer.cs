namespace WebTestGui
{
    partial class Alert_PresentWaitForCondition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert_PresentWaitForCondition));
            mainLabel = new Label();
            binImage = new PictureBox();
            presentLabel = new Label();
            presentCheckbox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(9, 10);
            mainLabel.Margin = new Padding(6, 0, 6, 0);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(180, 37);
            mainLabel.TabIndex = 12;
            mainLabel.Text = "Alert_present";
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(9, 75);
            binImage.Margin = new Padding(6);
            binImage.Name = "binImage";
            binImage.Size = new Size(37, 43);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 84;
            binImage.TabStop = false;
            binImage.Click += binImage_Click;
            // 
            // presentLabel
            // 
            presentLabel.AutoSize = true;
            presentLabel.BackColor = Color.Transparent;
            presentLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            presentLabel.ForeColor = Color.White;
            presentLabel.Location = new Point(232, 46);
            presentLabel.Margin = new Padding(6, 0, 6, 0);
            presentLabel.Name = "presentLabel";
            presentLabel.Size = new Size(66, 30);
            presentLabel.TabIndex = 86;
            presentLabel.Text = "Aktív:";
            // 
            // presentCheckbox
            // 
            presentCheckbox.AutoSize = true;
            presentCheckbox.BackColor = Color.Transparent;
            presentCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            presentCheckbox.ForeColor = Color.Silver;
            presentCheckbox.Location = new Point(310, 49);
            presentCheckbox.Margin = new Padding(6);
            presentCheckbox.Name = "presentCheckbox";
            presentCheckbox.Size = new Size(28, 27);
            presentCheckbox.TabIndex = 85;
            presentCheckbox.UseVisualStyleBackColor = false;
            // 
            // Alert_PresentWaitForCondition
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(presentLabel);
            Controls.Add(presentCheckbox);
            Controls.Add(binImage);
            Controls.Add(mainLabel);
            Margin = new Padding(6);
            Name = "Alert_PresentWaitForCondition";
            Size = new Size(509, 128);
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label mainLabel;
        private PictureBox binImage;
        protected Label presentLabel;
        private CheckBox presentCheckbox;
    }
}
