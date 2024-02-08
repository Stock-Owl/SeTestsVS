using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class Url_IsWaitForCondition : UserControl, IWaitForCondition
    {
        public Url_IsWaitForCondition()
        {
            InitializeComponent();
        }

        public string m_WaitForConditionType { get { return "url_is"; } }
        public WaitForConditions m_ParentClass { get; set; }

        public Dictionary<string, object> GetJSONFormatted()
        {
            Dictionary<string, object> waitForConditionData = new Dictionary<string, object>();

            waitForConditionData["type"] = m_WaitForConditionType;

            waitForConditionData["url"] = urlTextBox.Text;

            return waitForConditionData;
        }

        public void SetData(JToken jSondata)
        {
            urlTextBox.Text = (string)jSondata["url"]!;
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
