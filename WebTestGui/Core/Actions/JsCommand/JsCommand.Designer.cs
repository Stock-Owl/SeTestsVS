namespace WebTestGui
{
    partial class JsCommand
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
            mainLabel = new Label();
            commandConsole = new RichTextBox();
            deleteButton = new Button();
            idTextBox = new TextBox();
            idLabel = new Label();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.White;
            mainLabel.Location = new Point(3, 0);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(100, 21);
            mainLabel.TabIndex = 37;
            mainLabel.Text = "Command 0";
            // 
            // commandConsole
            // 
            commandConsole.AcceptsTab = true;
            commandConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            commandConsole.BackColor = Color.Black;
            commandConsole.BorderStyle = BorderStyle.None;
            commandConsole.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            commandConsole.ForeColor = Color.White;
            commandConsole.HideSelection = false;
            commandConsole.Location = new Point(0, 24);
            commandConsole.Name = "commandConsole";
            commandConsole.Size = new Size(469, 71);
            commandConsole.TabIndex = 54;
            commandConsole.Text = "";
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteButton.BackColor = Color.FromArgb(40, 40, 43);
            deleteButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.ForeColor = Color.White;
            deleteButton.Location = new Point(471, 65);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(62, 30);
            deleteButton.TabIndex = 56;
            deleteButton.Text = "Törlés...";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // idTextBox
            // 
            idTextBox.BackColor = Color.FromArgb(40, 40, 43);
            idTextBox.BorderStyle = BorderStyle.FixedSingle;
            idTextBox.Font = new Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point);
            idTextBox.ForeColor = Color.Gainsboro;
            idTextBox.Location = new Point(495, 5);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(35, 20);
            idTextBox.TabIndex = 57;
            idTextBox.Text = "0";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.BackColor = Color.Transparent;
            idLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            idLabel.ForeColor = Color.White;
            idLabel.Location = new Point(472, 7);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(23, 15);
            idLabel.TabIndex = 58;
            idLabel.Text = "ID:";
            // 
            // JsCommand
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            Controls.Add(deleteButton);
            Controls.Add(commandConsole);
            Controls.Add(mainLabel);
            Name = "JsCommand";
            Size = new Size(533, 95);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label mainLabel;
        private RichTextBox commandConsole;
        private Button deleteButton;
        private TextBox idTextBox;
        protected Label idLabel;
    }
}
