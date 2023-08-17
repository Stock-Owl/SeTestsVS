namespace WebTestGui
{
    partial class UnitPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitPanel));
            this.idLabel = new System.Windows.Forms.Label();
            this.binImage = new System.Windows.Forms.PictureBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.backupOfLabel = new System.Windows.Forms.Label();
            this.bindingsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.unitBackupComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.unitBindingsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addActionComboBox = new System.Windows.Forms.ComboBox();
            this.actionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.unitNameTextField = new System.Windows.Forms.TextBox();
            this.collapseActionsButton = new System.Windows.Forms.PictureBox();
            this.expandActionsButtton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.binImage)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collapseActionsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expandActionsButtton)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.BackColor = System.Drawing.Color.Transparent;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idLabel.ForeColor = System.Drawing.Color.White;
            this.idLabel.Location = new System.Drawing.Point(913, 6);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(47, 25);
            this.idLabel.TabIndex = 39;
            this.idLabel.Text = "UID:";
            // 
            // binImage
            // 
            this.binImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.binImage.Image = ((System.Drawing.Image)(resources.GetObject("binImage.Image")));
            this.binImage.Location = new System.Drawing.Point(963, 63);
            this.binImage.Name = "binImage";
            this.binImage.Size = new System.Drawing.Size(30, 30);
            this.binImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.binImage.TabIndex = 37;
            this.binImage.TabStop = false;
            this.binImage.Click += new System.EventHandler(this.Delete);
            // 
            // idTextBox
            // 
            this.idTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.idTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.idTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.idTextBox.Location = new System.Drawing.Point(958, 5);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(35, 25);
            this.idTextBox.TabIndex = 38;
            this.idTextBox.Text = "0";
            this.idTextBox.Leave += new System.EventHandler(this.OnUIdTextBoxFocusLeave);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.mainPanel.Controls.Add(this.backupOfLabel);
            this.mainPanel.Controls.Add(this.bindingsLabel);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.unitBackupComboBox);
            this.mainPanel.Controls.Add(this.label4);
            this.mainPanel.Controls.Add(this.unitBindingsComboBox);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.addActionComboBox);
            this.mainPanel.Controls.Add(this.actionsPanel);
            this.mainPanel.Controls.Add(this.unitNameTextField);
            this.mainPanel.Controls.Add(this.idTextBox);
            this.mainPanel.Controls.Add(this.binImage);
            this.mainPanel.Controls.Add(this.idLabel);
            this.mainPanel.Controls.Add(this.collapseActionsButton);
            this.mainPanel.Controls.Add(this.expandActionsButtton);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 97);
            this.mainPanel.TabIndex = 12;
            // 
            // backupOfLabel
            // 
            this.backupOfLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backupOfLabel.AutoSize = true;
            this.backupOfLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.backupOfLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.backupOfLabel.ForeColor = System.Drawing.Color.LightGray;
            this.backupOfLabel.Location = new System.Drawing.Point(544, 37);
            this.backupOfLabel.Name = "backupOfLabel";
            this.backupOfLabel.Size = new System.Drawing.Size(27, 15);
            this.backupOfLabel.TabIndex = 58;
            this.backupOfLabel.Text = "null";
            // 
            // bindingsLabel
            // 
            this.bindingsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bindingsLabel.AutoSize = true;
            this.bindingsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.bindingsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.bindingsLabel.ForeColor = System.Drawing.Color.LightGray;
            this.bindingsLabel.Location = new System.Drawing.Point(544, 9);
            this.bindingsLabel.Name = "bindingsLabel";
            this.bindingsLabel.Size = new System.Drawing.Size(27, 15);
            this.bindingsLabel.TabIndex = 57;
            this.bindingsLabel.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(418, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Biztonsági Unit:";
            // 
            // unitBackupComboBox
            // 
            this.unitBackupComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitBackupComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.unitBackupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitBackupComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.unitBackupComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.unitBackupComboBox.ForeColor = System.Drawing.Color.Silver;
            this.unitBackupComboBox.FormattingEnabled = true;
            this.unitBackupComboBox.Location = new System.Drawing.Point(540, 34);
            this.unitBackupComboBox.Name = "unitBackupComboBox";
            this.unitBackupComboBox.Size = new System.Drawing.Size(175, 23);
            this.unitBackupComboBox.TabIndex = 53;
            this.unitBackupComboBox.DropDown += new System.EventHandler(this.OnUnitBackupComboBoxDropDown);
            this.unitBackupComboBox.SelectedIndexChanged += new System.EventHandler(this.OnUnitBackupComboBoxSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(431, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 52;
            this.label4.Text = "Kapcsolt Unit:";
            // 
            // unitBindingsComboBox
            // 
            this.unitBindingsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.unitBindingsComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.unitBindingsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitBindingsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.unitBindingsComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.unitBindingsComboBox.ForeColor = System.Drawing.Color.Silver;
            this.unitBindingsComboBox.FormattingEnabled = true;
            this.unitBindingsComboBox.Location = new System.Drawing.Point(540, 5);
            this.unitBindingsComboBox.Name = "unitBindingsComboBox";
            this.unitBindingsComboBox.Size = new System.Drawing.Size(175, 23);
            this.unitBindingsComboBox.TabIndex = 46;
            this.unitBindingsComboBox.DropDown += new System.EventHandler(this.OnUnitBindingsComboBoxDropDown);
            this.unitBindingsComboBox.SelectedIndexChanged += new System.EventHandler(this.OnUnitBindingsComboBoxSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(734, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Akció hozzáadása...";
            // 
            // addActionComboBox
            // 
            this.addActionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addActionComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.addActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addActionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addActionComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.addActionComboBox.ForeColor = System.Drawing.Color.Silver;
            this.addActionComboBox.FormattingEnabled = true;
            this.addActionComboBox.Location = new System.Drawing.Point(730, 6);
            this.addActionComboBox.Name = "addActionComboBox";
            this.addActionComboBox.Size = new System.Drawing.Size(175, 28);
            this.addActionComboBox.TabIndex = 45;
            this.addActionComboBox.SelectedIndexChanged += new System.EventHandler(this.OnActionComboBoxItemSelect);
            // 
            // actionsPanel
            // 
            this.actionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionsPanel.AutoScroll = true;
            this.actionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.actionsPanel.Location = new System.Drawing.Point(78, 63);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(879, 30);
            this.actionsPanel.TabIndex = 43;
            // 
            // unitNameTextField
            // 
            this.unitNameTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitNameTextField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.unitNameTextField.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.unitNameTextField.ForeColor = System.Drawing.Color.White;
            this.unitNameTextField.Location = new System.Drawing.Point(8, 7);
            this.unitNameTextField.Name = "unitNameTextField";
            this.unitNameTextField.PlaceholderText = "Az Unit neve...";
            this.unitNameTextField.Size = new System.Drawing.Size(361, 29);
            this.unitNameTextField.TabIndex = 42;
            // 
            // collapseActionsButton
            // 
            this.collapseActionsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.collapseActionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.collapseActionsButton.Image = ((System.Drawing.Image)(resources.GetObject("collapseActionsButton.Image")));
            this.collapseActionsButton.Location = new System.Drawing.Point(8, 43);
            this.collapseActionsButton.Name = "collapseActionsButton";
            this.collapseActionsButton.Size = new System.Drawing.Size(50, 50);
            this.collapseActionsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.collapseActionsButton.TabIndex = 55;
            this.collapseActionsButton.TabStop = false;
            this.collapseActionsButton.Click += new System.EventHandler(this.OnCollapseActionsButtonClick);
            // 
            // expandActionsButtton
            // 
            this.expandActionsButtton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.expandActionsButtton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.expandActionsButtton.Image = ((System.Drawing.Image)(resources.GetObject("expandActionsButtton.Image")));
            this.expandActionsButtton.Location = new System.Drawing.Point(8, 43);
            this.expandActionsButtton.Name = "expandActionsButtton";
            this.expandActionsButtton.Size = new System.Drawing.Size(50, 50);
            this.expandActionsButtton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.expandActionsButtton.TabIndex = 56;
            this.expandActionsButtton.TabStop = false;
            this.expandActionsButtton.Click += new System.EventHandler(this.OnExpandActionsButttonClick);
            // 
            // UnitPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(1000, 97);
            this.Name = "UnitPanel";
            this.Size = new System.Drawing.Size(1000, 97);
            ((System.ComponentModel.ISupportInitialize)(this.binImage)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collapseActionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expandActionsButtton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected Label idLabel;
        private PictureBox binImage;
        private TextBox idTextBox;
        private Panel mainPanel;
        private TextBox unitNameTextField;
        private FlowLayoutPanel actionsPanel;
        private Label label1;
        private ComboBox addActionComboBox;
        private ComboBox unitBindingsComboBox;
        protected Label label4;
        protected Label label2;
        private ComboBox unitBackupComboBox;
        private PictureBox collapseActionsButton;
        private PictureBox expandActionsButtton;
        private Label bindingsLabel;
        private Label backupOfLabel;
    }
}
