using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public static class TestFormatter
    {
        public static string ConvertManagerAsJson(DriverManager driverManager)
        {
            Dictionary<string, object> jsonData = new Dictionary<string, object>();

            // Browser
            jsonData["browser"] = driverManager.m_Browser.ToString();

            // Options
            {
                Dictionary<string, object> optionsData = new Dictionary<string, object>();

                Dictionary<string, object> logJsData = new Dictionary<string, object>();
                logJsData["active"] = driverManager.m_Options.m_LogJs.m_Active;
                logJsData["path"] = Option.LogJS.m_Path;
                logJsData["refresh_rate"] = Option.LogJS.m_RefreshRate;
                logJsData["retry_timeout"] = Option.LogJS.m_RetryTimeout;
                optionsData["log_JS"] = logJsData;

                jsonData["options"] = optionsData;
            }

            // Driver Options
            {
                Dictionary<string, object> driverOptionsData = new Dictionary<string, object>();

                Dictionary<string, object> driverOptionsOptionsData = new Dictionary<string, object>();

                driverOptionsOptionsData["page_load_strategy"] = driverManager.m_Options.m_PageLoadStrategy.ToString();
                driverOptionsOptionsData["accept_insecure_certs"] = driverManager.m_Options.m_AcceptInsecureCerts.ToString().ToLower();

                Dictionary<string, object> timeoutData = new Dictionary<string, object>();
                timeoutData["type"] = driverManager.m_Options.m_Timeout.m_Type.ToString();
                timeoutData["value"] = driverManager.m_Options.m_Timeout.m_ValueInMiliseconds.ToString();
                driverOptionsOptionsData["timeout"] = timeoutData;

                driverOptionsOptionsData["unhandled_prompt_behavior"] = driverManager.m_Options.m_unhandledPromptBehaviour.ToString();
                driverOptionsOptionsData["keep_browser_open"] = driverManager.m_Options.m_KeepBrowserOpen.ToString().ToLower();
                driverOptionsOptionsData["browser_arguments"] = driverManager.m_Options.m_BrowserArgs;

                driverOptionsData["options"] = driverOptionsOptionsData;

                Dictionary<string, object> driverOptionsServiceData = new Dictionary<string, object>();

                driverOptionsServiceData["service_log_path"] = driverManager.m_Options.m_ServiceLogPath!;
                driverOptionsServiceData["service_arguments"] = driverManager.m_Options.m_ServiceArgs;

                driverOptionsData["service"] = driverOptionsServiceData;

                jsonData["driver-options"] = driverOptionsData;
            }

            // Actions
            {
                Dictionary<string, object> actionsData = new Dictionary<string, object>();
                foreach (IAction action in driverManager.m_Actions.m_Actions)
                {
                    actionsData[action.GetId().ToString()] = action.GetJSONFormatted();
                }
                jsonData["actions"] = actionsData;
            }

            return JsonConvert.SerializeObject(jsonData, Formatting.Indented);
        }

        public static DriverManager ConvertManagerFromJson(string rawJson, DriverManager driverManager)
        {
            JObject jsonObject = JObject.Parse(rawJson);

            // Browser
            driverManager.m_Browser = TypeHelpers.EnumTypeFromString<DriverManager.Browser>((string)jsonObject["browser"]!);

            // Options
            {
                JToken optionsData = jsonObject["options"]!;
                JToken logJsData = optionsData["log_JS"]!;

                driverManager.m_Options.m_LogJs.m_Active = (bool)logJsData["active"]!;
            }

            // Driver Options
            {
                JToken driverOptionsData = jsonObject["driver-options"]!;
                JToken driverOptionsOptionsData = driverOptionsData["options"]!;
                driverManager.m_Options.m_PageLoadStrategy = TypeHelpers.EnumTypeFromString<Option.PageLoadStrategies>((string)driverOptionsOptionsData["page_load_strategy"]!);
                driverManager.m_Options.m_AcceptInsecureCerts = (bool)driverOptionsOptionsData["accept_insecure_certs"]!;

                JToken timeoutData = driverOptionsOptionsData["timeout"]!;
                driverManager.m_Options.m_Timeout.m_Type = TypeHelpers.EnumTypeFromString<Option.Timeout.TimeoutType>((string)timeoutData["type"]!);
                driverManager.m_Options.m_Timeout.m_ValueInMiliseconds = (int)timeoutData["value"]!;

                driverManager.m_Options.m_unhandledPromptBehaviour = TypeHelpers.EnumTypeFromString<Option.UnhandledPromptBehaviours>((string)driverOptionsOptionsData["unhandled_prompt_behavior"]!);
                driverManager.m_Options.m_KeepBrowserOpen = (bool)driverOptionsOptionsData["keep_browser_open"]!;
                driverManager.m_Options.m_BrowserArgs = JsonHelper.ConvertJTokenToListString(driverOptionsOptionsData["browser_arguments"]!);

                JToken driverOptionsServiceData = driverOptionsData["service"]!;

                driverManager.m_Options.m_ServiceLogPath = (string)driverOptionsServiceData["service_log_path"]!;
                driverManager.m_Options.m_ServiceArgs = JsonHelper.ConvertJTokenToListString(driverOptionsServiceData["service_arguments"]!);
            }

            // Actions
            {
                JToken actionsData = jsonObject["actions"]!;
                foreach (JToken actionRawData in actionsData.Children())
                {
                    JToken actionData = actionRawData.First!;
                    string actionType = (string)actionRawData.First!.First!;

                    IAction action = Actions.CreateActionByType(actionType);
                    action.m_ParentForm = driverManager.m_MainForm;
                    action.SetData(actionData);
                    driverManager.m_Actions.m_Actions.Add(action);
                }
            }

            return driverManager;
        }
    }
}