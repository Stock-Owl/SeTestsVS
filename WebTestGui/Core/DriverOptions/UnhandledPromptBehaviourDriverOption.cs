using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class UnhandledPromptBehaviourDriverOption : UserControl, IDriverOption
    {
        public UnhandledPromptBehaviourDriverOption()
        {
            InitializeComponent();

            m_DriverOptionName = "unhandled_prompt_behavior";
        }

        // INTERFACE FUNCTIONS AND MEMBERS

        public object GetData()
        {
            return mainComboBox.Text;
        }

        public void SetData(JToken jSondata)
        {
            mainComboBox.Text = (string)jSondata!;
        }

        public string m_DriverOptionName { get; set; }
        public MainForm m_ParentForm { get; set; }
    }
}
