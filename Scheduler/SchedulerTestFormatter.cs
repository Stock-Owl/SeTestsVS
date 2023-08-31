using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Scheduler
{
    static class SchedulerTestFormatter
    {
        public static string SaveSchedulerTestToJson(List<SchedulerItem> schedulerTests)
        {
            Dictionary<string, object> jsonData = new Dictionary<string, object>();

            // Items
            {
                int counter = 0;
                foreach (SchedulerItem item in schedulerTests)
                {
                    jsonData[counter.ToString()] = item.GetData();
                    counter++;
                }
            }

            return JsonConvert.SerializeObject(jsonData, Formatting.Indented);
        }

        public static List<SchedulerItem> LoadSchedulerTestFromJson(string rawJson, Scheduler itemsParent)
        {
            JObject jsonObject = JObject.Parse(rawJson);

            List<SchedulerItem> schedulerItems = new List<SchedulerItem>();

            // Options
            {
                JObject optionObject = JObject.Parse(jsonObject.ToString());
                foreach (JProperty optionProperty in optionObject.Properties())
                {
                    JToken value = optionProperty.Value;

                    SchedulerItem item = new SchedulerItem(itemsParent);
                    item.SetData(value);
                    schedulerItems.Add(item);
                }
            }

            return schedulerItems;
        }
    }
}
