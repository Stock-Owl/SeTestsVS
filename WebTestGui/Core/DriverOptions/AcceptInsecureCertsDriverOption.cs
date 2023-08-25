using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class AcceptInsecureCertsDriverOption : UserControl, IDriverOption
    {
        public AcceptInsecureCertsDriverOption()
        {
            InitializeComponent();

            m_DriverOptionName = "accept_insecure_certs";
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
