using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class LogJSRetryTimeoutOption : UserControl, IOption
    {
        public LogJSRetryTimeoutOption()
        {
            InitializeComponent();

            m_OptionName = "log_JS_retry_timeout";
        }

        // INTERFACE FUNCTIONS AND MEMBERS

        public object GetData()
        {
            return int.Parse(timeoutTextBox.Text);
        }

        public void SetData(JToken jSondata)
        {
            timeoutTextBox.Text = ((int)jSondata!).ToString();
        }

        public void Enable(bool enabled)
        {
            Enabled = enabled;
        }

        public string m_OptionName { get; set; }
        public MainForm m_ParentForm { get; set; }

        // OPTION SPECIFIC FUNCTIONS AND MEMBERS
    }
}
