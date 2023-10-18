using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class KeepBrowserOpenDriverOption : UserControl, IDriverOption
    {
        public KeepBrowserOpenDriverOption()
        {
            InitializeComponent();

            m_DriverOptionName = "keep_browser_open";
        }

        // INTERFACE FUNCTIONS AND MEMBERS

        public object GetData()
        {
            return mainCheckbox.Checked;
        }

        public void SetData(JToken jSondata)
        {
            mainCheckbox.Checked = (bool)jSondata!;
        }

        public void Enable(bool enabled)
        {
            Enabled = enabled;
        }

        private void mainCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (mainCheckbox.Checked)
            {
                mainCheckbox.Text = "Igen";
            }
            else
            {
                mainCheckbox.Text = "Nem";
            }
        }

        public string m_DriverOptionName { get; set; }
        public MainForm m_ParentForm { get; set; }
    }
}
