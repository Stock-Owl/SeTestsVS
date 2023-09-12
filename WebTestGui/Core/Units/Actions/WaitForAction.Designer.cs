namespace WebTestGui
{
    partial class WaitForAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForAction));
            this.breakpointOnPicture = new System.Windows.Forms.PictureBox();
            this.breakpointOffPicture = new System.Windows.Forms.PictureBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.mainLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.binImage = new System.Windows.Forms.PictureBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.actionTypeLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.logicModifierComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.testRunTimeText = new System.Windows.Forms.Label();
            this.testRunTimeLabel = new System.Windows.Forms.Label();
            this.locatorTextBox = new System.Windows.Forms.ComboBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.locatorLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.timeOutTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.frequencyTextField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.conditionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.breakpointOnPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakpointOffPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binImage)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // breakpointOnPicture
            // 
            this.breakpointOnPicture.Image = global::WebTestGui.Properties.Resources.BreakpointOnIcon;
            this.breakpointOnPicture.Location = new System.Drawing.Point(828, 38);
            this.breakpointOnPicture.Name = "breakpointOnPicture";
            this.breakpointOnPicture.Size = new System.Drawing.Size(25, 25);
            this.breakpointOnPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.breakpointOnPicture.TabIndex = 40;
            this.breakpointOnPicture.TabStop = false;
            this.breakpointOnPicture.Click += new System.EventHandler(this.breakpointOnPicture_Click);
            // 
            // breakpointOffPicture
            // 
            this.breakpointOffPicture.Image = ((System.Drawing.Image)(resources.GetObject("breakpointOffPicture.Image")));
            this.breakpointOffPicture.Location = new System.Drawing.Point(828, 38);
            this.breakpointOffPicture.Name = "breakpointOffPicture";
            this.breakpointOffPicture.Size = new System.Drawing.Size(25, 25);
            this.breakpointOffPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.breakpointOffPicture.TabIndex = 41;
            this.breakpointOffPicture.TabStop = false;
            this.breakpointOffPicture.Click += new System.EventHandler(this.breakpointOffPicture_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.BackColor = System.Drawing.Color.Transparent;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idLabel.ForeColor = System.Drawing.Color.White;
            this.idLabel.Location = new System.Drawing.Point(782, 8);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(34, 25);
            this.idLabel.TabIndex = 39;
            this.idLabel.Text = "ID:";
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.mainLabel.ForeColor = System.Drawing.Color.White;
            this.mainLabel.Location = new System.Drawing.Point(14, 10);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(87, 25);
            this.mainLabel.TabIndex = 11;
            this.mainLabel.Text = "Wait-For:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(120, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Böngésző várakozásának viselkedéseit lehet beállítani.";
            // 
            // binImage
            // 
            this.binImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.binImage.Image = ((System.Drawing.Image)(resources.GetObject("binImage.Image")));
            this.binImage.Location = new System.Drawing.Point(825, 167);
            this.binImage.Name = "binImage";
            this.binImage.Size = new System.Drawing.Size(35, 35);
            this.binImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.binImage.TabIndex = 37;
            this.binImage.TabStop = false;
            this.binImage.Click += new System.EventHandler(this.binImage_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.idTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.idTextBox.Location = new System.Drawing.Point(818, 7);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(35, 25);
            this.idTextBox.TabIndex = 38;
            this.idTextBox.Text = "0";
            this.idTextBox.Leave += new System.EventHandler(this.OnUIdTextBoxFocusLeave);
            // 
            // actionTypeLabel
            // 
            this.actionTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actionTypeLabel.AutoSize = true;
            this.actionTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.actionTypeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.actionTypeLabel.ForeColor = System.Drawing.Color.Gray;
            this.actionTypeLabel.Location = new System.Drawing.Point(0, 190);
            this.actionTypeLabel.Name = "actionTypeLabel";
            this.actionTypeLabel.Size = new System.Drawing.Size(95, 15);
            this.actionTypeLabel.TabIndex = 43;
            this.actionTypeLabel.Text = "action:send-keys";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.mainPanel.Controls.Add(this.label6);
            this.mainPanel.Controls.Add(this.logicModifierComboBox);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.testRunTimeText);
            this.mainPanel.Controls.Add(this.testRunTimeLabel);
            this.mainPanel.Controls.Add(this.locatorTextBox);
            this.mainPanel.Controls.Add(this.valueLabel);
            this.mainPanel.Controls.Add(this.locatorLabel);
            this.mainPanel.Controls.Add(this.valueTextBox);
            this.mainPanel.Controls.Add(this.timeOutTextBox);
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.frequencyTextField);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.conditionComboBox);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.actionTypeLabel);
            this.mainPanel.Controls.Add(this.idTextBox);
            this.mainPanel.Controls.Add(this.binImage);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.mainLabel);
            this.mainPanel.Controls.Add(this.idLabel);
            this.mainPanel.Controls.Add(this.breakpointOffPicture);
            this.mainPanel.Controls.Add(this.breakpointOnPicture);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(863, 205);
            this.mainPanel.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(71, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 21);
            this.label6.TabIndex = 92;
            this.label6.Text = "Várakozási kondíció:";
            // 
            // logicModifierComboBox
            // 
            this.logicModifierComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.logicModifierComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logicModifierComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.logicModifierComboBox.ForeColor = System.Drawing.Color.DarkGray;
            this.logicModifierComboBox.FormattingEnabled = true;
            this.logicModifierComboBox.Items.AddRange(new object[] {
            "?",
            "!"});
            this.logicModifierComboBox.Location = new System.Drawing.Point(776, 67);
            this.logicModifierComboBox.Name = "logicModifierComboBox";
            this.logicModifierComboBox.Size = new System.Drawing.Size(76, 25);
            this.logicModifierComboBox.TabIndex = 91;
            this.logicModifierComboBox.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(644, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 90;
            this.label2.Text = "Logikai kapcsoló:";
            // 
            // testRunTimeText
            // 
            this.testRunTimeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testRunTimeText.AutoSize = true;
            this.testRunTimeText.BackColor = System.Drawing.Color.Transparent;
            this.testRunTimeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.testRunTimeText.ForeColor = System.Drawing.Color.DimGray;
            this.testRunTimeText.Location = new System.Drawing.Point(361, 187);
            this.testRunTimeText.Name = "testRunTimeText";
            this.testRunTimeText.Size = new System.Drawing.Size(48, 15);
            this.testRunTimeText.TabIndex = 89;
            this.testRunTimeText.Text = "0 / 0 ms";
            // 
            // testRunTimeLabel
            // 
            this.testRunTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testRunTimeLabel.AutoSize = true;
            this.testRunTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.testRunTimeLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.testRunTimeLabel.ForeColor = System.Drawing.Color.Gray;
            this.testRunTimeLabel.Location = new System.Drawing.Point(204, 187);
            this.testRunTimeLabel.Name = "testRunTimeLabel";
            this.testRunTimeLabel.Size = new System.Drawing.Size(157, 15);
            this.testRunTimeLabel.TabIndex = 88;
            this.testRunTimeLabel.Text = "Előző tesztelésen futási ideje:";
            // 
            // locatorTextBox
            // 
            this.locatorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.locatorTextBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.locatorTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.locatorTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.locatorTextBox.FormattingEnabled = true;
            this.locatorTextBox.Items.AddRange(new object[] {
            "xpath",
            "css_selector"});
            this.locatorTextBox.Location = new System.Drawing.Point(202, 118);
            this.locatorTextBox.Name = "locatorTextBox";
            this.locatorTextBox.Size = new System.Drawing.Size(192, 21);
            this.locatorTextBox.TabIndex = 87;
            this.locatorTextBox.Text = "xpath";
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.BackColor = System.Drawing.Color.Transparent;
            this.valueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.valueLabel.ForeColor = System.Drawing.Color.White;
            this.valueLabel.Location = new System.Drawing.Point(130, 145);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(48, 21);
            this.valueLabel.TabIndex = 86;
            this.valueLabel.Text = "Érték:";
            // 
            // locatorLabel
            // 
            this.locatorLabel.AutoSize = true;
            this.locatorLabel.BackColor = System.Drawing.Color.Transparent;
            this.locatorLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.locatorLabel.ForeColor = System.Drawing.Color.White;
            this.locatorLabel.Location = new System.Drawing.Point(130, 118);
            this.locatorLabel.Name = "locatorLabel";
            this.locatorLabel.Size = new System.Drawing.Size(66, 21);
            this.locatorLabel.TabIndex = 85;
            this.locatorLabel.Text = "Lokátor:";
            // 
            // valueTextBox
            // 
            this.valueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.valueTextBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.valueTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.valueTextBox.Location = new System.Drawing.Point(202, 145);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.PlaceholderText = "Érték...";
            this.valueTextBox.Size = new System.Drawing.Size(192, 22);
            this.valueTextBox.TabIndex = 84;
            // 
            // timeOutTextBox
            // 
            this.timeOutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeOutTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.timeOutTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.timeOutTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.timeOutTextBox.Location = new System.Drawing.Point(681, 132);
            this.timeOutTextBox.Name = "timeOutTextBox";
            this.timeOutTextBox.PlaceholderText = "Időtúllépés értéke...";
            this.timeOutTextBox.Size = new System.Drawing.Size(171, 27);
            this.timeOutTextBox.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(559, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "Időtúllépés (ms):";
            // 
            // frequencyTextField
            // 
            this.frequencyTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frequencyTextField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.frequencyTextField.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.frequencyTextField.ForeColor = System.Drawing.Color.DarkGray;
            this.frequencyTextField.Location = new System.Drawing.Point(681, 98);
            this.frequencyTextField.Name = "frequencyTextField";
            this.frequencyTextField.PlaceholderText = "Várakozás gyakorisága...";
            this.frequencyTextField.Size = new System.Drawing.Size(171, 27);
            this.frequencyTextField.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(559, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 55;
            this.label4.Text = "Gyakoriság (ms):";
            // 
            // conditionComboBox
            // 
            this.conditionComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.conditionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.conditionComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.conditionComboBox.ForeColor = System.Drawing.Color.DarkGray;
            this.conditionComboBox.FormattingEnabled = true;
            this.conditionComboBox.Location = new System.Drawing.Point(262, 87);
            this.conditionComboBox.Name = "conditionComboBox";
            this.conditionComboBox.Size = new System.Drawing.Size(132, 25);
            this.conditionComboBox.TabIndex = 54;
            this.conditionComboBox.Text = "loaded";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(132, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 21);
            this.label3.TabIndex = 53;
            this.label3.Text = "Kondíció típusa:";
            // 
            // WaitForAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.mainPanel);
            this.Name = "WaitForAction";
            this.Size = new System.Drawing.Size(863, 205);
            ((System.ComponentModel.ISupportInitialize)(this.breakpointOnPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakpointOffPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binImage)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

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
        private ComboBox conditionComboBox;
        protected Label label3;
        protected Label label4;
        private TextBox frequencyTextField;
        private TextBox timeOutTextBox;
        protected Label label5;
        protected Label valueLabel;
        protected Label locatorLabel;
        private TextBox valueTextBox;
        private ComboBox locatorTextBox;
        protected Label testRunTimeText;
        protected Label testRunTimeLabel;
        private ComboBox logicModifierComboBox;
        protected Label label2;
        protected Label label6;
    }
}
