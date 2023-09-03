using Newtonsoft.Json.Linq;
using WebTestGui;

namespace Scheduler
{
    public partial class SchedulerItem : UserControl
    {
        public SchedulerItem(Scheduler parent)
        {
            InitializeComponent();

            m_Parent = parent;
        }

        #region Runtime

        public void OnTestStart()
        {
            readyIcon.Visible = false;
            notReadyIcon.Visible = false;

            mainPanel.BackColor = Color.FromArgb(255, 80, 50, 50);
        }

        public void OnTestEnd(long runtimeInMiliseconds)
        {
            testRunTimeLabel.Text = $"Előző tesztelés teljes futási ideje: {runtimeInMiliseconds} ms";

            testRunTimeLabel.Visible = true;
            peekButton.Visible = true;

            readyIcon.Visible = true;
            notReadyIcon.Visible = true;

            mainPanel.BackColor = Color.FromArgb(255, 0, 0, 30);
        }

        public void HighlightWaitTextBox()
        {
            timeTypeTextBox.BackColor = Color.Maroon;
            timeTypeTextBox.ForeColor = Color.Black;
        }

        public void StopHighlight()
        {
            timeTypeTextBox.BackColor = Color.FromArgb(255, 40, 40, 43);
            timeTypeTextBox.ForeColor = Color.DarkGray;
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
                loadTestButton_Click(null!, null!);
            }
        }

        private void loadTestButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(testFilePathTextBox.Text))
            {
                pictureBox3_Click(null!, null!);
                return;
            }
            if (Path.Exists(testFilePathTextBox.Text))
            {
                m_TestRawJson = File.ReadAllText(testFilePathTextBox.Text);
                m_TestName = Path.GetFileNameWithoutExtension(testFilePathTextBox.Text);
                m_TestPath = testFilePathTextBox.Text;

                mainLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
                mainLabel.ForeColor = Color.White;
                testFilePathTextBox.Text = m_TestPath;
                mainLabel.Text = m_TestName;
                UpdateReadyState();
            }
            else
            {
                string message = "A megadott útvonalon nincsen valid .vstest fájl, vagy az út nem érvényes!";
                string title = "Teszt betöltési probléme...";
                MessageBox.Show(message, title);
            }
        }

        private void firefoxlogbutton_Click(object sender, EventArgs e)
        {
            m_Parent.m_ScheduledTestMainForm = new MainForm();
            m_Parent.m_ScheduledTestMainForm.LoadScheduledTestResults(m_TestPath, m_Result, m_TestStartTime);
            m_Parent.m_ScheduledTestMainForm.ShowDialog();
        }

        #endregion

        private void locatorTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = scheduleTypeTextBox.GetItemText(scheduleTypeTextBox.SelectedItem)!;
            scheduleTypeTextBox.Text = selected;
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

        private void binImage_Click(object sender, EventArgs e)
        {
            m_Parent.DeleteSchedulerItem(this);
        }

        #endregion

        public int GetWaitTime()
        {
            if (timeTypeTextBox.Visible)
                return int.Parse(timeTypeTextBox.Text);
            else
                return 0;
        }

        #region Load and Save data

        public Dictionary<string, object> GetData()
        {
            Refresh();

            Dictionary<string, object> data = new Dictionary<string, object>();
            data["test_path"] = testFilePathTextBox.Text;
            data["schedule_type"] = scheduleTypeTextBox.Text;
            data["time_type"] = timeTypeTextBox.Text;
            data["rootfolder_path"] = folderPath.Text;

            return data;
        }

        public void SetData(JToken data)
        {
            testFilePathTextBox.Text = (string)data["test_path"]!;
            m_TestPath = testFilePathTextBox.Text;

            scheduleTypeTextBox.Text = (string)data["schedule_type"]!;

            timeTypeTextBox.Text = (string)data["time_type"]!;

            folderPath.Text = (string)data["rootfolder_path"]!;
            m_RootLogDirectory = folderPath.Text;

            loadTestButton_Click(null!, null!);

            UpdateReadyState();
        }

        #endregion

        public Scheduler m_Parent;
        public ScheduledTestResult m_Result;
        public bool m_IsScheduledTestReady = false;
        public string m_RootLogDirectory;

        public string m_TestName;
        public string m_TestPath;

        public string m_TestRawJson;

        public string m_TestStartTime;
        public long m_TestRunTime = 0;

        public string m_ChromeRuntimeLog;
        public string m_FirefoxRuntimeLog;    
    }
}

