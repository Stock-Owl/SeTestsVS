using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class TimeoutDriverOption : UserControl, IDriverOption
    {
        public TimeoutDriverOption()
        {
            InitializeComponent();

            m_DriverOptionName = "timeout";
        }

        // INTERFACE FUNCTIONS AND MEMBERS

        public object GetData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            data["type"] = mainComboBox.Text;
            data["value"] = int.Parse(timeoutTextBox.Text);

            return data;
        }

        public void SetData(JToken jSondata)
        {
            mainComboBox.Text = (string)jSondata["type"]!;
            timeoutTextBox.Text = ((int)jSondata["value"]!).ToString();
        }

        public void Enable(bool enabled)
        {
            Enabled = enabled;
        }

        private void mainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = mainComboBox.GetItemText(mainComboBox.SelectedItem)!;

            switch (selected)
            {
                case "pageLoad":
                    timeoutTextBox.Text = "300000";
                    break;
                case "script":
                    timeoutTextBox.Text = "30000";
                    break;
                case "implicit":
                    timeoutTextBox.Text = "0";
                    break;
                default:
                    timeoutTextBox.Text = "0";
                    break;
            }
        }

        public string m_DriverOptionName { get; set; }
        public MainForm m_ParentForm { get; set; }
    }
}
