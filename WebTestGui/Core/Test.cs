namespace WebTestGui
{
    public class Test
    {
        public Test(MainForm mainForm)
        {
            m_Options = new Options();
            m_DriverOptions = new DriverOptions();

            m_Units = new Units();
            m_MainForm = mainForm;
        }

        public List<string> m_Browsers = new List<string>();
        public Options m_Options;
        public DriverOptions m_DriverOptions;

        public Units m_Units;

        public MainForm m_MainForm;
    }
}
