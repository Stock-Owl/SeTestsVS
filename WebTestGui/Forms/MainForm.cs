using System.Diagnostics;
using WebTestGui.Forms;
using WebTestGui.Forms.Controls;
using WebTestGui.Managers;
using WebTestGui.Utils;

namespace WebTestGui
{
    public partial class MainForm : Form
    {
        ConsoleFormatter consoleFormatter;

        public MainForm()
        {
            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            Text = AppConsts.AppConsts.s_AppName + " " + AppConsts.AppConsts.s_AppVersion;

            consoleFormatter = new ConsoleFormatter(console);

            consoleFormatter.WriteToConsoleFormatted("{Yellow}[Applikáció] indítása...\n");
            consoleFormatter.WriteToConsoleFormatted("Verzió: {Green}" + $"[{AppConsts.AppConsts.s_AppVersion}]\n");
            consoleFormatter.WriteToConsoleFormatted("{Orange}[Konzol] inicializálása...\n\n");
            consoleFormatter.WriteToConsoleFormatted("Az {Yellow}[alkalmazás] {Cyan}[sikeresen] elindult, a {Orange}[konzol] mûködik!\n");

            AddActionField();
            PopulateOptionsPanel();
        }

        #region Action adding logic

        private void addButton_Click(object sender, EventArgs e)
        {
            AddActionField();
        }

        private void AddActionField()
        {
            TextBox newTextField = new TextBox();
            newTextField.Size = new Size(180, 20);
            newTextField.Margin = new Padding(10);
            newTextField.BackColor = Color.FromArgb(255, 40, 40, 43);
            newTextField.ForeColor = Color.DarkGray;
            newTextField.BorderStyle = BorderStyle.Fixed3D;
            newTextField.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point);
            newTextField.Multiline = false;
            newTextField.PlaceholderText = "Mezõ neve...";

            Button deleteButton = new Button();
            deleteButton.Text = "Törlés";
            deleteButton.Margin = new Padding(10);
            deleteButton.BackColor = Color.FromArgb(40, 40, 43);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.Click += (sender, e) => DeleteTextField(newTextField, deleteButton);

            actionsPanel.Controls.Add(newTextField);
            actionsPanel.Controls.Add(deleteButton);

            PositionControls(actionsPanel);
        }

        private void DeleteTextField(TextBox textField, Button deleteButton)
        {
            actionsPanel.Controls.Remove(textField);
            actionsPanel.Controls.Remove(deleteButton);

            PositionControls(actionsPanel);
        }

        private void PositionControls(Panel parentPanel)
        {
            int y = 5;

            foreach (Control control in parentPanel.Controls)
            {
                if (control is Button)
                {
                    control.Location = new Point(10, y);
                    y += control.Height + 10;
                }
                else
                {
                    control.Location = new Point(5, y);
                    y += control.Height + 5;
                }
            }
        }

        #endregion

        private void PopulateOptionsPanel()
        {
            // PageLoadStrategy
            pageLoadStrategyOptionPanel.SetMainLabel("Lap betöltési stratégia:");
            pageLoadStrategyOptionPanel.SetMainCombobox<ExportManager.Options.PageLoadStrategies>("Lap betöltési stratégia típus...");
            pageLoadStrategyOptionPanel.SetSubElementsVisible(false);
            pageLoadStrategyOptionPanel.SetInfoBox("Lap betöltés", "A web-illesztõprogram hogyan kezeli az új oldal betöltését." +
                "Három különbözõ oldalbetöltési stratégia használható: Normál, Buzgó és Nincs.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(pageLoadStrategyOptionPanel);

            // AcceptInsecureCerts
            acceptInsuranceOptionPanel.SetMainLabel("Nem biztonságos bizonyítványok elfogadása:", 10);
            acceptInsuranceOptionPanel.SetMainCheckbox(false);
            acceptInsuranceOptionPanel.SetSubElementsVisible(false);
            acceptInsuranceOptionPanel.SetInfoBox("Bizonyítványok elfogadása", "Lehetõvé teszi, hogy a web-illesztõprogram olyan" +
                "weboldalakat is megnyisson, amelyeknél érvénytelen, vagy biztonsági tanúsítvány nélküli (insecure) SSL/TLS tanúsítványt használnak.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(acceptInsuranceOptionPanel);

            // Timeouts
            timeoutsOptionPanel.SetMainLabel("Idõtúllépések:");
            timeoutsOptionPanel.SetMainCombobox<ExportManager.Options.Timeout.TimeoutType>("Idõtûllépési lehetõségek...");
            timeoutsOptionPanel.SetSubElementsVisible(true);
            timeoutsOptionPanel.SetSubLabel("Értéke:");
            timeoutsOptionPanel.SetSubTextbox("Idõtúllépés értéke...*");
            timeoutsOptionPanel.SetInfoBox("Idõtúllépés", "Amikor a web-illesztõprogram egy parancsot végrehajt, például egy elem keresését vagy egy kattintást," +
                "elõfordulhat, hogy a weboldal betöltése vagy más folyamatok lassabban történnek, és idõre van szükségük a végrehajtáshoz.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(timeoutsOptionPanel);

            // UnhandledPromptBehaviour
            unhandledPromptBehaviourOptionPanel.SetMainLabel("Kezeletlen kérelmek:");
            unhandledPromptBehaviourOptionPanel.SetMainCombobox<ExportManager.Options.UnhandledPromptBehaviours>("Kezeletlen kérelmek kezelése...", 2);
            unhandledPromptBehaviourOptionPanel.SetSubElementsVisible(false);
            unhandledPromptBehaviourOptionPanel.SetInfoBox("Kezeletlen kérelmek", "Hogyan kezelje a nem várt vagy kezeletlen promptokat a böngészõben." +
                "Ez a beállítás hasznos lehet olyan helyzetekben, amikor a weboldalakon pop-up jelennek meg, amelyekhez választ vagy adatbevitelt igényelnek.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(unhandledPromptBehaviourOptionPanel);

            // KeepBrowserOpen
            keepBrowserOpenOptionPanel.SetMainLabel("Böngészõ nyitva marad:");
            keepBrowserOpenOptionPanel.SetMainCheckbox(false);
            keepBrowserOpenOptionPanel.SetSubElementsVisible(false);
            keepBrowserOpenOptionPanel.SetInfoBox("Böngészõ állapot", "A teszt befelyezése után bezáródjon-e a böngészõ ablak. Ha az 'Igen' opció van beállítva," +
                "akkor a böngészõn nyitva marad ameddig manuálisan vagy más program be nem zárja. Ellenkezõ esetben a teszt után automatikusa bezáródik.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(keepBrowserOpenOptionPanel);

            // Args
            browserArgsOptionPanel.SetMainLabel("Böngészõ indítási paraméterek:");
            browserArgsOptionPanel.SetMainTextbox("Extra paraméterek...");
            browserArgsOptionPanel.GiveHint("Spacel elválasztva)");
            browserArgsOptionPanel.SetSubElementsVisible(false);
            browserArgsOptionPanel.SetInfoBox("Böngészõ paraméterek", "Extra paraméterek amivel a program elindítja a böngészõt." +
                "Ezek a használt böngészõtõl függenek.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(browserArgsOptionPanel);

            // ServiceLogPath
            serviceLogOptionPanel.SetMainLabel("Web-illesztõprogram tevékenységeinek logolása:", 9);
            serviceLogOptionPanel.SetMainTextbox("A log fájl elérési útja...");
            serviceLogOptionPanel.SetSubElementsVisible(false);
            serviceLogOptionPanel.SetInfoBox("Web-illesztõprogram logolása", "A \"service log\" a Web-illesztõprogram tevékenységét rögzíti egy naplófájlba." +
                "Ez a naplófájl tartalmazza a szolgáltatás indításával és futtatásával kapcsolatos információkat és hibákat." +
                "Ezek a használt böngészõtõl függenek.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(serviceLogOptionPanel);

            // ServiceArgs
            serviceArgsOptionPanel.SetMainLabel("Konfigurációs paraméterek:");
            serviceArgsOptionPanel.SetMainTextbox("Extra paraméterek az programnak...");
            serviceArgsOptionPanel.GiveHint("(Spacel elválasztva)");
            serviceArgsOptionPanel.SetSubElementsVisible(false);
            serviceArgsOptionPanel.SetInfoBox("Konfigurációs paraméterek", "A \"service args\" lehetõvé teszi további parancssori argumentumok megadását" +
                "a web-illesztõprogram szolgáltatásának indításakor.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(serviceArgsOptionPanel);

        }

        private void testStartButton_Click(object sender, EventArgs e)
        {
            ExportManager exportManager = new ExportManager();
            try
            {
                exportManager.m_Options.m_PageLoadStrategy =
                    EnumHelpers.EnumTypeFromString<ExportManager.Options.PageLoadStrategies>(pageLoadStrategyOptionPanel.GetMainComboboxValue());
                exportManager.m_Options.m_AcceptInsecureCerts = acceptInsuranceOptionPanel.GetMainCheckboxValue();
                exportManager.m_Options.m_Timeout.m_Type =
                    EnumHelpers.EnumTypeFromString<ExportManager.Options.Timeout.TimeoutType>(timeoutsOptionPanel.GetMainComboboxValue());
                exportManager.m_Options.m_Timeout.m_ValueInMiliseconds = int.Parse(timeoutsOptionPanel.GetSubTextboxValue());
                exportManager.m_Options.m_unhandledPromptBehaviour =
                    EnumHelpers.EnumTypeFromString<ExportManager.Options.UnhandledPromptBehaviours>(unhandledPromptBehaviourOptionPanel.GetMainComboboxValue());
                exportManager.m_Options.m_KeepBrowserOpen = keepBrowserOpenOptionPanel.GetMainCheckboxValue();

                List<string> browserArgsList = new List<string>();
                browserArgsList.AddRange(browserArgsOptionPanel.GetMainTextboxValue().Split(' '));
                exportManager.m_Options.m_Args = browserArgsList;

                exportManager.m_Options.m_ServiceLogPath = serviceLogOptionPanel.GetMainTextboxValue();

                List<string> serviceArgsList = new List<string>();
                serviceArgsList.AddRange(serviceArgsOptionPanel.GetMainTextboxValue().Split(' '));
                exportManager.m_Options.m_ServiceArgs = serviceArgsList;

                exportManager.m_Actions.m_Goto = new ExportManager.Actions.ActionKeyValuePair() { Key = "url", Value = urlTextField.Text };
            }
            catch
            {
                InfoBox infoBox = new InfoBox("Hiányzó információ!", "Ki kell töltenie az összes mezõt!", InfoBox.InfoBoxType.Warning);
                infoBox.ShowDialog();
                return;
            }

            string JSON = exportManager.FormatDataToJson();
            consoleFormatter.WriteToConsoleFormatted("\nExportált {Magenta}[JSON] fájl:\n\n");
            console.AppendText(JSON + "\n");
        }

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

        OptionPanel pageLoadStrategyOptionPanel = new OptionPanel();
        OptionPanel acceptInsuranceOptionPanel = new OptionPanel();
        OptionPanel timeoutsOptionPanel = new OptionPanel();
        OptionPanel unhandledPromptBehaviourOptionPanel = new OptionPanel();
        OptionPanel keepBrowserOpenOptionPanel = new OptionPanel();
        OptionPanel browserArgsOptionPanel = new OptionPanel();
        OptionPanel serviceLogOptionPanel = new OptionPanel();
        OptionPanel serviceArgsOptionPanel = new OptionPanel();
    }
}
