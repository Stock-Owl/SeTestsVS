using Newtonsoft.Json;
using WebTestGui.Managers;

public static class JsonFormatter
{
    public static string FormatExportManagerToJson(DriverManager driverManager)
    {
        var jsonData = new Dictionary<string, object>();

        // Options
        {
            var optionsData = new Dictionary<string, object>();
            optionsData["page_load_strategy"] = driverManager.m_Options.m_PageLoadStrategy.ToString();
            optionsData["accept_insecure_certs"] = driverManager.m_Options.m_AcceptInsecureCerts.ToString().ToLower();

            var timeoutData = new Dictionary<string, object>();
            timeoutData["type"] = driverManager.m_Options.m_Timeout.m_Type.ToString().ToLower();
            timeoutData["value"] = driverManager.m_Options.m_Timeout.m_ValueInMiliseconds.ToString();
            optionsData["timeout"] = timeoutData;

            optionsData["unhandled_prompt_behavior"] = driverManager.m_Options.m_unhandledPromptBehaviour.ToString();
            optionsData["keep_browser_open"] = driverManager.m_Options.m_KeepBrowserOpen.ToString().ToLower();
            optionsData["browser_args"] = driverManager.m_Options.m_BrowserArgs;

            var logJsData = new Dictionary<string, object>();
            logJsData["active"] = driverManager.m_Options.m_LogJs.m_Active;
            logJsData["path"] = DriverManager.Options.LogJS.m_Path;
            logJsData["refresh_rate"] = DriverManager.Options.LogJS.m_RefreshRate;
            logJsData["retry_timeout"] = DriverManager.Options.LogJS.m_RetryTimeout;
            optionsData["log_JS"] = logJsData;

            optionsData["service_log_path"] = driverManager.m_Options.m_ServiceLogPath!;
            optionsData["service_args"] = driverManager.m_Options.m_ServiceArgs;

            jsonData["options"] = optionsData;
        }

        // Actions
        //{
        //    var actionsData = new Dictionary<string, object>();
        //    if (driverManager.m_Actions.m_Goto != null)
        //    {
        //        var gotoData = new Dictionary<string, object>();
        //        gotoData["url"] = driverManager.m_Actions.m_Goto.Value!;
        //        actionsData["goto"] = gotoData;
        //    }
        //    jsonData["actions"] = actionsData;
        //}

        return JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented);
    }
}
