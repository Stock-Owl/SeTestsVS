using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class PageLoadStrategyDriverOption : UserControl, IDriverOption
    {
        public PageLoadStrategyDriverOption()
        {
            InitializeComponent();

            m_DriverOptionName = "page_load_strategy";
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

        public void Enable(bool enabled)
        {
            Enabled = enabled;
        }

        public string m_DriverOptionName { get; set; }
        public MainForm m_ParentForm { get; set; }
    }
}
