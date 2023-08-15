namespace WebTestGui
{
    partial class ActionElement
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
            locatorTextBox = new TextBox();
            valueTextBox = new TextBox();
            locatorLabel = new Label();
            valueLabel = new Label();
            subElementLabel = new Label();
            addSubElementButton = new Button();
            deleteSubElementButton = new Button();
            label1 = new Label();
            typeComboBox = new ComboBox();
            SuspendLayout();
            // 
            // locatorTextBox
            // 
            locatorTextBox.BackColor = Color.FromArgb(40, 40, 43);
            locatorTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            locatorTextBox.ForeColor = Color.DarkGray;
            locatorTextBox.Location = new Point(81, 5);
            locatorTextBox.Name = "locatorTextBox";
            locatorTextBox.PlaceholderText = "Keresett lokátor...";
            locatorTextBox.Size = new Size(192, 22);
            locatorTextBox.TabIndex = 34;
            // 
            // valueTextBox
            // 
            valueTextBox.BackColor = Color.FromArgb(40, 40, 43);
            valueTextBox.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            valueTextBox.ForeColor = Color.DarkGray;
            valueTextBox.Location = new Point(81, 33);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.PlaceholderText = "Érték...";
            valueTextBox.Size = new Size(192, 22);
            valueTextBox.TabIndex = 35;
            // 
            // locatorLabel
            // 
            locatorLabel.AutoSize = true;
            locatorLabel.BackColor = Color.Transparent;
            locatorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            locatorLabel.ForeColor = Color.White;
            locatorLabel.Location = new Point(9, 6);
            locatorLabel.Name = "locatorLabel";
            locatorLabel.Size = new Size(66, 21);
            locatorLabel.TabIndex = 46;
            locatorLabel.Text = "Lokátor:";
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.BackColor = Color.Transparent;
            valueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            valueLabel.ForeColor = Color.White;
            valueLabel.Location = new Point(9, 33);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(48, 21);
            valueLabel.TabIndex = 47;
            valueLabel.Text = "Érték:";
            // 
            // subElementLabel
            // 
            subElementLabel.AutoSize = true;
            subElementLabel.BackColor = Color.Transparent;
            subElementLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            subElementLabel.ForeColor = Color.White;
            subElementLabel.Location = new Point(9, 97);
            subElementLabel.Name = "subElementLabel";
            subElementLabel.Size = new Size(67, 21);
            subElementLabel.TabIndex = 48;
            subElementLabel.Text = "Al-elem:";
            // 
            // addSubElementButton
            // 
            addSubElementButton.BackColor = Color.FromArgb(40, 40, 43);
            addSubElementButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            addSubElementButton.ForeColor = Color.White;
            addSubElementButton.Location = new Point(94, 95);
            addSubElementButton.Name = "addSubElementButton";
            addSubElementButton.Size = new Size(87, 25);
            addSubElementButton.TabIndex = 49;
            addSubElementButton.Text = "Hozzáadás...";
            addSubElementButton.UseVisualStyleBackColor = false;
            addSubElementButton.Click += addSubElementButton_Click;
            // 
            // deleteSubElementButton
            // 
            deleteSubElementButton.BackColor = Color.FromArgb(40, 40, 43);
            deleteSubElementButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            deleteSubElementButton.ForeColor = Color.White;
            deleteSubElementButton.Location = new Point(187, 95);
            deleteSubElementButton.Name = "deleteSubElementButton";
            deleteSubElementButton.Size = new Size(87, 25);
            deleteSubElementButton.TabIndex = 50;
            deleteSubElementButton.Text = "Törlés...";
            deleteSubElementButton.UseVisualStyleBackColor = false;
            deleteSubElementButton.Visible = false;
            deleteSubElementButton.Click += deleteSubElementButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(9, 65);
            label1.Name = "label1";
            label1.Size = new Size(50, 21);
            label1.TabIndex = 51;
            label1.Text = "Típus:";
            // 
            // typeComboBox
            // 
            typeComboBox.BackColor = Color.FromArgb(40, 40, 43);
            typeComboBox.FlatStyle = FlatStyle.Popup;
            typeComboBox.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            typeComboBox.ForeColor = Color.DarkGray;
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Location = new Point(81, 63);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new Size(163, 25);
            typeComboBox.TabIndex = 52;
            typeComboBox.Text = "element";
            // 
            // ActionElement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(typeComboBox);
            Controls.Add(label1);
            Controls.Add(deleteSubElementButton);
            Controls.Add(addSubElementButton);
            Controls.Add(subElementLabel);
            Controls.Add(valueLabel);
            Controls.Add(locatorLabel);
            Controls.Add(valueTextBox);
            Controls.Add(locatorTextBox);
            Name = "ActionElement";
            Size = new Size(281, 122);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox locatorTextBox;
        private TextBox valueTextBox;
        protected Label locatorLabel;
        protected Label valueLabel;
        protected Label subElementLabel;
        private Button addSubElementButton;
        private Button deleteSubElementButton;
        protected Label label1;
        private ComboBox typeComboBox;
    }
}
