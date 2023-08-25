using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class AutoExitIFramesOption : UserControl, IOption
    {
        public AutoExitIFramesOption()
        {
            InitializeComponent();

            m_OptionName = "auto_exit_iframes";
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

        public string m_OptionName { get; set; }
        public MainForm m_ParentForm { get; set; }

        // OPTION SPECIFIC FUNCTIONS AND MEMBERS

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
    }
}
