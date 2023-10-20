namespace WebTestGui
{
    partial class UnitHierarchy
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
            unitsPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // unitsPanel
            // 
            unitsPanel.AutoScroll = true;
            unitsPanel.BackColor = Color.FromArgb(45, 45, 50);
            unitsPanel.Dock = DockStyle.Fill;
            unitsPanel.Location = new Point(0, 0);
            unitsPanel.Name = "unitsPanel";
            unitsPanel.Size = new Size(342, 403);
            unitsPanel.TabIndex = 40;
            // 
            // UnitHierarchy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 53);
            Controls.Add(unitsPanel);
            Name = "UnitHierarchy";
            Size = new Size(342, 403);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel unitsPanel;
    }
}
