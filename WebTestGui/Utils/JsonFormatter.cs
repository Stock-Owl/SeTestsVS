using Newtonsoft.Json;
using WebTestGui.Managers;

public static class JsonFormatter
{
    public static string FormatExportManagerToJson(ExportManager exportManager)
    {
        var jsonData = new Dictionary<string, object>();

        // Options
        {
            var optionsData = new Dictionary<string, object>();
            optionsData["page_load_strategy"] = exportManager.m_Options.m_PageLoadStrategy.ToString();
            optionsData["accept_insecure_certs"] = exportManager.m_Options.m_AcceptInsecureCerts.ToString().ToLower();

            var timeoutData = new Dictionary<string, object>();
            timeoutData["type"] = exportManager.m_Options.m_Timeout.m_Type.ToString().ToLower();
            timeoutData["value"] = exportManager.m_Options.m_Timeout.m_ValueInMiliseconds.ToString();
            optionsData["timeout"] = timeoutData;

            optionsData["unhandled_prompt_behavior"] = exportManager.m_Options.m_unhandledPromptBehaviour.ToString();
            optionsData["keep_browser_open"] = exportManager.m_Options.m_KeepBrowserOpen.ToString().ToLower();
            optionsData["args"] = exportManager.m_Options.m_Args;

            optionsData["service_log_path"] = exportManager.m_Options.m_ServiceLogPath;
            optionsData["service_args"] = exportManager.m_Options.m_ServiceArgs;

            jsonData["options"] = optionsData;
        }

        // Actions
        {
            var actionsData = new Dictionary<string, object>();
            if (exportManager.m_Actions.m_Goto != null)
            {
                var gotoData = new Dictionary<string, object>();
                gotoData["url"] = exportManager.m_Actions.m_Goto.Value;
                actionsData["goto"] = gotoData;
            }
            jsonData["actions"] = actionsData;
        }

        return JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented);
    }
}
