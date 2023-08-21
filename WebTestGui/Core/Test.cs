﻿namespace WebTestGui
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

        public string GetRootLogDirectoryPath()
        {
            foreach (IOption option in m_Options.m_Options)
            {
                if (option is ParentLogPathOption)
                {
                    ParentLogPathOption parentLogPathOption = (ParentLogPathOption)option;
                    return parentLogPathOption.GetRootLogPath();
                }
            }
            return "";
        }

        public void PopulateDefaultOptions()
        {
            object[] optionClassNames = TypeHelpers.GetAllSubClassesFromInterface<IOption>();
            IOption[] optionClasses = new IOption[optionClassNames.Length];
            for (int i = 0; i < optionClassNames.Length; i++)
            {
                Type optionType = TypeHelpers.GetClassFromString(optionClassNames[i].ToString()!);
                IOption option = (IOption)Activator.CreateInstance(optionType)!;
                optionClasses[i] = option;
            }
            m_Options.m_Options.AddRange(optionClasses);

            object[] driverOptionClassNames = TypeHelpers.GetAllSubClassesFromInterface<IDriverOption>();
            IDriverOption[] driverOptionClasses = new IDriverOption[driverOptionClassNames.Length];
            for (int i = 0; i < driverOptionClassNames.Length; i++)
            {
                Type driverOptionType = TypeHelpers.GetClassFromString(driverOptionClassNames[i].ToString()!);
                IDriverOption driverOption = (IDriverOption)Activator.CreateInstance(driverOptionType)!;
                driverOptionClasses[i] = driverOption;
            }
            m_DriverOptions.m_DriverOptions.AddRange(driverOptionClasses);
        }

        public string m_SaveFilePath;

        public string m_Name = "Névtelen";
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
            Break = 4,
            Finished = 5
        }
    }
}
