using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public static class TestFormatter
    {
        public static string SaveDriverManagerToJson(DriverStorage driverManager)
        {
            Dictionary<string, object> jsonData = new Dictionary<string, object>();

            // Browser
            jsonData["browser"] = driverManager.m_Browsers;

            // Options
            {
                Dictionary<string, object> optionsData = new Dictionary<string, object>();
                foreach (IOption option in driverManager.m_Options.m_Options)
                {
                    optionsData[option.m_OptionName] = option.GetData();
                }
                jsonData["options"] = optionsData;
            }

            // Driver Options
            {
                Dictionary<string, object> driverOptionsData = new Dictionary<string, object>();
                foreach (IDriverOption driverOption in driverManager.m_DriverOptions.m_DriverOptions)
                {
                    driverOptionsData[driverOption.m_DriverOptionName] = driverOption.GetData();
                }
                jsonData["driver_options"] = driverOptionsData;
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

        public static DriverStorage LoadDriverManagerFromJson(string rawJson, DriverStorage driverManager)
        {
            JObject jsonObject = JObject.Parse(rawJson);

            // Browser
            driverManager.m_Browsers = JsonHelper.ConvertJTokenToListString(jsonObject["browser"]!);
            
            // Options
            {
                JToken optionsData = jsonObject["options"]!;
                JObject optionObject = JObject.Parse(optionsData.ToString());
                foreach (JProperty optionProperty in optionObject.Properties())
                {
                    string key = optionProperty.Name;
                    JToken value = optionProperty.Value;

                    IOption option = Options.CreateOptionByType(key);
                    option.m_ParentForm = driverManager.m_MainForm;
                    option.SetData(value);
                    driverManager.m_Options.m_Options.Add(option);
                }
            }

            // Driver Options
            {
                JToken driverOptionsData = jsonObject["driver_options"]!;
                JObject driverOptionObject = JObject.Parse(driverOptionsData.ToString());
                foreach (JProperty driverOptionProperty in driverOptionObject.Properties())
                {
                    string key = driverOptionProperty.Name;
                    JToken value = driverOptionProperty.Value;

                    IDriverOption driverOption = DriverOptions.CreateDriverOptionByType(key);
                    driverOption.m_ParentForm = driverManager.m_MainForm;
                    driverOption.SetData(value);
                    driverManager.m_DriverOptions.m_DriverOptions.Add(driverOption);
                }
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