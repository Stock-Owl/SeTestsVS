namespace WebTestGui
{
    public partial class MainForm : Form
    {
        /* TODO:
        - Tabok (egyszerre több teszt szerkeztése egy ablakban)
        - Mindegyik konzol elérhetõ (4 darab, abból csak a napi az, amit el is kell menteni)
        - Gomb ami megnyitja a feladatkezelõben a log mappát
        - Idõzítõ különálló applikáció (tesztek futtatásának idõzítése, és beállítása)
        - Python backend meghívása és kommunikációs fájlok kezelése
        
        - Komplex Action (több Action egymásba pakolása, mint egy sablon)
        - Opciók sablonok létrehozása, import és exportálása
        */

        public MainForm()
        {
            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            Text = AppConsts.s_AppName + " " + AppConsts.s_AppVersion;

            m_ConsoleManager = new TextboxFormatter(console);
            m_JsConsoleManager = new TextboxFormatter(jsConsole);
            m_Test = new Test(this);

            m_ConsoleManager.Print("{Yellow}[Applikáció] indítása...\n");
            m_ConsoleManager.Print("Verzió: {LightSeaGreen}" + $"[{AppConsts.s_AppVersion}]\n");
            m_ConsoleManager.Print("Idõ: {DarkGray}" + $"[-{DateTime.Now}]\n");
            m_ConsoleManager.Print("{Orange}[Konzol] inicializálása...\n\n");
            m_ConsoleManager.Print("Az {Yellow}[alkalmazás] {Cyan}[sikeresen] elindult, a {Orange}[konzolok] mûködnek!\n");

            m_JsConsoleManager.Print("{Yellow}[JavaScript] konzol...\n");
            m_JsConsoleManager.Print("A teszt ideje alatt minden {Yellow}[JavaScript] {Orange}[log] " +
                "információ {Cyan}[ide] lesz kiiratva.");

            PopulateComboBoxes();
        }

        public void PopulateComboBoxes()
        {
            object[] optionClasses = TypeHelpers.GetAllSubClassesFromInterface<IOption>();
            addOptionComboBox.Items.AddRange(optionClasses);
            object[] driverOptionClasses = TypeHelpers.GetAllSubClassesFromInterface<IDriverOption>();
            addDriverActionComboBox.Items.AddRange(driverOptionClasses);
        }

        #region Option panel functions

        private void OnOptionComboBoxItemSelect(object sender, EventArgs e)
        {
            string selected = addOptionComboBox.GetItemText(addOptionComboBox.SelectedItem)!;
            addOptionComboBox.Items.Remove(selected);
            addOptionComboBox.Text = "";

            Type optionType = TypeHelpers.GetClassFromString(selected);
            IOption option = (IOption)Activator.CreateInstance(optionType)!;
            option.m_ParentForm = this;

            m_Test.m_Options.m_Options.Add(option);
            RefreshOptionsPanel();
        }

        private void OnDriverOptionComboBoxItemSelect(object sender, EventArgs e)
        {
            string selected = addDriverActionComboBox.GetItemText(addDriverActionComboBox.SelectedItem)!;
            addDriverActionComboBox.Items.Remove(selected);
            addDriverActionComboBox.Text = "";

            Type driverOptionType = TypeHelpers.GetClassFromString(selected);
            IDriverOption driverOption = (IDriverOption)Activator.CreateInstance(driverOptionType)!;
            driverOption.m_ParentForm = this;

            m_Test.m_DriverOptions.m_DriverOptions.Add(driverOption);
            RefreshOptionsPanel();
        }

        public void RefreshOptionsPanel()
        {
            optionsPanel.Controls.Clear();

            Control[] optionControls = new Control[m_Test.m_Options.m_Options.Count];
            for (int i = 0; i < optionControls.Length; i++)
            {
                optionControls[i] = (Control)m_Test.m_Options.m_Options[i];
            }
            optionsPanel.Controls.AddRange(optionControls);

            Control[] driverOptionControls = new Control[m_Test.m_DriverOptions.m_DriverOptions.Count];
            for (int i = 0; i < driverOptionControls.Length; i++)
            {
                driverOptionControls[i] = (Control)m_Test.m_DriverOptions.m_DriverOptions[i];
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
            m_Test.m_Units.m_Units.Add(unit);
            unit.m_UnitName = $"UNIT {m_Test.m_Units.m_Units.Count}";
            unit.Refresh();
            RefreshUnitsPanel();
        }

        public void RefreshUnitsPanel()
        {
            Control[] controls = new Control[m_Test.m_Units.m_Units.Count];

            for (int i = 0; i < controls.Length; i++)
            {
                m_Test.m_Units.m_Units[i].SetUId(i);
                m_Test.m_Units.m_Units[i].Refresh();
                controls[i] = (Control)m_Test.m_Units.m_Units[i];
            }

            unitsPanel.Controls.Clear();
            unitsPanel.Controls.AddRange(controls);
        }

        public void DeleteUnit(IUnit unit)
        {
            m_Test.m_Units.m_Units.Remove(unit);
            RefreshUnitsPanel();
        }

        public void MoveUnit(IUnit unit, int newUId)
        {
            m_Test.m_Units.MoveUnit(unit, newUId);
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
                m_Test.m_Browsers.AddIfNotExists("chrome");
            }
            else
            {
                chromeCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Regular);
                m_Test.m_Browsers.Remove("chrome");

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
                m_Test.m_Browsers.AddIfNotExists("firefox");
            }
            else
            {
                firefoxCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Regular);
                m_Test.m_Browsers.Remove("firefox");

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

            jsConsole.Visible = false;

            switchToOptionsButton.ForeColor = Color.White;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Bold);

            switchToJsLogButton.ForeColor = Color.Silver;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
        }

        private void OnSwitchToJsLogButtonPressed(object sender, EventArgs e)
        {
            jsConsole.Visible = true;

            optionHeaderPanel.Visible = false;
            optionsPanel.Visible = false;
            optionLabel.Visible = false;

            switchToJsLogButton.ForeColor = Color.White;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Bold);

            switchToOptionsButton.ForeColor = Color.Silver;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
        }

        #endregion

        #region Manage Tests Buttons and Functions

        private void OnStartTestButtonPressed(object sender, EventArgs e)
        {
            m_ConsoleManager.Print("\n\n{LightSeaGreen}[Teszt] indítása... {DarkGray}" + $"[-{DateTime.Now}]\n");
            m_JsConsoleManager.Print("\n\n{LightSeaGreen}[Teszt] indítása... {DarkGray}" + $"[-{DateTime.Now}]\n");
            OnSwitchToJsLogButtonPressed(sender, e);
            m_ConsoleManager.Print("\nExportált {Magenta}[JSON] fájl:\n\n");

            string JSONString = GetTestJSON();
            console.AppendText(JSONString + "\n");
        }

        private void OnSaveTestButtonPressed(object sender, EventArgs e)
        {
            SaveTest();
        }

        private void OnLoadTestButtonPressed(object sender, EventArgs e)
        {
            LoadTest();
        }

        private string GetTestJSON()
        {
            string JSON = TestFormatter.SaveDriverManagerToJson(m_Test);
            return JSON;
        }

        private void SaveTest()
        {
            if (!AppConsts.s_IsEditingAlreadyExistingTest)
            {
                SaveFileDialog of = new SaveFileDialog();
                of.Title = "Teszt mentése...";
                of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    string savedInfo = GetTestJSON();
                    File.WriteAllText(of.FileName, savedInfo);
                    m_ConsoleManager.Print("\n\n{Orange}[Teszt] {Cyan}[sikeresen] exportálva és mentve az alábbi helyre... {DarkGray}" + $"[-{of.FileName}]\n");
                }
            }
            else
            {
                string savedInfo = GetTestJSON();
                File.WriteAllText(AppConsts.s_LoadedTestFilepath!, savedInfo);
                m_ConsoleManager.Print("\n\n{Orange}[Teszt] {Cyan}[sikeresen] exportálva és mentve az alábbi helyre... {DarkGray}" + $"[-{AppConsts.s_LoadedTestFilepath}]\n");
            }
        }

        private void LoadTest()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt betöltése...";
            of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string loadedInfo = File.ReadAllText(of.FileName);
                m_Test.m_Options.m_Options.Clear();
                m_Test.m_DriverOptions.m_DriverOptions.Clear();
                m_Test.m_Units.m_Units.Clear();
                m_Test.m_Browsers.Clear();
                m_Test = TestFormatter.LoadDriverManagerFromJson(loadedInfo, m_Test);

                chromeCheckBox.Checked = false;
                firefoxCheckBox.Checked = false;
                if (m_Test.m_Browsers.Contains("chrome"))
                {
                    chromeCheckBox.Checked = true;
                }

                if (m_Test.m_Browsers.Contains("firefox"))
                {
                    firefoxCheckBox.Checked = true;
                }

                RefreshOptionsPanel();
                RefreshUnitsPanel();

                m_ConsoleManager.Print("\n\n{Orange}[Teszt] {Cyan}[sikeresen] importálva és betöltve az alábbi helyrõl... {DarkGray}" + $"[-{of.FileName}]\n");

                AppConsts.s_IsEditingAlreadyExistingTest = true;
                AppConsts.s_LoadedTestFilepath = of.FileName;
                currentlyEditedText.Text = AppConsts.s_LoadedTestFilepath;
            }
        }

        #endregion

        public static bool s_IsChromeChecked = true; // Certain Actions need to know which one is selected

        TextboxFormatter m_ConsoleManager;
        public void PrintToConsole(string msg) { m_ConsoleManager.Print(msg); }

        TextboxFormatter m_JsConsoleManager;
        public void PrintToJsConsole(string msg) { m_JsConsoleManager.Print(msg); }

        Test m_Test;
        public Test GetTestObject() { return m_Test; }
    }
}
