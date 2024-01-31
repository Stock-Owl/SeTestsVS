using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public static class TestFormatter
    {
        public static string SaveTestToJson(Test test)
        {
            Dictionary<string, object> jsonData = new Dictionary<string, object>();

            // Interceptor check
            jsonData["interceptor"] = test.HaveInterceptorActions();
            
            // Name
            jsonData["name"] = test.m_Name;

            // Browsers
            jsonData["browsers"] = new List<string>() { "chrome", "firefox" };

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

        public static Test LoadTestFromJson(string rawJson, Test test)
        {
            JObject jsonObject = JObject.Parse(rawJson);

            // Name
            test.m_Name = (string)jsonObject["name"]!;

            // Browsers
            //test.m_Browsers = JsonHelper.ConvertJTokenToListString(jsonObject["browsers"]!);
            
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

                // Must happen after all the Units have loaded, because of the references
                foreach (IUnit unit in test.m_Units.m_Units)
                {
                    unit.SetUnitBindings();
                    unit.SetUnitBackupOf();
                }
            }

            return test;
        }

        public static string SaveOptionsFromTest(Test test)
        {
            Dictionary<string, object> jsonData = new Dictionary<string, object>();

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

            return JsonConvert.SerializeObject(jsonData, Formatting.Indented);
        }

        public static void LoadOptionsToTest(string rawOptionsJson, Test test)
        {
            test.m_Options.m_Options.Clear();
            test.m_DriverOptions.m_DriverOptions.Clear();
            JObject jsonObject = JObject.Parse(rawOptionsJson);

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
        }
    }
}