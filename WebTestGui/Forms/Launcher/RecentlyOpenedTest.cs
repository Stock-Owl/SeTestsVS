namespace WebTestGui
{
    public partial class RecentlyOpenedTest : UserControl
    {
        public RecentlyOpenedTest(Launcher parentLauncher)
        {
            InitializeComponent();
            m_ParentLauncher = parentLauncher;
        }

        public void UpdateLabels()
        {
            testFilePathLabel.Text = m_TestFilePath;
            lastOpenedLabel.Text = m_LastOpenedDate;

            testNameLabel.Text = Path.GetFileNameWithoutExtension(m_TestFilePath);
        }

        private void testNameLabel_Click(object sender, EventArgs e)
        {
            OnClick();
        }

        private void testFilePathLabel_Click(object sender, EventArgs e)
        {
            OnClick();
        }

        private void lastOpenedLabel_Click(object sender, EventArgs e)
        {
            OnClick();
        }

        private void RecentlyOpenedTest_Click(object sender, EventArgs e)
        {
            OnClick();
        }

        void OnClick()
        {
            m_ParentLauncher.OpenTest(testFilePathLabel.Text);
        }

        public string m_TestFilePath;
        public string m_LastOpenedDate;

        public Launcher m_ParentLauncher;

        
    }
}
