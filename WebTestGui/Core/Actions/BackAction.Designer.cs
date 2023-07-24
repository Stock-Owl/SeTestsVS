namespace WebTestGui
{
    partial class BackAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackAction));
            mainLabel = new Label();
            mainPanel = new Panel();
            actionTypeLabel = new Label();
            idTextBox = new TextBox();
            binImage = new PictureBox();
            label1 = new Label();
            idLabel = new Label();
            breakpointOffPicture = new PictureBox();
            breakpointOnPicture = new PictureBox();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOffPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOnPicture).BeginInit();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(14, 10);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(54, 25);
            mainLabel.TabIndex = 11;
            mainLabel.Text = "Back:";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 45, 50);
            mainPanel.Controls.Add(actionTypeLabel);
            mainPanel.Controls.Add(idTextBox);
            mainPanel.Controls.Add(binImage);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(mainLabel);
            mainPanel.Controls.Add(idLabel);
            mainPanel.Controls.Add(breakpointOffPicture);
            mainPanel.Controls.Add(breakpointOnPicture);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(863, 58);
            mainPanel.TabIndex = 12;
            // 
            // actionTypeLabel
            // 
            actionTypeLabel.AutoSize = true;
            actionTypeLabel.BackColor = Color.Transparent;
            actionTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            actionTypeLabel.ForeColor = Color.Gray;
            actionTypeLabel.Location = new Point(3, 39);
            actionTypeLabel.Name = "actionTypeLabel";
            actionTypeLabel.Size = new Size(65, 15);
            actionTypeLabel.TabIndex = 42;
            actionTypeLabel.Text = "action:goto";
            // 
            // idTextBox
            // 
            idTextBox.BackColor = Color.FromArgb(40, 40, 43);
            idTextBox.BorderStyle = BorderStyle.FixedSingle;
            idTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(818, 7);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(35, 25);
            idTextBox.TabIndex = 38;
            idTextBox.Text = "0";
            // 
            // binImage
            // 
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(741, 10);
            binImage.Name = "binImage";
            binImage.Size = new Size(35, 35);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 37;
            binImage.TabStop = false;
            binImage.Click += binImage_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(100, 16);
            label1.Name = "label1";
            label1.Size = new Size(225, 15);
            label1.TabIndex = 36;
            label1.Text = "Visszalép a böngeszőben az előző oldalra.";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.BackColor = Color.Transparent;
            idLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            idLabel.ForeColor = Color.White;
            idLabel.Location = new Point(782, 8);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(34, 25);
            idLabel.TabIndex = 39;
            idLabel.Text = "ID:";
            // 
            // breakpointOffPicture
            // 
            breakpointOffPicture.Image = (Image)resources.GetObject("breakpointOffPicture.Image");
            breakpointOffPicture.Location = new Point(710, 15);
            breakpointOffPicture.Name = "breakpointOffPicture";
            breakpointOffPicture.Size = new Size(25, 25);
            breakpointOffPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointOffPicture.TabIndex = 41;
            breakpointOffPicture.TabStop = false;
            breakpointOffPicture.Click += breakpointOffPicture_Click;
            // 
            // breakpointOnPicture
            // 
            breakpointOnPicture.Image = Properties.Resources.BreakpointOnIcon;
            breakpointOnPicture.Location = new Point(710, 15);
            breakpointOnPicture.Name = "breakpointOnPicture";
            breakpointOnPicture.Size = new Size(25, 25);
            breakpointOnPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointOnPicture.TabIndex = 40;
            breakpointOnPicture.TabStop = false;
            breakpointOnPicture.Click += breakpointOnPicture_Click;
            // 
            // BackAction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(mainPanel);
            Name = "BackAction";
            Size = new Size(863, 58);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOffPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOnPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        protected Label mainLabel;
        private Panel mainPanel;
        protected Label label1;
        private PictureBox binImage;
        private TextBox idTextBox;
        protected Label idLabel;
        private PictureBox breakpointOnPicture;
        private PictureBox breakpointOffPicture;
        protected Label actionTypeLabel;
    }
}
