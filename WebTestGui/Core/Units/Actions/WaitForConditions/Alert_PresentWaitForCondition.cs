using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class Alert_PresentWaitForCondition : UserControl, IWaitForCondition
    {
        public Alert_PresentWaitForCondition()
        {
            InitializeComponent();
        }

        public string m_WaitForConditionType { get { return "alert_present"; } }
        public WaitForConditions m_ParentClass { get; set; }

        public Dictionary<string, object> GetJSONFormatted()
        {
            Dictionary<string, object> waitForConditionData = new Dictionary<string, object>();

            waitForConditionData["type"] = m_WaitForConditionType;

            waitForConditionData["present"] = presentCheckbox.Checked;

            return waitForConditionData;
        }

        public void SetData(JToken jSondata)
        {
            presentCheckbox.Checked = (bool)jSondata["present"]!;
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
