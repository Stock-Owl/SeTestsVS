namespace WebTestGui
{
    partial class InterceptorAddAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterceptorAddAction));
            breakpointOnPicture = new PictureBox();
            breakpointOffPicture = new PictureBox();
            idLabel = new Label();
            mainLabel = new Label();
            label1 = new Label();
            binImage = new PictureBox();
            idTextBox = new TextBox();
            actionTypeLabel = new Label();
            mainPanel = new Panel();
            label2 = new Label();
            valueTextBox = new TextBox();
            testRunTimeText = new Label();
            testRunTimeLabel = new Label();
            typeTextBox = new ComboBox();
            valueLabel = new Label();
            locatorLabel = new Label();
            keyTextBox = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
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
            mainLabel.Size = new Size(211, 25);
            mainLabel.TabIndex = 11;
            mainLabel.Text = "Interszeptor hozzáadása";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(273, 18);
            label1.Name = "label1";
            label1.Size = new Size(200, 15);
            label1.TabIndex = 36;
            label1.Text = "Hozzáad egy megadott interszeptort.";
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(818, 143);
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
            idTextBox.Leave += OnUIdTextBoxFocusLeave;
            // 
            // actionTypeLabel
            // 
            actionTypeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            actionTypeLabel.AutoSize = true;
            actionTypeLabel.BackColor = Color.Transparent;
            actionTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            actionTypeLabel.ForeColor = Color.Gray;
            actionTypeLabel.Location = new Point(0, 166);
            actionTypeLabel.Name = "actionTypeLabel";
            actionTypeLabel.Size = new Size(64, 15);
            actionTypeLabel.TabIndex = 43;
            actionTypeLabel.Text = "action:click";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 45, 50);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(textBox1);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(valueTextBox);
            mainPanel.Controls.Add(testRunTimeText);
            mainPanel.Controls.Add(testRunTimeLabel);
            mainPanel.Controls.Add(typeTextBox);
            mainPanel.Controls.Add(valueLabel);
            mainPanel.Controls.Add(locatorLabel);
            mainPanel.Controls.Add(keyTextBox);
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
            mainPanel.Size = new Size(863, 181);
            mainPanel.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(209, 127);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 83;
            label2.Text = "Érték:";
            // 
            // valueTextBox
            // 
            valueTextBox.BackColor = Color.FromArgb(40, 40, 43);
            valueTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            valueTextBox.ForeColor = Color.DarkGray;
            valueTextBox.Location = new Point(281, 127);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.PlaceholderText = "Érték...";
            valueTextBox.Size = new Size(350, 22);
            valueTextBox.TabIndex = 82;
            // 
            // testRunTimeText
            // 
            testRunTimeText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(470, 163);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(48, 15);
            testRunTimeText.TabIndex = 81;
            testRunTimeText.Text = "0 / 0 ms";
            // 
            // testRunTimeLabel
            // 
            testRunTimeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            testRunTimeLabel.AutoSize = true;
            testRunTimeLabel.BackColor = Color.Transparent;
            testRunTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeLabel.ForeColor = Color.Gray;
            testRunTimeLabel.Location = new Point(313, 163);
            testRunTimeLabel.Name = "testRunTimeLabel";
            testRunTimeLabel.Size = new Size(157, 15);
            testRunTimeLabel.TabIndex = 80;
            testRunTimeLabel.Text = "Előző tesztelésen futási ideje:";
            // 
            // typeTextBox
            // 
            typeTextBox.BackColor = Color.FromArgb(40, 40, 43);
            typeTextBox.FlatStyle = FlatStyle.Popup;
            typeTextBox.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            typeTextBox.ForeColor = Color.DarkGray;
            typeTextBox.FormattingEnabled = true;
            typeTextBox.Items.AddRange(new object[] { "header" });
            typeTextBox.Location = new Point(247, 73);
            typeTextBox.Name = "typeTextBox";
            typeTextBox.Size = new Size(384, 21);
            typeTextBox.TabIndex = 79;
            typeTextBox.Text = "header";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.BackColor = Color.Transparent;
            valueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            valueLabel.ForeColor = Color.White;
            valueLabel.Location = new Point(209, 99);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(49, 21);
            valueLabel.TabIndex = 78;
            valueLabel.Text = "Kulcs:";
            // 
            // locatorLabel
            // 
            locatorLabel.AutoSize = true;
            locatorLabel.BackColor = Color.Transparent;
            locatorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            locatorLabel.ForeColor = Color.White;
            locatorLabel.Location = new Point(175, 73);
            locatorLabel.Name = "locatorLabel";
            locatorLabel.Size = new Size(58, 21);
            locatorLabel.TabIndex = 77;
            locatorLabel.Text = "Típusa:";
            // 
            // keyTextBox
            // 
            keyTextBox.BackColor = Color.FromArgb(40, 40, 43);
            keyTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            keyTextBox.ForeColor = Color.DarkGray;
            keyTextBox.Location = new Point(281, 99);
            keyTextBox.Name = "keyTextBox";
            keyTextBox.PlaceholderText = "Kulcs...";
            keyTextBox.Size = new Size(350, 22);
            keyTextBox.TabIndex = 76;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(192, 46);
            label3.Name = "label3";
            label3.Size = new Size(41, 21);
            label3.TabIndex = 85;
            label3.Text = "Név:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(40, 40, 43);
            textBox1.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            textBox1.ForeColor = Color.DarkGray;
            textBox1.Location = new Point(247, 45);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Interszeptor neve:";
            textBox1.Size = new Size(384, 22);
            textBox1.TabIndex = 84;
            // 
            // InterceptorAddAction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(mainPanel);
            Name = "InterceptorAddAction";
            Size = new Size(863, 181);
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
        private Panel mainPanel;
        protected Label valueLabel;
        protected Label locatorLabel;
        private TextBox keyTextBox;
        private ComboBox typeTextBox;
        protected Label testRunTimeText;
        protected Label testRunTimeLabel;
        protected Label label2;
        private TextBox valueTextBox;
        protected Label label3;
        private TextBox textBox1;
    }
}
