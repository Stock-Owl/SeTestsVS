namespace WebTestGui
{
    public class Option
    {
        public Option()
        {
            m_Timeout = new Timeout();
            m_LogJs = new LogJS();
        }

        public PageLoadStrategies m_PageLoadStrategy;
        public bool m_AcceptInsecureCerts;
        public Timeout m_Timeout;
        public UnhandledPromptBehaviours m_unhandledPromptBehaviour;
        public bool m_KeepBrowserOpen;
        public List<string> m_BrowserArgs = new List<string>();

        public LogJS m_LogJs;

        public string? m_ServiceLogPath;
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

        public class LogJS
        {
            public bool m_Active;
            public const string m_Path = "./JS.log";
            public const int m_RefreshRate = 1000;
            public const int m_RetryTimeout = 1000;
        }
    }
}
