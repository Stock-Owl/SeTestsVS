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

        public string m_Name;
        public string m_SaveFilePath;

        public List<string> m_Browsers = new List<string>();
        public Options m_Options;
        public DriverOptions m_DriverOptions;

        public Units m_Units;

        public MainForm m_MainForm;

        public TestState m_State;

        public enum TestState
        {
            Load = 0,
            Edit = 1,
            Compile = 2,
            Run = 3,
            Break = 4
        }
    }
}
