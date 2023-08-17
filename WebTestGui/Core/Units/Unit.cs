using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public class Units
    {
        public List<IUnit> m_Units = new List<IUnit>();

        public void MoveUnit(IUnit unitToMove, int newId)
        {
            // Use try catch, because initially, when the action is loaded to the MainForm's panel, the id is being
            // overriden on load, and that point in time the action is not yet inside the m_Actions list, so it would
            // throw an OutOfRangeException
            try
            {
                int oldId = m_Units.IndexOf(unitToMove);

                if (oldId == newId)
                {
                    return;
                }
                if (newId > m_Units.Count)
                {
                    return;
                }

                IUnit element = m_Units[oldId];
                m_Units.RemoveAt(oldId);

                m_Units.Insert(newId, element);
            }
            catch
            {
                // Do nothing...
            }
        }
    }

    public interface IUnit
    {
        public void SetUId(int uid);
        public int GetUId();
        public void OnUIdOverride(object sender, KeyPressEventArgs e);

        public void Delete(object sender, EventArgs e);

        public void DeleteAction(IAction action);
        public void MoveAction(IAction action, int newId);

        public void Refresh();

        public void OnBorderLineDraw(object sender, PaintEventArgs e);

        public Dictionary<string, object> GetJSONFormatted();
        public void SetData(JToken jSondata);

        public void SetUnitBindings();
        public void SetUnitBackupOf();

        public string m_UnitName { get; set; }
        public MainForm m_ParentForm { get; set; }

        public IUnit m_Bindings { get; set; }
        public IUnit m_BackupOf { get; set; }

        public Actions m_Actions { get; set; }
    }
}
