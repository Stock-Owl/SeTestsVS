using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public class Actions
    {
        public List<IAction> m_Actions = new List<IAction>();

        public static IAction CreateActionByType(string actionType)
        {
            var actionTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IAction).IsAssignableFrom(p) && !p.IsInterface);

            Type matchingType = actionTypes.FirstOrDefault(t =>
            {
                var instance = (IAction)Activator.CreateInstance(t)!;
                return instance.m_ActionType == actionType;
            })!;

            if (matchingType != null)
            {
                return (IAction)Activator.CreateInstance(matchingType)!;
            }

            return null!;
        }

        public void MoveElement(IAction actionToMove, int newId)
        {
            // Use try catch, because initially, when the action is loaded to the MainForm's panel, the id is being
            // overriden on load, and that point in time the action is not yet inside the m_Actions list, so it would
            // throw an OutOfRangeException
            try
            {
                int oldId = m_Actions.IndexOf(actionToMove);

                if (oldId == newId)
                {
                    return;
                }
                if (newId > m_Actions.Count)
                {
                    return;
                }

                IAction element = m_Actions[oldId];
                m_Actions.RemoveAt(oldId);

                m_Actions.Insert(newId, element);
            }
            catch
            {
                // Do nothing...
            }
        }
    }

    public interface IAction
    {
        public void SetId(int id);
        public int GetId();
        public void OnIdOverride(object sender, KeyPressEventArgs e);

        public void Delete();

        public void Refresh(bool needWholePanelRefresh);

        public void OnBorderLineDraw(object sender, PaintEventArgs e);

        public Dictionary<string, object> GetJSONFormatted();
        public void SetData(JToken jSondata);


        public string m_ActionType { get; }
        public MainForm m_ParentForm { get; set; }
        public bool m_HaveBreakpoint { get; set; }
    }
}
