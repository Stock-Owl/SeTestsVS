using System.Diagnostics;
using WebTestGui.Forms;
using WebTestGui.Forms.Controls;
using WebTestGui.Managers;
using WebTestGui.Utils;

namespace WebTestGui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            Text = AppConsts.AppConsts.s_AppName + " " + AppConsts.AppConsts.s_AppVersion;

            consoleFormatter = new ConsoleFormatter(console);
            driverManager = new DriverManager();

            consoleFormatter.WriteToConsoleFormatted("{Yellow}[Applik�ci�] ind�t�sa...\n");
            consoleFormatter.WriteToConsoleFormatted("Verzi�: {Green}" + $"[{AppConsts.AppConsts.s_AppVersion}]\n");
            consoleFormatter.WriteToConsoleFormatted("{Orange}[Konzol] inicializ�l�sa...\n\n");
            consoleFormatter.WriteToConsoleFormatted("Az {Yellow}[alkalmaz�s] {Cyan}[sikeresen] elindult, a {Orange}[konzol] m�k�dik!\n");

            PopulateOptionsPanel();
            addActionComboBox.Items.AddRange(TypeHelpers.GetAllSubClasses<Forms.Controls.Action>());
        }

        private void addActionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.addActionComboBox.GetItemText(this.addActionComboBox.SelectedItem)!;
            addActionComboBox.Text = "";
            Type test = TypeHelpers.GetClassFromString(selected);
            actionsPanel.Controls.Add((Control)Activator.CreateInstance(test)!);
        }

        private void testStartButton_Click(object sender, EventArgs e)
        {
            try
            {
                driverManager.m_Options.m_PageLoadStrategy = 
                    TypeHelpers.EnumTypeFromString<DriverManager.Options.PageLoadStrategies>(pageLoadStrategyOptionPanel.GetMainComboboxValue());
                driverManager.m_Options.m_AcceptInsecureCerts = acceptInsuranceOptionPanel.GetMainCheckboxValue();
                driverManager.m_Options.m_Timeout.m_Type =
                    TypeHelpers.EnumTypeFromString<DriverManager.Options.Timeout.TimeoutType>(timeoutsOptionPanel.GetMainComboboxValue());
                driverManager.m_Options.m_Timeout.m_ValueInMiliseconds = int.Parse(timeoutsOptionPanel.GetSubTextboxValue());
                driverManager.m_Options.m_unhandledPromptBehaviour =
                    TypeHelpers.EnumTypeFromString<DriverManager.Options.UnhandledPromptBehaviours>(unhandledPromptBehaviourOptionPanel.GetMainComboboxValue());
                driverManager.m_Options.m_KeepBrowserOpen = keepBrowserOpenOptionPanel.GetMainCheckboxValue();

                List<string> browserArgsList = new List<string>();
                browserArgsList.AddRange(browserArgsOptionPanel.GetMainTextboxValue().Split(' '));
                driverManager.m_Options.m_BrowserArgs = browserArgsList;

                bool test = logJsActiveOptionPanel.GetMainCheckboxValue();
                driverManager.m_Options.m_LogJs.m_Active = test;

                driverManager.m_Options.m_ServiceLogPath = serviceLogOptionPanel.GetMainTextboxValue();

                List<string> serviceArgsList = new List<string>();
                serviceArgsList.AddRange(serviceArgsOptionPanel.GetMainTextboxValue().Split(' '));
                driverManager.m_Options.m_ServiceArgs = serviceArgsList;
            }
            catch
            {
                InfoBox infoBox = new InfoBox("Hi�nyz� inform�ci�!", "Ki kell t�ltenie az �sszes mez�t!", InfoBox.InfoBoxType.Warning);
                infoBox.ShowDialog();
                return;
            }

            string JSON = driverManager.FormatDataToJson();
            consoleFormatter.WriteToConsoleFormatted("\nExport�lt {Magenta}[JSON] f�jl:\n\n");
            console.AppendText(JSON + "\n");
        }

        #region Option Panel

        private void PopulateOptionsPanel()
        {
            // PageLoadStrategy
            pageLoadStrategyOptionPanel.SetMainLabel("Lap bet�lt�si strat�gia:");
            pageLoadStrategyOptionPanel.SetMainCombobox<DriverManager.Options.PageLoadStrategies>("Lap bet�lt�si strat�gia t�pus...");
            pageLoadStrategyOptionPanel.SetSubElementsVisible(false);
            pageLoadStrategyOptionPanel.SetInfoBox("Lap bet�lt�s", "A web-illeszt�program hogyan kezeli az �j oldal bet�lt�s�t." +
                "H�rom k�l�nb�z� oldalbet�lt�si strat�gia haszn�lhat�: Norm�l, Buzg� �s Nincs.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(pageLoadStrategyOptionPanel);

            // AcceptInsecureCerts
            acceptInsuranceOptionPanel.SetMainLabel("Nem biztons�gos bizony�tv�nyok elfogad�sa:", 10);
            acceptInsuranceOptionPanel.SetMainCheckbox(false);
            acceptInsuranceOptionPanel.SetSubElementsVisible(false);
            acceptInsuranceOptionPanel.SetInfoBox("Bizony�tv�nyok elfogad�sa", "Lehet�v� teszi, hogy a web-illeszt�program olyan" +
                "weboldalakat is megnyisson, amelyekn�l �rv�nytelen, vagy biztons�gi tan�s�tv�ny n�lk�li (insecure) SSL/TLS tan�s�tv�nyt haszn�lnak.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(acceptInsuranceOptionPanel);

            // Timeouts
            timeoutsOptionPanel.SetMainLabel("Id�t�ll�p�sek:");
            timeoutsOptionPanel.SetMainCombobox<DriverManager.Options.Timeout.TimeoutType>("Id�t�ll�p�si lehet�s�gek...");
            timeoutsOptionPanel.SetSubElementsVisible(true);
            timeoutsOptionPanel.SetSubLabel("�rt�ke:");
            timeoutsOptionPanel.SetSubTextbox("Id�t�ll�p�s �rt�ke (ms)...*", "300000");
            timeoutsOptionPanel.SetInfoBox("Id�t�ll�p�s", "Amikor a web-illeszt�program egy parancsot v�grehajt, p�ld�ul egy elem keres�s�t vagy egy kattint�st," +
                "el�fordulhat, hogy a weboldal bet�lt�se vagy m�s folyamatok lassabban t�rt�nnek, �s id�re van sz�ks�g�k a v�grehajt�shoz.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(timeoutsOptionPanel);

            // UnhandledPromptBehaviour
            unhandledPromptBehaviourOptionPanel.SetMainLabel("Kezeletlen k�relmek:");
            unhandledPromptBehaviourOptionPanel.SetMainCombobox<DriverManager.Options.UnhandledPromptBehaviours>("Kezeletlen k�relmek kezel�se...", 2);
            unhandledPromptBehaviourOptionPanel.SetSubElementsVisible(false);
            unhandledPromptBehaviourOptionPanel.SetInfoBox("Kezeletlen k�relmek", "Hogyan kezelje a nem v�rt vagy kezeletlen promptokat a b�ng�sz�ben." +
                "Ez a be�ll�t�s hasznos lehet olyan helyzetekben, amikor a weboldalakon pop-up jelennek meg, amelyekhez v�laszt vagy adatbevitelt ig�nyelnek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(unhandledPromptBehaviourOptionPanel);

            // KeepBrowserOpen
            keepBrowserOpenOptionPanel.SetMainLabel("B�ng�sz� nyitva marad:");
            keepBrowserOpenOptionPanel.SetMainCheckbox(true);
            keepBrowserOpenOptionPanel.SetSubElementsVisible(false);
            keepBrowserOpenOptionPanel.SetInfoBox("B�ng�sz� �llapot", "A teszt befelyez�se ut�n bez�r�djon-e a b�ng�sz� ablak. Ha az 'Igen' opci� van be�ll�tva," +
                "akkor a b�ng�sz�n nyitva marad ameddig manu�lisan vagy m�s program be nem z�rja. Ellenkez� esetben a teszt ut�n automatikusa bez�r�dik.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(keepBrowserOpenOptionPanel);

            // BrowserArgs
            browserArgsOptionPanel.SetMainLabel("B�ng�sz� ind�t�si param�terek:");
            browserArgsOptionPanel.SetMainTextbox("Extra param�terek...");
            browserArgsOptionPanel.GiveHint("(Spacel elv�lasztva)");
            browserArgsOptionPanel.SetSubElementsVisible(false);
            browserArgsOptionPanel.SetInfoBox("B�ng�sz� param�terek", "Extra param�terek amivel a program elind�tja a b�ng�sz�t." +
                "Ezek a haszn�lt b�ng�sz�t�l f�ggenek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(browserArgsOptionPanel);

            // LogJSActive
            logJsActiveOptionPanel.SetMainLabel("JS akt�v logol�sa:");
            logJsActiveOptionPanel.SetMainCheckbox(true);
            logJsActiveOptionPanel.SetSubElementsVisible(false);
            logJsActiveOptionPanel.SetInfoBox("JavaScript log", "A teszt ideje alatt legyen-e akt�v logol�sa a b�ng�sz�nek. Ez ki�rja az �sszes " +
                "inform�ci�t, amit a JavaScript szkript v�gez. Esetlegesen tartalmazhat fontos inform�ci�kat.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(logJsActiveOptionPanel);

            // ServiceLogPath
            serviceLogOptionPanel.SetMainLabel("Web-illeszt�program tev�kenys�geinek logol�sa:", 9);
            serviceLogOptionPanel.SetMainTextbox("A log f�jl el�r�si �tja...");
            serviceLogOptionPanel.SetSubElementsVisible(false);
            serviceLogOptionPanel.AddFolderDialog();
            serviceLogOptionPanel.SetInfoBox("Web-illeszt�program logol�sa", "A \"service log\" a Web-illeszt�program tev�kenys�g�t r�gz�ti egy napl�f�jlba." +
                "Ez a napl�f�jl tartalmazza a szolg�ltat�s ind�t�s�val �s futtat�s�val kapcsolatos inform�ci�kat �s hib�kat." +
                "Ezek a haszn�lt b�ng�sz�t�l f�ggenek.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(serviceLogOptionPanel);

            // ServiceArgs
            serviceArgsOptionPanel.SetMainLabel("Konfigur�ci�s param�terek:");
            serviceArgsOptionPanel.SetMainTextbox("Extra param�terek az programnak...");
            serviceArgsOptionPanel.GiveHint("(Spacel elv�lasztva)");
            serviceArgsOptionPanel.SetSubElementsVisible(false);
            serviceArgsOptionPanel.SetInfoBox("Konfigur�ci�s param�terek", "A \"service args\" lehet�v� teszi tov�bbi parancssori argumentumok megad�s�t" +
                "a web-illeszt�program szolg�ltat�s�nak ind�t�sakor.", InfoBox.InfoBoxType.Info);
            optionsPanel.Controls.Add(serviceArgsOptionPanel);
        }

        #endregion

        #region Browser button functions

        private void searchForFolderButton_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    logPathBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void webSearchButton_Click(object sender, EventArgs e)
        {
            string executable = chromeCheckBox.Checked ? BrowserHelper.GetChromeExecutablePath() : BrowserHelper.GetFirefoxExecutablePath();
            string url = string.IsNullOrEmpty(urlTextField.Text) ? "google.com" : urlTextField.Text;
            Process.Start($"{executable}", url);
        }

        #endregion

        #region Browser Checkboxes logic functions

        private void chromeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (chromeCheckBox.Checked)
            {
                chromeCheckBox.Checked = true;
                chromeCheckBox.Font = new Font(chromeCheckBox.Font, FontStyle.Bold);

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

        private void logPathInfo_Resize(object sender, EventArgs e)
        {
            logPathInfo.Size = new Size(15, 15);
        }

        private void urlTextFieldInfo_Resize(object sender, EventArgs e)
        {
            urlTextFieldInfo.Size = new Size(15, 15);
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

        // TODO: remove these
        Option pageLoadStrategyOptionPanel = new Option();
        Option acceptInsuranceOptionPanel = new Option();
        Option timeoutsOptionPanel = new Option();
        Option unhandledPromptBehaviourOptionPanel = new Option();
        Option keepBrowserOpenOptionPanel = new Option();
        Option browserArgsOptionPanel = new Option();
        Option logJsActiveOptionPanel = new Option();
        Option serviceLogOptionPanel = new Option();
        Option serviceArgsOptionPanel = new Option();

        ConsoleFormatter consoleFormatter;
        DriverManager driverManager;
    }
}
