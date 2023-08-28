using WebTestGui;

namespace Scheduler
{
    public partial class Scheduler : Form
    {
        public Scheduler()
        {
            InitializeComponent();

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
            Text = AppConsts.s_AppName + "" + "Idõzítõ" + " " + AppConsts.s_AppVersion;
        }

        private void addUnitButton_Click(object sender, EventArgs e)
        {
            SchedulerItem item = new SchedulerItem(this);
            item.SetId(m_SchedulerItems.Count);
            m_SchedulerItems.Add(item);
            schedulerPanel.Controls.AddRange(m_SchedulerItems.ToArray());
        }

        public void MoveElement(SchedulerItem itemToMove, int newId)
        {
            // Use try catch, because initially, when the action is loaded to the MainForm's panel, the id is being
            // overriden on load, and that point in time the action is not yet inside the m_Actions list, so it would
            // throw an OutOfRangeException
            try
            {
                int oldId = m_SchedulerItems.IndexOf(itemToMove);

                if (oldId == newId)
                {
                    return;
                }
                if (newId > m_SchedulerItems.Count)
                {
                    return;
                }

                SchedulerItem item = m_SchedulerItems[oldId];
                m_SchedulerItems.RemoveAt(oldId);

                m_SchedulerItems.Insert(newId, item);

                for (int i = 0; i < m_SchedulerItems.Count; i++)
                {
                    m_SchedulerItems[i].SetId(i);
                }

                schedulerPanel.Controls.Clear();
                schedulerPanel.Controls.AddRange(m_SchedulerItems.ToArray());
            }
            catch
            {
                // Do nothing...
            }
        }

        public List<SchedulerItem> m_SchedulerItems = new List<SchedulerItem>();
    }
}