namespace WebTestGui
{
    public class DriverStorage
    {
        public DriverStorage(MainForm mainForm)
        {
            m_Options = new Options();
            m_DriverOptions = new DriverOptions();

            m_Actions = new Actions();
            m_MainForm = mainForm;
        }

        public List<string> m_Browsers = new List<string>();
        public Options m_Options;
        public DriverOptions m_DriverOptions;

        public Actions m_Actions;

        public MainForm m_MainForm;
    }
}
