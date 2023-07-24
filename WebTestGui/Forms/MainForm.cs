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

            m_ConsoleManager.Print("{Yellow}[Applik�ci�] ind�t�sa...\n");
            m_ConsoleManager.Print("Verzi�: {LightSeaGreen}" + $"[{AppConsts.s_AppVersion}]\n");
            m_ConsoleManager.Print("Id�: {DarkGray}" + $"[-{DateTime.Now}]\n");
            m_ConsoleManager.Print("{Orange}[Konzol] inicializ�l�sa...\n\n");
            m_ConsoleManager.Print("Az {Yellow}[alkalmaz�s] {Cyan}[sikeresen] elindult, a {Orange}[konzolok] m�k�dnek!\n");

            m_JsConsoleManager.Print("{Yellow}[JavaScript] konzol...\n");
            m_JsConsoleManager.Print("A teszt ideje alatt minden {Yellow}[JavaScript] {Orange}[log] " +
                "inform�ci� {Cyan}[ide] lesz kiiratva.");

            PopulateOptionsPanel();
            object[] actionClasses = TypeHelpers.GetAllSubClassesFromInterface<IAction>();
            addActionComboBox.Items.AddRange(actionClasses);
        }

        #region Option panel functions

        private void PopulateOptionsPanel()
        {
            // PageLoadStrategy
            m_PageLoadStrategyOptionPanel.SetMainLabel("Lap bet�lt�si strat�gia:");
            m_PageLoadStrategyOptionPanel.SetMainCombobox<Option.PageLoadStrategies>("Lap bet�lt�si strat�gia t�pus...");
            m_PageLoadStrategyOptionPanel.SetSubElementsVisible(false);
            m_PageLoadStrategyOptionPanel.SetInfoBox("Lap bet�lt�s", "A web-illeszt�program hogyan kezeli az �j oldal bet�lt�s�t." +
                "H�rom k�l�nb�z� oldalbet�lt�si strat�gia haszn�lhat�: Norm�l, Buzg� �s Nincs.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_PageLoadStrategyOptionPanel);

            // AcceptInsecureCerts
            m_AcceptInsuranceOptionPanel.SetMainLabel("Nem biztons�gos bizony�tv�nyok elfogad�sa:", 10);
            m_AcceptInsuranceOptionPanel.SetMainCheckbox(false);
            m_AcceptInsuranceOptionPanel.SetSubElementsVisible(false);
            m_AcceptInsuranceOptionPanel.SetInfoBox("Bizony�tv�nyok elfogad�sa", "Lehet�v� teszi, hogy a web-illeszt�program olyan" +
                "weboldalakat is megnyisson, amelyekn�l �rv�nytelen, vagy biztons�gi tan�s�tv�ny n�lk�li (insecure) SSL/TLS tan�s�tv�nyt haszn�lnak.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_AcceptInsuranceOptionPanel);

            // Timeouts
            m_TimeoutsOptionPanel.SetMainLabel("Id�t�ll�p�sek:");
            m_TimeoutsOptionPanel.SetMainCombobox<Option.Timeout.TimeoutType>("Id�t�ll�p�si lehet�s�gek...");
            m_TimeoutsOptionPanel.SetSubElementsVisible(true);
            m_TimeoutsOptionPanel.SetSubLabel("�rt�ke:");
            m_TimeoutsOptionPanel.SetSubTextbox("Id�t�ll�p�s �rt�ke (ms)...*", "300000");
            m_TimeoutsOptionPanel.SetInfoBox("Id�t�ll�p�s", "Amikor a web-illeszt�program egy parancsot v�grehajt, p�ld�ul egy elem keres�s�t vagy egy kattint�st," +
                "el�fordulhat, hogy a weboldal bet�lt�se vagy m�s folyamatok lassabban t�rt�nnek, �s id�re van sz�ks�g�k a v�grehajt�shoz.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_TimeoutsOptionPanel);

            // UnhandledPromptBehaviour
            m_UnhandledPromptBehaviourOptionPanel.SetMainLabel("Kezeletlen k�relmek:");
            m_UnhandledPromptBehaviourOptionPanel.SetMainCombobox<Option.UnhandledPromptBehaviours>("Kezeletlen k�relmek kezel�se...", 2);
            m_UnhandledPromptBehaviourOptionPanel.SetSubElementsVisible(false);
            m_UnhandledPromptBehaviourOptionPanel.SetInfoBox("Kezeletlen k�relmek", "Hogyan kezelje a nem v�rt vagy kezeletlen promptokat a b�ng�sz�ben." +
                "Ez a be�ll�t�s hasznos lehet olyan helyzetekben, amikor a weboldalakon pop-up jelennek meg, amelyekhez v�laszt vagy adatbevitelt ig�nyelnek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_UnhandledPromptBehaviourOptionPanel);

            // KeepBrowserOpen
            m_KeepBrowserOpenOptionPanel.SetMainLabel("B�ng�sz� nyitva marad:");
            m_KeepBrowserOpenOptionPanel.SetMainCheckbox(true);
            m_KeepBrowserOpenOptionPanel.SetSubElementsVisible(false);
            m_KeepBrowserOpenOptionPanel.SetInfoBox("B�ng�sz� �llapot", "A teszt befelyez�se ut�n bez�r�djon-e a b�ng�sz� ablak. Ha az 'Igen' opci� van be�ll�tva," +
                "akkor a b�ng�sz�n nyitva marad ameddig manu�lisan vagy m�s program be nem z�rja. Ellenkez� esetben a teszt ut�n automatikusa bez�r�dik.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_KeepBrowserOpenOptionPanel);

            // BrowserArgs
            m_BrowserArgsOptionPanel.SetMainLabel("B�ng�sz� ind�t�si param�terek:");
            m_BrowserArgsOptionPanel.SetMainTextbox("Extra param�terek...");
            m_BrowserArgsOptionPanel.GiveHint("(Spacel elv�lasztva)");
            m_BrowserArgsOptionPanel.SetSubElementsVisible(false);
            m_BrowserArgsOptionPanel.SetInfoBox("B�ng�sz� param�terek", "Extra param�terek amivel a program elind�tja a b�ng�sz�t." +
                "Ezek a haszn�lt b�ng�sz�t�l f�ggenek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_BrowserArgsOptionPanel);

            // LogJSActive
            m_LogJsActiveOptionPanel.SetMainLabel("JS akt�v logol�sa:");
            m_LogJsActiveOptionPanel.SetMainCheckbox(true);
            m_LogJsActiveOptionPanel.SetSubElementsVisible(false);
            m_LogJsActiveOptionPanel.SetInfoBox("JavaScript log", "A teszt ideje alatt legyen-e akt�v logol�sa a b�ng�sz�nek. Ez ki�rja az �sszes " +
                "inform�ci�t, amit a JavaScript szkript v�gez. Esetlegesen tartalmazhat fontos inform�ci�kat.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_LogJsActiveOptionPanel);

            // ServiceLogPath
            m_ServiceLogOptionPanel.SetMainLabel("Web-illeszt�program tev�kenys�geinek logol�sa:", 9);
            m_ServiceLogOptionPanel.SetMainTextbox("A log f�jl el�r�si �tja...");
            m_ServiceLogOptionPanel.SetSubElementsVisible(false);
            m_ServiceLogOptionPanel.AddFolderDialog();
            m_ServiceLogOptionPanel.SetInfoBox("Web-illeszt�program logol�sa", "A \"service log\" a Web-illeszt�program tev�kenys�g�t r�gz�ti egy napl�f�jlba." +
                "Ez a napl�f�jl tartalmazza a szolg�ltat�s ind�t�s�val �s futtat�s�val kapcsolatos inform�ci�kat �s hib�kat." +
                "Ezek a haszn�lt b�ng�sz�t�l f�ggenek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(m_ServiceLogOptionPanel);

            // ServiceArgs
            m_ServiceArgsOptionPanel.SetMainLabel("Konfigur�ci�s param�terek:");
            m_ServiceArgsOptionPanel.SetMainTextbox("Extra param�terek az programnak...");
            m_ServiceArgsOptionPanel.GiveHint("(Spacel elv�lasztva)");
            m_ServiceArgsOptionPanel.SetSubElementsVisible(false);
            m_ServiceArgsOptionPanel.SetInfoBox("Konfigur�ci�s param�terek", "A \"service args\" lehet�v� teszi tov�bbi parancssori argumentumok megad�s�t" +
                "a web-illeszt�program szolg�ltat�s�nak ind�t�sakor.", InfoBox.InfoBoxType.Info);
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
            InfoBox infoBox = new InfoBox("Tesztelend� weblap", "Annak a weblapnak az URL-je, amin fusson a tesztel�s.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void logPathInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Logol�si �tvonal", "Az egy�b, esetleg fontos inform�ci�kat a tesztr�l az applik�ci� ki�rja az adott mapp�ba.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void fieldPanelInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Akci�k", "A tesztelend� oldalon v�grehajtand� akci�k �s feladatok list�ja.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void optionInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Opci�k", "Egyes tesztel�s k�zben el�fordulhat� esem�nyeket lehet be�ll�tani.", InfoBox.InfoBoxType.Info);
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
            m_ConsoleManager.Print("\n\n{LightSeaGreen}[Teszt] ind�t�sa... {DarkGray}" + $"[-{DateTime.Now}]\n");
            m_JsConsoleManager.Print("\n\n{LightSeaGreen}[Teszt] ind�t�sa... {DarkGray}" + $"[-{DateTime.Now}]\n");
            switchToJsLogButton_Click(sender, e);
            m_ConsoleManager.Print("\nExport�lt {Magenta}[JSON] f�jl:\n\n");

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
                of.Title = "Teszt ment�se...";
                of.Filter = $"Teszt f�jl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    string savedInfo = GetTestJSON();
                    File.WriteAllText(of.FileName, savedInfo);
                    m_ConsoleManager.Print("\n\n{Orange}[Teszt] {Cyan}[sikeresen] export�lva �s mentve az al�bbi helyre... {DarkGray}" + $"[-{of.FileName}]\n");
                }
            }
            else
            {
                string savedInfo = GetTestJSON();
                File.WriteAllText(AppConsts.s_LoadedTestFilepath!, savedInfo);
                m_ConsoleManager.Print("\n\n{Orange}[Teszt] {Cyan}[sikeresen] export�lva �s mentve az al�bbi helyre... {DarkGray}" + $"[-{AppConsts.s_LoadedTestFilepath}]\n");
            }
        }

        private void LoadTest()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt bet�lt�se...";
            of.Filter = $"Teszt f�jl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
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

                    m_ConsoleManager.Print("\n\n{Orange}[Teszt] {Cyan}[sikeresen] import�lva �s bet�ltve az al�bbi helyr�l... {DarkGray}" + $"[-{of.FileName}]\n");

                    AppConsts.s_IsEditingAlreadyExistingTest = true;
                    AppConsts.s_LoadedTestFilepath = of.FileName;
                    currentlyEditedText.Text = AppConsts.s_LoadedTestFilepath;
                }
                catch
                {
                    InfoBox infoBox = new InfoBox("Sikertelen bet�lt�s", "A mentett tesztf�jl bet�lt�se sikertelen volt! " +
                        "ellen�rizze a f�jl �ps�g�t, �s hogy nincs-e megnyitva m�s programban fut�si id� alatt!", InfoBox.InfoBoxType.Error);
                    infoBox.ShowDialog();

                    m_ConsoleManager.Print("\n\n{Orange}[Teszt] bet�lt�se {Red}[sikertelen] az al�bbi helyr�l... {DarkGray}" + $"[-{of.FileName}]\n");
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
