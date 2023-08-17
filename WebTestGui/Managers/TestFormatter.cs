using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public static class TestFormatter
    {
        public static string SaveDriverManagerToJson(Test driverManager)
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

            // Units
            {
                Dictionary<string, object> unitsData = new Dictionary<string, object>();
                foreach (IUnit unit in driverManager.m_Units.m_Units)
                {
                    unitsData[unit.m_UnitName] = unit.GetJSONFormatted();
                }
                jsonData["units"] = unitsData;
            }

            return JsonConvert.SerializeObject(jsonData, Formatting.Indented);
        }

        public static Test LoadDriverManagerFromJson(string rawJson, Test driverManager)
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

            // Units
            {
                // JToken unitsData = jsonObject["units"]!;
                // foreach (JToken unitRawData in unitsData.Children())
                // {
                //     JToken unitData = unitRawData.First!.First!;
                //     string unitName = (string)unitRawData.First!;
                // 
                //     IUnit unit = new UnitPanel();
                //     unit.m_ParentForm = driverManager.m_MainForm;
                //     unit.m_UnitName = unitName;
                //     unit.SetData(unitData);
                //     driverManager.m_Units.m_Units.Add(unit);
                // }
            }

            return driverManager;
        }
    }
}