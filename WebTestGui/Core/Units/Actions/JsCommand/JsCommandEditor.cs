using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class JsCommandEditor : UserControl
    {
        public JsCommandEditor(IAction parent)
        {
            InitializeComponent();

            m_Parent = parent;
        }

        public void AddCommand()
        {
            m_CommandsData.Add(new JsCommand(this));
            m_Parent.Refresh(true);
        }

        public void AddCommand(JsCommand command)
        {
            m_CommandsData.Add(command);
            m_Parent.Refresh(true);
        }

        public void RemoveCommand(JsCommand command)
        {
            m_CommandsData.Remove(command);
            m_Parent.Refresh(true);
        }

        public void MoveCommand(JsCommand actionToMove, int newId)
        {
            int oldId = m_CommandsData.IndexOf(actionToMove);

            if (oldId == newId)
            {
                return;
            }
            if (newId > m_CommandsData.Count)
            {
                return;
            }

            JsCommand element = m_CommandsData[oldId];
            m_CommandsData.RemoveAt(oldId);

            m_CommandsData.Insert(newId, element);
            m_Parent.Refresh(true);
        }

        public void Refresh(bool needWholePanelRefresh)
        {
            jsCommandsPanel.Controls.Clear();

            int counter = 0;
            foreach (JsCommand jsCommand in m_CommandsData)
            {
                jsCommand.SetCommandId(counter);
                jsCommandsPanel.Controls.Add(jsCommand);

                counter++;
            }

            ((UserControl)m_Parent).Size = new Size(((UserControl)m_Parent).Size.Width, 150 + ((counter - 1) * 100));
            Size = new Size(Size.Width, Size.Height + ((counter - 1) * 90));
            if (needWholePanelRefresh)
            {
                m_ParentUnit.Refresh();
            }
        }

        public List<string> GetCommands()
        {
            List<string> commands = new List<string>();

            foreach (JsCommand jsCommand in m_CommandsData)
            {
                commands.Add(jsCommand.GetCommandString());
            }

            return commands;
        }

        public void SetCommands(JToken data)
        {
            List<string> loadedDatas = JsonHelper.ConvertJTokenToListString(data);

            foreach (string loadedData in loadedDatas)
            {
                JsCommand command = new JsCommand(this);
                command.SetCommandString(loadedData);
                AddCommand(command);
            }

            Refresh(true);
        }

        private void switchToOptionsButton_Click(object sender, EventArgs e)
        {
            m_CommandsData.Add(new JsCommand(this));
            m_Parent.Refresh(true);
        }

        public IAction m_Parent;
        public IUnit m_ParentUnit;

        private List<JsCommand> m_CommandsData = new List<JsCommand>();
    }
}
