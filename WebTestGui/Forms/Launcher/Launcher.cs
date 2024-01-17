using System.Diagnostics;

namespace WebTestGui
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args != null)
            {
                if (args.Length > 1)
                {
                    MainForm mainForm = new MainForm();
                    if (!string.IsNullOrEmpty(args[1]) && !string.IsNullOrEmpty(args[2]))
                    {
                        mainForm.RUN_SCHEDULED_TEST(args[1], args[2]);
                        mainForm.Show();
                    }

                    if (args.Length > 3)
                    {
                        if (!string.IsNullOrEmpty(args[3]))
                        {
                            mainForm.m_ScheduledTestLogName = args[3];
                            mainForm.Show();
                        }
                    }
                }
            }

            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);

            versionLabel.Text = AppConsts.s_AppVersion;

            m_LauncherAttributes = new LauncherAttributes(this);
            UpdateRecentlyOpenedPanel();
        }

        private void openTestButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt betöltése...";
            of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                OpenTest(of.FileName);
            }
        }

        public void OpenTest(string testFilePath)
        {
            MainForm mainForm = new MainForm(testFilePath);
            mainForm.Show();

            m_LauncherAttributes.AddToRecentlyOpenedTests(testFilePath, DateTime.Now.ToString("M/d/yyyy H:mm"));
            m_LauncherAttributes.SaveAttributesToFile();
            UpdateRecentlyOpenedPanel();
        }

        private void createTestButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void startQuickTestButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt betöltése...";
            of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                MainForm mainForm = new MainForm(of.FileName);
                mainForm.SetBreakpointsIgnore(true);
                mainForm.OnTestStart();
                mainForm.Show();
            }
        }

        private void scheduledTestLogLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt opciók mentése...";
            of.Filter = $"Teszt opciók fájl|*.vslog|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                string loadedLog = File.ReadAllText(of.FileName);
                ScheduledTestResult scheduledTestResult = new ScheduledTestResult();
                scheduledTestResult.SetData(loadedLog);

                MainForm schedulerMainForm = new MainForm();
                schedulerMainForm.LoadScheduledTestResults(scheduledTestResult, of.FileName);
                schedulerMainForm.Show();
                return;
            }
        }

        void UpdateRecentlyOpenedPanel()
        {
            m_LauncherAttributes.OrganiseRecentlyOpenedTests();
            foreach (RecentlyOpenedTest recentlyOpenedTest in m_LauncherAttributes.m_RecentlyOpenedTests)
                recentlyOpenedTest.UpdateLabels();
            lastOpenedTestsPanel.Controls.Clear();
            lastOpenedTestsPanel.Controls.AddRange(m_LauncherAttributes.m_RecentlyOpenedTests.ToArray());
        }

        LauncherAttributes m_LauncherAttributes;
    }
}
