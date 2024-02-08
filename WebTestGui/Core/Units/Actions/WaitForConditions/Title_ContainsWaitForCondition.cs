using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class Title_ContainsWaitForCondition : UserControl, IWaitForCondition
    {
        public Title_ContainsWaitForCondition()
        {
            InitializeComponent();
        }

        public string m_WaitForConditionType { get { return "title_contains"; } }
        public WaitForConditions m_ParentClass { get; set; }

        public Dictionary<string, object> GetJSONFormatted()
        {
            Dictionary<string, object> waitForConditionData = new Dictionary<string, object>();

            waitForConditionData["type"] = m_WaitForConditionType;

            waitForConditionData["case_sensitive"] = caseSensitiveCheckbox.Checked;
            waitForConditionData["value"] = valueTextBox.Text;

            return waitForConditionData;
        }

        public void SetData(JToken jSondata)
        {
            caseSensitiveCheckbox.Checked = (bool)jSondata["case_sensitive"]!;
            valueTextBox.Text = (string)jSondata["value"]!;
        }

        public void Delete(IWaitForCondition self)
        {
            m_ParentClass.DeleteWaitForCondition(self);
        }

        private void binImage_Click(object sender, EventArgs e)
        {
            Delete(this);
        }
    }
}
