using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public static class TestFormatter
    {
        public static string SaveDriverManagerToJson(Test test)
        {
            Dictionary<string, object> jsonData = new Dictionary<string, object>();

            // Browser
            jsonData["browser"] = test.m_Browsers;

            // Options
            {
                Dictionary<string, object> optionsData = new Dictionary<string, object>();
                foreach (IOption option in test.m_Options.m_Options)
                {
                    optionsData[option.m_OptionName] = option.GetData();
                }
                jsonData["options"] = optionsData;
            }

            // Driver Options
            {
                Dictionary<string, object> driverOptionsData = new Dictionary<string, object>();
                foreach (IDriverOption driverOption in test.m_DriverOptions.m_DriverOptions)
                {
                    driverOptionsData[driverOption.m_DriverOptionName] = driverOption.GetData();
                }
                jsonData["driver_options"] = driverOptionsData;
            }

            // Units
            {
                Dictionary<string, object> unitsData = new Dictionary<string, object>();
                foreach (IUnit unit in test.m_Units.m_Units)
                {
                    unitsData[unit.m_UnitName] = unit.GetJSONFormatted();
                }
                jsonData["units"] = unitsData;
            }

            return JsonConvert.SerializeObject(jsonData, Formatting.Indented);
        }

        public static Test LoadDriverManagerFromJson(string rawJson, Test test)
        {
            JObject jsonObject = JObject.Parse(rawJson);

            // Browser
            test.m_Browsers = JsonHelper.ConvertJTokenToListString(jsonObject["browser"]!);
            
            // Options
            {
                JToken optionsData = jsonObject["options"]!;
                JObject optionObject = JObject.Parse(optionsData.ToString());
                foreach (JProperty optionProperty in optionObject.Properties())
                {
                    string key = optionProperty.Name;
                    JToken value = optionProperty.Value;

                    IOption option = Options.CreateOptionByType(key);
                    option.m_ParentForm = test.m_MainForm;
                    option.SetData(value);
                    test.m_Options.m_Options.Add(option);
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
                    driverOption.m_ParentForm = test.m_MainForm;
                    driverOption.SetData(value);
                    test.m_DriverOptions.m_DriverOptions.Add(driverOption);
                }
            }

            // Units
            {
                JToken unitsData = jsonObject["units"]!;
                JObject unitsObject = JObject.Parse(unitsData.ToString());
                foreach (JProperty unitProperty in unitsObject.Properties())
                {
                    string key = unitProperty.Name;
                    JToken value = unitProperty.Value;

                    IUnit unit = new UnitPanel();
                    unit.m_ParentForm = test.m_MainForm;
                    unit.m_UnitName = key;
                    unit.SetData(value);
                    test.m_Units.m_Units.Add(unit);
                }

                // Must happen after all the Units have loaded, because of the refernces
                foreach (IUnit unit in test.m_Units.m_Units)
                {
                    unit.SetUnitBindings();
                    unit.SetUnitBackupOf();
                }
            }

            return test;
        }
    }
}