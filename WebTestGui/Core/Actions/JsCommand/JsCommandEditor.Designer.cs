namespace WebTestGui
{
    partial class JsCommandEditor
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
            addCommandButton = new Button();
            jsCommandsPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // addCommandButton
            // 
            addCommandButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addCommandButton.BackColor = Color.FromArgb(40, 40, 43);
            addCommandButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            addCommandButton.ForeColor = Color.White;
            addCommandButton.Location = new Point(561, 0);
            addCommandButton.Name = "addCommandButton";
            addCommandButton.Size = new Size(101, 30);
            addCommandButton.TabIndex = 52;
            addCommandButton.Text = "Hozzáadás...";
            addCommandButton.UseVisualStyleBackColor = false;
            addCommandButton.Click += switchToOptionsButton_Click;
            // 
            // jsCommandsPanel
            // 
            jsCommandsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            jsCommandsPanel.AutoScroll = true;
            jsCommandsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            jsCommandsPanel.BackColor = Color.FromArgb(45, 45, 50);
            jsCommandsPanel.Location = new Point(0, 0);
            jsCommandsPanel.Name = "jsCommandsPanel";
            jsCommandsPanel.Size = new Size(555, 115);
            jsCommandsPanel.TabIndex = 53;
            // 
            // JsCommandEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 50);
            Controls.Add(jsCommandsPanel);
            Controls.Add(addCommandButton);
            Name = "JsCommandEditor";
            Size = new Size(662, 115);
            ResumeLayout(false);
        }

        #endregion

        private Button addCommandButton;
        private FlowLayoutPanel jsCommandsPanel;
    }
}
