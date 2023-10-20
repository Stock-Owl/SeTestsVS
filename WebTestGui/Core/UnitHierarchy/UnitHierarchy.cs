namespace WebTestGui
{
    public partial class UnitHierarchy : UserControl
    {
        public UnitHierarchy(MainForm mainForm)
        {
            InitializeComponent();

            m_ParentForm = mainForm;
        }

        public void AddUnitHierarchyItem(IUnit parentUnit)
        {
            UnitHierarchyItem item = new UnitHierarchyItem(this, parentUnit);
            m_UnitHierarchyItems.Add(item);
            unitsPanel.Controls.Add(item);
        }

        public void ClearItems()
        {
            m_UnitHierarchyItems.Clear();
            unitsPanel.Controls.Clear();
        }

        public List<UnitHierarchyItem> m_UnitHierarchyItems = new List<UnitHierarchyItem>();
        public MainForm m_ParentForm;
    }
}
