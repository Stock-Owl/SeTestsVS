using Newtonsoft.Json.Linq;
using System;

namespace WebTestGui
{
    public partial class LogJSOption : UserControl, IOption
    {
        public LogJSOption()
        {
            InitializeComponent();

            m_OptionName = "log_JS";
        }

        // INTERFACE FUNCTIONS AND MEMBERS

        public object GetData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            data["active"] = mainCheckbox.Checked;
            data["refresh_rate"] = int.Parse(refreshRateTextBox.Text);
            data["retry_timeout"] = int.Parse(timeoutTextBox.Text);

            return data;
        }

        public void SetData(JToken jSondata)
        {
            mainCheckbox.Checked = (bool)jSondata["active"]!;
            refreshRateTextBox.Text = ((int)jSondata["refresh_rate"]!).ToString();
            timeoutTextBox.Text = ((int)jSondata["retry_timeout"]!).ToString();
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
