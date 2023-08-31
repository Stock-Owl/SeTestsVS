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
            this.tabPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.plusIcon = new System.Windows.Forms.PictureBox();
            this.addBlankIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.plusIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBlankIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPanel.AutoScroll = true;
            this.tabPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.tabPanel.Location = new System.Drawing.Point(85, -2);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(664, 36);
            this.tabPanel.TabIndex = 54;
            // 
            // plusIcon
            // 
            this.plusIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.plusIcon.Image = ((System.Drawing.Image)(resources.GetObject("plusIcon.Image")));
            this.plusIcon.Location = new System.Drawing.Point(5, 3);
            this.plusIcon.Name = "plusIcon";
            this.plusIcon.Size = new System.Drawing.Size(30, 30);
            this.plusIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plusIcon.TabIndex = 55;
            this.plusIcon.TabStop = false;
            this.plusIcon.Click += new System.EventHandler(this.AddNewItem);
            // 
            // addBlankIcon
            // 
            this.addBlankIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.addBlankIcon.Image = ((System.Drawing.Image)(resources.GetObject("addBlankIcon.Image")));
            this.addBlankIcon.Location = new System.Drawing.Point(47, 3);
            this.addBlankIcon.Name = "addBlankIcon";
            this.addBlankIcon.Size = new System.Drawing.Size(30, 30);
            this.addBlankIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addBlankIcon.TabIndex = 56;
            this.addBlankIcon.TabStop = false;
            this.addBlankIcon.Click += new System.EventHandler(this.ONAddBlankTestButtonClicked);
            // 
            // TestTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.Controls.Add(this.addBlankIcon);
            this.Controls.Add(this.plusIcon);
            this.Controls.Add(this.tabPanel);
            this.Name = "TestTab";
            this.Size = new System.Drawing.Size(749, 35);
            ((System.ComponentModel.ISupportInitialize)(this.plusIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBlankIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel tabPanel;
        private PictureBox plusIcon;
        private PictureBox addBlankIcon;
    }
}
