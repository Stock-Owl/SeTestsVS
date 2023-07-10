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

            consoleFormatter.WriteToConsoleFormatted("{Yellow}[Applik�ci�] ind�t�sa...\n");
            consoleFormatter.WriteToConsoleFormatted("Verzi�: {Green}" + $"[{AppConsts.AppConsts.s_AppVersion}]\n");
            consoleFormatter.WriteToConsoleFormatted("{Orange}[Konzol] inicializ�l�sa...\n\n");
            consoleFormatter.WriteToConsoleFormatted("Az {Yellow}[alkalmaz�s] {Cyan}[sikeresen] elindult, a {Orange}[konzol] m�k�dik!\n");

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
            newTextField.PlaceholderText = "Mez� neve...";

            Button deleteButton = new Button();
            deleteButton.Text = "T�rl�s";
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
            pageLoadStrategyOptionPanel.SetMainLabel("Lap bet�lt�si strat�gia:");
            pageLoadStrategyOptionPanel.SetMainCombobox<ExportManager.Options.PageLoadStrategies>("Lap bet�lt�si strat�gia t�pus...");
            pageLoadStrategyOptionPanel.SetSubElementsVisible(false);
            pageLoadStrategyOptionPanel.SetInfoBox("Lap bet�lt�s", "A web-illeszt�program hogyan kezeli az �j oldal bet�lt�s�t." +
                "H�rom k�l�nb�z� oldalbet�lt�si strat�gia haszn�lhat�: Norm�l, Buzg� �s Nincs.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(pageLoadStrategyOptionPanel);

            // AcceptInsecureCerts
            acceptInsuranceOptionPanel.SetMainLabel("Nem biztons�gos bizony�tv�nyok elfogad�sa:", 10);
            acceptInsuranceOptionPanel.SetMainCheckbox(false);
            acceptInsuranceOptionPanel.SetSubElementsVisible(false);
            acceptInsuranceOptionPanel.SetInfoBox("Bizony�tv�nyok elfogad�sa", "Lehet�v� teszi, hogy a web-illeszt�program olyan" +
                "weboldalakat is megnyisson, amelyekn�l �rv�nytelen, vagy biztons�gi tan�s�tv�ny n�lk�li (insecure) SSL/TLS tan�s�tv�nyt haszn�lnak.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(acceptInsuranceOptionPanel);

            // Timeouts
            timeoutsOptionPanel.SetMainLabel("Id�t�ll�p�sek:");
            timeoutsOptionPanel.SetMainCombobox<ExportManager.Options.Timeout.TimeoutType>("Id�t�ll�p�si lehet�s�gek...");
            timeoutsOptionPanel.SetSubElementsVisible(true);
            timeoutsOptionPanel.SetSubLabel("�rt�ke:");
            timeoutsOptionPanel.SetSubTextbox("Id�t�ll�p�s �rt�ke...*");
            timeoutsOptionPanel.SetInfoBox("Id�t�ll�p�s", "Amikor a web-illeszt�program egy parancsot v�grehajt, p�ld�ul egy elem keres�s�t vagy egy kattint�st," +
                "el�fordulhat, hogy a weboldal bet�lt�se vagy m�s folyamatok lassabban t�rt�nnek, �s id�re van sz�ks�g�k a v�grehajt�shoz.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(timeoutsOptionPanel);

            // UnhandledPromptBehaviour
            unhandledPromptBehaviourOptionPanel.SetMainLabel("Kezeletlen k�relmek:");
            unhandledPromptBehaviourOptionPanel.SetMainCombobox<ExportManager.Options.UnhandledPromptBehaviours>("Kezeletlen k�relmek kezel�se...", 2);
            unhandledPromptBehaviourOptionPanel.SetSubElementsVisible(false);
            unhandledPromptBehaviourOptionPanel.SetInfoBox("Kezeletlen k�relmek", "Hogyan kezelje a nem v�rt vagy kezeletlen promptokat a b�ng�sz�ben." +
                "Ez a be�ll�t�s hasznos lehet olyan helyzetekben, amikor a weboldalakon pop-up jelennek meg, amelyekhez v�laszt vagy adatbevitelt ig�nyelnek.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(unhandledPromptBehaviourOptionPanel);

            // KeepBrowserOpen
            keepBrowserOpenOptionPanel.SetMainLabel("B�ng�sz� nyitva marad:");
            keepBrowserOpenOptionPanel.SetMainCheckbox(false);
            keepBrowserOpenOptionPanel.SetSubElementsVisible(false);
            keepBrowserOpenOptionPanel.SetInfoBox("B�ng�sz� �llapot", "A teszt befelyez�se ut�n bez�r�djon-e a b�ng�sz� ablak. Ha az 'Igen' opci� van be�ll�tva," +
                "akkor a b�ng�sz�n nyitva marad ameddig manu�lisan vagy m�s program be nem z�rja. Ellenkez� esetben a teszt ut�n automatikusa bez�r�dik.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(keepBrowserOpenOptionPanel);

            // Args
            browserArgsOptionPanel.SetMainLabel("B�ng�sz� ind�t�si param�terek:");
            browserArgsOptionPanel.SetMainTextbox("Extra param�terek...");
            browserArgsOptionPanel.GiveHint("Spacel elv�lasztva)");
            browserArgsOptionPanel.SetSubElementsVisible(false);
            browserArgsOptionPanel.SetInfoBox("B�ng�sz� param�terek", "Extra param�terek amivel a program elind�tja a b�ng�sz�t." +
                "Ezek a haszn�lt b�ng�sz�t�l f�ggenek.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(browserArgsOptionPanel);

            // ServiceLogPath
            serviceLogOptionPanel.SetMainLabel("Web-illeszt�program tev�kenys�geinek logol�sa:", 9);
            serviceLogOptionPanel.SetMainTextbox("A log f�jl el�r�si �tja...");
            serviceLogOptionPanel.SetSubElementsVisible(false);
            serviceLogOptionPanel.SetInfoBox("Web-illeszt�program logol�sa", "A \"service log\" a Web-illeszt�program tev�kenys�g�t r�gz�ti egy napl�f�jlba." +
                "Ez a napl�f�jl tartalmazza a szolg�ltat�s ind�t�s�val �s futtat�s�val kapcsolatos inform�ci�kat �s hib�kat." +
                "Ezek a haszn�lt b�ng�sz�t�l f�ggenek.", InfoBox.InfoBoxType.Info);
            flowLayoutPanel1.Controls.Add(serviceLogOptionPanel);

            // ServiceArgs
            serviceArgsOptionPanel.SetMainLabel("Konfigur�ci�s param�terek:");
            serviceArgsOptionPanel.SetMainTextbox("Extra param�terek az programnak...");
            serviceArgsOptionPanel.GiveHint("(Spacel elv�lasztva)");
            serviceArgsOptionPanel.SetSubElementsVisible(false);
            serviceArgsOptionPanel.SetInfoBox("Konfigur�ci�s param�terek", "A \"service args\" lehet�v� teszi tov�bbi parancssori argumentumok megad�s�t" +
                "a web-illeszt�program szolg�ltat�s�nak ind�t�sakor.", InfoBox.InfoBoxType.Info);
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
                InfoBox infoBox = new InfoBox("Hi�nyz� inform�ci�!", "Ki kell t�ltenie az �sszes mez�t!", InfoBox.InfoBoxType.Warning);
                infoBox.ShowDialog();
                return;
            }

            string JSON = exportManager.FormatDataToJson();
            consoleFormatter.WriteToConsoleFormatted("\nExport�lt {Magenta}[JSON] f�jl:\n\n");
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
