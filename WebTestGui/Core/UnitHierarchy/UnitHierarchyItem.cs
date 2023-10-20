namespace WebTestGui
{
    public partial class UnitHierarchyItem : UserControl
    {
        public UnitHierarchyItem(UnitHierarchy parentHierarchy, IUnit parentUnit)
        {
            InitializeComponent();

            m_ParentHierarchy = parentHierarchy;
            m_ParentUnit = parentUnit;

            unitNameLabel.Text = parentUnit.m_UnitName;
            idTextBox.Text = parentUnit.GetUId().ToString();

            Tuple<int, int> runtimeValued = m_ParentUnit.GetRunTime();
            testRunTimeText.Text = (runtimeValued.Item1.ToString() + " / " + runtimeValued.Item2.ToString() + " ms");
        }

        private void unitNameLabel_Click(object sender, EventArgs e)
        {
            m_ParentHierarchy.m_ParentForm.ScrollToUnit(m_ParentUnit.m_UnitName);
        }

        private void UnitHierarchyItem_Load(object sender, EventArgs e)
        {
            m_ParentHierarchy.m_ParentForm.ScrollToUnit(m_ParentUnit.m_UnitName);
        }

        private void testRunTimeLabel_Click(object sender, EventArgs e)
        {
            m_ParentHierarchy.m_ParentForm.ScrollToUnit(m_ParentUnit.m_UnitName);
        }

        private void testRunTimeText_Click(object sender, EventArgs e)
        {
            m_ParentHierarchy.m_ParentForm.ScrollToUnit(m_ParentUnit.m_UnitName);
        }

        UnitHierarchy m_ParentHierarchy;
        IUnit m_ParentUnit;
    }
}
