using System.Diagnostics;
using WebTestGui.Forms;
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

            //pageLoadStrategyBox.Items.AddRange(Enum.GetValues(typeof(ExportManager.Options.PageLoadStrategies)).Cast<object>().ToArray());
            //pageLoadStrategyBox.SelectedIndex = 0;

            //timeoutsBox.Items.AddRange(Enum.GetValues(typeof(ExportManager.Options.Timeout.TimeoutType)).Cast<object>().ToArray());
            //timeoutsBox.SelectedIndex = 0;

            //unhandledPromprBehaviourBox.Items.AddRange(Enum.GetValues(typeof(ExportManager.Options.UnhandledPromptBehaviours)).Cast<object>().ToArray());
            //unhandledPromprBehaviourBox.SelectedIndex = 2;

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
            //optionsPanel.Controls.Add(pageLoadStrategyText);
            //optionsPanel.Controls.Add(pageLoadStrategyBox);

            //optionsPanel.Controls.Add(acceptInsecureCertsText);
            //optionsPanel.Controls.Add(acceptInsecureCertsCheckbox);

            //optionsPanel.Controls.Add(timeoutsText);
            //optionsPanel.Controls.Add(timeoutsBox);
            //optionsPanel.Controls.Add(timeoutsInfo);
            //optionsPanel.Controls.Add(timeoutValueText);

            //optionsPanel.Controls.Add(unhandledPromprBehaviourText);
            //optionsPanel.Controls.Add(unhandledPromprBehaviourBox);

            //optionsPanel.Controls.Add(keepBrowserOpenText);
            //optionsPanel.Controls.Add(keepBrowserOpenCheckbox);

            //optionsPanel.Controls.Add(argsText);
            //optionsPanel.Controls.Add(splitterInfoText);
            //optionsPanel.Controls.Add(argsBox);

            //optionsPanel.Controls.Add(serviceLogPathText);
            //optionsPanel.Controls.Add(serviceLogPathBox);

            int y = 10;

            foreach (Control control in optionsPanel.Controls)
            {
                if (control is PictureBox)
                {

                }

                if (control is ComboBox || control is CheckBox || control is TextBox)
                {
                    control.Location = new Point(40, y);
                    y += control.Height + 20;
                }
                else
                {
                    control.Location = new Point(30, y);
                    y += control.Height + 3;
                }
            }
        }

        private void testStartButton_Click(object sender, EventArgs e)
        {
            ExportManager exportManager = new ExportManager();
            try
            {
                //exportManager.m_Options.m_PageLoadStrategy =
                //    (ExportManager.Options.PageLoadStrategies)Enum.Parse(typeof(ExportManager.Options.PageLoadStrategies), pageLoadStrategyBox.Text);
                //exportManager.m_Options.m_AcceptInsecureCerts = acceptInsecureCertsCheckbox.Checked;
                //exportManager.m_Options.m_Timeout.m_Type =
                //    (ExportManager.Options.Timeout.TimeoutType)Enum.Parse(typeof(ExportManager.Options.Timeout.TimeoutType), timeoutsBox.Text);

                //exportManager.m_Options.m_Timeout.m_ValueInMiliseconds = int.Parse(timeoutValueBox.Text);

                //exportManager.m_Options.m_unhandledPromptBehaviour =
                //    (ExportManager.Options.UnhandledPromptBehaviours)Enum.Parse(typeof(ExportManager.Options.UnhandledPromptBehaviours), unhandledPromprBehaviourBox.Text);

                //exportManager.m_Options.m_KeepBrowserOpen = keepBrowserOpenCheckbox.Checked;

                //List<string> argsList = new List<string>();
                //argsList.AddRange(argsBox.Text.Split(';'));
                //exportManager.m_Options.m_Args = argsList;

                //exportManager.m_Options.m_ServiceLogPath = serviceLogPathBox.Text;
                //exportManager.m_Options.m_ServiceArgs = new List<string>() { "one", "two", "three" }; // ADD GUI FUNCTIONALITY

                //exportManager.m_Actions.m_Goto = new ExportManager.Actions.ActionKeyValuePair() { Key = "url", Value = urlTextField.Text };
            }
            catch
            {
                InfoBox infoBox = new InfoBox("Hiányzó információ!", "Ki kell töltenie az összes '*'-gal jelölt mezõt!", InfoBox.InfoBoxType.Warning);
                infoBox.ShowDialog();
                return;
            }

            string JSON = exportManager.FormatDataToJson();
            consoleFormatter.WriteToConsoleFormatted("\nExportált {Magenta}[JSON] fájl:\n\n");
            console.AppendText(JSON + "\n");
        }



        private void acceptInsecureCertsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            //if (acceptInsecureCertsCheckbox.Checked)
            //{
            //    acceptInsecureCertsCheckbox.Text = "Igen";
            //}
            //else
            //{
            //    acceptInsecureCertsCheckbox.Text = "Nem";
            //}
        }

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

        private void pageLoadStrategyInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Lapbetöltés", "Meghatározza a lapbetöltés módját a teszt megkezdése elõtt.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void acceptInsecureCertsInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Bizonyítványok kezelése", "Meghatárózza, hogy az applikáció elfogadja-e a nem biztonságos kérelmeket.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void timeoutsInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Idõtúllépés", "Hogyan reagáljon a program az idõtúllépés elõfordulásakor.", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void unhandledPromprBehaviourInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Kezeletlen kérelem", "Kezeletlen kérelem esetén hogyan reagáljon a program", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        private void argsInfo_Click(object sender, EventArgs e)
        {
            InfoBox infoBox = new InfoBox("Extra paraméterek", "Plusz lehetséges paraméterek a teszt elindításához. (Opcionális)", InfoBox.InfoBoxType.Info);
            infoBox.ShowDialog();
        }

        #endregion
    }
}
