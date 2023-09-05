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

            UnitPanel sampleUnit = new UnitPanel();
            if (m_MainForm != null)
            {
                sampleUnit.m_ParentForm = m_MainForm;
            }
            sampleUnit.SetUId(m_Units.m_Units.Count);
            sampleUnit.m_UnitName = $"Példa Unit";
            sampleUnit.Refresh();

            GotoAction sampleGotoAction = new GotoAction();
            sampleGotoAction.m_ParentUnit = sampleUnit;
            sampleGotoAction.SetId(sampleUnit.m_Actions.m_Actions.Count);
            sampleGotoAction.SetGotoUrl("https://www.visionsoft.hu/");
            sampleUnit.m_Actions.m_Actions.Add(sampleGotoAction);

            m_Units.m_Units.Add(sampleUnit);
        }

        public bool HaveInterceptorActions()
        {
            bool haveInterceptorActions = false;
            foreach (IUnit unit in m_Units.m_Units)
            {
                foreach (IAction action in unit.m_Actions.m_Actions)
                {
                    if (action is InterceptorAddAction || action is InterceptorRemoveAction ||
                        action is InterceptorOnAction || action is InterceptorOffAction)
                    {
                        haveInterceptorActions = true;
                    }
                }
            }
            return haveInterceptorActions;
        }

        public string m_SaveFilePath;

        public string m_Name = "Névtelen";
        public List<string> m_Browsers = new List<string>();
        public Options m_Options;
        public DriverOptions m_DriverOptions;

        public string m_FullTestRunTime = "Előző tesztelés teljes futási ideje: 0 / 0 ms";

        public Units m_Units;

        public MainForm m_MainForm;

        public TestState m_State = TestState.Edit;

        public enum TestState
        {
            Edit = 0,
            Run = 1,
            Break = 2,
        }
    }
}
