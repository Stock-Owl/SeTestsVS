namespace WebTestGui
{
    public partial class TestTabItem : UserControl
    {
        public TestTabItem(TestTab testTab, Test test)
        {
            InitializeComponent();

            m_Test = test;
            m_ParentTab = testTab;

            testNameLabel.Text = test.m_Name;
        }

        public void OnClicked(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        public void DeleteTabItem(object sender, EventArgs e)
        {
            m_ParentTab.DeleteItem(this);
        }

        private void TestTabItem_Click(object sender, EventArgs e)
        {
            m_ParentTab.SelectItem(this);
        }

        private void testNameLabel_Click(object sender, EventArgs e)
        {
            m_ParentTab.SelectItem(this);
        }

        public void SelectItem()
        {
            testNameLabel.Font = new Font(testNameLabel.Font, FontStyle.Bold | FontStyle.Underline);
            BackColor = Color.FromArgb(255, 70, 70, 75);
            testNameLabel.BackColor = Color.FromArgb(255, 70, 70, 75);
        }

        public void DeselectItem()
        {
            testNameLabel.Font = new Font(testNameLabel.Font, FontStyle.Italic);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            testNameLabel.BackColor = Color.FromArgb(255, 50, 50, 53);
        }

        public Test m_Test;
        public TestTab m_ParentTab;
    }
}
