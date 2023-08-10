namespace WebTestGui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            Text = AppConsts.s_AppName + " " + AppConsts.s_AppVersion;

            m_ConsoleManager = new TextboxFormatter(console);
            m_JsConsoleManager = new TextboxFormatter(jsConsole);
            m_DriverManager = new DriverManager(this);

            m_ConsoleManager.Print("{Yellow}[Applikáció] indítása...\n");
            m_ConsoleManager.Print("Verzió: {LightSeaGreen}" + $"[{AppConsts.s_AppVersion}]\n");
            m_ConsoleManager.Print("Idõ: {DarkGray}" + $"[-{DateTime.Now}]\n");
            m_ConsoleManager.Print("{Orange}[Konzol] inicializálása...\n\n");
            m_ConsoleManager.Print("Az {Yellow}[alkalmazás] {Cyan}[sikeresen] elindult, a {Orange}[konzolok] mûködnek!\n");

            m_JsConsoleManager.Print("{Yellow}[JavaScript] konzol...\n");
            m_JsConsoleManager.Print("A teszt ideje alatt minden {Yellow}[JavaScript] {Orange}[log] " +
                "információ {Cyan}[ide] lesz kiiratva.");

            PopulateOptionsPanel();
            object[] actionClasses = TypeHelpers.GetAllSubClassesFromInterface<IAction>();
            addActionComboBox.Items.AddRange(actionClasses);
        }

        #region Option panel functions

        private void PopulateOptionsPanel()
        {
            // PageLoadStrategy
            m_PageLoadStrategyOptionPanel.SetMainLabel("Lap betöltési stratégia:");
            m_PageLoadStrategyOptionPanel.SetMainCombobox<Option.PageLoadStrategies>("Lap betöltési stratégia típus...");
            m_PageLoadStrategyOptionPanel.SetSubElementsVisible(false);
            m_PageLoadStrategyOptionPanel.SetInfoBox("Lap betöltés", "A web-illesztõprogram hogyan kezeli az új oldal betöltését." +
                "Három különbözõ oldalbetöltési stratégia használható: Normál, Buzgó és Nincs.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_PageLoadStrategyOptionPanel);

            // AcceptInsecureCerts
            m_AcceptInsuranceOptionPanel.SetMainLabel("Nem biztonságos bizonyítványok elfogadása:", 10);
            m_AcceptInsuranceOptionPanel.SetMainCheckbox(false);
            m_AcceptInsuranceOptionPanel.SetSubElementsVisible(false);
            m_AcceptInsuranceOptionPanel.SetInfoBox("Bizonyítványok elfogadása", "Lehetõvé teszi, hogy a web-illesztõprogram olyan" +
                "weboldalakat is megnyisson, amelyeknél érvénytelen, vagy biztonsági tanúsítvány nélküli (insecure) SSL/TLS tanúsítványt használnak.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_AcceptInsuranceOptionPanel);

            // Timeouts
            m_TimeoutsOptionPanel.SetMainLabel("Idõtúllépések:");
            m_TimeoutsOptionPanel.SetMainCombobox<Option.Timeout.TimeoutType>("Idõtûllépési lehetõségek...");
            m_TimeoutsOptionPanel.SetSubElementsVisible(true);
            m_TimeoutsOptionPanel.SetSubLabel("Értéke:");
            m_TimeoutsOptionPanel.SetSubTextbox("Idõtúllépés értéke (ms)...*", "300000");
            m_TimeoutsOptionPanel.SetInfoBox("Idõtúllépés", "Amikor a web-illesztõprogram egy parancsot végrehajt, például egy elem keresését vagy egy kattintást," +
                "elõfordulhat, hogy a weboldal betöltése vagy más folyamatok lassabban történnek, és idõre van szükségük a végrehajtáshoz.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_TimeoutsOptionPanel);

            // UnhandledPromptBehaviour
            m_UnhandledPromptBehaviourOptionPanel.SetMainLabel("Kezeletlen kérelmek:");
            m_UnhandledPromptBehaviourOptionPanel.SetMainCombobox<Option.UnhandledPromptBehaviours>("Kezeletlen kérelmek kezelése...", 2);
            m_UnhandledPromptBehaviourOptionPanel.SetSubElementsVisible(false);
            m_UnhandledPromptBehaviourOptionPanel.SetInfoBox("Kezeletlen kérelmek", "Hogyan kezelje a nem várt vagy kezeletlen promptokat a böngészõben." +
                "Ez a beállítás hasznos lehet olyan helyzetekben, amikor a weboldalakon pop-up jelennek meg, amelyekhez választ vagy adatbevitelt igényelnek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_UnhandledPromptBehaviourOptionPanel);

            // KeepBrowserOpen
            m_KeepBrowserOpenOptionPanel.SetMainLabel("Böngészõ nyitva marad:");
            m_KeepBrowserOpenOptionPanel.SetMainCheckbox(true);
            m_KeepBrowserOpenOptionPanel.SetSubElementsVisible(false);
            m_KeepBrowserOpenOptionPanel.SetInfoBox("Böngészõ állapot", "A teszt befelyezése után bezáródjon-e a böngészõ ablak. Ha az 'Igen' opció van beállítva," +
                "akkor a böngészõn nyitva marad ameddig manuálisan vagy más program be nem zárja. Ellenkezõ esetben a teszt után automatikusa bezáródik.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_KeepBrowserOpenOptionPanel);

            // BrowserArgs
            m_BrowserArgsOptionPanel.SetMainLabel("Böngészõ indítási paraméterek:");
            m_BrowserArgsOptionPanel.SetMainTextbox("Extra paraméterek...");
            m_BrowserArgsOptionPanel.GiveHint("(Spacel elválasztva)");
            m_BrowserArgsOptionPanel.SetSubElementsVisible(false);
            m_BrowserArgsOptionPanel.SetInfoBox("Böngészõ paraméterek", "Extra paraméterek amivel a program elindítja a böngészõt." +
                "Ezek a használt böngészõtõl függenek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_BrowserArgsOptionPanel);

            // LogJSActive
            m_LogJsActiveOptionPanel.SetMainLabel("JS aktív logolása:");
            m_LogJsActiveOptionPanel.SetMainCheckbox(true);
            m_LogJsActiveOptionPanel.SetSubElementsVisible(false);
            m_LogJsActiveOptionPanel.SetInfoBox("JavaScript log", "A teszt ideje alatt legyen-e aktív logolása a böngészõnek. Ez kiírja az összes " +
                "információt, amit a JavaScript szkript végez. Esetlegesen tartalmazhat fontos információkat.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_LogJsActiveOptionPanel);

            // ServiceLogPath
            m_ServiceLogOptionPanel.SetMainLabel("Web-illesztõprogram tevékenységeinek logolása:", 9);
            m_ServiceLogOptionPanel.SetMainTextbox("A log fájl elérési útja...");
            m_ServiceLogOptionPanel.SetSubElementsVisible(false);
            m_ServiceLogOptionPanel.AddFolderDialog();
            m_ServiceLogOptionPanel.SetInfoBox("Web-illesztõprogram logolása", "A \"service log\" a Web-illesztõprogram tevékenységét rögzíti egy naplófájlba." +
                "Ez a naplófájl tartalmazza a szolgáltatás indításával és futtatásával kapcsolatos információkat és hibákat." +
                "Ezek a használt böngészõtõl függenek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_ServiceLogOptionPanel);

            // ServiceArgs
            m_ServiceArgsOptionPanel.SetMainLabel("Konfigurációs paraméterek:");
            m_ServiceArgsOptionPanel.SetMainTextbox("Extra paraméterek az programnak...");
            m_ServiceArgsOptionPanel.GiveHint("(Spacel elválasztva)");
            m_ServiceArgsOptionPanel.SetSubElementsVisible(false);
            m_ServiceArgsOptionPanel.SetInfoBox("Konfigurációs paraméterek", "A \"service args\" lehetõvé teszi további parancssori argumentumok megadását" +
                "a web-illesztõprogram szolgáltatásának indításakor.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_ServiceArgsOptionPanel);
        }

        #endregion

        #region Actions handlers and functions

        private void addActionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.addActionComboBox.GetItemText(this.addActionComboBox.SelectedItem)!;
            addActionComboBox.Text = "";
            Type actionType = TypeHelpers.GetClassFromString(selected);
            IAction action = (IAction)Activator.CreateInstance(actionType)!;
            action.m_ParentForm = this;

            action.SetId(actionsPanel.Controls.Count);
            m_DriverManager.m_Actions.m_Actions.Add(action);
            RefreshActionsPanel();
        }

        public void DeleteAction(IAction action)
        {
            m_DriverManager.m_Actions.m_Actions.Remove(action);
            RefreshActionsPanel();
        }

        public void MoveAction(IAction action, int newId)
        {
            m_DriverManager.m_Actions.MoveElement(action, newId);
            RefreshActionsPanel();
        }

        public void RefreshActionsPanel()
        {
            Control[] controls = new Control[m_DriverManager.m_Actions.m_Actions.Count];

            for (int i = 0; i < controls.Length; i++)
            {
                m_DriverManager.m_Actions.m_Actions[i].SetId(i);
                controls[i] = (Control)m_DriverManager.m_Actions.m_Actions[i];
            }

            actionsPanel.Controls.Clear();
            actionsPanel.Controls.AddRange(controls);
        }

        public void ScrollToAction(IAction action)
        {
            actionsPanel.ScrollControlIntoView((Control)action);
        }

        #endregion

        #region Browser Checkboxes logic functions

        private void chromeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chromeCheckBox.Checked)
            {
                chromeCheckBox.Checked = true;
                chromeCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Bold);
                m_DriverManager.m_Browser = DriverManager.Browser.chrome;
                s_IsChromeChecked = true;

                firefoxCheckBox.Checked = false;
                firefoxCheckBox.Font = new Font(firefoxCheckBox.Font, FontStyle.Regular);
            }
            else
            {
                if (!firefoxCheckBox.Checked)
                {
                    firefoxCheckBox.Checked = true;
                }
            }
        }

        private void firefoxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (firefoxCheckBox.Checked)
            {
                firefoxCheckBox.Checked = true;
                firefoxCheckBox.Font = new Font(firefoxCheckBox.Font, FontStyle.Bold);
                m_DriverManager.m_Browser = DriverManager.Browser.firefox;
                s_IsChromeChecked = false;

                chromeCheckBox.Checked = false;
                chromeCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Regular);
            }
            else
            {
                if (!chromeCheckBox.Checked)
                {
                    chromeCheckBox.Checked = true;
                }
            }
        }

        #endregion

        #region Methods for handling picture ratios when the window got resized

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(25, 25);
        }

        private void pictureBox2_Resize(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(25, 25);
        }

        #endregion

        #region Information pop-up boxes and functions

        private void urlTextFieldInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Tesztelendõ weblap", "Annak a weblapnak az URL-je, amin fusson a tesztelés.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void logPathInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Logolási útvonal", "Az egyéb, esetleg fontos információkat a tesztrõl az applikáció kiírja az adott mappába.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void fieldPanelInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Akciók", "A tesztelendõ oldalon végrehajtandó akciók és feladatok listája.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void optionInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Opciók", "Egyes tesztelés közben elõfordulható eseményeket lehet beállítani.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        #endregion

        #region Logic switching between options and JS console

        private void switchToOptionsButton_Click(object sender, EventArgs e)
        {
            optionHeaderPanel.Visible = true;
            optionsPanel.Visible = true;
            optionLabel.Visible = true;
            optionInfo.Visible = true;

            jsConsole.Visible = false;

            switchToOptionsButton.ForeColor = Color.White;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Bold);

            switchToJsLogButton.ForeColor = Color.Silver;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
        }

        private void switchToJsLogButton_Click(object sender, EventArgs e)
        {
            jsConsole.Visible = true;

            optionHeaderPanel.Visible = false;
            optionsPanel.Visible = false;
            optionLabel.Visible = false;
            optionInfo.Visible = false;

            switchToJsLogButton.ForeColor = Color.White;
            switchToJsLogButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Bold);

            switchToOptionsButton.ForeColor = Color.Silver;
            switchToOptionsButton.Font = new Font(switchToOptionsButton.Font, FontStyle.Italic);
        }

        #endregion

        private void testStartButton_Click(object sender, EventArgs e)
        {
            m_ConsoleManager.Print("\n\n{LightSeaGreen}[Teszt] indítása... {DarkGray}" + $"[-{DateTime.Now}]\n");
            m_JsConsoleManager.Print("\n\n{LightSeaGreen}[Teszt] indítása... {DarkGray}" + $"[-{DateTime.Now}]\n");
            switchToJsLogButton_Click(sender, e);
            m_ConsoleManager.Print("\nExportált {Magenta}[JSON] fájl:\n\n");

            string JSONString = GetTestJSON();
            console.AppendText(JSONString + "\n");
            AppConsts.StartTestWithPythonScript(JSONString);
        }

        private void saveTestButton_Click(object sender, EventArgs e)
        {
            SaveTest();
        }

        private void loadTestButton_Click(object sender, EventArgs e)
        {
            LoadTest();
        }

        private string GetTestJSON()
        {
            m_DriverManager.m_Options.m_PageLoadStrategy =
                    TypeHelpers.EnumTypeFromString<Option.PageLoadStrategies>(m_PageLoadStrategyOptionPanel.GetMainComboboxValue());
            m_DriverManager.m_Options.m_AcceptInsecureCerts = m_AcceptInsuranceOptionPanel.GetMainCheckboxValue();
            m_DriverManager.m_Options.m_Timeout.m_Type =
                TypeHelpers.EnumTypeFromString<Option.Timeout.TimeoutType>(m_TimeoutsOptionPanel.GetMainComboboxValue());
            m_DriverManager.m_Options.m_Timeout.m_ValueInMiliseconds = int.Parse(m_TimeoutsOptionPanel.GetSubTextboxValue());
            m_DriverManager.m_Options.m_unhandledPromptBehaviour =
                TypeHelpers.EnumTypeFromString<Option.UnhandledPromptBehaviours>(m_UnhandledPromptBehaviourOptionPanel.GetMainComboboxValue());
            m_DriverManager.m_Options.m_KeepBrowserOpen = m_KeepBrowserOpenOptionPanel.GetMainCheckboxValue();

            List<string> browserArgsList = new List<string>();
            browserArgsList.AddRange(m_BrowserArgsOptionPanel.GetMainTextboxValue().Split(' '));
            m_DriverManager.m_Options.m_BrowserArgs = browserArgsList;

            bool test = m_LogJsActiveOptionPanel.GetMainCheckboxValue();
            m_DriverManager.m_Options.m_LogJs.m_Active = test;

            m_DriverManager.m_Options.m_ServiceLogPath = m_ServiceLogOptionPanel.GetMainTextboxValue();

            List<string> serviceArgsList = new List<string>();
            serviceArgsList.AddRange(m_ServiceArgsOptionPanel.GetMainTextboxValue().Split(' '));
            m_DriverManager.m_Options.m_ServiceArgs = serviceArgsList;

            // Actions aren't collected here, they're collected and managed during runtime.
            // The Json converter saves and loads them directly from the DriverManager class instance
            string JSON = m_DriverManager.FormatDataToJson();
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
                try
                {
                    string loadedInfo = File.ReadAllText(of.FileName);
                    m_DriverManager.m_Actions.m_Actions.Clear();
                    m_DriverManager = TestFormatter.ConvertManagerFromJson(loadedInfo, m_DriverManager);

                    if (m_DriverManager.m_Browser == DriverManager.Browser.chrome)
                    {
                        chromeCheckBox.Checked = true;
                        firefoxCheckBox.Checked = false;
                    }
                    else
                    {
                        chromeCheckBox.Checked = false;
                        firefoxCheckBox.Checked = true;
                    }

                    m_PageLoadStrategyOptionPanel.SetMainComboboxSelected(m_DriverManager.m_Options.m_PageLoadStrategy.ToString());
                    m_AcceptInsuranceOptionPanel.SetMainCheckboxValue(m_DriverManager.m_Options.m_AcceptInsecureCerts);
                    m_TimeoutsOptionPanel.SetMainComboboxSelected(m_DriverManager.m_Options.m_Timeout.m_Type.ToString());
                    m_TimeoutsOptionPanel.SetSubTextboxText(m_DriverManager.m_Options.m_Timeout.m_ValueInMiliseconds.ToString());
                    m_UnhandledPromptBehaviourOptionPanel.SetMainComboboxSelected(m_DriverManager.m_Options.m_unhandledPromptBehaviour.ToString());
                    m_KeepBrowserOpenOptionPanel.SetMainCheckboxValue(m_DriverManager.m_Options.m_KeepBrowserOpen);
                    m_BrowserArgsOptionPanel.SetMainTextBoxText(string.Join(' ', m_DriverManager.m_Options.m_BrowserArgs));
                    m_LogJsActiveOptionPanel.SetMainCheckboxValue(m_DriverManager.m_Options.m_LogJs.m_Active);
                    m_ServiceLogOptionPanel.SetMainTextBoxText(m_DriverManager.m_Options.m_ServiceLogPath!);
                    m_ServiceArgsOptionPanel.SetMainTextBoxText(string.Join(' ', m_DriverManager.m_Options.m_ServiceArgs));

                    RefreshActionsPanel();

                    m_ConsoleManager.Print("\n\n{Orange}[Teszt] {Cyan}[sikeresen] importálva és betöltve az alábbi helyrõl... {DarkGray}" + $"[-{of.FileName}]\n");

                    AppConsts.s_IsEditingAlreadyExistingTest = true;
                    AppConsts.s_LoadedTestFilepath = of.FileName;
                    currentlyEditedText.Text = AppConsts.s_LoadedTestFilepath;
                }
                catch
                {
                    InfoBox infoBox = new InfoBox("Sikertelen betöltés", "A mentett tesztfájl betöltése sikertelen volt! " +
                        "ellenõrizze a fájl épségét, és hogy nincs-e megnyitva más programban futási idõ alatt!", InfoBox.InfoBoxType.Error);
                    infoBox.ShowDialog();

                    m_ConsoleManager.Print("\n\n{Orange}[Teszt] betöltése {Red}[sikertelen] az alábbi helyrõl... {DarkGray}" + $"[-{of.FileName}]\n");
                }
            }
        }

        Options m_PageLoadStrategyOptionPanel = new Options();
        Options m_AcceptInsuranceOptionPanel = new Options();
        Options m_TimeoutsOptionPanel = new Options();
        Options m_UnhandledPromptBehaviourOptionPanel = new Options();
        Options m_KeepBrowserOpenOptionPanel = new Options();
        Options m_BrowserArgsOptionPanel = new Options();
        Options m_LogJsActiveOptionPanel = new Options();
        Options m_ServiceLogOptionPanel = new Options();
        Options m_ServiceArgsOptionPanel = new Options();

        public static bool s_IsChromeChecked = true;

        TextboxFormatter m_ConsoleManager;
        public void PrintToConsole(string msg) { m_ConsoleManager.Print(msg); }

        TextboxFormatter m_JsConsoleManager;
        public void PrintToJsConsole(string msg) { m_JsConsoleManager.Print(msg); }

        DriverManager m_DriverManager;
        public DriverManager GetDriverManager() { return m_DriverManager; }
    }
}
