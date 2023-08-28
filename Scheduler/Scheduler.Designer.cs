namespace Scheduler
{
    partial class Scheduler
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduler));
            mainLabel = new Label();
            schedulerPanel = new FlowLayoutPanel();
            testRunTimeText = new Label();
            vsLogo = new PictureBox();
            addUnitButton = new PictureBox();
            unitLabel = new Label();
            unitHeaderPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)vsLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)addUnitButton).BeginInit();
            unitHeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.BackColor = Color.Transparent;
            mainLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.Silver;
            mainLabel.Location = new Point(4, 3);
            mainLabel.Margin = new Padding(4, 0, 4, 0);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(234, 37);
            mainLabel.TabIndex = 53;
            mainLabel.Text = "Időzítő applikáció";
            // 
            // schedulerPanel
            // 
            schedulerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            schedulerPanel.AutoScroll = true;
            schedulerPanel.BackColor = Color.FromArgb(45, 45, 50);
            schedulerPanel.Location = new Point(4, 91);
            schedulerPanel.Margin = new Padding(4, 3, 4, 3);
            schedulerPanel.Name = "schedulerPanel";
            schedulerPanel.Size = new Size(556, 380);
            schedulerPanel.TabIndex = 54;
            // 
            // testRunTimeText
            // 
            testRunTimeText.AutoSize = true;
            testRunTimeText.BackColor = Color.Transparent;
            testRunTimeText.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            testRunTimeText.ForeColor = Color.DimGray;
            testRunTimeText.Location = new Point(12, 43);
            testRunTimeText.Margin = new Padding(4, 0, 4, 0);
            testRunTimeText.Name = "testRunTimeText";
            testRunTimeText.Size = new Size(358, 15);
            testRunTimeText.TabIndex = 62;
            testRunTimeText.Text = "Válassza ki az időzítendő teszteket és állítsa be az időzítés módját...";
            // 
            // vsLogo
            // 
            vsLogo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            vsLogo.BackColor = Color.Transparent;
            vsLogo.Image = (Image)resources.GetObject("vsLogo.Image");
            vsLogo.Location = new Point(504, 3);
            vsLogo.Margin = new Padding(4, 3, 4, 3);
            vsLogo.Name = "vsLogo";
            vsLogo.Size = new Size(55, 55);
            vsLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            vsLogo.TabIndex = 63;
            vsLogo.TabStop = false;
            // 
            // addUnitButton
            // 
            addUnitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addUnitButton.BackColor = Color.FromArgb(50, 50, 53);
            addUnitButton.Image = (Image)resources.GetObject("addUnitButton.Image");
            addUnitButton.Location = new Point(528, 3);
            addUnitButton.Margin = new Padding(4, 3, 4, 3);
            addUnitButton.Name = "addUnitButton";
            addUnitButton.Size = new Size(24, 25);
            addUnitButton.SizeMode = PictureBoxSizeMode.StretchImage;
            addUnitButton.TabIndex = 57;
            addUnitButton.TabStop = false;
            addUnitButton.Click += addUnitButton_Click;
            // 
            // unitLabel
            // 
            unitLabel.AutoSize = true;
            unitLabel.BackColor = Color.FromArgb(40, 40, 43);
            unitLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            unitLabel.ForeColor = Color.White;
            unitLabel.Location = new Point(4, 3);
            unitLabel.Margin = new Padding(4, 0, 4, 0);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new Size(131, 21);
            unitLabel.TabIndex = 9;
            unitLabel.Text = "Időzített tesztek:";
            // 
            // unitHeaderPanel
            // 
            unitHeaderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unitHeaderPanel.BackColor = Color.FromArgb(40, 40, 45);
            unitHeaderPanel.Controls.Add(addUnitButton);
            unitHeaderPanel.Controls.Add(unitLabel);
            unitHeaderPanel.Location = new Point(4, 61);
            unitHeaderPanel.Margin = new Padding(4, 3, 4, 3);
            unitHeaderPanel.Name = "unitHeaderPanel";
            unitHeaderPanel.Size = new Size(556, 30);
            unitHeaderPanel.TabIndex = 64;
            // 
            // Scheduler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 53);
            ClientSize = new Size(562, 511);
            Controls.Add(unitHeaderPanel);
            Controls.Add(vsLogo);
            Controls.Add(testRunTimeText);
            Controls.Add(schedulerPanel);
            Controls.Add(mainLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(578, 550);
            Name = "Scheduler";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)vsLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)addUnitButton).EndInit();
            unitHeaderPanel.ResumeLayout(false);
            unitHeaderPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label mainLabel;
        private FlowLayoutPanel schedulerPanel;
        protected Label testRunTimeText;
        private PictureBox vsLogo;
        private PictureBox addUnitButton;
        private Label unitLabel;
        private Panel unitHeaderPanel;
    }
}