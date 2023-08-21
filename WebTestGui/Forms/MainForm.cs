using System.Diagnostics;

namespace WebTestGui
{
    public partial class MainForm : Form
    {
        /* TODO:
        - Idõzítõ különálló applikáció (tesztek futtatásának idõzítése, és beállítása)
        - Python backend meghívása és kommunikációs fájlok kezelése
        - Sablon új test
        - Opciók sablonok létrehozása, import és exportálása
        - Action idõmérés
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
            m_RunLogConsole.Size = new Size(240, 520);

            m_JsLogConsole = new Console(this);
            Controls.Add(m_JsLogConsole);
            m_JsLogConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            m_JsLogConsole.Location = new Point(645, 142);
            m_JsLogConsole.Size = new Size(327, 267);
            m_JsLogConsole.Visible = false;

            m_TestTab = new TestTab(this);
            Controls.Add(m_TestTab);
            m_TestTab.Location = new Point(236, 0);
            m_TestTab.AddNewBlankItem();

            m_RunLogConsole.AddToConsoles("Applikáció indítása...\n");
            m_RunLogConsole.AddToConsoles("Verzió: " + $"{AppConsts.s_AppVersion}\n");
            m_RunLogConsole.AddToConsoles("Idõ: " + $"{DateTime.Now}\n");
            m_RunLogConsole.AddToConsoles("Konzol inicializálása...\n\n");
            m_RunLogConsole.AddToConsoles("Az alkalmazás sikeresen elindult, a konzolok mûködnek!\n");

            m_JsLogConsole.AddToConsoles("JavaScript konzol...\n");
            m_JsLogConsole.AddToConsoles("A teszt ideje alatt minden JavaScript log " +
                "információ ide lesz kiiratva.");

            RefreshOptionsPanel();
        }

        #region Option panel function

        public void RefreshOptionsPanel()
        {
            optionsPanel.Controls.Clear();

            Control[] optionControls = new Control[m_TestTab.m_SelectedItem.m_Test.m_Options.m_Options.Count];
            for (int i = 0; i < optionControls.Length; i++)
            {
                optionControls[i] = (Control)m_TestTab.m_SelectedItem.m_Test.m_Options.m_Options[i];
            }
            optionsPanel.Controls.AddRange(optionControls);

            Control[] driverOptionControls = new Control[m_TestTab.m_SelectedItem.m_Test.m_DriverOptions.m_DriverOptions.Count];
            for (int i = 0; i < driverOptionControls.Length; i++)
            {
                driverOptionControls[i] = (Control)m_TestTab.m_SelectedItem.m_Test.m_DriverOptions.m_DriverOptions[i];
            }
            optionsPanel.Controls.AddRange(driverOptionControls);
        }

        #endregion

        #region Unit handlers and functions

        private void OnAddUnitButtonPressed(object sender, EventArgs e)
        {
            IUnit unit = new UnitPanel();
            unit.m_ParentForm = this;

            unit.SetUId(unitsPanel.Controls.Count);
            m_TestTab.m_SelectedItem.m_Test.m_Units.m_Units.Add(unit);
            unit.m_UnitName = $"UNIT {m_TestTab.m_SelectedItem.m_Test.m_Units.m_Units.Count}";
            unit.Refresh();
            RefreshUnitsPanel();
        }

        public void RefreshUnitsPanel()
        {
            Control[] controls = new Control[m_TestTab.m_SelectedItem.m_Test.m_Units.m_Units.Count];

            for (int i = 0; i < controls.Length; i++)
            {
                m_TestTab.m_SelectedItem.m_Test.m_Units.m_Units[i].SetUId(i);
                m_TestTab.m_SelectedItem.m_Test.m_Units.m_Units[i].Refresh();
                controls[i] = (Control)m_TestTab.m_SelectedItem.m_Test.m_Units.m_Units[i];
            }

            unitsPanel.Controls.Clear();
            unitsPanel.Controls.AddRange(controls);
        }

        public void DeleteUnit(IUnit unit)
        {
            m_TestTab.m_SelectedItem.m_Test.m_Units.m_Units.Remove(unit);
            RefreshUnitsPanel();
        }

        public void MoveUnit(IUnit unit, int newUId)
        {
            m_TestTab.m_SelectedItem.m_Test.m_Units.MoveUnit(unit, newUId);
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
                m_TestTab.m_SelectedItem.m_Test.m_Browsers.AddIfNotExists("chrome");
            }
            else
            {
                chromeCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Regular);
                m_TestTab.m_SelectedItem.m_Test.m_Browsers.Remove("chrome");

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
                m_TestTab.m_SelectedItem.m_Test.m_Browsers.AddIfNotExists("firefox");
            }
            else
            {
                firefoxCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Regular);
                m_TestTab.m_SelectedItem.m_Test.m_Browsers.Remove("firefox");

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

        private async void OnStartTestButtonPressed(object sender, EventArgs e)
        {
            m_RunLogConsole.AddToConsoles("\n\nTeszt indítása... " + $"{DateTime.Now}\n\n");
            m_JsLogConsole.AddToConsoles("\n\nTeszt indítása... " + $"{DateTime.Now}\n\n");
            OnSwitchToJsLogButtonPressed(sender, e);

            string JSONString = GetTestJSON(GetTest());

            string filePath = GetTest().GetRootLogDirectoryPath() + @"/watch.txt";

            //using (FileWatcher fileWatcher = new FileWatcher(filePath))
            //{
            //    fileWatcher.FileChanged += async (content) =>
            //    {
            //        m_RunLogConsole.consoleTextBox.Invoke((Action)(() =>
            //        {
            //            m_RunLogConsole.consoleTextBox.Text += "\n" + content;
            //        }));
            //    };
            //
            //    m_RunLogConsole.consoleTextBox.Text += ("File watcher started. Press Enter to exit.");
            //    await Task.Delay(-1); // Várakozás a program bezárásáig
            //}
        }

        #endregion

        #region Save and load test

        private void OnSaveTestButtonPressed(object sender, EventArgs e)
        {
            SaveTest(GetTest());
        }

        private void OnLoadTestButtonPressed(object sender, EventArgs e)
        {
            m_TestTab.AddNewItem(sender, e);
        }

        private string GetTestJSON(Test test)
        {
            string JSON = TestFormatter.SaveDriverManagerToJson(test);
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
                    string savedInfo = GetTestJSON(GetTest());
                    File.WriteAllText(of.FileName, savedInfo);

                    test.m_SaveFilePath = of.FileName;
                    test.m_Name = Path.GetFileNameWithoutExtension(of.FileName);
                    currentlyEditedText.Text = test.m_SaveFilePath;

                    m_RunLogConsole.AddToConsoles("\n\nTeszt sikeresen exportálva és mentve az alábbi helyre... " + $"{of.FileName}\n");

                    m_TestTab.DeleteItem(m_TestTab.m_SelectedItem);
                    m_TestTab.AddNewItemFromFilePath(of.FileName);
                }
            }
            else
            {
                string savedInfo = GetTestJSON(GetTest());
                File.WriteAllText(test.m_SaveFilePath, savedInfo);
                m_RunLogConsole.AddToConsoles("\n\nTeszt sikeresen exportálva és mentve az alábbi helyre... " + $"{test.m_SaveFilePath}\n");
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
                loadedTest.m_Options.m_Options.Clear();
                loadedTest.m_DriverOptions.m_DriverOptions.Clear();
                loadedTest.m_Units.m_Units.Clear();
                loadedTest.m_Browsers.Clear();
                loadedTest = TestFormatter.LoadDriverManagerFromJson(loadedInfo, loadedTest);

                chromeCheckBox.Checked = false;
                firefoxCheckBox.Checked = false;
                if (loadedTest.m_Browsers.Contains("chrome"))
                {
                    chromeCheckBox.Checked = true;
                }

                if (loadedTest.m_Browsers.Contains("firefox"))
                {
                    firefoxCheckBox.Checked = true;
                }

                RefreshOptionsPanel();
                RefreshUnitsPanel();

                m_RunLogConsole.AddToConsoles("\n\n{Orange}[Teszt] {Cyan}[sikeresen] importálva és betöltve az alábbi helyrõl... {DarkGray}" + $"[-{of.FileName}]\n");

                loadedTest.m_Name = Path.GetFileNameWithoutExtension(of.FileName);
                loadedTest.m_SaveFilePath = of.FileName;
                currentlyEditedText.Text = loadedTest.m_SaveFilePath;
                RefreshUnitsPanel();
                return loadedTest;
            }
            return null!;
        }

        public Test LoadTestFromFile(string filePath)
        {
            Test loadedTest = new Test(this);

            string loadedInfo = File.ReadAllText(filePath);
            loadedTest.m_Options.m_Options.Clear();
            loadedTest.m_DriverOptions.m_DriverOptions.Clear();
            loadedTest.m_Units.m_Units.Clear();
            loadedTest.m_Browsers.Clear();
            loadedTest = TestFormatter.LoadDriverManagerFromJson(loadedInfo, loadedTest);

            if (m_TestTab.m_SelectedItem.m_Test.m_Browsers.Contains("chrome"))
            {
                chromeCheckBox.Checked = true;
            }
            else
            {
                chromeCheckBox.Checked = false;
            }

            if (m_TestTab.m_SelectedItem.m_Test.m_Browsers.Contains("firefox"))
            {
                firefoxCheckBox.Checked = true;
            }
            else
            {
                firefoxCheckBox.Checked = false;
            }

            RefreshOptionsPanel();
            RefreshUnitsPanel();

            m_RunLogConsole.AddToConsoles("\n\n{Orange}[Teszt] {Cyan}[sikeresen] importálva és betöltve az alábbi helyrõl... {DarkGray}" + $"[-{filePath}]\n");

            loadedTest.m_Name = Path.GetFileNameWithoutExtension(filePath);
            loadedTest.m_SaveFilePath = filePath;
            currentlyEditedText.Text = loadedTest.m_SaveFilePath;
            RefreshUnitsPanel();
            return loadedTest;
        }

        public void LoadTest()
        {
            if (m_TestTab.m_SelectedItem.m_Test.m_Browsers.Contains("chrome"))
            {
                chromeCheckBox.Checked = true;
            }
            else
            {
                chromeCheckBox.Checked = false;
            }

            if (m_TestTab.m_SelectedItem.m_Test.m_Browsers.Contains("firefox"))
            {
                firefoxCheckBox.Checked = true;
            }
            else
            {
                firefoxCheckBox.Checked = false;
            }

            currentlyEditedText.Text = m_TestTab.m_SelectedItem.m_Test.m_SaveFilePath;
            RefreshOptionsPanel();
            RefreshUnitsPanel();
        }

        #endregion

        #region Root log folder Logic

        private void rootLogDirectoryButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GetTest().GetRootLogDirectoryPath());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            rootLogDirectoryButton_Click(sender, e);
        }

        #endregion

        public static bool s_IsChromeChecked = true;

        TestTab m_TestTab;
        public Test GetTest() { return m_TestTab.m_SelectedItem.m_Test; }

        Console m_RunLogConsole;
        Console m_JsLogConsole;
    }
}
