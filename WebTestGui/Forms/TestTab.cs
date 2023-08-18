﻿namespace WebTestGui
{
    public partial class TestTab : UserControl
    {
        public TestTab(MainForm mainForm)
        {
            InitializeComponent();
            Paint += OnBorderLineDraw!;

            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            m_ParentForm = mainForm;
        }

        public void OnBorderLineDraw(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.DarkGray, 2);
                var point1 = new Point(0, Height);
                var point2 = new Point(Size.Width, Height);
                g.DrawLine(p, point1, point2);
            }
        }

        public void RefreshTabItems()
        {
            tabPanel.Controls.Clear();
            tabPanel.Controls.AddRange(m_TestTabItems.ToArray());
        }

        public void AddNewBlankItem()
        {
            TestTabItem loadedTestTabItem = new TestTabItem(this, new Test(m_ParentForm));
            SelectItem(loadedTestTabItem);
            m_TestTabItems.Add(loadedTestTabItem);
            RefreshTabItems();
        }

        public void AddNewItem(object sender, EventArgs e)
        {
            Test loadedTest = m_ParentForm.LoadTestFromFile();
            if (loadedTest != null)
            {
                TestTabItem loadedTestTabItem = new TestTabItem(this, loadedTest);
                m_TestTabItems.Add(loadedTestTabItem);
                RefreshTabItems();
                SelectItem(loadedTestTabItem);
            }
        }

        public void AddNewItemFromFilePath(string filePath)
        {
            Test loadedTest = m_ParentForm.LoadTestFromFile(filePath);
            if (loadedTest != null)
            {
                TestTabItem loadedTestTabItem = new TestTabItem(this, loadedTest);
                m_TestTabItems.Add(loadedTestTabItem);
                RefreshTabItems();
                SelectItem(loadedTestTabItem);
            }
        }

        public void DeleteItem(TestTabItem item)
        {
            m_TestTabItems.Remove(item);
            if (m_TestTabItems.Count != 0)
            {
                SelectItem(m_TestTabItems[0]);
            }
            else
            {
                AddNewBlankItem();
            }
            RefreshTabItems();
        }

        public void SelectItem(TestTabItem selectedItem)
        {
            foreach (TestTabItem item in m_TestTabItems)
            {
                if (item == selectedItem)
                {
                    item.SelectItem();
                }
                else
                {
                    item.DeselectItem();
                }
            }
            m_SelectedItem = selectedItem;
            m_ParentForm.LoadTest();
        }

        public TestTabItem m_SelectedItem;
        public List<TestTabItem> m_TestTabItems = new List<TestTabItem>();
        public MainForm m_ParentForm;
    }
}
