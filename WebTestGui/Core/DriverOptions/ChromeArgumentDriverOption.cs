using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class ChromeArgumentDriverOption : UserControl, IDriverOption
    {
        public ChromeArgumentDriverOption()
        {
            InitializeComponent();

            m_DriverOptionName = "chrome_arguments";
        }

        // INTERFACE FUNCTIONS AND MEMBERS

        public object GetData()
        {
            return paramTextBox.Text.Split(" ");
        }

        public void SetData(JToken jSondata)
        {
            if (jSondata is JArray jArray)
            {
                paramTextBox.Text = string.Join(" ", jArray.Select(item => item.ToString()));
            }
            else
            {
                paramTextBox.Text = string.Empty;
            }
        }

        public string m_DriverOptionName { get; set; }
        public MainForm m_ParentForm { get; set; }
    }
}
