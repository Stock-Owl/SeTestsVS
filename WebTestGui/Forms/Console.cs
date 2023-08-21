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

        bool isChrome = true;

        string m_ChromeLogString;
        string m_FirefoxLogString;

        MainForm m_ParentForm;
    }
}
