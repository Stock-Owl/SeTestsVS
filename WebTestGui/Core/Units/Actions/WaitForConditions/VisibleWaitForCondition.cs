using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class VisibleWaitForCondition : UserControl, IWaitForCondition
    {
        public VisibleWaitForCondition()
        {
            InitializeComponent();
        }

        public string m_WaitForConditionType { get { return "visible"; } }
        public WaitForConditions m_ParentClass { get; set; }

        public Dictionary<string, object> GetJSONFormatted()
        {
            Dictionary<string, object> waitForConditionData = new Dictionary<string, object>();

            waitForConditionData["type"] = m_WaitForConditionType;
            waitForConditionData["locator"] = locatorTextBox.Text;
            waitForConditionData["value"] = valueTextBox.Text;

            return waitForConditionData;
        }

        public void SetData(JToken jSondata)
        {
            locatorTextBox.Text = (string)jSondata["locator"]!;
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
