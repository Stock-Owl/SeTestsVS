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

        private void addUnitButton_Click(object sender, EventArgs e)
        {
            SchedulerItem item = new SchedulerItem(this);
            item.SetId(m_SchedulerItems.Count);
            m_SchedulerItems.Add(item);
            schedulerPanel.Controls.AddRange(m_SchedulerItems.ToArray());
        }

        public void RefreshPanel()
        {
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

            if (m_ScheduledTestRunning)
            {
                OnTestAbort();
            }
            else
            {
                m_ScheduledTestRunning = true;
                STARTTEST();
            }
        }

        bool m_ScheduledTestRunning = false;

        public List<SchedulerItem> m_SchedulerItems = new List<SchedulerItem>();

        SchedulerItem m_CurrentlyTestedTestItem;
        int m_CurrentlyTestedTestItemID = -1;
        Process m_CurrentProcess;
        string m_TestStartTime;

        #region TEST RUNTIME

        private bool _STOP_BRK_LOG_REQ = false;
        private bool _STOP_JS_LOG_REQ = false;

        public async void STARTTEST()
        {
            if (m_CurrentlyTestedTestItemID == (m_SchedulerItems.Count - 1))
            {
                OnTestingEnd();
            }
            else
            {
                m_CurrentlyTestedTestItemID++;
                m_CurrentlyTestedTestItem = m_SchedulerItems[m_CurrentlyTestedTestItemID];
                OnTestStart();
            }
        }

        public async void OnTestingEnd()
        {
            m_ScheduledTestRunning = false;

            BackColor = Color.FromArgb(255, 50, 50, 53);
            testStartButton.Text = "TESZTELÉS INDITÁSA...";
        }

        public async Task OnTestStart()
        {
            // TODO: START TIMER FOR TEST

            // Checking if the root log directory contains chrome and firefox folders
            if (!Directory.Exists(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/chrome"))
            {
                Directory.CreateDirectory(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/chrome");
            }
            if (!Directory.Exists(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/firefox"))
            {
                Directory.CreateDirectory(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/firefox");
            }

            testStartButton.Text = "TESZT FUT";

            string JSONString = m_CurrentlyTestedTestItem.m_TestRawJson;
            DateTime currentTime = DateTime.Now;
            m_TestStartTime = currentTime.ToString("HH:mm:ss:ffffff");

            // Getting python directory
            // TODO: MOST LIKELY WILL CHANGE ON PRODUCTION BUILD
            string temp = Application.ExecutablePath;
            string[] temparray = temp.Split(@"Scheduler");

            File.WriteAllText(temparray[0] + "run.json", JSONString);

            StartPython(temparray[0], "main.py");

            File.WriteAllText(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/chrome/run.log", string.Empty);
            File.WriteAllText(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/firefox/run.log", string.Empty);

            // Later, when there are more files with a filewatcher expand File.Exists() check
            if (!File.Exists(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/file.brk"))
            {
                File.Create(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/file.brk");
            }
            if (!File.Exists(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/js.log"))
            {
                File.Create(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/js.log");
            }

            _STOP_BRK_LOG_REQ = false;
            _STOP_JS_LOG_REQ = false;

            File.WriteAllText(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/file.brk", string.Empty);
            string breakPointFilePath = m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/file.brk";
            StartBreakPointFileWatcher(breakPointFilePath);

            File.WriteAllText(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/js.log", string.Empty);
            string jsLogFilePath = m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/js.log";
            StartJsLogFileWatcher(jsLogFilePath);
        }

        public void OnTestAbort()
        {
            m_CurrentProcess.Kill();

            OnTestFinished(true);
        }

        public void OnTestFinished(bool final)
        {
            _STOP_BRK_LOG_REQ = true;
            _STOP_JS_LOG_REQ = true;
            File.WriteAllText(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/file.brk", string.Empty);

            string chromeRunLog = File.ReadAllText(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/chrome/run.log");
            string firefoxRunLog = File.ReadAllText(m_CurrentlyTestedTestItem.m_RootLogDirectory + @"/firefox/run.log");

            if (final)
                OnTestingEnd();
            else
                STARTTEST();
            // TODO: STOP TIMER FOR TEST
        }

        public async Task StartPython(string targetDir, string pythonScriptName)
        {
            string targetDirectory = targetDir;
            string pythonScript = pythonScriptName;

            m_CurrentProcess = Process.Start("cmd.exe", $"/K cd /D {targetDirectory} && python {pythonScript} && exit");

            await m_CurrentProcess.WaitForExitAsync();

            OnTestFinished(false);
        }

        public async void StartBreakPointFileWatcher(string logPath)
        {
            using (FileWatcher fileWatcher = new FileWatcher(logPath, true))
            {
                fileWatcher.FileChanged += async (content) =>
                {
                    // clearing breakpoint log immediately

                    if (_STOP_BRK_LOG_REQ)
                    {
                        return;
                    }
                };

                while (!_STOP_BRK_LOG_REQ)
                {
                    await Task.Delay(100);
                }
            }
        }

        public async void StartJsLogFileWatcher(string logPath)
        {
            using (FileWatcher fileWatcher = new FileWatcher(logPath, true))
            {
                fileWatcher.FileChanged += async (content) =>
                {
                    // clearing js log immediately
                };

                while (!_STOP_JS_LOG_REQ)
                {
                    await Task.Delay(100);
                }
            }
        }

        #endregion
    }
}