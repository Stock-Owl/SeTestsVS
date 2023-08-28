using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebTestGui
{
    public partial class MainForm : Form
    {
        /* TODO:
            - Sablon új test
            - Opciók sablonok létrehozása, import és exportálása
            - Log fájlok elõkészítése, ha nem léteznek még (FileWatcher miatt)
            - Idõzítõ app integrálása
            - Unit keresés (név alapján)
            - Teszt lefutása után leírni az egész teszt lefutási idejét (Chrome/Firefox)
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
            m_JsLogConsole.Location = new Point(795, 155);
            m_JsLogConsole.Size = new Size(327, 353);
            m_JsLogConsole.Visible = false;

            m_TestTab = new TestTab(this);
            Controls.Add(m_TestTab);
            m_TestTab.Location = new Point(410, 0);
            m_TestTab.AddNewBlankItem();

            m_RunLogConsole.AddToConsoles("Applikáció indítása...\n");
            m_RunLogConsole.AddToConsoles("Verzió: " + $"{AppConsts.s_AppVersion}\n");
            m_RunLogConsole.AddToConsoles("Idõ: " + $"{DateTime.Now}\n");

            m_JsLogConsole.AddToConsoles("JavaScript konzol...\n");
            m_JsLogConsole.AddToConsoles("A teszt ideje alatt minden JavaScript log " +
                "információ ide lesz kiiratva.");

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

        private bool _STOP_JS_LOG_REQ = false;
        private bool _STOP_BRK_LOG_REQ = false;

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
                string message = "A jelenleg megadott 'Gyökér logolási könyvtár' útvonala nem létezik!";
                string title = "Indítási probléma...";
                MessageBox.Show(message, title);
                return;
            }
            // Both browsers selected
            if (!chromeCheckBox.Checked || !firefoxCheckBox.Checked)
            {
                string message = "Jelenleg a Tesztelés csak mindkét böngészõvel történhet egyszerre!";
                string title = "Indítási probléma...";
                MessageBox.Show(message, title);
                return;
            }
            // Unit Panel empty
            if (Test().m_Units.m_Units.Count == 0)
            {
                string message = "Üres tesztet nem lehet futtatni!";
                string title = "Indítási probléma...";
                MessageBox.Show(message, title);
                return;
            }

            Test().m_State = WebTestGui.Test.TestState.Run;
            testStartButton.Text = "TESZT FUT";

            string JSONString = GetTestJSON(Test());
            DateTime currentTime = DateTime.Now;
            m_TestStartTime = currentTime.ToString("HH:mm:ss:ffffff");

            string temp = Application.ExecutablePath;
            string[] temparray = temp.Split(@"WebTestGui");

            File.WriteAllText(temparray[0] + "run.json", JSONString);

            SetColorSchemeToRun();

            StartPython(temparray[0]);

            m_TestTab.RefreshTabItems();

            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/chrome/run.log", string.Empty);
            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/firefox/run.log", string.Empty);

            // string jsLogFilePath = Test().GetRootLogDirectoryPath() + @"/js.log";
            // StartJSLogFileWatcher(jsLogFilePath);

            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);
            string breakPointFilePath = Test().GetRootLogDirectoryPath() + @"/file.brk";
            StartBreakPointFileWatcher(breakPointFilePath);

            _STOP_JS_LOG_REQ = false;
            _STOP_BRK_LOG_REQ = false;

            m_RunLogConsole.AddToConsoles("\n ------TESZT INDITÁSA \n");
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
            m_RunLogConsole.AddToConsoles("\n ------TESZT SZÜNETELTETVE \n");
            testStartButton.Text = "TESZT FOLYTATÁSA...";

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

            breakpointIcon.Visible = true;

            m_TestTab.RefreshTabItems();

            IntPtr mainFormHandle = Handle;
            User32Interop.SetForegroundWindow(mainFormHandle);
        }

        public void OnTestContinue() // Should be called only after a breakpoint hit
        {
            Test().m_State = WebTestGui.Test.TestState.Run;
            testStartButton.Text = "TESZT FUT.../ TESZT LEÁLLÍTÁSA";

            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);

            foreach (IUnit unit in Test().m_Units.m_Units)
            {
                unit.OnBreakpointLeave();
            }
            RefreshUnitsPanel();

            breakpointIcon.Visible = true;

            m_TestTab.RefreshTabItems();
        }

        public void OnTestFinished()
        {
            Test().m_State = WebTestGui.Test.TestState.Edit;
            testStartButton.Text = "TESZT INDÍTÁSA...";
            SetColorSchemeToEdit();

            _STOP_JS_LOG_REQ = true;
            _STOP_BRK_LOG_REQ = true;
            File.WriteAllText(Test().GetRootLogDirectoryPath() + @"/file.brk", string.Empty);

            string chromeRunLog = File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/chrome/run.log");
            string firefoxRunLog = File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/firefox/run.log");
            m_RunLogConsole.AddToChrome("\n\n" + chromeRunLog);
            m_RunLogConsole.AddToFirefox("\n\n" + firefoxRunLog);

            string JsLog = File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/js.log");
            m_JsLogConsole.AddToConsoles("\n\n" + JsLog);

            m_RunLogConsole.AddToConsoles("\n ------TESZT VÉGE \n");

            LoadRunTimesToActions(chromeRunLog, firefoxRunLog);
            LoadRunTimesToUnits();

            m_TestTab.RefreshTabItems();
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

        public async Task StartPython(string targetDir)
        {
            string targetDirectory = targetDir;
            string pythonScript = "main.py";

            m_CurrentProcess = Process.Start("cmd.exe", $"/K cd /D {targetDirectory} && python {pythonScript} && exit");

            await m_CurrentProcess.WaitForExitAsync();

            OnTestFinished();
        }

        public async void StartJSLogFileWatcher(string logPath)
        {
            using (FileWatcher fileWatcher = new FileWatcher(logPath, true))
            {
                fileWatcher.FileChanged += async (content) =>
                {
                    m_RunLogConsole.consoleTextBox.Invoke((Action)(() =>
                    {
                        m_JsLogConsole.AddToConsoles("\n" + content + "\n");
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
                                        m_RunLogConsole.AddToConsoles("\nBREAKPOINT HIT:" + content.Split('\n')[0]);
                                    }
                                }
                                if (content.Split('\n')[0].Split(':')[0] == "f")
                                {
                                    if (content.Split('\n')[1].Split(':')[0] == "c")
                                    {
                                        OnTestBreak(content);
                                        m_RunLogConsole.AddToConsoles("\nBREAKPOINT HIT:" + content.Split('\n')[0]);
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

        #endregion

        #region Save and load test

        private void OnSaveTestButtonPressed(object sender, EventArgs e)
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
                of.Title = "Teszt mentése...";
                of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
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

            if (Test().m_State == WebTestGui.Test.TestState.Edit)
            {
                SetColorSchemeToEdit();
                testStartButton.Text = "TESZT INDÍTÁSA...";
            }
            else if (Test().m_State == WebTestGui.Test.TestState.Break)
            {
                SetColorSchemeToRun();
                testStartButton.Text = "TESZT FOLYTATÁSA...";
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

            saveTestButton.Enabled = true;
            loadTestButton.Enabled = true;
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

            saveTestButton.Enabled = false;
            loadTestButton.Enabled = false;
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
