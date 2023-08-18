namespace WebTestGui
{
    partial class TestTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestTab));
            tabPanel = new FlowLayoutPanel();
            plusIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)plusIcon).BeginInit();
            SuspendLayout();
            // 
            // tabPanel
            // 
            tabPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabPanel.AutoScroll = true;
            tabPanel.BackColor = Color.FromArgb(55, 55, 60);
            tabPanel.Location = new Point(39, -2);
            tabPanel.Name = "tabPanel";
            tabPanel.Size = new Size(710, 36);
            tabPanel.TabIndex = 54;
            // 
            // plusIcon
            // 
            plusIcon.BackColor = Color.FromArgb(50, 50, 53);
            plusIcon.Image = (Image)resources.GetObject("plusIcon.Image");
            plusIcon.Location = new Point(5, 3);
            plusIcon.Name = "plusIcon";
            plusIcon.Size = new Size(30, 30);
            plusIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            plusIcon.TabIndex = 55;
            plusIcon.TabStop = false;
            plusIcon.Click += AddNewItem;
            // 
            // TestTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 53);
            Controls.Add(plusIcon);
            Controls.Add(tabPanel);
            Name = "TestTab";
            Size = new Size(749, 35);
            ((System.ComponentModel.ISupportInitialize)plusIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel tabPanel;
        private PictureBox plusIcon;
    }
}
