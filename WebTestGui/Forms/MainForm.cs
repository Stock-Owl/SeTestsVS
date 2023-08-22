using System.Diagnostics;

namespace WebTestGui
{
    public partial class MainForm : Form
    {
        /* TODO:
        - Idõzítõ különálló applikáció (tesztek futtatásának idõzítése, és beállítása)
        - Sablon új test
        - Opciók sablonok létrehozása, import és exportálása
        - Action idõmérés
        - Új logó hozzáadása
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
            m_RunLogConsole.Size = new Size(270, 520);

            m_JsLogConsole = new Console(this);
            Controls.Add(m_JsLogConsole);
            m_JsLogConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            m_JsLogConsole.Location = new Point(645, 155);
            m_JsLogConsole.Size = new Size(327, 267);
            m_JsLogConsole.Visible = false;

            m_TestTab = new TestTab(this);
            Controls.Add(m_TestTab);
            m_TestTab.Location = new Point(270, 0);
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
            else if (Test().m_State == WebTestGui.Test.TestState.Break)
            {
                OnTestContinue();
            }
        }

        public async void OnTestStart()
        {
            string JSONString = GetTestJSON(Test());

            string temp = Application.ExecutablePath;
            string[] temparray = temp.Split(@"WebTestGui");

            File.WriteAllText(temparray[0] + "run.json", JSONString);

            SetColorSchemeToRun();

            StartPython(temparray[0]);

            Test().m_State = WebTestGui.Test.TestState.Run;
            testStartButton.Text = "TESZT FUT";
            m_TestTab.RefreshTabItems();

            _STOP_JS_LOG_REQ = false;
            _STOP_BRK_LOG_REQ = false;

            string jsLogFilePath = Test().GetRootLogDirectoryPath() + @"/js.log";
            StartJSLogFileWatcher(jsLogFilePath);
            string breakPointFilePath = Test().GetRootLogDirectoryPath() + @"/file.brk";
            StartBreakPointFileWatcher(breakPointFilePath);

            m_RunLogConsole.AddToConsoles("\n TESZT INDITÁSA \n");
        }

        public void OnTestBreak()
        {
            Test().m_State = WebTestGui.Test.TestState.Break;
            testStartButton.Text = "TESZT FOLYTATÁSA...";
            m_TestTab.RefreshTabItems();
        }

        public void OnTestContinue()
        {
            Test().m_State = WebTestGui.Test.TestState.Run;
            testStartButton.Text = "TESZT FUT";
            m_TestTab.RefreshTabItems();
        }

        public async Task OnTestFinished()
        {
            SetColorSchemeToEdit();
            m_RunLogConsole.AddToConsoles("\n TESZT VÉGE");

            _STOP_JS_LOG_REQ = true;
            _STOP_BRK_LOG_REQ = true;

            m_RunLogConsole.AddToChrome("\n\n" + File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/chrome/run.log"));
            m_RunLogConsole.AddToFirefox("\n\n" + File.ReadAllText(Test().GetRootLogDirectoryPath() + @"/firefox/run.log"));

            Test().m_State = WebTestGui.Test.TestState.Edit;
            testStartButton.Text = "TESZT INDÍTÁSA...";
            m_TestTab.RefreshTabItems();
        }

        public async Task StartPython(string targetDir)
        {
            string targetDirectory = targetDir;
            string pythonScript = "main.py";

            Process process = Process.Start("cmd.exe", $"/K cd /D {targetDirectory} && python {pythonScript}");

            await process.WaitForExitAsync();

            await OnTestFinished();
        }

        public async void StartJSLogFileWatcher(string logPath)
        {
            using (FileWatcher fileWatcher = new FileWatcher(logPath))
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
                            m_RunLogConsole.AddToConsoles("\nBREAKPOINT HIT:" + content);
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
            unitsPanel.BackColor = Color.FromArgb(255, 45, 45, 50);
            optionsPanel.BackColor = Color.FromArgb(255, 45, 45, 50);
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

            m_TestTab.Enabled = true;
            saveTestButton.Enabled = true;
            loadTestButton.Enabled = true;
        }

        public void SetColorSchemeToRun()
        {
            BackColor = Color.FromArgb(255, 60, 50, 50);
            unitsPanel.BackColor = Color.FromArgb(255, 50, 45, 45);
            optionsPanel.BackColor = Color.FromArgb(255, 50, 45, 45);
            flowLayoutPanel2.BackColor = Color.FromArgb(255, 70, 60, 60);
            unitHeaderPanel.BackColor = Color.FromArgb(255, 50, 40, 40);
            optionHeaderPanel.BackColor = Color.FromArgb(255, 50, 40, 40);
            m_RunLogConsole.SetSchemeToRunning();
            m_JsLogConsole.SetSchemeToRunning();

            testNameLabel.BackColor = Color.FromArgb(255, 60, 50, 50);
            browserLabel.BackColor = Color.FromArgb(255, 60, 50, 50);
            chromeCheckBox.BackColor = Color.FromArgb(255, 60, 50, 50);
            firefoxCheckBox.BackColor = Color.FromArgb(255, 60, 50, 50);
            pictureBox1.BackColor = Color.FromArgb(255, 60, 50, 50);
            pictureBox2.BackColor = Color.FromArgb(255, 60, 50, 50);

            unitLabel.BackColor = Color.FromArgb(255, 50, 40, 40);
            optionLabel.BackColor = Color.FromArgb(255, 50, 40, 40);

            currentlyEditedLabel.BackColor = Color.FromArgb(255, 70, 60, 60);
            currentlyEditedText.BackColor = Color.FromArgb(255, 70, 60, 60);

            m_TestTab.Enabled = false;
            saveTestButton.Enabled = false;
            loadTestButton.Enabled = false;
        }

        #endregion

        public static bool s_IsChromeChecked = true;

        TestTab m_TestTab;
        public Test Test() { return m_TestTab.m_SelectedItem.m_Test; }

        Console m_RunLogConsole;
        Console m_JsLogConsole;
    }
}
