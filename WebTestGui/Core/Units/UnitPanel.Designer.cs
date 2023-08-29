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
            idLabel = new Label();
            binImage = new PictureBox();
            idTextBox = new TextBox();
            mainPanel = new Panel();
            resetBackupOfButton = new PictureBox();
            resetBindingButton = new PictureBox();
            testRunTimeText = new Label();
            testRunTimeLabel = new Label();
            backupOfLabel = new Label();
            bindingsLabel = new Label();
            label2 = new Label();
            unitBackupComboBox = new ComboBox();
            label4 = new Label();
            unitBindingsComboBox = new ComboBox();
            label1 = new Label();
            addActionComboBox = new ComboBox();
            actionsPanel = new FlowLayoutPanel();
            unitNameTextField = new TextBox();
            collapseActionsButton = new PictureBox();
            expandActionsButtton = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)binImage).BeginInit();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)resetBackupOfButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resetBindingButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)collapseActionsButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)expandActionsButtton).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.BackColor = Color.Transparent;
            idLabel.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            idLabel.ForeColor = Color.White;
            idLabel.Location = new Point(913, 6);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(47, 25);
            idLabel.TabIndex = 39;
            idLabel.Text = "UID:";
            // 
            // binImage
            // 
            binImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            binImage.Image = (Image)resources.GetObject("binImage.Image");
            binImage.Location = new Point(963, 63);
            binImage.Name = "binImage";
            binImage.Size = new Size(30, 30);
            binImage.SizeMode = PictureBoxSizeMode.StretchImage;
            binImage.TabIndex = 37;
            binImage.TabStop = false;
            binImage.Click += Delete;
            // 
            // idTextBox
            // 
            idTextBox.BackColor = Color.FromArgb(40, 40, 43);
            idTextBox.BorderStyle = BorderStyle.FixedSingle;
            idTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(958, 5);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(35, 25);
            idTextBox.TabIndex = 38;
            idTextBox.Text = "0";
            idTextBox.Leave += OnUIdTextBoxFocusLeave;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 45, 50);
            mainPanel.Controls.Add(collapseActionsButton);
            mainPanel.Controls.Add(resetBackupOfButton);
            mainPanel.Controls.Add(resetBindingButton);
            mainPanel.Controls.Add(testRunTimeText);
            mainPanel.Controls.Add(testRunTimeLabel);
            mainPanel.Controls.Add(backupOfLabel);
            mainPanel.Controls.Add(bindingsLabel);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(unitBackupComboBox);
            mainPanel.Controls.Add(label4);
            mainPanel.Controls.Add(unitBindingsComboBox);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(addActionComboBox);
            mainPanel.Controls.Add(actionsPanel);
            mainPanel.Controls.Add(unitNameTextField);
            mainPanel.Controls.Add(idTextBox);
            mainPanel.Controls.Add(binImage);
            mainPanel.Controls.Add(idLabel);
            mainPanel.Controls.Add(expandActionsButtton);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1000, 97);
            mainPanel.TabIndex = 12;
            // 
            // resetBackupOfButton
            // 
            resetBackupOfButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            resetBackupOfButton.Image = (Image)resources.GetObject("resetBackupOfButton.Image");
            resetBackupOfButton.Location = new Point(696, 35);
            resetBackupOfButton.Name = "resetBackupOfButton";
            resetBackupOfButton.Size = new Size(20, 20);
            resetBackupOfButton.SizeMode = PictureBoxSizeMode.StretchImage;
            resetBackupOfButton.TabIndex = 62;
            resetBackupOfButton.TabStop = false;
            resetBackupOfButton.Click += resetBackupOfButton_Click;
            // 
            // resetBindingButton
            // 
            resetBindingButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            resetBindingButton.Image = (Image)resources.GetObject("resetBindingButton.Image");
            resetBindingButton.Location = new Point(696, 7);
            resetBindingButton.Name = "resetBindingButton";
            resetBindingButton.Size = new Size(20, 20);
            resetBindingButton.SizeMode = PictureBoxSizeMode.StretchImage;
            resetBindingButton.TabIndex = 61;
            resetBindingButton.TabStop = false;
            resetBindingButton.Click += resetBindingButton_Click;
            // 
            // testRunTimeText
            // 
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(235, 41);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(48, 15);
            testRunTimeText.TabIndex = 60;
            testRunTimeText.Text = "0 / 0 ms";
            // 
            // testRunTimeLabel
            // 
            testRunTimeLabel.AutoSize = true;
            testRunTimeLabel.BackColor = Color.Transparent;
            testRunTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeLabel.ForeColor = Color.Gray;
            testRunTimeLabel.Location = new Point(78, 41);
            testRunTimeLabel.Name = "testRunTimeLabel";
            testRunTimeLabel.Size = new Size(157, 15);
            testRunTimeLabel.TabIndex = 59;
            testRunTimeLabel.Text = "Előző tesztelésen futási ideje:";
            // 
            // backupOfLabel
            // 
            backupOfLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            backupOfLabel.AutoSize = true;
            backupOfLabel.BackColor = Color.FromArgb(40, 40, 43);
            backupOfLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            backupOfLabel.ForeColor = Color.LightGray;
            backupOfLabel.Location = new Point(519, 37);
            backupOfLabel.Name = "backupOfLabel";
            backupOfLabel.Size = new Size(27, 15);
            backupOfLabel.TabIndex = 58;
            backupOfLabel.Text = "null";
            // 
            // bindingsLabel
            // 
            bindingsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bindingsLabel.AutoSize = true;
            bindingsLabel.BackColor = Color.FromArgb(40, 40, 43);
            bindingsLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            bindingsLabel.ForeColor = Color.LightGray;
            bindingsLabel.Location = new Point(519, 9);
            bindingsLabel.Name = "bindingsLabel";
            bindingsLabel.Size = new Size(27, 15);
            bindingsLabel.TabIndex = 57;
            bindingsLabel.Text = "null";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(393, 37);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 54;
            label2.Text = "Biztonsági Unit:";
            // 
            // unitBackupComboBox
            // 
            unitBackupComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            unitBackupComboBox.BackColor = Color.FromArgb(40, 40, 43);
            unitBackupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            unitBackupComboBox.FlatStyle = FlatStyle.Popup;
            unitBackupComboBox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            unitBackupComboBox.ForeColor = Color.Silver;
            unitBackupComboBox.FormattingEnabled = true;
            unitBackupComboBox.Location = new Point(515, 34);
            unitBackupComboBox.Name = "unitBackupComboBox";
            unitBackupComboBox.Size = new Size(175, 23);
            unitBackupComboBox.TabIndex = 53;
            unitBackupComboBox.DropDown += OnUnitBackupComboBoxDropDown;
            unitBackupComboBox.SelectedIndexChanged += OnUnitBackupComboBoxSelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(406, 7);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 52;
            label4.Text = "Kapcsolt Unit:";
            // 
            // unitBindingsComboBox
            // 
            unitBindingsComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            unitBindingsComboBox.BackColor = Color.FromArgb(40, 40, 43);
            unitBindingsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            unitBindingsComboBox.FlatStyle = FlatStyle.Popup;
            unitBindingsComboBox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            unitBindingsComboBox.ForeColor = Color.Silver;
            unitBindingsComboBox.FormattingEnabled = true;
            unitBindingsComboBox.Location = new Point(515, 5);
            unitBindingsComboBox.Name = "unitBindingsComboBox";
            unitBindingsComboBox.Size = new Size(175, 23);
            unitBindingsComboBox.TabIndex = 46;
            unitBindingsComboBox.DropDown += OnUnitBindingsComboBoxDropDown;
            unitBindingsComboBox.SelectedIndexChanged += OnUnitBindingsComboBoxSelectedIndexChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(40, 40, 43);
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(734, 10);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 44;
            label1.Text = "Akció hozzáadása...";
            // 
            // addActionComboBox
            // 
            addActionComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addActionComboBox.BackColor = Color.FromArgb(40, 40, 43);
            addActionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            addActionComboBox.FlatStyle = FlatStyle.Popup;
            addActionComboBox.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            addActionComboBox.ForeColor = Color.Silver;
            addActionComboBox.FormattingEnabled = true;
            addActionComboBox.Location = new Point(730, 6);
            addActionComboBox.Name = "addActionComboBox";
            addActionComboBox.Size = new Size(175, 28);
            addActionComboBox.TabIndex = 45;
            addActionComboBox.SelectedIndexChanged += OnActionComboBoxItemSelect;
            // 
            // actionsPanel
            // 
            actionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            actionsPanel.AutoScroll = true;
            actionsPanel.BackColor = Color.FromArgb(45, 45, 50);
            actionsPanel.Location = new Point(78, 63);
            actionsPanel.Name = "actionsPanel";
            actionsPanel.Size = new Size(879, 30);
            actionsPanel.TabIndex = 43;
            // 
            // unitNameTextField
            // 
            unitNameTextField.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unitNameTextField.BackColor = Color.FromArgb(40, 40, 43);
            unitNameTextField.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            unitNameTextField.ForeColor = Color.White;
            unitNameTextField.Location = new Point(8, 7);
            unitNameTextField.Name = "unitNameTextField";
            unitNameTextField.PlaceholderText = "Az Unit neve...";
            unitNameTextField.Size = new Size(361, 29);
            unitNameTextField.TabIndex = 42;
            unitNameTextField.Leave += OnUnitNameTextFieldChanged;
            // 
            // collapseActionsButton
            // 
            collapseActionsButton.Anchor = AnchorStyles.Top;
            collapseActionsButton.BackColor = Color.FromArgb(35, 35, 40);
            collapseActionsButton.Image = (Image)resources.GetObject("collapseActionsButton.Image");
            collapseActionsButton.Location = new Point(8, 42);
            collapseActionsButton.Name = "collapseActionsButton";
            collapseActionsButton.Size = new Size(50, 50);
            collapseActionsButton.SizeMode = PictureBoxSizeMode.StretchImage;
            collapseActionsButton.TabIndex = 55;
            collapseActionsButton.TabStop = false;
            collapseActionsButton.Click += OnCollapseActionsButtonClick;
            // 
            // expandActionsButtton
            // 
            expandActionsButtton.Anchor = AnchorStyles.Top;
            expandActionsButtton.BackColor = Color.FromArgb(60, 60, 65);
            expandActionsButtton.Image = (Image)resources.GetObject("expandActionsButtton.Image");
            expandActionsButtton.Location = new Point(8, 43);
            expandActionsButtton.Name = "expandActionsButtton";
            expandActionsButtton.Size = new Size(50, 50);
            expandActionsButtton.SizeMode = PictureBoxSizeMode.StretchImage;
            expandActionsButtton.TabIndex = 56;
            expandActionsButtton.TabStop = false;
            expandActionsButtton.Click += OnExpandActionsButttonClick;
            // 
            // UnitPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 55);
            Controls.Add(mainPanel);
            MinimumSize = new Size(1000, 97);
            Name = "UnitPanel";
            Size = new Size(1000, 97);
            ((System.ComponentModel.ISupportInitialize)binImage).EndInit();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)resetBackupOfButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)resetBindingButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)collapseActionsButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)expandActionsButtton).EndInit();
            ResumeLayout(false);
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
        protected Label testRunTimeLabel;
        protected Label testRunTimeText;
        private PictureBox resetBindingButton;
        private PictureBox resetBackupOfButton;
    }
}
