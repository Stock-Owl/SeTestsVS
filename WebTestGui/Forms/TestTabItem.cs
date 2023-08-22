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

            if (m_Test.m_State == Test.TestState.Edit)
            {
                BackColor = Color.FromArgb(255, 70, 70, 75);
                testNameLabel.BackColor = Color.FromArgb(255, 70, 70, 75);
            }
            else if (m_Test.m_State == Test.TestState.Break)
            {
                BackColor = Color.FromArgb(255, 80, 70, 70);
                testNameLabel.BackColor = Color.FromArgb(255, 80, 70, 70);
                // SHOW BREAKPOINT ICON
            }
            else if (m_Test.m_State == Test.TestState.Run)
            {
                BackColor = Color.FromArgb(255, 80, 70, 70);
                testNameLabel.BackColor = Color.FromArgb(255, 80, 70, 70);
            }
        }

        public void DeselectItem()
        {
            testNameLabel.Font = new Font(testNameLabel.Font, FontStyle.Italic);

            if (m_Test.m_State == Test.TestState.Edit)
            {
                BackColor = Color.FromArgb(255, 50, 50, 53);
                testNameLabel.BackColor = Color.FromArgb(255, 50, 50, 53);
            }
            else if (m_Test.m_State == Test.TestState.Break)
            {
                BackColor = Color.FromArgb(255, 60, 50, 50);
                testNameLabel.BackColor = Color.FromArgb(255, 60, 50, 50);
                // SHOW BREAKPOINT ICON
            }
            else if (m_Test.m_State == Test.TestState.Run)
            {
                BackColor = Color.FromArgb(255, 60, 50, 50);
                testNameLabel.BackColor = Color.FromArgb(255, 60, 50, 50);
            }
        }

        public Test m_Test;
        public TestTab m_ParentTab;
    }
}
