using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public static class JsonHelper
    {
        public static List<string> ConvertJTokenToListString(JToken jToken)
        {
            List<string> stringList = new List<string>();

            if (jToken.Type == JTokenType.Array)
            {
                foreach (JToken item in jToken)
                {
                    stringList.Add(item.ToString());
                }
            }
            else if (jToken.Type == JTokenType.String)
            {
                stringList.Add(jToken.ToString());
            }

            return stringList;
        }
    }
}
