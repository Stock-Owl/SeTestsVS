namespace WebTestGui
{
    public partial class SchedulerItem : UserControl
    {
        public SchedulerItem(Scheduler.Scheduler parent)
        {
            InitializeComponent();

            m_Parent = parent;
        }

        public void OnTestStart()
        {

        }

        public void OnTestEnd(bool successful)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt betöltése...";
            of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                m_TestPath = of.FileName;
                testFilePathTextBox.Text = m_TestPath;
            }
        }

        private void locatorTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = locatorTextBox.GetItemText(locatorTextBox.SelectedItem)!;
            locatorTextBox.Text = selected;
            if (selected == "Az előző teszt után egyből...")
            {
                timeTypeTextBox.Visible = false;
                timeTypeLabel.Visible = false;
                msLabel.Visible = false;
            }
            else
            {
                timeTypeTextBox.Visible = true;
                timeTypeLabel.Visible = true;
                msLabel.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainLabel.Text = "Teszt neve...";
            testFilePathTextBox.Text = "";
            mainLabel.Font = new Font("Segoe UI", 15F, FontStyle.Italic, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.DimGray;
        }

        private void folderIcon_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    folderPath.Text = folderDialog.SelectedPath;
                    m_RootLogDirectory = folderDialog.SelectedPath;
                }
            }
        }

        private void searchForFolderButton_Click(object sender, EventArgs e)
        {
            folderIcon_Click(null!, null!);
        }

        #region Update ready state methods

        void UpdateReadyState()
        {
            if (Path.Exists(testFilePathTextBox.Text) && int.TryParse(timeTypeTextBox.Text, out _) && Path.Exists(folderPath.Text))
            {
                readyIcon.BringToFront();
                m_IsScheduledTestReady = true;
            }
            else
            {
                notReadyIcon.BringToFront();
                m_IsScheduledTestReady = false;
            }
        }

        private void loadTestButton_Click(object sender, EventArgs e)
        {
            if (Path.Exists(m_TestPath))
            {
                m_TestRawJson = File.ReadAllText(m_TestPath);
                m_TestName = Path.GetFileNameWithoutExtension(m_TestPath);

                mainLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
                mainLabel.ForeColor = Color.White;
                testFilePathTextBox.Text = m_TestPath;
                mainLabel.Text = m_TestName;
                UpdateReadyState();
            }
        }

        private void timeTypeTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateReadyState();
        }

        private void folderPath_TextChanged(object sender, EventArgs e)
        {
            UpdateReadyState();
        }

        #endregion

        #region ID logic

        public void SetId(int id)
        {
            idTextBox.Text = id.ToString();
        }
        public int GetId()
        {
            return int.Parse(idTextBox.Text);
        }

        public void OnIdOverride(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (int.TryParse(idTextBox.Text, out int _))
                {
                    int newId = int.Parse(idTextBox.Text);
                    m_Parent.MoveElement(this, newId);
                }
            }
        }

        private void OnUIdTextBoxFocusLeave(object sender, EventArgs e)
        {
            if (int.TryParse(idTextBox.Text, out int _))
            {
                int newId = int.Parse(idTextBox.Text);
                m_Parent.MoveElement(this, newId);
            }
        }

        #endregion

        public int GetWaitTime()
        {
            if (timeTypeTextBox.Visible)
                return int.Parse(timeTypeTextBox.Text);
            else
                return 0;
        }

        public Scheduler.Scheduler m_Parent;
        public bool m_IsScheduledTestReady = false;
        public string m_RootLogDirectory;

        public string m_TestName;
        public string m_TestPath;

        public string m_TestRawJson;

        private void notReadyIcon_Click(object sender, EventArgs e)
        {
            if (Path.Exists(testFilePathTextBox.Text) && int.TryParse(timeTypeTextBox.Text, out _) && Path.Exists(folderPath.Text))
            {
                readyIcon.BringToFront();
            }
            else
            {
                notReadyIcon.BringToFront();
            }
        }

    }
}

