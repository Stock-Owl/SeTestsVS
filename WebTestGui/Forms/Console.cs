namespace WebTestGui
{
    public partial class Console : UserControl
    {
        public Console(MainForm mainForm)
        {
            InitializeComponent();
        }

        public void AddToConsoles(string text)
        {
            consoleTextBox.Text += text;
            m_ChromeLogString += text;
            m_FirefoxLogString += text;
        }

        public void AddToChrome(string text)
        {
            m_ChromeLogString += text;
            if (isChrome)
            {
                consoleTextBox.Text += text;
            }
        }

        public void AddToFirefox(string text)
        {
            m_FirefoxLogString += text;
            if (!isChrome)
            {
                consoleTextBox.Text += text;
            }
        }

        private void chromeButton_Click(object sender, EventArgs e)
        {
            consoleTextBox.Clear();
            consoleTextBox.Text = m_ChromeLogString;
            chromeButton.Font = new Font(chromeButton.Font, FontStyle.Bold);
            firefoxButton.Font = new Font(firefoxButton.Font, FontStyle.Italic);

            isChrome = true;
        }

        private void firefoxButton_Click(object sender, EventArgs e)
        {
            consoleTextBox.Clear();
            consoleTextBox.Text = m_FirefoxLogString;
            chromeButton.Font = new Font(chromeButton.Font, FontStyle.Italic);
            firefoxButton.Font = new Font(firefoxButton.Font, FontStyle.Bold);

            isChrome = false;
        }

        public void SetSchemeToRunning()
        {
            BackColor = Color.FromArgb(255, 70, 50, 50);
            consoleTextBox.ForeColor = Color.FromArgb(255, 192, 203);

            chromeButton.BackColor = Color.FromArgb(255, 70, 50, 50);
            firefoxButton.BackColor = Color.FromArgb(255, 70, 50, 50);

            chromeButton.BackColor = Color.FromArgb(255, 70, 50, 50);
            firefoxButton.BackColor = Color.FromArgb(255, 70, 50, 50);

            clearButton.BackColor = Color.FromArgb(255, 70, 50, 50);
        }

        public void SetSchemeToEdtiting()
        {
            BackColor = Color.FromArgb(255, 50, 50, 53);
            consoleTextBox.ForeColor = Color.LightBlue;

            chromeButton.BackColor = Color.FromArgb(255, 50, 50, 53);
            firefoxButton.BackColor = Color.FromArgb(255, 50, 50, 53);

            chromeButton.BackColor = Color.FromArgb(255, 50, 50, 53);
            firefoxButton.BackColor = Color.FromArgb(255, 50, 50, 53);

            clearButton.BackColor = Color.FromArgb(255, 50, 50, 53);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            m_ChromeLogString = string.Empty;
            m_FirefoxLogString = string.Empty;
            consoleTextBox.Clear();
        }

        bool isChrome = true;

        string m_ChromeLogString;
        string m_FirefoxLogString;

        MainForm m_ParentForm;
    }
}
