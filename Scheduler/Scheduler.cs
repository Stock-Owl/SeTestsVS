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
            Text = AppConsts.s_AppName + "" + "Idõzítõ" + " " + AppConsts.s_AppVersion;
        }

        private void addUnitButton_Click(object sender, EventArgs e)
        {
            SchedulerItem item = new SchedulerItem(this);
            item.SetId(m_SchedulerItems.Count);
            m_SchedulerItems.Add(item);
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

        public void SetColorSchemeToRun()
        {

        }

        public void SetColorSchemeToEdit()
        {

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

        private async Task testStartButton_Click(object sender, EventArgs e)
        {
            // Start testing loop
            foreach (SchedulerItem schedulerItem in m_SchedulerItems)
            {
                m_CurrentlyTestedRawJson = schedulerItem.m_TestRawJson;
                //OnTestStart();
            }
        }

        public List<SchedulerItem> m_SchedulerItems = new List<SchedulerItem>();
        public string m_RootLogDirectory;

        string m_CurrentlyTestedRawJson;
        Process m_CurrentProcess;
        string m_TestStartTime;

        #region TEST RUNTIME

        private bool _STOP_BRK_LOG_REQ = false;
        private bool _STOP_JS_LOG_REQ = false;

        public async void OnTestStart()
        {
            // TODO: START TIMER FOR TEST

            // Does parent log path exist
            if (!Path.Exists(m_RootLogDirectory))
            {
                string message = "A jelenleg megadott 'Gyökér logolási könyvtár' útvonala nem létezik!";
                string title = "Indítási probléma...";
                MessageBox.Show(message, title);
                return;
            }

            // Checking if the root log directory contains chrome and firefox folders
            if (!Directory.Exists(m_RootLogDirectory + @"/chrome"))
            {
                Directory.CreateDirectory(m_RootLogDirectory + @"/chrome");
            }
            if (!Directory.Exists(m_RootLogDirectory + @"/firefox"))
            {
                Directory.CreateDirectory(m_RootLogDirectory + @"/firefox");
            }

            testStartButton.Text = "TESZT FUT";

            string JSONString = m_CurrentlyTestedRawJson;
            DateTime currentTime = DateTime.Now;
            m_TestStartTime = currentTime.ToString("HH:mm:ss:ffffff");

            // Getting python directory
            // TODO: MOST LIKELY WILL CHANGE ON PRODUCTION BUILD
            string temp = Application.ExecutablePath;
            string[] temparray = temp.Split(@"WebTestGui");

            File.WriteAllText(temparray[0] + "run.json", JSONString);

            SetColorSchemeToRun();

            if (!Test().HaveInterceptorActions())
            {
                StartPython(temparray[0], "main.py");
            }
            else
            {
                // Call interceptor python file instead
                StartPython(temparray[0], "main.py");
            }

            File.WriteAllText(m_RootLogDirectory + @"/chrome/run.log", string.Empty);
            File.WriteAllText(m_RootLogDirectory + @"/firefox/run.log", string.Empty);

            // Later, when there are more files with a filewatcher expand File.Exists() check
            if (!File.Exists(m_RootLogDirectory + @"/file.brk"))
            {
                File.Create(m_RootLogDirectory + @"/file.brk");
            }
            if (!File.Exists(m_RootLogDirectory + @"/js.log"))
            {
                File.Create(m_RootLogDirectory + @"/js.log");
            }

            _STOP_BRK_LOG_REQ = false;
            _STOP_JS_LOG_REQ = false;

            File.WriteAllText(m_RootLogDirectory + @"/file.brk", string.Empty);
            string breakPointFilePath = m_RootLogDirectory + @"/file.brk";
            StartBreakPointFileWatcher(breakPointFilePath);

            File.WriteAllText(m_RootLogDirectory + @"/js.log", string.Empty);
            string jsLogFilePath = m_RootLogDirectory + @"/js.log";
            StartJsLogFileWatcher(jsLogFilePath);

            if (!Test().HaveInterceptorActions())
        }

        public void OnTestAbort()
        {
            m_CurrentProcess.Kill();
            SetColorSchemeToEdit();

            OnTestFinished();
        }

        public void OnTestFinished()
        {
            Test().m_State = WebTestGui.Test.TestState.Edit;
            testStartButton.Text = "TESZT INDÍTÁSA...";
            SetColorSchemeToEdit();

            _STOP_BRK_LOG_REQ = true;
            _STOP_JS_LOG_REQ = true;
            File.WriteAllText(m_RootLogDirectory + @"/file.brk", string.Empty);

            string chromeRunLog = File.ReadAllText(m_RootLogDirectory + @"/chrome/run.log");
            string firefoxRunLog = File.ReadAllText(m_RootLogDirectory + @"/firefox/run.log");

            // TODO: STOP TIMER FOR TEST
        }

        public async Task StartPython(string targetDir, string pythonScriptName)
        {
            string targetDirectory = targetDir;
            string pythonScript = pythonScriptName;

            m_CurrentProcess = Process.Start("cmd.exe", $"/K cd /D {targetDirectory} && python {pythonScript} && exit");

            await m_CurrentProcess.WaitForExitAsync();

            OnTestFinished();
        }

        public async void StartBreakPointFileWatcher(string logPath)
        {
            using (FileWatcher fileWatcher = new FileWatcher(logPath))
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