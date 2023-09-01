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
            this.mainLabel = new System.Windows.Forms.Label();
            this.schedulerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.testRunTimeText = new System.Windows.Forms.Label();
            this.vsLogo = new System.Windows.Forms.PictureBox();
            this.addUnitButton = new System.Windows.Forms.PictureBox();
            this.unitLabel = new System.Windows.Forms.Label();
            this.unitHeaderPanel = new System.Windows.Forms.Panel();
            this.testStartButton = new System.Windows.Forms.Button();
            this.saveSchedulerButton = new System.Windows.Forms.Button();
            this.loadSchedulerButton = new System.Windows.Forms.Button();
            this.currentlyEditedLabel = new System.Windows.Forms.Label();
            this.currentlyEditedText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vsLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addUnitButton)).BeginInit();
            this.unitHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.BackColor = System.Drawing.Color.Transparent;
            this.mainLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainLabel.ForeColor = System.Drawing.Color.Silver;
            this.mainLabel.Location = new System.Drawing.Point(4, 3);
            this.mainLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(234, 37);
            this.mainLabel.TabIndex = 53;
            this.mainLabel.Text = "Időzítő applikáció";
            // 
            // schedulerPanel
            // 
            this.schedulerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schedulerPanel.AutoScroll = true;
            this.schedulerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.schedulerPanel.Location = new System.Drawing.Point(4, 91);
            this.schedulerPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.schedulerPanel.Name = "schedulerPanel";
            this.schedulerPanel.Size = new System.Drawing.Size(618, 501);
            this.schedulerPanel.TabIndex = 54;
            // 
            // testRunTimeText
            // 
            this.testRunTimeText.AutoSize = true;
            this.testRunTimeText.BackColor = System.Drawing.Color.Transparent;
            this.testRunTimeText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.testRunTimeText.ForeColor = System.Drawing.Color.DimGray;
            this.testRunTimeText.Location = new System.Drawing.Point(12, 43);
            this.testRunTimeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.testRunTimeText.Name = "testRunTimeText";
            this.testRunTimeText.Size = new System.Drawing.Size(358, 15);
            this.testRunTimeText.TabIndex = 62;
            this.testRunTimeText.Text = "Válassza ki az időzítendő teszteket és állítsa be az időzítés módját...";
            // 
            // vsLogo
            // 
            this.vsLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vsLogo.BackColor = System.Drawing.Color.Transparent;
            this.vsLogo.Image = ((System.Drawing.Image)(resources.GetObject("vsLogo.Image")));
            this.vsLogo.Location = new System.Drawing.Point(566, 3);
            this.vsLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.vsLogo.Name = "vsLogo";
            this.vsLogo.Size = new System.Drawing.Size(55, 55);
            this.vsLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.vsLogo.TabIndex = 63;
            this.vsLogo.TabStop = false;
            // 
            // addUnitButton
            // 
            this.addUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addUnitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.addUnitButton.Image = ((System.Drawing.Image)(resources.GetObject("addUnitButton.Image")));
            this.addUnitButton.Location = new System.Drawing.Point(590, 3);
            this.addUnitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addUnitButton.Name = "addUnitButton";
            this.addUnitButton.Size = new System.Drawing.Size(24, 25);
            this.addUnitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addUnitButton.TabIndex = 57;
            this.addUnitButton.TabStop = false;
            this.addUnitButton.Click += new System.EventHandler(this.addUnitButton_Click);
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.unitLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.unitLabel.ForeColor = System.Drawing.Color.White;
            this.unitLabel.Location = new System.Drawing.Point(4, 3);
            this.unitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(131, 21);
            this.unitLabel.TabIndex = 9;
            this.unitLabel.Text = "Időzített tesztek:";
            // 
            // unitHeaderPanel
            // 
            this.unitHeaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.unitHeaderPanel.Controls.Add(this.addUnitButton);
            this.unitHeaderPanel.Controls.Add(this.unitLabel);
            this.unitHeaderPanel.Location = new System.Drawing.Point(4, 61);
            this.unitHeaderPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.unitHeaderPanel.Name = "unitHeaderPanel";
            this.unitHeaderPanel.Size = new System.Drawing.Size(618, 30);
            this.unitHeaderPanel.TabIndex = 64;
            // 
            // testStartButton
            // 
            this.testStartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.testStartButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.testStartButton.ForeColor = System.Drawing.Color.White;
            this.testStartButton.Location = new System.Drawing.Point(4, 633);
            this.testStartButton.Name = "testStartButton";
            this.testStartButton.Size = new System.Drawing.Size(327, 40);
            this.testStartButton.TabIndex = 65;
            this.testStartButton.Text = "TESZTELÉS INDITÁSA...";
            this.testStartButton.UseVisualStyleBackColor = false;
            this.testStartButton.Click += new System.EventHandler(this.testStartButton_Click);
            // 
            // saveSchedulerButton
            // 
            this.saveSchedulerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveSchedulerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.saveSchedulerButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveSchedulerButton.ForeColor = System.Drawing.Color.White;
            this.saveSchedulerButton.Location = new System.Drawing.Point(355, 633);
            this.saveSchedulerButton.Name = "saveSchedulerButton";
            this.saveSchedulerButton.Size = new System.Drawing.Size(128, 40);
            this.saveSchedulerButton.TabIndex = 66;
            this.saveSchedulerButton.Text = "Időzítő mentése...";
            this.saveSchedulerButton.UseVisualStyleBackColor = false;
            this.saveSchedulerButton.Click += new System.EventHandler(this.saveSchedulerButton_Click);
            // 
            // loadSchedulerButton
            // 
            this.loadSchedulerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadSchedulerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.loadSchedulerButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loadSchedulerButton.ForeColor = System.Drawing.Color.White;
            this.loadSchedulerButton.Location = new System.Drawing.Point(489, 633);
            this.loadSchedulerButton.Name = "loadSchedulerButton";
            this.loadSchedulerButton.Size = new System.Drawing.Size(132, 40);
            this.loadSchedulerButton.TabIndex = 67;
            this.loadSchedulerButton.Text = "Időzítő betöltése...";
            this.loadSchedulerButton.UseVisualStyleBackColor = false;
            this.loadSchedulerButton.Click += new System.EventHandler(this.loadSchedulerButton_Click);
            // 
            // currentlyEditedLabel
            // 
            this.currentlyEditedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentlyEditedLabel.AutoSize = true;
            this.currentlyEditedLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentlyEditedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentlyEditedLabel.ForeColor = System.Drawing.Color.White;
            this.currentlyEditedLabel.Location = new System.Drawing.Point(5, 599);
            this.currentlyEditedLabel.Name = "currentlyEditedLabel";
            this.currentlyEditedLabel.Size = new System.Drawing.Size(226, 19);
            this.currentlyEditedLabel.TabIndex = 68;
            this.currentlyEditedLabel.Text = "Jelenleg szerkeztett időzített teszt:";
            // 
            // currentlyEditedText
            // 
            this.currentlyEditedText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentlyEditedText.AutoSize = true;
            this.currentlyEditedText.BackColor = System.Drawing.Color.Transparent;
            this.currentlyEditedText.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.currentlyEditedText.ForeColor = System.Drawing.Color.DarkGray;
            this.currentlyEditedText.Location = new System.Drawing.Point(5, 618);
            this.currentlyEditedText.Name = "currentlyEditedText";
            this.currentlyEditedText.Size = new System.Drawing.Size(68, 12);
            this.currentlyEditedText.TabIndex = 69;
            this.currentlyEditedText.Text = "Új időzített fájl";
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(624, 679);
            this.Controls.Add(this.currentlyEditedLabel);
            this.Controls.Add(this.currentlyEditedText);
            this.Controls.Add(this.loadSchedulerButton);
            this.Controls.Add(this.saveSchedulerButton);
            this.Controls.Add(this.testStartButton);
            this.Controls.Add(this.unitHeaderPanel);
            this.Controls.Add(this.vsLogo);
            this.Controls.Add(this.testRunTimeText);
            this.Controls.Add(this.schedulerPanel);
            this.Controls.Add(this.mainLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(578, 550);
            this.Name = "Scheduler";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.vsLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addUnitButton)).EndInit();
            this.unitHeaderPanel.ResumeLayout(false);
            this.unitHeaderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Label mainLabel;
        private FlowLayoutPanel schedulerPanel;
        protected Label testRunTimeText;
        private PictureBox vsLogo;
        private PictureBox addUnitButton;
        private Label unitLabel;
        private Panel unitHeaderPanel;
        private Button testStartButton;
        private Button saveSchedulerButton;
        private Button loadSchedulerButton;
        private Label currentlyEditedLabel;
        private Label currentlyEditedText;
    }
}