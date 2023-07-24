using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static WebTestGui.ActionElement;

namespace WebTestGui
{
    public partial class ActionElementEditor : UserControl
    {
        public ActionElementEditor(IAction parent)
        {
            InitializeComponent();

            m_ParentActionElement = new ActionElement(parent);
            actionElementsPanel.Controls.Add(m_ParentActionElement);

            m_Parent = parent;
        }

        public void Refresh(bool needWholePanelRefresh)
        {
            actionElementsPanel.Controls.Clear();

            ActionElement currentElement = m_ParentActionElement;
            Dictionary<string, object> currentStructure = m_ElementData;

            int counter = 0;
            while (currentElement != null)
            {
                actionElementsPanel.Controls.Add(currentElement);
                currentElement.Margin = new Padding(counter * 20, 0, 0, 0);
                currentStructure["type"] = currentElement.GetElementType();
                currentStructure["locator"] = currentElement.GetLocator();
                currentStructure["value"] = currentElement.GetValue();

                currentElement = currentElement.SubElement;
                currentStructure["element"] = new Dictionary<string, object>();
                currentStructure = (Dictionary<string, object>)currentStructure["element"];

                counter++;
            }

            ((UserControl)m_Parent).Size = new Size(((UserControl)m_Parent).Size.Width, 170 + ((counter - 1) * 130));
            Size = new Size(Size.Width, Size.Height + ((counter - 1) * 130));
            if (needWholePanelRefresh)
            {
                m_ParentForm.RefreshActionsPanel();
            }
        }

        public void SetElementsData(JToken data)
        {
            actionElementsPanel.Controls.Clear();

            JToken currentData = data["element"]!;
            ActionElement currentElement = m_ParentActionElement;

            int counter = 0;
            while (currentData.HasValues)
            {
                actionElementsPanel.Controls.Add(currentElement);
                currentElement.Margin = new Padding(counter * 20, 0, 0, 0);
                currentElement.SetElementType(TypeHelpers.EnumTypeFromString<ActionElementType>((string)currentData["type"]!));
                currentElement.SetLocator((string)currentData["locator"]!);
                currentElement.SetValue((string)currentData["value"]!);

                currentData = currentData["element"]!;
                if (currentData.HasValues)
                {
                    currentElement.AddSubElement();
                    currentElement = currentElement.SubElement;
                }
                counter++;
            }

            Refresh(true);
        }

        private void switchToOptionsButton_Click(object sender, EventArgs e)
        {
            if (jSonTextBox.Visible == false)
            {
                Refresh(false);
                jSonTextBox.Visible = true;
                actionElementsPanel.Visible = false;
                switchToOptionsButton.Text = "Elem szerkeztő...";

                jSonTextBox.Text = JsonConvert.SerializeObject(m_ElementData, Formatting.Indented);
                JsonSyntaxHighlighter.HighlightJsonSyntax(jSonTextBox);
            }
            else
            {
                jSonTextBox.Visible = false;
                actionElementsPanel.Visible = true;
                switchToOptionsButton.Text = "JSON nézet...";

                jSonTextBox.Text = "";
            }
        }

        public IAction m_Parent;
        public MainForm m_ParentForm;

        private ActionElement m_ParentActionElement;
        public Dictionary<string, object> m_ElementData = new Dictionary<string, object>();
    }
}
