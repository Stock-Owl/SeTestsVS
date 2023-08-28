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

        public List<SchedulerItem> m_SchedulerItems = new List<SchedulerItem>();
        public string m_RootLogDirectory;

        Process m_CurrentProcess;

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

        private void testStartButton_Click(object sender, EventArgs e)
        {
            // Start testing loop
        }

        #region TEST RUNTIME

        private bool _STOP_BRK_LOG_REQ = false;
        private bool _STOP_JS_LOG_REQ = false;

        public async void OnTestStart()
        {
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

            Test().m_State = WebTestGui.Test.TestState.Run;
            testStartButton.Text = "TESZT FUT";

            string JSONString = GetTestJSON(Test());
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

            m_TestTab.m_TestRunning = true;

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
            OnSwitchToJsLogButtonPressed(null!, null!);

            if (!Test().HaveInterceptorActions())
                m_RunLogConsole.AddToConsoles("\n ------TESZT INDITÁSA \n");
            else
                m_RunLogConsole.AddToConsoles("\n ------INTERCEPTOROS TESZT INDITÁSA \n");
        }

        public void OnTestAbort()
        {
            m_RunLogConsole.AddToConsoles("\n ------TESZT LEÁLLÍTVA \n");
            m_CurrentProcess.Kill();
            SetColorSchemeToEdit();

            OnTestFinished();
        }

        public void OnTestBreak(string content)
        {
            Test().m_State = WebTestGui.Test.TestState.Break;
            m_RunLogConsole.AddToConsoles("\n ------TESZT SZÜNETELTETVE (BREAKPOINT) \n");
            testStartButton.Text = "TESZT FOLYTATÁSA...";
            SetColorSchemeToBreakpointHit();

            string[] contentParts = content.Split('\n')[0].Split(':'); // (c:ble 1:1)

            foreach (IUnit unit in Test().m_Units.m_Units)
            {
                if (unit.m_UnitName == contentParts[1])
                {
                    unitsPanel.ScrollControlIntoView((Control)unit);
                    unit.OnBreakpointHit(int.Parse(contentParts[2]));
                }
            }

            string chromeRunLog = File.ReadAllText(m_RootLogDirectory + @"/chrome/run.log");
            string firefoxRunLog = File.ReadAllText(m_RootLogDirectory + @"/firefox/run.log");

            LoadRunTimesToActions(chromeRunLog, firefoxRunLog);
            LoadRunTimesToUnits();
            LoadRunTime();

            breakpointIcon.Visible = true;

            IntPtr mainFormHandle = Handle;
            User32Interop.SetForegroundWindow(mainFormHandle);
        }

        public void OnTestContinue() // Should be called only after a breakpoint hit
        {
            Test().m_State = WebTestGui.Test.TestState.Run;
            testStartButton.Text = "TESZT FUT.../ TESZT LEÁLLÍTÁSA";
            SetColorSchemeToRun();

            File.WriteAllText(m_RootLogDirectory + @"/file.brk", string.Empty);

            foreach (IUnit unit in Test().m_Units.m_Units)
            {
                unit.OnBreakpointLeave();
            }
            RefreshUnitsPanel();

            breakpointIcon.Visible = false;
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
            m_RunLogConsole.AddToChrome("\n\n" + chromeRunLog);
            m_RunLogConsole.AddToFirefox("\n\n" + firefoxRunLog);

            m_JsLogConsole.AddToConsoles(File.ReadAllText(m_RootLogDirectory + @"/js.log"));

            m_RunLogConsole.AddToConsoles("\n ------TESZT VÉGE \n");

            LoadRunTimesToActions(chromeRunLog, firefoxRunLog);
            LoadRunTimesToUnits();
            LoadRunTime();

            m_TestTab.m_TestRunning = false;
            RefreshUnitsPanel();
        }

        #region Extract time information from logs methods

        void LoadRunTimesToActions(string chromeRunLog, string firefoxRunLog)
        {
            string[] chromeRunLogs = chromeRunLog.Split('\n');
            string[] firefoxRunLogs = firefoxRunLog.Split('\n');

            long chromePrevTime = TimeToMicroseconds(m_TestStartTime);
            long firefoxPrevTime = TimeToMicroseconds(m_TestStartTime);
            for (int i = 0; i < Math.Max(chromeRunLogs.Length, firefoxRunLogs.Length); i++)
            {
                string tempChromeRunLog;
                string tempFirefoxRunLog;
                if (i < chromeRunLogs.Length)
                {
                    tempChromeRunLog = chromeRunLogs[i];
                }
                else
                {
                    tempChromeRunLog = "";
                }

                if (i < firefoxRunLogs.Length)
                {
                    tempFirefoxRunLog = firefoxRunLogs[i];
                }
                else
                {
                    tempFirefoxRunLog = "";
                }

                RunLog tempRunLog = GetRunTimeFromRunLog(tempChromeRunLog, tempFirefoxRunLog);

                long chromeTimeToMicro = TimeToMicroseconds(tempRunLog.chromeTime);
                long firefoxTimeToMicro = TimeToMicroseconds(tempRunLog.firefoxTime);

                if (chromePrevTime != 0)
                    tempRunLog.chromeTimeDelta = Math.Abs(chromeTimeToMicro - chromePrevTime);
                chromePrevTime = chromeTimeToMicro;

                if (firefoxPrevTime != 0)
                    tempRunLog.firefoxTimeDelta = Math.Abs(firefoxTimeToMicro - firefoxPrevTime);
                firefoxPrevTime = firefoxTimeToMicro;

                if (tempRunLog.chromeUnitName != "" && tempRunLog.chromeActionName != "")
                {
                    foreach (IUnit unit in Test().m_Units.m_Units)
                    {
                        if (unit.m_UnitName == tempRunLog.chromeUnitName)
                        {
                            unit.m_Actions.m_Actions[
                                int.Parse(tempRunLog.chromeActionName)].SetChromeRunTime(tempRunLog.chromeTimeDelta / 1000);
                        }
                    }
                }

                if (tempRunLog.firefoxUnitName != "" && tempRunLog.firefoxActionName != "")
                {
                    foreach (IUnit unit in Test().m_Units.m_Units)
                    {
                        if (unit.m_UnitName == tempRunLog.firefoxUnitName)
                        {
                            unit.m_Actions.m_Actions[
                                int.Parse(tempRunLog.firefoxActionName)].SetFirefoxRunTime(tempRunLog.firefoxTimeDelta / 1000);
                        }
                    }
                }
            }
        }

        void LoadRunTimesToUnits()
        {
            foreach (IUnit unit in Test().m_Units.m_Units)
            {
                unit.SetRunTime();
            }
        }

        void LoadRunTime()
        {
            int chromeSum = 0;
            int firefoxSum = 0;
            foreach (IUnit unit in Test().m_Units.m_Units)
            {
                Tuple<int, int> sum = unit.GetRunTime();
                chromeSum += sum.Item1;
                firefoxSum += sum.Item2;
            }

            if (Test().m_State == WebTestGui.Test.TestState.Break)
            {
                testRunTimeText.ForeColor = Color.Firebrick;
                testRunTimeText.Text = "Jelenlegi teszt futási ideje a Breakpoint-ig: " + (chromeSum.ToString() + " / " + firefoxSum.ToString() + " ms");
            }
            else if (Test().m_State == WebTestGui.Test.TestState.Edit)
            {
                testRunTimeText.ForeColor = Color.DimGray;
                testRunTimeText.Text = "Elõzõ tesztelés teljes futási ideje: " + (chromeSum.ToString() + " / " + firefoxSum.ToString() + " ms");
            }
        }

        long TimeToMicroseconds(string timeStr)
        {
            try
            {
                string[] parts = timeStr.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);
                int seconds = int.Parse(parts[2]);
                int microseconds = int.Parse(parts[3]);

                long totalMicros = hours * 3600L * 1000000L + minutes * 60L * 1000000L + seconds * 1000000L + microseconds;
                return totalMicros;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        class RunLog
        {
            public string chromeTime = "";
            public long chromeTimeDelta = 0;

            public string chromeUnitName = "";
            public string chromeActionName = "";

            public string firefoxTime = "";
            public long firefoxTimeDelta = 0;

            public string firefoxUnitName = "";
            public string firefoxActionName = "";
        }
        RunLog GetRunTimeFromRunLog(string chromeLog, string firefoxLog)
        {
            RunLog runLog = new RunLog();

            {
                int firstSlashIndex = chromeLog.IndexOf('/');
                int secondSlashIndex = chromeLog.IndexOf('/', firstSlashIndex + 1);

                if (firstSlashIndex != -1 && secondSlashIndex != -1)
                {
                    string extractedText = chromeLog.Substring(firstSlashIndex + 1, secondSlashIndex - firstSlashIndex - 1);
                    runLog.chromeTime = extractedText;
                }
                else
                {
                    runLog.chromeTime = "";
                }

                int firstOpenBracketIndex = chromeLog.IndexOf('[');
                int firstCloseBracketIndex = chromeLog.IndexOf(']');
                int secondOpenBracketIndex = chromeLog.IndexOf('[', firstCloseBracketIndex + 1);
                int secondCloseBracketIndex = chromeLog.IndexOf(']', secondOpenBracketIndex + 1);

                if (firstOpenBracketIndex != -1 && firstCloseBracketIndex != -1 && secondOpenBracketIndex != -1 && secondCloseBracketIndex != -1)
                {
                    string firstExtractedText = chromeLog.Substring(firstOpenBracketIndex + 1, firstCloseBracketIndex - firstOpenBracketIndex - 1);
                    string secondExtractedText = chromeLog.Substring(secondOpenBracketIndex + 1, secondCloseBracketIndex - secondOpenBracketIndex - 1);

                    runLog.chromeUnitName = firstExtractedText.Split(':')[1];
                    runLog.chromeActionName = secondExtractedText.Split(':')[1];
                }
                else
                {
                    runLog.chromeUnitName = "";
                    runLog.chromeActionName = "";
                }
            }

            {
                int firstSlashIndex = firefoxLog.IndexOf('/');
                int secondSlashIndex = firefoxLog.IndexOf('/', firstSlashIndex + 1);

                if (firstSlashIndex != -1 && secondSlashIndex != -1)
                {
                    string extractedText = firefoxLog.Substring(firstSlashIndex + 1, secondSlashIndex - firstSlashIndex - 1);
                    runLog.firefoxTime = extractedText;
                }
                else
                {
                    runLog.firefoxTime = "";
                }

                int firstOpenBracketIndex = firefoxLog.IndexOf('[');
                int firstCloseBracketIndex = firefoxLog.IndexOf(']');
                int secondOpenBracketIndex = firefoxLog.IndexOf('[', firstCloseBracketIndex + 1);
                int secondCloseBracketIndex = firefoxLog.IndexOf(']', secondOpenBracketIndex + 1);

                if (firstOpenBracketIndex != -1 && firstCloseBracketIndex != -1 && secondOpenBracketIndex != -1 && secondCloseBracketIndex != -1)
                {
                    string firstExtractedText = firefoxLog.Substring(firstOpenBracketIndex + 1, firstCloseBracketIndex - firstOpenBracketIndex - 1);
                    string secondExtractedText = firefoxLog.Substring(secondOpenBracketIndex + 1, secondCloseBracketIndex - secondOpenBracketIndex - 1);

                    runLog.firefoxUnitName = firstExtractedText.Split(':')[1];
                    runLog.firefoxActionName = secondExtractedText.Split(':')[1];
                }
                else
                {
                    runLog.firefoxUnitName = "";
                    runLog.firefoxActionName = "";
                }
            }

            return runLog;
        }

        #endregion

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