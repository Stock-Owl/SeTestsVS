using Newtonsoft.Json;

namespace WebTestGui
{
    public partial class ActionElement : UserControl
    {
        public ActionElement(IAction parentAction)
        {
            InitializeComponent();

            m_ParentAction = parentAction;
            typeComboBox.Items.AddRange(TypeHelpers.GetEnumTypes<ActionElementType>()!);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        private void addSubElementButton_Click(object sender, EventArgs e)
        {
            AddSubElement();
        }

        public void AddSubElement()
        {
            SubElement = new ActionElement(m_ParentAction);
            m_ParentAction.Refresh(true);

            addSubElementButton.Visible = false;
            deleteSubElementButton.Visible = true;
        }

        private void deleteSubElementButton_Click(object sender, EventArgs e)
        {
            DeleteSubElement();
            m_ParentAction.Refresh(true);

            addSubElementButton.Visible = true;
            deleteSubElementButton.Visible = false;
        }

        public void DeleteSubElement()
        {
            if (SubElement != null)
            {
                SubElement.DeleteSubElement();
                SubElement = null;
            }
        }

        public string GetLocator()
        {
            return locatorTextBox.Text;
        }

        public string GetValue()
        {
            return valueTextBox.Text;
        }

        public void SetLocator(string text)
        {
            locatorTextBox.Text = text;
        }

        public void SetValue(string text)
        {
            valueTextBox.Text = text;
        }

        public void SetElementType(ActionElementType type)
        {
            typeComboBox.Text = type.ToString();
        }

        public string GetElementType()
        {
            return typeComboBox.Text;
        }

        public ActionElement SubElement = null;

        protected IAction m_ParentAction;

        public enum ActionElementType
        {
            element = 0,
            iframe = 1
        }
    }
}
