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

        private void breakpointOffIcon_Click(object sender, EventArgs e)
        {
            m_ParentTab.SelectItem(this);
        }

        private void TestTabItem_Click(object sender, EventArgs e)
        {
            if (m_ParentTab.m_ParentForm.GetMainTest().m_State == Test.TestState.Edit)
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
                BackColor = Color.FromArgb(255, 30, 30, 33);
                testNameLabel.BackColor = Color.FromArgb(255, 30, 30, 33);
                pictureBox2.BackColor = Color.FromArgb(255, 30, 30, 33);
                breakpointOffIcon.Visible = true;
                breakpointOnIcon.Visible = false;
            }
            else if (m_Test.m_State == Test.TestState.Break)
            {
                BackColor = Color.FromArgb(255, 80, 70, 70);
                testNameLabel.BackColor = Color.FromArgb(255, 80, 70, 70);
                pictureBox2.BackColor = Color.FromArgb(255, 80, 70, 70);
                breakpointOffIcon.Visible = false;
                breakpointOnIcon.Visible = true;
            }
            else if (m_Test.m_State == Test.TestState.Run)
            {
                BackColor = Color.FromArgb(255, 80, 70, 70);
                testNameLabel.BackColor = Color.FromArgb(255, 80, 70, 70);
                pictureBox2.BackColor = Color.FromArgb(255, 80, 70, 70);
                breakpointOffIcon.Visible = true;
                breakpointOnIcon.Visible = false;
            }
        }

        public void DeselectItem()
        {
            testNameLabel.Font = new Font(testNameLabel.Font, FontStyle.Italic);

            if (m_Test.m_State == Test.TestState.Edit)
            {
                BackColor = Color.FromArgb(255, 50, 50, 55);
                testNameLabel.BackColor = Color.FromArgb(255, 50, 50, 55);
                pictureBox2.BackColor = Color.FromArgb(255, 50, 50, 55);
                breakpointOffIcon.Visible = true;
                breakpointOnIcon.Visible = false;
            }
            else if (m_Test.m_State == Test.TestState.Break)
            {
                BackColor = Color.FromArgb(255, 60, 50, 50);
                testNameLabel.BackColor = Color.FromArgb(255, 60, 50, 50);
                pictureBox2.BackColor = Color.FromArgb(255, 60, 50, 50);
                breakpointOffIcon.Visible = false;
                breakpointOnIcon.Visible = true;
            }
            else if (m_Test.m_State == Test.TestState.Run)
            {
                BackColor = Color.FromArgb(255, 60, 50, 50);
                testNameLabel.BackColor = Color.FromArgb(255, 60, 50, 50);
                pictureBox2.BackColor = Color.FromArgb(255, 60, 50, 50);
                breakpointOffIcon.Visible = true;
                breakpointOnIcon.Visible = false;
            }
        }

        public Test m_Test;
        public TestTab m_ParentTab;
    }
}
