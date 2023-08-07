namespace WebTestGui
{
    partial class ClickAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClickAction));
            breakpointOnPicture = new PictureBox();
            breakpointOffPicture = new PictureBox();
            idLabel = new Label();
            mainLabel = new Label();
            label1 = new Label();
            binImage = new PictureBox();
            idTextBox = new TextBox();
            actionTypeLabel = new Label();
            singleCheckbox = new CheckBox();
            singleLabel = new Label();
            label2 = new Label();
            mainPanel = new Panel();
            label8 = new Label();
            selectedCheckBox = new CheckBox();
            label7 = new Label();
            enabledCheckBox = new CheckBox();
            label6 = new Label();
            displayedCheckbox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)breakpointOnPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOffPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // breakpointOnPicture
            // 
            breakpointOnPicture.Image = Properties.Resources.BreakpointOnIcon;
            breakpointOnPicture.Location = new Point(828, 38);
            breakpointOnPicture.Name = "breakpointOnPicture";
            breakpointOnPicture.Size = new Size(25, 25);
            breakpointOnPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointOnPicture.TabIndex = 40;
            breakpointOnPicture.TabStop = false;
            breakpointOnPicture.Click += breakpointOnPicture_Click;
            // 
            // breakpointOffPicture
            // 
            breakpointOffPicture.Image = (Image)resources.GetObject("breakpointOffPicture.Image");
            breakpointOffPicture.Location = new Point(828, 38);
            breakpointOffPicture.Name = "breakpointOffPicture";
            breakpointOffPicture.Size = new Size(25, 25);
            breakpointOffPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            breakpointOffPicture.TabIndex = 41;
            breakpointOffPicture.TabStop = false;
            breakpointOffPicture.Click += breakpointOffPicture_Click;
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
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(14, 10);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(55, 25);
            mainLabel.TabIndex = 11;
            mainLabel.Text = "Click:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(100, 16);
            label1.Name = "label1";
            label1.Size = new Size(161, 15);
            label1.TabIndex = 36;
            label1.Text = "Rákattint a megadott elemre.";
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(818, 185);
            binImage.Name = "binImage";
            binImage.Size = new Size(35, 35);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 37;
            binImage.TabStop = false;
            binImage.Click += binImage_Click;
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
            // actionTypeLabel
            // 
            actionTypeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            actionTypeLabel.AutoSize = true;
            actionTypeLabel.BackColor = Color.Transparent;
            actionTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            actionTypeLabel.ForeColor = Color.Gray;
            actionTypeLabel.Location = new Point(0, 208);
            actionTypeLabel.Name = "actionTypeLabel";
            actionTypeLabel.Size = new Size(64, 15);
            actionTypeLabel.TabIndex = 43;
            actionTypeLabel.Text = "action:click";
            // 
            // singleCheckbox
            // 
            singleCheckbox.AutoSize = true;
            singleCheckbox.BackColor = Color.Transparent;
            singleCheckbox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            singleCheckbox.ForeColor = Color.Silver;
            singleCheckbox.Location = new Point(619, 14);
            singleCheckbox.Name = "singleCheckbox";
            singleCheckbox.Size = new Size(15, 14);
            singleCheckbox.TabIndex = 44;
            singleCheckbox.UseVisualStyleBackColor = false;
            singleCheckbox.CheckedChanged += singleCheckbox_CheckedChanged;
            // 
            // singleLabel
            // 
            singleLabel.AutoSize = true;
            singleLabel.BackColor = Color.Transparent;
            singleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            singleLabel.ForeColor = Color.White;
            singleLabel.Location = new Point(561, 9);
            singleLabel.Name = "singleLabel";
            singleLabel.Size = new Size(44, 21);
            singleLabel.TabIndex = 45;
            singleLabel.Text = "Elem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(651, 13);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 46;
            label2.Text = "Scope selektor";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 45, 50);
            mainPanel.Controls.Add(label8);
            mainPanel.Controls.Add(selectedCheckBox);
            mainPanel.Controls.Add(label7);
            mainPanel.Controls.Add(enabledCheckBox);
            mainPanel.Controls.Add(label6);
            mainPanel.Controls.Add(displayedCheckbox);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(singleLabel);
            mainPanel.Controls.Add(singleCheckbox);
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
            mainPanel.Size = new Size(863, 223);
            mainPanel.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(651, 112);
            label8.Name = "label8";
            label8.Size = new Size(52, 19);
            label8.TabIndex = 70;
            label8.Text = "Kijelölt:";
            // 
            // selectedCheckBox
            // 
            selectedCheckBox.AutoSize = true;
            selectedCheckBox.BackColor = Color.Transparent;
            selectedCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            selectedCheckBox.ForeColor = Color.Silver;
            selectedCheckBox.Location = new Point(744, 116);
            selectedCheckBox.Name = "selectedCheckBox";
            selectedCheckBox.Size = new Size(15, 14);
            selectedCheckBox.TabIndex = 69;
            selectedCheckBox.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(651, 91);
            label7.Name = "label7";
            label7.Size = new Size(77, 19);
            label7.TabIndex = 68;
            label7.Text = "Bekapcsolt:";
            // 
            // enabledCheckBox
            // 
            enabledCheckBox.AutoSize = true;
            enabledCheckBox.BackColor = Color.Transparent;
            enabledCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            enabledCheckBox.ForeColor = Color.Silver;
            enabledCheckBox.Location = new Point(744, 95);
            enabledCheckBox.Name = "enabledCheckBox";
            enabledCheckBox.Size = new Size(15, 14);
            enabledCheckBox.TabIndex = 67;
            enabledCheckBox.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(651, 70);
            label6.Name = "label6";
            label6.Size = new Size(90, 19);
            label6.TabIndex = 66;
            label6.Text = "Megjelenítve:";
            // 
            // displayedCheckbox
            // 
            displayedCheckbox.AutoSize = true;
            displayedCheckbox.BackColor = Color.Transparent;
            displayedCheckbox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            displayedCheckbox.ForeColor = Color.Silver;
            displayedCheckbox.Location = new Point(744, 74);
            displayedCheckbox.Name = "displayedCheckbox";
            displayedCheckbox.Size = new Size(15, 14);
            displayedCheckbox.TabIndex = 65;
            displayedCheckbox.UseVisualStyleBackColor = false;
            // 
            // ClickAction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(mainPanel);
            Name = "ClickAction";
            Size = new Size(863, 223);
            ((System.ComponentModel.ISupportInitialize)breakpointOnPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)breakpointOffPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox breakpointOnPicture;
        private PictureBox breakpointOffPicture;
        protected Label idLabel;
        protected Label mainLabel;
        protected Label label1;
        private PictureBox binImage;
        private TextBox idTextBox;
        protected Label actionTypeLabel;
        private CheckBox singleCheckbox;
        protected Label singleLabel;
        protected Label label2;
        private Panel mainPanel;
        protected Label label8;
        private CheckBox selectedCheckBox;
        protected Label label7;
        private CheckBox enabledCheckBox;
        protected Label label6;
        private CheckBox displayedCheckbox;
    }
}
