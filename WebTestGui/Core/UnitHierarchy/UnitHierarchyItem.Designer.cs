namespace WebTestGui
{
    partial class UnitHierarchyItem
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
            unitNameLabel = new Label();
            idTextBox = new TextBox();
            idLabel = new Label();
            testRunTimeText = new Label();
            testRunTimeLabel = new Label();
            SuspendLayout();
            // 
            // unitNameLabel
            // 
            unitNameLabel.AutoSize = true;
            unitNameLabel.BackColor = Color.FromArgb(45, 45, 50);
            unitNameLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point);
            unitNameLabel.ForeColor = Color.White;
            unitNameLabel.Location = new Point(3, -1);
            unitNameLabel.Name = "unitNameLabel";
            unitNameLabel.Size = new Size(102, 28);
            unitNameLabel.TabIndex = 56;
            unitNameLabel.Text = "unitName";
            unitNameLabel.Click += unitNameLabel_Click;
            // 
            // idTextBox
            // 
            idTextBox.BackColor = Color.FromArgb(40, 40, 43);
            idTextBox.BorderStyle = BorderStyle.FixedSingle;
            idTextBox.Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(260, 4);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(35, 20);
            idTextBox.TabIndex = 57;
            idTextBox.Text = "0";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.BackColor = Color.Transparent;
            idLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            idLabel.ForeColor = Color.White;
            idLabel.Location = new Point(221, 5);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(36, 19);
            idLabel.TabIndex = 58;
            idLabel.Text = "UID:";
            // 
            // testRunTimeText
            // 
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(199, 27);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(48, 15);
            testRunTimeText.TabIndex = 62;
            testRunTimeText.Text = "0 / 0 ms";
            testRunTimeText.Click += testRunTimeText_Click;
            // 
            // testRunTimeLabel
            // 
            testRunTimeLabel.AutoSize = true;
            testRunTimeLabel.BackColor = Color.Transparent;
            testRunTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeLabel.ForeColor = Color.Gray;
            testRunTimeLabel.Location = new Point(42, 27);
            testRunTimeLabel.Name = "testRunTimeLabel";
            testRunTimeLabel.Size = new Size(157, 15);
            testRunTimeLabel.TabIndex = 61;
            testRunTimeLabel.Text = "Előző tesztelésen futási ideje:";
            testRunTimeLabel.Click += testRunTimeLabel_Click;
            // 
            // UnitHierarchyItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(testRunTimeText);
            Controls.Add(testRunTimeLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            Controls.Add(unitNameLabel);
            Name = "UnitHierarchyItem";
            Size = new Size(300, 45);
            Load += UnitHierarchyItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label unitNameLabel;
        private TextBox idTextBox;
        protected Label idLabel;
        protected Label testRunTimeText;
        protected Label testRunTimeLabel;
    }
}
