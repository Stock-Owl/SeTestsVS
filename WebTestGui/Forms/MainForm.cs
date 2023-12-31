using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebTestGui
{
    public partial class MainForm : Form
    {
        /* TODO:
            - Id�z�t� app integr�l�sa
            - RAW szerkezt� (a teszt JSON sz�veg� �ssze�ll�t�sa)
        */

        public MainForm()
        {
            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            Text = AppConsts.s_AppName + " " + AppConsts.s_AppVersion;

            m_RunLogConsole = new Console(this);
            Controls.Add(m_RunLogConsole);
            m_RunLogConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            m_RunLogConsole.Location = new Point(0, 0);
            m_RunLogConsole.Size = new Size(410, 620);
            m_RunLogConsole.BringToFront();

            m_JsLogConsole = new Console(this);
            Controls.Add(m_JsLogConsole);
            m_JsLogConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            m_JsLogConsole.Location = new Point(795, 136);
            m_JsLogConsole.Size = new Size(327, 353);
            m_JsLogConsole.Visible = false;

            m_TestTab = new TestTab(this);
            Controls.Add(m_TestTab);
            m_TestTab.Location = new Point(410, 0);
            m_TestTab.AddNewBlankItem();

            m_RunLogConsole.AddToConsoles("Applik�ci� ind�t�sa...\n");
            m_RunLogConsole.AddToConsoles("Verzi�: " + $"{AppConsts.s_AppVersion}\n");
            m_RunLogConsole.AddToConsoles("Id�: " + $"{DateTime.Now}\n");

            m_JsLogConsole.AddToConsoles("JavaScript konzol...\n");
            m_JsLogConsole.AddToConsoles("A teszt ideje alatt minden JavaScript log " +
                "inform�ci� ide lesz kiiratva.\n");

            RefreshOptionsPanel();
        }

        #region Option panel function

        private void RefreshOptionsPanel()
        {
            optionsPanel.Controls.Clear();

            Control[] optionControls = new Control[Test().m_Options.m_Options.Count];
            for (int i = 0; i < optionControls.Length; i++)
            {
                optionControls[i] = (Control)Test().m_Options.m_Options[i];
            }
            optionsPanel.Controls.AddRange(optionControls);

            Control[] driverOptionControls = new Control[Test().m_DriverOptions.m_DriverOptions.Count];
            for (int i = 0; i < driverOptionControls.Length; i++)
            {
                driverOptionControls[i] = (Control)Test().m_DriverOptions.m_DriverOptions[i];
            }
            optionsPanel.Controls.AddRange(driverOptionControls);
        }

        private void exportOptionTemplate_Click(object sender, EventArgs e)
        {
            SaveFileDialog of = new SaveFileDialog();
            of.Title = "Teszt opci�k ment�se...";
            of.Filter = $"Teszt opci�k f�jl|*{AppConsts.s_AppDefaultFileExtension + "options"}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string savedInfo = TestFormatter.SaveOptionsFromTest(Test());
                File.WriteAllText(of.FileName, savedInfo);
            }
        }

        private void importOptionTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt opci�k bet�lt�se...";
            of.Filter = $"Teszt opci�k f�jl|*{AppConsts.s_AppDefaultFileExtension + "options"}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string loadedInfo = File.ReadAllText(of.FileName);
                TestFormatter.LoadOptionsToTest(loadedInfo, Test());
                RefreshOptionsPanel();
            }
        }

        #endregion

        #region Unit handlers and functions

        private void RefreshUnitsPanel()
        {
            Control[] controls = new Control[Test().m_Units.m_Units.Count];

            for (int i = 0; i < controls.Length; i++)
            {
                Test().m_Units.m_Units[i].SetUId(i);
                Test().m_Units.m_Units[i].Refresh();
                controls[i] = (Control)Test().m_Units.m_Units[i];
            }

            unitsPanel.Controls.Clear();
            unitsPanel.Controls.AddRange(controls);
        }

        private void OnAddUnitButtonPressed(object sender, EventArgs e)
        {
            IUnit unit = new UnitPanel();
            unit.m_ParentForm = this;

            unit.SetUId(unitsPanel.Controls.Count);
            Test().m_Units.m_Units.Add(unit);
            unit.m_UnitName = $"UNIT {Test().m_Units.m_Units.Count}";
            unit.Refresh();
            RefreshUnitsPanel();
            unitsPanel.ScrollControlIntoView((Control)unit);
        }

        public void DeleteUnit(IUnit unit)
        {
            Test().m_Units.m_Units.Remove(unit);
            RefreshUnitsPanel();
        }

        public void MoveUnit(IUnit unit, int newUId)
        {
            Test().m_Units.MoveUnit(unit, newUId);
            RefreshUnitsPanel();
        }

        private void gotoUnitComboBox_DropDown(object sender, EventArgs e)
        {
            gotoUnitComboBox.Items.Clear();
            string[] unitNames = new string[Test().m_Units.m_Units.Count];
            for (int i = 0; i < unitNames.Length; i++)
            {
                unitNames[i] = Test().m_Units.m_Units[i].m_UnitName;
            }

            gotoUnitComboBox.Items.AddRange(unitNames);
        }

        private void gotoUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUnitName = gotoUnitComboBox.GetItemText(gotoUnitComboBox.SelectedItem)!;

            IUnit selectedUnit = new UnitPanel();
            foreach (IUnit unit in Test().m_Units.m_Units)
            {
                if (unit.m_UnitName == selectedUnitName)
                {
                    selectedUnit = unit;
                }
            }
            unitsPanel.ScrollControlIntoView((Control)selectedUnit);
        }

        #endregion

        #region Browser Checkboxes logic functions

        private void OnChromeCheckBoxChecked(object sender, EventArgs e)
        {
            if (chromeCheckBox.Checked)
            {
                chromeCheckBox.Checked = true;
                chromeCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Bold);
                Test().m_Browsers.AddIfNotExists("chrome");
            }
            else
            {
                chromeCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Regular);
                Test().m_Browsers.Remove("chrome");

                if (!firefoxCheckBox.Checked)
                {
                    firefoxCheckBox.Checked = true;
                }
            }
        }

        private void OnFirefoxCheckBoxChecked(object sender, EventArgs e)
        {
            if (firefoxCheckBox.Checked)
            {
                firefoxCheckBox.Checked = true;
                firefoxCheckBox.Font = new Font(firefoxCheckBox.Font, FontStyle.Bold);
                Test().m_Browsers.AddIfNotExists("firefox");
            }
            else
            {
                firefoxCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Regular);
                Test().m_Browsers.Remove("firefox");

                if (!chromeCheckBox.Checked)
                {
                    chromeCheckBox.Checked = true;
                }
            }
        }

        #endregion

        #region Methods for handling picture ratios when the window got resized

        private void OnChromeLogoResize(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(25, 25);
        }

        private void OnFirefoxLogoResize(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(25, 25);
        }

        #endregion

        #region Logic switching between options and JS console

        private void OnSwitchToOptionsButtonPressed(object sender, EventArgs e)
        {
            optionHeaderPanel.Visible = true;
            optionsPanel.Visible = true;
            optionLabel.Visible = true;

            m_JsLogConsole.Visible = false;

            switchToOptionsButton.ForeColor = Color.White;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Bold);

            switchToJsLogButton.ForeColor = Color.Silver;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
        }

        private void OnSwitchToJsLogButtonPressed(object sender, EventArgs e)
        {
            m_JsLogConsole.Visible = true;

            optionHeaderPanel.Visible = false;
            optionsPanel.Visible = false;
            optionLabel.Visible = false;

            switchToJsLogButton.ForeColor = Color.White;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Bold);

            switchToOptionsButton.ForeColor = Color.Silver;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
        }

        #endregion

        #region TEST RUNTIME

        private bool _STOP_BRK_LOG_REQ = false;
        private bool _STOP_JS_LOG_REQ = false;

        private async void OnStartTestButtonPressed(object sender, EventArgs e)
        {
            if (Test().m_State == WebTestGui.Test.TestState.Edit)
            {
                OnTestStart();
            }
            else if (Test().m_State == WebTestGui.Test.TestState.Run)
            {
                OnTestAbort();
            }
            else if (Test().m_State == WebTestGui.Test.TestState.Break)
            {
                OnTestContinue();
            }
        }

        public async void OnTestStart()
        {
            // Does parent log path exist
            if (!Path.Exists(Test().GetRootLogDirectoryPath()))
            {
                string message = "A jelenleg megadott 'Gy�k�r logol�si k�nyvt�r' �tvonala nem l�tezik!";
                string title = "Ind�t�si probl�ma...";
                MessageBox.Show(message, title);
                return;
            }
            // Both browsers selected
            if (!chromeCheckBox.Checked || !firefoxCheckBox.Checked)
            {
                string message = "Jelenleg a Tesztel�s csak mindk�t b�ng�sz�vel t�rt�nhet egyszerre!";
                string title = "Ind�t�si probl�ma...";
                MessageBox.Show(message, title);
                return;
            }
            // Unit Panel empty
            if (Test().m_Units.m_Units.Count == 0)
            {
                string message = "�res tesztet nem lehet futtatni!";
                string title = "Ind�t�si probl�ma...";
                MessageBox.Show(message, title);
                return;
            }

            // Checking if the root log directory contains chrome and firefox folders
            if (!Directory.Exists(Test().GetRootLogDirectoryPath() + @"/chrome"))
            {
                Directory.CreateDirectory(Test().GetRootLogDirectoryPath() + @"/chrome");
            }
            if (!Directory.Exists(Test().GetRootLogDirectoryPath() + @"/firefox"))
            {
                Directory.CreateDirectory(Test().GetRootLogDirectoryPath() + @"/firefox");
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

            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/chrome/run.log", string.Empty);
            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/firefox/run.log", string.Empty);

            // Later, when there are more files with a filewatcher expand File.Exists() check
            if (!File.Exists(Test().GetRootLogDirectoryPath() + @"/file.brk"))
            {
                File.Create(Test().GetRootLogDirectoryPath() + @"/file.brk");
            }
            if (!File.Exists(Test().GetRootLogDirectoryPath() + @"/js.log"))
            {
                File.Create(Test().GetRootLogDirectoryPath() + @"/js.log");
            }

            _STOP_BRK_LOG_REQ = false;
            _STOP_JS_LOG_REQ = false;

            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);
            string breakPointFilePath = Test().GetRootLogDirectoryPath() + @"/file.brk";
            StartBreakPointFileWatcher(breakPointFilePath);

            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/js.log", string.Empty);
            string jsLogFilePath = Test().GetRootLogDirectoryPath() + @"/js.log";
            StartJsLogFileWatcher(jsLogFilePath);
            OnSwitchToJsLogButtonPressed(null!, null!);

            if (!Test().HaveInterceptorActions())
                m_RunLogConsole.AddToConsoles("\n ------TESZT INDIT�SA \n");
            else
                m_RunLogConsole.AddToConsoles("\n ------INTERCEPTOROS TESZT INDIT�SA \n");
        }

        public void OnTestAbort()
        {
            m_RunLogConsole.AddToConsoles("\n ------TESZT LE�LL�TVA \n");
            m_CurrentProcess.Kill();
            SetColorSchemeToEdit();

            OnTestFinished();
        }

        public void OnTestBreak(string content)
        {
            Test().m_State = WebTestGui.Test.TestState.Break;
            m_RunLogConsole.AddToConsoles("\n ------TESZT SZ�NETELTETVE (BREAKPOINT) \n");
            testStartButton.Text = "TESZT FOLYTAT�SA...";
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

            string chromeRunLog = File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/chrome/run.log");
            string firefoxRunLog = File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/firefox/run.log");

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
            testStartButton.Text = "TESZT FUT.../ TESZT LE�LL�T�SA";
            SetColorSchemeToRun();

            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);

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
            testStartButton.Text = "TESZT IND�T�SA...";
            SetColorSchemeToEdit();

            _STOP_BRK_LOG_REQ = true;
            _STOP_JS_LOG_REQ = true;
            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);

            string chromeRunLog = File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/chrome/run.log");
            string firefoxRunLog = File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/firefox/run.log");
            m_RunLogConsole.AddToChrome("\n\n" + chromeRunLog);
            m_RunLogConsole.AddToFirefox("\n\n" + firefoxRunLog);

            m_JsLogConsole.AddToConsoles(File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/js.log"));

            m_RunLogConsole.AddToConsoles("\n ------TESZT V�GE \n");

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
                testRunTimeText.Text = "Jelenlegi teszt fut�si ideje a Breakpoint-ig: " + (chromeSum.ToString() + " / " + firefoxSum.ToString() + " ms");
            }
            else if (Test().m_State == WebTestGui.Test.TestState.Edit)
            {
                testRunTimeText.ForeColor = Color.DimGray;
                testRunTimeText.Text = "El�z� tesztel�s teljes fut�si ideje: " + (chromeSum.ToString() + " / " + firefoxSum.ToString() + " ms");
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
                                        OnTestBreak(content);
                                    }
                                }
                                if (content.Split('\n')[0].Split(':')[0] == "f")
                                {
                                    if (content.Split('\n')[1].Split(':')[0] == "c")
                                    {
                                        OnTestBreak(content);
                                    }
                                }
                            }
                        }
                    }));

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
                    m_JsLogConsole.consoleTextBox.Invoke((Action)(() =>
                    {
                        if (!string.IsNullOrEmpty(content))
                            m_JsLogConsole.AddToConsoles(content);
                    }));

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
        }

        #endregion

        #region Save and load test

        public void OnSaveTestButtonPressed(object sender, EventArgs e)
        {
            SaveTest(Test());
        }

        private void OnLoadTestButtonPressed(object sender, EventArgs e)
        {
            m_TestTab.AddNewItem(sender, e);
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
                of.Title = "Teszt ment�se...";
                of.Filter = $"Teszt f�jl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    Test().m_Name = Path.GetFileNameWithoutExtension(of.FileName);
                    string savedInfo = GetTestJSON(Test());
                    File.WriteAllText(of.FileName, savedInfo);

                    test.m_SaveFilePath = of.FileName;
                    test.m_Name = Path.GetFileNameWithoutExtension(of.FileName);
                    currentlyEditedText.Text = test.m_SaveFilePath;

                    m_TestTab.AddNewItemFromFilePath(of.FileName);
                }
            }
            else
            {
                string savedInfo = GetTestJSON(Test());
                File.WriteAllText(test.m_SaveFilePath, savedInfo);
            }
        }

        public Test LoadTestFromFile()
        {
            Test loadedTest = new Test(this);

            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt bet�lt�se...";
            of.Filter = $"Teszt f�jl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
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

        #endregion

        #region Editor Refresh method

        public void RefreshEditor()
        {
            // Must happen after m_TestTab.m_SelectedItem.m_Test set in the TestTab
            // it uses that Test instance to load information

            if (Test().m_Browsers.Contains("chrome"))
            {
                chromeCheckBox.Checked = true;
            }
            else
            {
                chromeCheckBox.Checked = false;
            }

            if (Test().m_Browsers.Contains("firefox"))
            {
                firefoxCheckBox.Checked = true;
            }
            else
            {
                firefoxCheckBox.Checked = false;
            }

            currentlyEditedText.Text = Test().m_SaveFilePath;
            testNameLabel.Text = Test().m_Name;

            breakpointIcon.Location = new Point((testNameLabel.Location.X + testNameLabel.Size.Width), 47);
            testRunTimeText.Location = new Point((breakpointIcon.Location.X + breakpointIcon.Size.Width + 10), 52);

            if (Test().m_State == WebTestGui.Test.TestState.Edit)
            {
                SetColorSchemeToEdit();
                testStartButton.Text = "TESZT IND�T�SA...";
            }
            else if (Test().m_State == WebTestGui.Test.TestState.Break)
            {
                SetColorSchemeToBreakpointHit();
                testStartButton.Text = "TESZT FOLYTAT�SA...";
            }
            else if (Test().m_State == WebTestGui.Test.TestState.Run)
            {
                SetColorSchemeToRun();
                testStartButton.Text = "TESZT FUT";
            }

            RefreshOptionsPanel();
            RefreshUnitsPanel();
        }

        #endregion

        #region Root log folder Logic

        private void rootLogDirectoryButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Test().GetRootLogDirectoryPath());
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
            flowLayoutPanel2.BackColor = Color.FromArgb(255, 60, 60, 65);
            unitHeaderPanel.BackColor = Color.FromArgb(255, 40, 40, 45);
            optionHeaderPanel.BackColor = Color.FromArgb(255, 40, 40, 45);
            m_RunLogConsole.SetSchemeToEdtiting();
            m_JsLogConsole.SetSchemeToEdtiting();

            testNameLabel.BackColor = Color.FromArgb(255, 50, 50, 53);
            browserLabel.BackColor = Color.FromArgb(255, 50, 50, 53);
            chromeCheckBox.BackColor = Color.FromArgb(255, 50, 50, 53);
            firefoxCheckBox.BackColor = Color.FromArgb(255, 50, 50, 53);
            pictureBox1.BackColor = Color.FromArgb(255, 50, 50, 53);
            pictureBox2.BackColor = Color.FromArgb(255, 50, 50, 53);

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
            flowLayoutPanel2.BackColor = Color.FromArgb(255, 90, 60, 60);
            unitHeaderPanel.BackColor = Color.FromArgb(255, 70, 40, 40);
            optionHeaderPanel.BackColor = Color.FromArgb(255, 70, 40, 40);
            m_RunLogConsole.SetSchemeToRunning();
            m_JsLogConsole.SetSchemeToRunning();

            testNameLabel.BackColor = Color.FromArgb(255, 80, 50, 50);
            browserLabel.BackColor = Color.FromArgb(255, 80, 50, 50);
            chromeCheckBox.BackColor = Color.FromArgb(255, 80, 50, 50);
            firefoxCheckBox.BackColor = Color.FromArgb(255, 80, 50, 50);
            pictureBox1.BackColor = Color.FromArgb(255, 80, 50, 50);
            pictureBox2.BackColor = Color.FromArgb(255, 80, 50, 50);

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
            flowLayoutPanel2.BackColor = Color.FromArgb(255, 80, 60, 60);
            unitHeaderPanel.BackColor = Color.FromArgb(255, 60, 40, 40);
            optionHeaderPanel.BackColor = Color.FromArgb(255, 60, 40, 40);
            m_RunLogConsole.SetSchemeToRunning();
            m_JsLogConsole.SetSchemeToRunning();

            testNameLabel.BackColor = Color.FromArgb(255, 70, 50, 50);
            browserLabel.BackColor = Color.FromArgb(255, 70, 50, 50);
            chromeCheckBox.BackColor = Color.FromArgb(255, 70, 50, 50);
            firefoxCheckBox.BackColor = Color.FromArgb(255, 70, 50, 50);
            pictureBox1.BackColor = Color.FromArgb(255, 70, 50, 50);
            pictureBox2.BackColor = Color.FromArgb(255, 70, 50, 50);

            unitLabel.BackColor = Color.FromArgb(255, 60, 40, 40);
            optionLabel.BackColor = Color.FromArgb(255, 60, 40, 40);

            currentlyEditedLabel.BackColor = Color.FromArgb(255, 80, 60, 60);
            currentlyEditedText.BackColor = Color.FromArgb(255, 80, 60, 60);

            exportOptionsLabel.BackColor = Color.FromArgb(255, 60, 40, 40);
            importOptionsLabel.BackColor = Color.FromArgb(255, 60, 40, 40);
        }

        #endregion

        public static bool s_IsChromeChecked = true;

        TestTab m_TestTab;
        public Test Test() { return m_TestTab.m_SelectedItem.m_Test; }

        Process m_CurrentProcess;

        string m_TestStartTime;

        Console m_RunLogConsole;
        Console m_JsLogConsole;
    }

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
}
