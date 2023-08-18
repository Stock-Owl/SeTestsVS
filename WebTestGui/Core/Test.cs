using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace WebTestGui
{
    public class Test
    {
        public Test(MainForm mainForm)
        {
            m_Options = new Options();
            object[] optionClassNames = TypeHelpers.GetAllSubClassesFromInterface<IOption>();
            IOption[] optionClasses = new IOption[optionClassNames.Length];
            for (int i = 0; i < optionClassNames.Length; i++)
            {
                Type optionType = TypeHelpers.GetClassFromString(optionClassNames[i].ToString()!);
                IOption option = (IOption)Activator.CreateInstance(optionType)!;
                optionClasses[i] = option;
            }
            m_Options.m_Options.AddRange(optionClasses);

            m_DriverOptions = new DriverOptions();
            object[] driverOptionClassNames = TypeHelpers.GetAllSubClassesFromInterface<IDriverOption>();
            IDriverOption[] driverOptionClasses = new IDriverOption[driverOptionClassNames.Length];
            for (int i = 0; i < driverOptionClassNames.Length; i++)
            {
                Type driverOptionType = TypeHelpers.GetClassFromString(driverOptionClassNames[i].ToString()!);
                IDriverOption driverOption = (IDriverOption)Activator.CreateInstance(driverOptionType)!;
                driverOptionClasses[i] = driverOption;
            }
            m_DriverOptions.m_DriverOptions.AddRange(driverOptionClasses);

            m_Units = new Units();
            m_MainForm = mainForm;
        }

        public string m_Name = "Untitled";
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
