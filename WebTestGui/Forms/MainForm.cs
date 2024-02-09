using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebTestGui
{
    public partial class MainForm : Form
    {
        #region On start

        public MainForm(string testFilePath = "")
        {
            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            Text = AppConsts.s_AppName + " " + AppConsts.s_AppVersion;

            m_RunLogConsole = new Console(this);
            Controls.Add(m_RunLogConsole);
            m_RunLogConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            m_RunLogConsole.Location = new Point(0, 0);
            m_RunLogConsole.Size = new Size(500, 575);
            m_RunLogConsole.SendToBack();

            m_JsLogConsole = new Console(this);
            Controls.Add(m_JsLogConsole);
            m_JsLogConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            m_JsLogConsole.Location = new Point(795, 40);
            m_JsLogConsole.Size = new Size(327, 440);
            m_JsLogConsole.Visible = false;

            m_UnitHierarchyPanel = new UnitHierarchy(this);
            Controls.Add(m_UnitHierarchyPanel);
            m_UnitHierarchyPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            m_UnitHierarchyPanel.Location = new Point(795, 40);
            m_UnitHierarchyPanel.Size = new Size(327, 440);
            m_UnitHierarchyPanel.Visible = false;

            m_RunLogConsole.AddToConsoles("Applikáció indítása...\n");
            m_RunLogConsole.AddToConsoles("Verzió: " + $"{AppConsts.s_AppVersion}\n");
            m_RunLogConsole.AddToConsoles("Idő: " + $"{DateTime.Now}\n");

            m_JsLogConsole.AddToConsoles("JavaScript konzol...\n");
            m_JsLogConsole.AddToConsoles("A teszt ideje alatt minden JavaScript log " +
                "információ ide lesz kiiratva.\n");

            if (testFilePath == "")
            {
                m_Test = new Test(this);
                m_Test.PopulateDefaultOptions();
            }
            else
            {
                m_Test = LoadTestFromFile(testFilePath);
            }

            RefreshOptionsPanel();
            RefreshUnitsPanel();

            RefreshEditor();
        }

        #endregion

        #region Option panel function

        private void RefreshOptionsPanel()
        {
            optionsPanel.Controls.Clear();

            Control[] optionControls = new Control[GetMainTest().m_Options.m_Options.Count];
            for (int i = 0; i < optionControls.Length; i++)
            {
                optionControls[i] = (Control)GetMainTest().m_Options.m_Options[i];
            }
            optionsPanel.Controls.AddRange(optionControls);

            Control[] driverOptionControls = new Control[GetMainTest().m_DriverOptions.m_DriverOptions.Count];
            for (int i = 0; i < driverOptionControls.Length; i++)
            {
                driverOptionControls[i] = (Control)GetMainTest().m_DriverOptions.m_DriverOptions[i];
            }
            optionsPanel.Controls.AddRange(driverOptionControls);
        }

        private void exportOptionTemplate_Click(object sender, EventArgs e)
        {
            SaveFileDialog of = new SaveFileDialog();
            of.Title = "Teszt opciók mentése...";
            of.Filter = $"Teszt opciók fájl|*{AppConsts.s_AppDefaultFileExtension + "options"}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string savedInfo = TestFormatter.SaveOptionsFromTest(GetMainTest());
                File.WriteAllText(of.FileName, savedInfo);
            }
        }

        private void importOptionTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt opciók betöltése...";
            of.Filter = $"Teszt opciók fájl|*{AppConsts.s_AppDefaultFileExtension + "options"}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string loadedInfo = File.ReadAllText(of.FileName);
                TestFormatter.LoadOptionsToTest(loadedInfo, GetMainTest());
                RefreshOptionsPanel();
            }
        }

        #endregion

        #region Unit handlers and functions

        private void RefreshUnitsPanel(bool closeAllUnits = false)
        {
            Control[] controls = new Control[GetMainTest().m_Units.m_Units.Count];

            m_UnitHierarchyPanel.ClearItems();
            for (int i = 0; i < controls.Length; i++)
            {
                GetMainTest().m_Units.m_Units[i].SetUId(i);
                GetMainTest().m_Units.m_Units[i].Refresh();
                if (closeAllUnits)
                    GetMainTest().m_Units.m_Units[i].Collapse(true);
                controls[i] = (Control)GetMainTest().m_Units.m_Units[i];
                m_UnitHierarchyPanel.AddUnitHierarchyItem(GetMainTest().m_Units.m_Units[i]);
            }

            unitsPanel.Controls.Clear();
            unitsPanel.Controls.AddRange(controls);
        }

        private void OnAddUnitButtonPressed(object sender, EventArgs e)
        {
            IUnit unit = new UnitPanel();
            unit.m_ParentForm = this;

            unit.SetUId(unitsPanel.Controls.Count);
            GetMainTest().m_Units.m_Units.Add(unit);
            unit.m_UnitName = $"UNIT {GetMainTest().m_Units.m_Units.Count}";
            unit.Refresh();
            RefreshUnitsPanel();
            unitsPanel.ScrollControlIntoView((Control)unit);
        }

        public void DeleteUnit(IUnit unit)
        {
            GetMainTest().m_Units.m_Units.Remove(unit);
            RefreshUnitsPanel();
        }

        public void MoveUnit(IUnit unit, int newUId)
        {
            GetMainTest().m_Units.MoveUnit(unit, newUId);
            RefreshUnitsPanel();
        }

        private void gotoUnitComboBox_DropDown(object sender, EventArgs e)
        {
            gotoUnitComboBox.Items.Clear();
            string[] unitNames = new string[GetMainTest().m_Units.m_Units.Count];
            for (int i = 0; i < unitNames.Length; i++)
            {
                unitNames[i] = GetMainTest().m_Units.m_Units[i].m_UnitName;
            }

            gotoUnitComboBox.Items.AddRange(unitNames);
        }

        private void gotoUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUnitName = gotoUnitComboBox.GetItemText(gotoUnitComboBox.SelectedItem)!;
            ScrollToUnit(selectedUnitName);
        }

        public void ScrollToUnit(string unitName)
        {
            IUnit selectedUnit = new UnitPanel();
            foreach (IUnit unit in GetMainTest().m_Units.m_Units)
            {
                if (unit.m_UnitName == unitName)
                {
                    selectedUnit = unit;
                }
            }
            unitsPanel.ScrollControlIntoView((Control)selectedUnit);
        }

        #endregion

        #region Logic switching between unit hierarchy options and JS console

        private void unitHierarchyButton_Click(object sender, EventArgs e)
        {
            m_UnitHierarchyPanel.Visible = true;

            optionHeaderPanel.Visible = false;
            optionsPanel.Visible = false;
            optionLabel.Visible = false;

            m_JsLogConsole.Visible = false;

            unitHierarchyButton.ForeColor = Color.White;
            unitHierarchyButton.Font = new Font(unitHierarchyButton.Font, FontStyle.Bold);

            switchToJsLogButton.ForeColor = Color.Silver;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
            switchToOptionsButton.ForeColor = Color.Silver;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
        }

        private void OnSwitchToOptionsButtonPressed(object sender, EventArgs e)
        {
            m_UnitHierarchyPanel.Visible = false;

            optionHeaderPanel.Visible = true;
            optionsPanel.Visible = true;
            optionLabel.Visible = true;

            m_JsLogConsole.Visible = false;

            switchToOptionsButton.ForeColor = Color.White;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Bold);

            switchToJsLogButton.ForeColor = Color.Silver;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
            unitHierarchyButton.ForeColor = Color.Silver;
            unitHierarchyButton.Font = new Font(unitHierarchyButton.Font, FontStyle.Italic);
        }

        private void OnSwitchToJsLogButtonPressed(object sender, EventArgs e)
        {
            m_UnitHierarchyPanel.Visible = false;

            m_JsLogConsole.Visible = true;

            optionHeaderPanel.Visible = false;
            optionsPanel.Visible = false;
            optionLabel.Visible = false;

            switchToJsLogButton.ForeColor = Color.White;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Bold);

            switchToOptionsButton.ForeColor = Color.Silver;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
            unitHierarchyButton.ForeColor = Color.Silver;
            unitHierarchyButton.Font = new Font(unitHierarchyButton.Font, FontStyle.Italic);
        }

        #endregion

        #region TEST RUNTIME

        private bool _STOP_BRK_LOG_REQ = false;
        private bool _STOP_JS_LOG_REQ = false;

        private async void OnStartTestButtonPressed(object sender, EventArgs e)
        {
            if (GetMainTest().m_State == WebTestGui.Test.TestState.Edit)
            {
                OnTestStart();
            }
            else if (GetMainTest().m_State == WebTestGui.Test.TestState.Run)
            {
                OnTestAbort();
            }
            else if (GetMainTest().m_State == WebTestGui.Test.TestState.Break)
            {
                OnTestContinue();
            }
        }

        public void SetBreakpointsIgnore(bool ignore)
        {
            ignoreBreakpointsCheckbox.Checked = ignore;
        }

        public void OnTestStart()
        {
            // Does parent log path exist
            if (!Path.Exists(GetMainTest().GetRootLogDirectoryPath()))
            {
                string message = "A jelenleg megadott 'Gyökér logolási könyvtár' útvonala nem létezik!";
                string title = "Indítási probléma...";
                MessageBox.Show(message, title);
                return;
            }
            // Unit Panel empty
            if (GetMainTest().m_Units.m_Units.Count == 0)
            {
                string message = "Üres tesztet nem lehet futtatni!";
                string title = "Indítási probléma...";
                MessageBox.Show(message, title);
                return;
            }

            // Checking if the root log directory contains chrome and firefox folders
            if (!Directory.Exists(GetMainTest().GetRootLogDirectoryPath() + @"/chrome"))
            {
                Directory.CreateDirectory(GetMainTest().GetRootLogDirectoryPath() + @"/chrome");
            }
            if (!Directory.Exists(GetMainTest().GetRootLogDirectoryPath() + @"/firefox"))
            {
                Directory.CreateDirectory(GetMainTest().GetRootLogDirectoryPath() + @"/firefox");
            }

            if (!Directory.Exists(GetMainTest().GetRootLogDirectoryPath() + @"/chrome/ltlogs"))
            {
                Directory.CreateDirectory(GetMainTest().GetRootLogDirectoryPath() + @"/chrome/ltlogs");
            }
            if (!Directory.Exists(GetMainTest().GetRootLogDirectoryPath() + @"/firefox/ltlogs"))
            {
                Directory.CreateDirectory(GetMainTest().GetRootLogDirectoryPath() + @"/firefox/ltlogs");
            }

            GetMainTest().m_State = WebTestGui.Test.TestState.Run;
            testStartButton.Text = "TESZT FUT";

            m_TestStartDate = DateTime.Now.ToString("MM_dd_yyyy_HH_mm");
            m_TestStartDateExtra = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            testDateLabel.Text = $"Teszt indításának időpontja: {m_TestStartDateExtra}";
            GetMainTest().m_TestDateTimeStart = testDateLabel.Text;

            string JSONString = GetTestJSON(GetMainTest());

            if (ignoreBreakpointsCheckbox.Checked)
            {
                JSONString = JSONString.Replace("\"break\": true", "\"break\": false");
            }

            DateTime currentTime = DateTime.Now;
            m_TestStartTime = currentTime.ToString("HH:mm:ss:ffffff");

            // Getting python directory
            // TODO: MOST LIKELY WILL CHANGE ON PRODUCTION BUILD
            string temp = Application.ExecutablePath;
            string[] temparray = temp.Split(@"gui");

            File.WriteAllText(temparray[0] + "run.json", JSONString);

            SetColorSchemeToRun();

            if (!GetMainTest().HaveInterceptorActions())
            {
                StartPython(temparray[0], "main.py");
            }
            else
            {
                // Call interceptor python file instead
                StartPython(temparray[0], "main.py");
            }

            File.WriteAllText(GetMainTest().GetRootLogDirectoryPath() + @"/chrome/run.log", string.Empty);
            File.WriteAllText(GetMainTest().GetRootLogDirectoryPath() + @"/firefox/run.log", string.Empty);

            // Later, when there are more files with a filewatcher expand File.Exists() check
            if (!File.Exists(GetMainTest().GetRootLogDirectoryPath() + @"/file.brk"))
            {
                File.Create(GetMainTest().GetRootLogDirectoryPath() + @"/file.brk");
            }
            if (!File.Exists(GetMainTest().GetRootLogDirectoryPath() + @"/js.log"))
            {
                File.Create(GetMainTest().GetRootLogDirectoryPath() + @"/js.log");
            }

            _STOP_BRK_LOG_REQ = false;
            _STOP_JS_LOG_REQ = false;

            if (!m_IsScheduled)
            {
                try
                {
                    File.WriteAllText(GetMainTest().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);
                }
                catch
                {
                }
                string breakPointFilePath = GetMainTest().GetRootLogDirectoryPath() + @"/file.brk";
                StartBreakPointFileWatcher(breakPointFilePath);
            }

            File.WriteAllText(GetMainTest().GetRootLogDirectoryPath() + @"/js.log", string.Empty);
            string jsLogFilePath = GetMainTest().GetRootLogDirectoryPath() + @"/js.log";
            StartJsLogFileWatcher(jsLogFilePath);
            OnSwitchToJsLogButtonPressed(null!, null!);

            m_RunLogConsole.Clear();
            m_JsLogConsole.Clear();

            m_RunLogConsole.AddToConsoles($"\n ------TESZT INDITÁSA: ({m_TestStartDateExtra}) \n");
        }

        public void OnTestAbort()
        {
            m_RunLogConsole.AddToConsoles("\n ------TESZT ABORTÁLVA \n");
            m_CurrentProcess.Kill();
            SetColorSchemeToEdit();

            OnTestFinished();
        }

        public void OnTestBreak(string content, bool continueImmediately = false)
        {
            GetMainTest().m_State = WebTestGui.Test.TestState.Break;
            testStartButton.Text = "TESZT FOLYTATÁSA...";
            SetColorSchemeToBreakpointHit();

            string[] contentParts = content.Split('\n')[0].Split(':'); // (c:ble 1:1)
            m_RunLogConsole.AddToConsoles($"\n ------TESZT SZÜNETELTETVE: UNIT:{contentParts[1]}, ACTION:{contentParts[2]} \n");

            foreach (IUnit unit in GetMainTest().m_Units.m_Units)
            {
                if (unit.m_UnitName == contentParts[1])
                {
                    unitsPanel.ScrollControlIntoView((Control)unit);
                    unit.OnBreakpointHit(int.Parse(contentParts[2]));
                }
            }

            string chromeRunLog = File.ReadAllText(GetMainTest().GetRootLogDirectoryPath() + @"/chrome/run.log");
            string firefoxRunLog = File.ReadAllText(GetMainTest().GetRootLogDirectoryPath() + @"/firefox/run.log");

            LoadRunTimesToActions(chromeRunLog, firefoxRunLog);
            LoadRunTimesToUnits();
            LoadRunTime();

            breakpointIcon.Visible = true;

            if (continueImmediately)
            {
                OnTestContinue();
                return;
            }

            IntPtr mainFormHandle = Handle;
            User32Interop.SetForegroundWindow(mainFormHandle);
        }

        public void OnTestContinue() // Should be called only after a breakpoint hit
        {
            GetMainTest().m_State = WebTestGui.Test.TestState.Run;
            testStartButton.Text = "TESZT FUT.../ TESZT LEÁLLÍTÁSA";
            SetColorSchemeToRun();

            File.WriteAllText(GetMainTest().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);

            foreach (IUnit unit in GetMainTest().m_Units.m_Units)
            {
                unit.OnBreakpointLeave();
            }
            RefreshUnitsPanel();

            breakpointIcon.Visible = false;
        }

        public void OnTestFinished()
        {
            GetMainTest().m_State = WebTestGui.Test.TestState.Edit;
            testStartButton.Text = "TESZT INDÍTÁSA...";
            SetColorSchemeToEdit();

            _STOP_BRK_LOG_REQ = true;
            _STOP_JS_LOG_REQ = true;
            File.WriteAllText(GetMainTest().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);

            string chromeRunLog = File.ReadAllText(GetMainTest().GetRootLogDirectoryPath() + @"/chrome/run.log");
            string firefoxRunLog = File.ReadAllText(GetMainTest().GetRootLogDirectoryPath() + @"/firefox/run.log");
            m_RunLogConsole.AddToChrome("\n\n" + chromeRunLog);
            m_RunLogConsole.AddToFirefox("\n\n" + firefoxRunLog);

            m_JsLogConsole.AddToConsoles(File.ReadAllText(GetMainTest().GetRootLogDirectoryPath() + @"/js.log"));

            m_RunLogConsole.AddToConsoles("\n ------TESZT VÉGE \n");

            if (m_IsScheduled)
            {
                ScheduledTestResult scheduledTestResult = new ScheduledTestResult();

                string schedulerChromeRunLog = File.ReadAllText(GetMainTest().GetRootLogDirectoryPath() + @"/chrome/run.log");
                string schedulerFirefoxRunLog = File.ReadAllText(GetMainTest().GetRootLogDirectoryPath() + @"/firefox/run.log");

                scheduledTestResult.m_ChromeRunLog = schedulerChromeRunLog;
                scheduledTestResult.m_FirefoxRunLog = schedulerFirefoxRunLog;

                scheduledTestResult.m_ChromeJsLog = m_JsLogConsole.m_FirefoxLogString;
                scheduledTestResult.m_FirefoxJsLog = m_JsLogConsole.m_FirefoxLogString;

                scheduledTestResult.m_TestStartTime = m_TestStartTime;
                scheduledTestResult.m_StartDate = m_TestStartDate;
                scheduledTestResult.m_TestJSON = m_ScheduledTestJSON;

                scheduledTestResult.m_ScheduledTestName = GetMainTest().m_Name;
                scheduledTestResult.m_StartDateExtra = m_TestStartDateExtra;

                if (m_CurrentProcess != null)
                    m_CurrentProcess.Kill();

                string logName = m_ScheduledTestLogName == "" ? scheduledTestResult.m_StartDate : m_ScheduledTestLogName;
                string data = scheduledTestResult.GetCompiledData();
                if (!Directory.Exists(GetMainTest().GetRootLogDirectoryPath() + "/scheduled_logs"))
                    Directory.CreateDirectory(GetMainTest().GetRootLogDirectoryPath() + "/scheduled_logs");
                string filename = GetMainTest().GetRootLogDirectoryPath() + "/scheduled_logs/" + logName + ".vslog";
                File.WriteAllText(filename, data);
                Close();
                //LoadScheduledTestResults(scheduledTestResult);
            }
            else
            {
                LoadRunTimesToActions(chromeRunLog, firefoxRunLog);
                LoadRunTimesToUnits();
                LoadRunTime();

                // FOR SCHEDULING
                RefreshUnitsPanel();
            }
        }

        public async Task StartPython(string targetDir, string pythonScriptName)
        {
            string targetDirectory = targetDir;
            string pythonScript = pythonScriptName;

            m_CurrentProcess = Process.Start("cmd.exe", $"/K cd /D {targetDirectory} && python {pythonScript} && exit");

            await m_CurrentProcess.WaitForExitAsync();

            OnTestFinished();
        }

        public async Task StartBreakPointFileWatcher(string logPath)
        {
            FileWatcher fileWatcher = new FileWatcher(logPath);

            fileWatcher.FileChanged += async (content) =>
            {
                m_RunLogConsole.consoleTextBox.Invoke((Action)(() =>
                {
                    if (!string.IsNullOrEmpty(content))
                    {
                        if (content.Split('\n').Length >= 2)
                        {
                            if (content.Split('\n')[0].Split(':')[0] == "c")
                            {
                                if (content.Split('\n')[1].Split(':')[0] == "f")
                                {
                                    if (m_IsScheduled)
                                    {
                                        OnTestBreak(content, true);
                                    }
                                    else
                                    {
                                        OnTestBreak(content);
                                    }
                                }
                            }
                            if (content.Split('\n')[0].Split(':')[0] == "f")
                            {
                                if (content.Split('\n')[1].Split(':')[0] == "c")
                                {
                                    if (m_IsScheduled)
                                    {
                                        OnTestBreak(content, true);
                                    }
                                    else
                                    {
                                        OnTestBreak(content);
                                    }
                                }
                            }
                        }
                    }
                }));
            };

            while (!_STOP_BRK_LOG_REQ)
            {
                await Task.Delay(100);
            }
        }

        public async void StartJsLogFileWatcher(string logPath)
        {
            FileWatcher fileWatcher = new FileWatcher(logPath, true);
            fileWatcher.FileChanged += async (content) =>
            {
                try
                {
                    m_JsLogConsole.consoleTextBox.Invoke((Action)(() =>
                    {
                        if (!string.IsNullOrEmpty(content))
                            m_JsLogConsole.AddToConsoles(content);
                    }));
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                }

                if (_STOP_JS_LOG_REQ)
                {
                    return;
                }
            };

            while (!_STOP_JS_LOG_REQ)
            {
                await Task.Delay(100);
            }
        }

        private void ignoreBreakpointsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreBreakpointsCheckbox.Checked)
            {
                ignoreBreakpointsLabel.Font = new Font(ignoreBreakpointsLabel.Font, FontStyle.Bold);
            }
            else
            {
                ignoreBreakpointsLabel.Font = new Font(ignoreBreakpointsLabel.Font, FontStyle.Regular);
            }
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
                    foreach (IUnit unit in GetMainTest().m_Units.m_Units)
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
                    foreach (IUnit unit in GetMainTest().m_Units.m_Units)
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
            foreach (IUnit unit in GetMainTest().m_Units.m_Units)
            {
                unit.SetRunTime();
            }
        }

        void LoadRunTime()
        {
            int chromeSum = 0;
            int firefoxSum = 0;
            foreach (IUnit unit in GetMainTest().m_Units.m_Units)
            {
                Tuple<int, int> sum = unit.GetRunTime();
                chromeSum += sum.Item1;
                firefoxSum += sum.Item2;
            }

            if (GetMainTest().m_State == WebTestGui.Test.TestState.Break)
            {
                testRunTimeText.ForeColor = Color.Firebrick;
                testRunTimeText.Text = "Jelenlegi teszt futási ideje a Breakpoint-ig:\n " + (chromeSum.ToString() + " / " + firefoxSum.ToString() + " ms");
            }
            else if (GetMainTest().m_State == WebTestGui.Test.TestState.Edit)
            {
                testRunTimeText.ForeColor = Color.DimGray;
                testRunTimeText.Text = "Előző tesztelés teljes futási ideje:\n " + (chromeSum.ToString() + " / " + firefoxSum.ToString() + " ms");
            }

            GetMainTest().m_FullTestRunTime = testRunTimeText.Text;
        }

        long TimeToMicroseconds(string timeStr)
        {
            try
            {
                if (timeStr == null)
                {
                    return 0;
                }
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

        #endregion

        #region Save and load test

        public void OnSaveTestButtonPressed(object sender, EventArgs e)
        {
            SaveTest(GetMainTest());
        }

        private string GetTestJSON(Test test)
        {
            string JSON = TestFormatter.SaveTestToJson(test);
            return JSON;
        }

        private void SaveTest(Test test)
        {
            if (string.IsNullOrEmpty(test.m_SaveFilePath))
            {
                SaveFileDialog of = new SaveFileDialog();
                of.Title = "Teszt mentése...";
                of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    GetMainTest().m_Name = Path.GetFileNameWithoutExtension(of.FileName);
                    string savedInfo = GetTestJSON(GetMainTest());
                    File.WriteAllText(of.FileName, savedInfo);

                    test.m_SaveFilePath = of.FileName;
                    test.m_Name = Path.GetFileNameWithoutExtension(of.FileName);
                    currentlyEditedText.Text = test.m_SaveFilePath;
                    RefreshEditor();
                }
            }
            else
            {
                string savedInfo = GetTestJSON(GetMainTest());
                File.WriteAllText(test.m_SaveFilePath, savedInfo);
            }
        }

        public Test LoadTestFromFile()
        {
            Test loadedTest = new Test(this);

            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt betöltése...";
            of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string loadedInfo = File.ReadAllText(of.FileName);
                loadedTest = TestFormatter.LoadTestFromJson(loadedInfo, loadedTest);
                loadedTest.m_SaveFilePath = of.FileName;

                return loadedTest;
            }
            return null!;
        }

        public Test LoadTestFromFile(string filePath)
        {
            Test loadedTest = new Test(this);

            string loadedInfo = File.ReadAllText(filePath);
            loadedTest = TestFormatter.LoadTestFromJson(loadedInfo, loadedTest);
            loadedTest.m_SaveFilePath = filePath;

            return loadedTest;
        }

        public Test LoadTestFromJSONString(string JSON)
        {
            Test loadedTest = new Test(this);

            string loadedInfo = JSON;
            loadedTest = TestFormatter.LoadTestFromJson(loadedInfo, loadedTest);
            loadedTest.m_SaveFilePath = "NaN";

            return loadedTest;
        }

        #endregion

        #region Editor Refresh

        public void RefreshEditor(bool collapseAllUnits = false)
        {
            // it uses Test instance to load information

            currentlyEditedText.Text = GetMainTest().m_SaveFilePath;
            testNameLabel.Text = GetMainTest().m_Name;

            if (GetMainTest().m_State == Test.TestState.Edit)
            {
                SetColorSchemeToEdit();
                testStartButton.Text = "TESZT INDÍTÁSA...";
            }
            else if (GetMainTest().m_State == Test.TestState.Break)
            {
                SetColorSchemeToBreakpointHit();
                testStartButton.Text = "TESZT FOLYTATÁSA...";
            }
            else if (GetMainTest().m_State == Test.TestState.Run)
            {
                SetColorSchemeToRun();
                testStartButton.Text = "TESZT FUT";
            }

            testRunTimeText.Text = GetMainTest().m_FullTestRunTime;
            testDateLabel.Text = GetMainTest().m_TestDateTimeStart;

            RefreshOptionsPanel();
            RefreshUnitsPanel(collapseAllUnits);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

        }

        #endregion

        #region Root log folder Logic

        private void rootLogDirectoryButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GetMainTest().GetRootLogDirectoryPath());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            rootLogDirectoryButton_Click(sender, e);
        }

        #endregion

        #region Color Schemes

        public void SetColorSchemeToEdit()
        {
            BackColor = Color.FromArgb(255, 50, 50, 53);

            ignoreBreakpointsLabel.BackColor = Color.FromArgb(255, 50, 50, 53);
            ignoreBreakpointsCheckbox.BackColor = Color.FromArgb(255, 50, 50, 53);

            flowLayoutPanel2.BackColor = Color.FromArgb(255, 60, 60, 65);
            unitHeaderPanel.BackColor = Color.FromArgb(255, 40, 40, 45);
            optionHeaderPanel.BackColor = Color.FromArgb(255, 40, 40, 45);
            m_RunLogConsole.SetSchemeToEdtiting();
            m_JsLogConsole.SetSchemeToEdtiting();

            testNameLabel.BackColor = Color.FromArgb(255, 50, 50, 53);

            unitLabel.BackColor = Color.FromArgb(255, 40, 40, 45);
            optionLabel.BackColor = Color.FromArgb(255, 40, 40, 45);

            currentlyEditedLabel.BackColor = Color.FromArgb(255, 60, 60, 65);
            currentlyEditedText.BackColor = Color.FromArgb(255, 60, 60, 65);

            exportOptionsLabel.BackColor = Color.FromArgb(255, 40, 40, 45);
            importOptionsLabel.BackColor = Color.FromArgb(255, 40, 40, 45);
        }

        public void SetColorSchemeToBreakpointHit()
        {
            BackColor = Color.FromArgb(255, 80, 50, 50);

            ignoreBreakpointsLabel.BackColor = Color.FromArgb(255, 80, 50, 50);
            ignoreBreakpointsCheckbox.BackColor = Color.FromArgb(255, 80, 50, 50);

            flowLayoutPanel2.BackColor = Color.FromArgb(255, 90, 60, 60);
            unitHeaderPanel.BackColor = Color.FromArgb(255, 70, 40, 40);
            optionHeaderPanel.BackColor = Color.FromArgb(255, 70, 40, 40);
            m_RunLogConsole.SetSchemeToRunning();
            m_JsLogConsole.SetSchemeToRunning();

            testNameLabel.BackColor = Color.FromArgb(255, 80, 50, 50);

            unitLabel.BackColor = Color.FromArgb(255, 70, 40, 40);
            optionLabel.BackColor = Color.FromArgb(255, 70, 40, 40);

            currentlyEditedLabel.BackColor = Color.FromArgb(255, 90, 60, 60);
            currentlyEditedText.BackColor = Color.FromArgb(255, 90, 60, 60);

            exportOptionsLabel.BackColor = Color.FromArgb(255, 70, 40, 40);
            importOptionsLabel.BackColor = Color.FromArgb(255, 70, 40, 40);
        }

        public void SetColorSchemeToRun()
        {
            BackColor = Color.FromArgb(255, 70, 50, 50);

            ignoreBreakpointsLabel.BackColor = Color.FromArgb(255, 70, 50, 50);
            ignoreBreakpointsCheckbox.BackColor = Color.FromArgb(255, 70, 50, 50);

            flowLayoutPanel2.BackColor = Color.FromArgb(255, 80, 60, 60);
            unitHeaderPanel.BackColor = Color.FromArgb(255, 60, 40, 40);
            optionHeaderPanel.BackColor = Color.FromArgb(255, 60, 40, 40);
            m_RunLogConsole.SetSchemeToRunning();
            m_JsLogConsole.SetSchemeToRunning();

            testNameLabel.BackColor = Color.FromArgb(255, 70, 50, 50);

            unitLabel.BackColor = Color.FromArgb(255, 60, 40, 40);
            optionLabel.BackColor = Color.FromArgb(255, 60, 40, 40);

            currentlyEditedLabel.BackColor = Color.FromArgb(255, 80, 60, 60);
            currentlyEditedText.BackColor = Color.FromArgb(255, 80, 60, 60);

            exportOptionsLabel.BackColor = Color.FromArgb(255, 60, 40, 40);
            importOptionsLabel.BackColor = Color.FromArgb(255, 60, 40, 40);
        }

        #endregion

        #region Scheduling

        public void RUN_SCHEDULED_TEST(string scheduledTestFilePath, string parentLogPath)
        {
            m_ScheduledTestJSON = File.ReadAllText(scheduledTestFilePath);
            Test m_loadedTest = LoadTestFromJSONString(m_ScheduledTestJSON);
            m_Test = m_loadedTest;

            RefreshEditor();

            m_IsScheduled = true;

            // Setting log path
            foreach (IOption option in GetMainTest().m_Options.m_Options)
            {
                if (option is ParentLogPathOption parentLogPathOption)
                {
                    parentLogPathOption.SetRootLogPath(parentLogPath);
                }
            }

            foreach (IUnit unit in GetMainTest().m_Units.m_Units)
            {
                foreach (IAction action in unit.m_Actions.m_Actions)
                {
                    action.m_HaveBreakpoint = false;
                }
            }

            OnTestStart();
        }

        public void LoadScheduledTestResults(ScheduledTestResult results, string logFileName)
        {
            Test m_loadedTest = LoadTestFromJSONString(results.m_TestJSON);
            m_Test = m_loadedTest;

            m_RunLogConsole.Clear();
            m_JsLogConsole.Clear();

            Text += $" Időzített teszt vizsgáló: {results.m_ScheduledTestName} teszt -{results.m_StartDateExtra}";

            testStartButton.Visible = false;
            saveTestButton.Visible = false;

            foreach (IOption option in GetMainTest().m_Options.m_Options)
            {
                option.Enable(false);
            }
            foreach (IDriverOption driverOption in GetMainTest().m_DriverOptions.m_DriverOptions)
            {
                driverOption.Enable(false);
            }
            foreach (IUnit unit in GetMainTest().m_Units.m_Units)
            {
                unit.Enable(false);
            }

            exportOptionsLabel.Visible = false;
            exportOptionTemplate.Visible = false;
            importOptionsLabel.Visible = false;
            importOptionTemplate.Visible = false;
            optionsPanel.Size = new Size(optionsPanel.Size.Width, optionsPanel.Size.Height + 45);
            m_JsLogConsole.Size = new Size(m_JsLogConsole.Size.Width, m_JsLogConsole.Size.Height + 45);

            optionsPanel.Size = new Size(optionsPanel.Size.Width, 423);
            testDateLabel.Visible = false;

            rootLogDirectoryButton.Location = new Point(rootLogDirectoryButton.Location.X + 300, rootLogDirectoryButton.Location.Y);
            pictureBox3.Location = new Point(pictureBox3.Location.X + 300, pictureBox3.Location.Y);

            gotoUnitComboBox.Location = new Point(gotoUnitComboBox.Location.X + 24, gotoUnitComboBox.Location.Y);
            gotoUnitLabel.Location = new Point(gotoUnitLabel.Location.X + 24, gotoUnitLabel.Location.Y);

            rootLogDirectoryButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            pictureBox3.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;

            testDateLabel.Location = new Point(testDateLabel.Location.X, testDateLabel.Location.Y + 45);
            testDateLabel.Text = $"Teszt indításának időpontja: {results.m_StartDateExtra}";

            ignoreBreakpointsLabel.Visible = false;
            ignoreBreakpointsCheckbox.Visible = false;

            currentlyEditedLabel.Text = $"A '{results.m_ScheduledTestName}' időzített teszt ekkor: '{results.m_StartDateExtra}'";
            currentlyEditedText.Text = $"{Path.GetFileNameWithoutExtension(logFileName)} log fájl alapján itt: {logFileName}";

            addUnitButton.Visible = false;
            gotoUnitComboBox.Size = new Size(126, 21);

            m_RunLogConsole.HideClearIcon();
            m_JsLogConsole.HideClearIcon();

            m_TestStartTime = results.m_TestStartTime;
            LoadRunTimesToActions(results.m_ChromeRunLog, results.m_FirefoxRunLog);
            LoadRunTimesToUnits();
            LoadRunTime();

            RefreshUnitsPanel();
            testNameLabel.Text = GetMainTest().m_Name;

            m_RunLogConsole.AddToChrome(results.m_ChromeRunLog);
            m_RunLogConsole.AddToFirefox(results.m_FirefoxRunLog);

            m_JsLogConsole.AddToChrome(results.m_ChromeJsLog);
            m_JsLogConsole.AddToFirefox(results.m_FirefoxJsLog);
        }

        #endregion

        #region Global class variables

        public bool m_IsScheduled = false;
        public string m_ScheduledTestLogName = "";
        string m_ScheduledTestJSON;

        Test m_Test;
        public Test GetMainTest() { return m_Test; }

        Process m_CurrentProcess;

        string m_TestStartTime;
        string m_TestStartDate;
        string m_TestStartDateExtra;

        Console m_RunLogConsole;
        Console m_JsLogConsole;
        UnitHierarchy m_UnitHierarchyPanel;

        #endregion
    }

    #region Scheduled test information structure

    public class ScheduledTestResult
    {
        public string m_ChromeRunLog;
        public string m_FirefoxRunLog;

        public string m_ChromeJsLog;
        public string m_FirefoxJsLog;

        public string m_TestStartTime;
        public string m_StartDate;
        public string m_TestJSON;

        public string m_ScheduledTestName;
        public string m_StartDateExtra;

        public string GetCompiledData()
        {
            string data = "";
            data += m_ChromeRunLog + m_SplitString;
            data += m_FirefoxRunLog + m_SplitString;
            data += m_ChromeJsLog + m_SplitString;
            data += m_FirefoxJsLog + m_SplitString;
            data += m_TestStartTime + m_SplitString;
            data += m_StartDate + m_SplitString;
            data += m_TestJSON + m_SplitString;
            data += m_ScheduledTestName + m_SplitString;
            data += m_StartDateExtra;

            return data;
        }

        public void SetData(string compiledData)
        {
            string[] data = compiledData.Split(m_SplitString);
            m_ChromeRunLog = data[0];
            m_FirefoxRunLog = data[1];
            m_ChromeJsLog = data[2];
            m_FirefoxJsLog = data[3];
            m_TestStartTime = data[4];
            m_StartDate = data[5];
            m_TestJSON = data[6];
            m_ScheduledTestName = data[7];
            m_StartDateExtra = data[8];
        }

        string m_SplitString = "Ł$";
    }

    #endregion

    #region Window foreground

    public static class User32Interop
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
    }

    #endregion
}
