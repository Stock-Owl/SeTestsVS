namespace WebTestGui
{
    partial class ActionElementEditor
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
            switchToOptionsButton = new Button();
            actionElementsPanel = new FlowLayoutPanel();
            jSonTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // switchToOptionsButton
            // 
            switchToOptionsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            switchToOptionsButton.BackColor = Color.FromArgb(40, 40, 43);
            switchToOptionsButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            switchToOptionsButton.ForeColor = Color.White;
            switchToOptionsButton.Location = new Point(561, 0);
            switchToOptionsButton.Name = "switchToOptionsButton";
            switchToOptionsButton.Size = new Size(101, 30);
            switchToOptionsButton.TabIndex = 52;
            switchToOptionsButton.Text = "JSON nézet...";
            switchToOptionsButton.UseVisualStyleBackColor = false;
            switchToOptionsButton.Click += switchToOptionsButton_Click;
            // 
            // actionElementsPanel
            // 
            actionElementsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            actionElementsPanel.AutoScroll = true;
            actionElementsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            actionElementsPanel.BackColor = Color.FromArgb(45, 45, 50);
            actionElementsPanel.Location = new Point(0, 0);
            actionElementsPanel.Name = "actionElementsPanel";
            actionElementsPanel.Size = new Size(555, 160);
            actionElementsPanel.TabIndex = 51;
            // 
            // jSonTextBox
            // 
            jSonTextBox.AcceptsTab = true;
            jSonTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            jSonTextBox.BackColor = Color.FromArgb(45, 45, 50);
            jSonTextBox.BorderStyle = BorderStyle.None;
            jSonTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            jSonTextBox.ForeColor = Color.LightBlue;
            jSonTextBox.Location = new Point(0, 0);
            jSonTextBox.Name = "jSonTextBox";
            jSonTextBox.Size = new Size(555, 160);
            jSonTextBox.TabIndex = 53;
            jSonTextBox.Text = "";
            jSonTextBox.Visible = false;
            // 
            // ActionElementEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(switchToOptionsButton);
            Controls.Add(actionElementsPanel);
            Controls.Add(jSonTextBox);
            Name = "ActionElementEditor";
            Size = new Size(662, 160);
            ResumeLayout(false);
        }

        #endregion

        private Button switchToOptionsButton;
        private FlowLayoutPanel actionElementsPanel;
        private RichTextBox jSonTextBox;
    }
}
