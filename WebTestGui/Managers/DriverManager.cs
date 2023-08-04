namespace WebTestGui
{
    public class DriverManager
    {
        public DriverManager(MainForm mainForm)
        {
            m_Options = new Option();
            m_Actions = new Actions();
            m_MainForm = mainForm;
        }

        public string FormatDataToJson()
        {
            return TestFormatter.ConvertManagerAsJson(this);
        }

        public Browser m_Browser = Browser.chrome;
        public Option m_Options;
        public Actions m_Actions;

        public MainForm m_MainForm;

        public enum Browser
        {
            chrome = 0,
            firefox = 1,
        }
    }
}
