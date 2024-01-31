using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public class WaitForConditions
    {
        public WaitForConditions(WaitForAction action)
        {
            m_ParentAction = action;
        }

        public List<IWaitForCondition> m_WaitForConditions = new List<IWaitForCondition>();

        public static IWaitForCondition CreateWaitForConditionByType(string waitForConditionType)
        {
            var waitForConditionTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IWaitForCondition).IsAssignableFrom(p) && !p.IsInterface);

            Type matchingType = waitForConditionTypes.FirstOrDefault(t =>
            {
                var instance = (IWaitForCondition)Activator.CreateInstance(t)!;
                return instance.m_WaitForConditionType == waitForConditionType;
            })!;

            if (matchingType != null)
            {
                return (IWaitForCondition)Activator.CreateInstance(matchingType)!;
            }

            return null!;
        }

        public List<Dictionary<string, object>> GetWaitForConditionsJSON()
        {
            List<Dictionary<string, object>> waitForConditionData = new List<Dictionary<string, object>>();
            foreach (IWaitForCondition waitForCondition in m_WaitForConditions)
            {
                waitForConditionData.Add(waitForCondition.GetJSONFormatted());
            }
            return waitForConditionData;
        }

        public void SetData(JToken jSondata)
        {
            foreach (JToken data in jSondata)
            {
                string waitForConditionType = (string)data["type"]!;
                IWaitForCondition waitForCondition = CreateWaitForConditionByType(waitForConditionType);
                waitForCondition.m_ParentClass = this;
                waitForCondition.SetData(data);
                m_WaitForConditions.Add(waitForCondition);
            }
        }

        public void DeleteWaitForCondition(IWaitForCondition waitForCondition)
        {
            m_WaitForConditions.Remove(waitForCondition);
            m_ParentAction.RefreshConditionListPanel();
        }

        public WaitForAction m_ParentAction;
    }

    public interface IWaitForCondition
    {
        public Dictionary<string, object> GetJSONFormatted();
        public void SetData(JToken jSondata);

        public void Delete(IWaitForCondition self);

        public string m_WaitForConditionType { get; }
        public WaitForConditions m_ParentClass { get; set; }
    }
}
