using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WebTestGui;

namespace Scheduler
{
    public partial class Scheduler : Form
    {
        public Scheduler()
        {
            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            Text = AppConsts.s_AppName + " " + "Idõzítõ" + " " + AppConsts.s_AppVersion;
        }

        #region Item logic

        private void addUnitButton_Click(object sender, EventArgs e)
        {
            SchedulerItem item = new SchedulerItem(this);
            item.SetId(m_SchedulerItems.Count);
            m_SchedulerItems.Add(item);
            schedulerPanel.Controls.AddRange(m_SchedulerItems.ToArray());
        }

        public void RefreshPanel()
        {
            foreach (SchedulerItem item in m_SchedulerItems)
            {
                item.SetId(m_SchedulerItems.IndexOf(item));
            }
            schedulerPanel.Controls.Clear();
            schedulerPanel.Controls.AddRange(m_SchedulerItems.ToArray());
        }

        public void MoveElement(SchedulerItem itemToMove, int newId)
        {
            // Use try catch, because initially, when the action is loaded to the MainForm's panel, the id is being
            // overriden on load, and that point in time the action is not yet inside the m_Actions list, so it would
            // throw an OutOfRangeException
            try
            {
                int oldId = m_SchedulerItems.IndexOf(itemToMove);

                if (oldId == newId)
                {
                    return;
                }
                if (newId > m_SchedulerItems.Count)
                {
                    return;
                }

                SchedulerItem item = m_SchedulerItems[oldId];
                m_SchedulerItems.RemoveAt(oldId);

                m_SchedulerItems.Insert(newId, item);

                for (int i = 0; i < m_SchedulerItems.Count; i++)
                {
                    m_SchedulerItems[i].SetId(i);
                }

                schedulerPanel.Controls.Clear();
                schedulerPanel.Controls.AddRange(m_SchedulerItems.ToArray());
            }
            catch
            {
                // Do nothing...
            }
        }

        public void DeleteSchedulerItem(SchedulerItem item)
        {
            m_SchedulerItems.Remove(item);
            RefreshPanel();
        }

        #endregion

        #region Runtime

        private async void testStartButton_Click(object sender, EventArgs e)
        {
            foreach (SchedulerItem item in m_SchedulerItems)
            {
                if (!item.m_IsScheduledTestReady)
                {
                    string message = "Minden idõzített tesztnek érvényesek az adatai!\n" +
                                     "Bizonyosodjon meg róla, hogy mindegyik teszt mellett zöld pipa legyen!";
                    string title = "Indítási probléma...";
                    MessageBox.Show(message, title);
                    return;
                }
            }

            BackColor = Color.FromArgb(255, 80, 50, 50);
            addUnitButton.Enabled = false;

            saveSchedulerButton.Enabled = false;
            loadSchedulerButton.Enabled = false;

            if (m_ScheduledTestRunning)
            {
            }
            else
            {
                m_ScheduledTestRunning = true;
                STARTTEST();
            }
        }

        public async void STARTTEST()
        {
            testStartButton.Text = "TESZTELÉS FUT";
            if (m_CurrentlyTestedTestItemID == (m_SchedulerItems.Count - 1))
            {
                OnTestingEnd();
            }
            else
            {
                m_CurrentlyTestedTestItemID++;
                m_CurrentlyTestedTestItem = m_SchedulerItems[m_CurrentlyTestedTestItemID];
                if (m_CurrentlyTestedTestItem.GetWaitTime() != 0)
                {
                    m_CurrentlyTestedTestItem.HighlightWaitTextBox();
                    Thread.Sleep(m_CurrentlyTestedTestItem.GetWaitTime() * 1000);
                    m_CurrentlyTestedTestItem.StopHighlight();
                }
                OnTestStart();
            }
        }

        public async void OnTestingEnd()
        {
            m_ScheduledTestRunning = false;
            m_CurrentlyTestedTestItemID = -1;

            BackColor = Color.FromArgb(255, 50, 50, 53);
            addUnitButton.Enabled = true;

            saveSchedulerButton.Enabled = true;
            loadSchedulerButton.Enabled = true;

            testStartButton.Text = "TESZTELÉS INDITÁSA...";
        }

        public async void OnTestStart()
        {
            m_TestStopwatch = new Stopwatch();
            m_TestStopwatch.Start();

            DateTime currentTime = DateTime.Now;
            m_CurrentlyTestedTestItem.m_TestStartTime = currentTime.ToString("HH:mm:ss:ffffff");

            m_CurrentlyTestedTestItem.OnTestStart();
            m_ScheduledTestMainForm = new MainForm();
            m_ScheduledTestMainForm.Show();

            ScheduledTestResult testResult = await m_ScheduledTestMainForm.RUN_SCHEDULED_TEST(m_CurrentlyTestedTestItem.m_TestPath,
                m_CurrentlyTestedTestItem.m_RootLogDirectory);
            m_CurrentlyTestedTestItem.m_Result = testResult;

            m_ScheduledTestMainForm.Killllllllllllllllllllllllllll();
            m_ScheduledTestMainForm.Close();
            m_ScheduledTestMainForm = null!;
            GC.Collect();

            m_TestStopwatch.Stop();
            m_CurrentlyTestedTestItem.OnTestEnd(m_TestStopwatch.ElapsedMilliseconds);

            STARTTEST();
        }

        #endregion

        bool m_ScheduledTestRunning = false;

        public List<SchedulerItem> m_SchedulerItems = new List<SchedulerItem>();

        public MainForm m_ScheduledTestMainForm;

        Stopwatch m_TestStopwatch;

        SchedulerItem m_CurrentlyTestedTestItem;
        int m_CurrentlyTestedTestItemID = -1;

        public bool m_IsProjectLoaded;
        public string m_ProjectFilePath;

        #region Save and load projects

        private void saveSchedulerButton_Click(object sender, EventArgs e)
        {
            string savedJSON = SchedulerTestFormatter.SaveSchedulerTestToJson(m_SchedulerItems);
            if (m_IsProjectLoaded)
            {
                File.WriteAllText(m_ProjectFilePath, savedJSON);
            }
            else
            {
                SaveFileDialog of = new SaveFileDialog();
                of.Title = "Idõzített teszt mentése...";
                of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultSchedulerTestFileExtension}|Any File|*.*";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(of.FileName, savedJSON);
                    m_ProjectFilePath = of.FileName;
                    m_IsProjectLoaded = true;
                }
            }

            currentlyEditedLabel.Text = $"Jelenleg szerkeztett idõzített teszt: {Path.GetFileNameWithoutExtension(m_ProjectFilePath)}";
            currentlyEditedText.Text = m_ProjectFilePath;
        }

        private void loadSchedulerButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt betöltése...";
            of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultSchedulerTestFileExtension}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string loadedJSON = File.ReadAllText(of.FileName);
                m_SchedulerItems = SchedulerTestFormatter.LoadSchedulerTestFromJson(loadedJSON, this);
                RefreshPanel();

                m_ProjectFilePath = of.FileName;
                m_IsProjectLoaded = true;
            }

            currentlyEditedLabel.Text = $"Jelenleg szerkeztett idõzített teszt: {Path.GetFileNameWithoutExtension(m_ProjectFilePath)}";
            currentlyEditedText.Text = m_ProjectFilePath;
        }

        #endregion
    }
}