namespace WebTestGui.Managers
{
    public class ExportManager
    {
        public ExportManager()
        {
            m_Options = new Options();
            m_Actions = new Actions();
        }

        public string FormatDataToJson()
        {
            return JsonFormatter.FormatExportManagerToJson(this);
        }

        public Options m_Options;
        public Actions m_Actions;

        public class Options
        {
            public Options()
            {
                m_Timeout = new Timeout();
            }

            public PageLoadStrategies m_PageLoadStrategy;
            public bool m_AcceptInsecureCerts;
            public Timeout m_Timeout;
            public UnhandledPromptBehaviours m_unhandledPromptBehaviour;
            public bool m_KeepBrowserOpen;
            public List<string> m_Args = new List<string>();

            public string m_ServiceLogPath;
            public List<string> m_ServiceArgs = new List<string>();

            public enum PageLoadStrategies
            {
                normal = 0,
                eager = 1,
                none = 2
            }

            public class Timeout
            {
                public int m_ValueInMiliseconds;
                public TimeoutType m_Type;

                public enum TimeoutType
                {
                    pageLoad = 0,
                    script = 1,
                    Implicit = 2 // Cannot use lowercase impilict word, because its a keyword...
                }
            }

            public enum UnhandledPromptBehaviours
            {
                dismiss = 0,
                accept = 1,
                dismissAndNotify = 2,
                acceptAndNotify = 3,
                ignore = 4
            }
        }

        public class Actions
        {
            public ActionKeyValuePair? m_Goto;
             
            public class ActionKeyValuePair
            {
                public string? Key;
                public string? Value;
            }
        }
    }
}
