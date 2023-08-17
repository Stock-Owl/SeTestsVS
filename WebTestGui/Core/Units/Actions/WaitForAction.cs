using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class WaitForAction : UserControl, IAction
    {
        public WaitForAction()
        {
            InitializeComponent();
            mainPanel.Paint += OnBorderLineDraw!;
            idTextBox.KeyPress += OnIdOverride!;

            mainLabel.Text = "Wait-For";
            actionTypeLabel.Text = "action:" + m_ActionType;

            conditionComboBox.Items.AddRange(TypeHelpers.GetEnumTypes<WaitForCondition>());
        }

        // ACTION INTERFACE FUNCTIONS AND MEMBERS

        public void SetId(int id)
        {
            idTextBox.Text = id.ToString();
        }

        public int GetId()
        {
            return int.Parse(idTextBox.Text);
        }

        public void OnIdOverride(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (int.TryParse(idTextBox.Text, out int _))
                {
                    int newId = int.Parse(idTextBox.Text);
                    m_ParentUnit.MoveAction(this, newId);
                }
            }
        }

        private void OnUIdTextBoxFocusLeave(object sender, EventArgs e)
        {
            if (int.TryParse(idTextBox.Text, out int _))
            {
                int newId = int.Parse(idTextBox.Text);
                m_ParentUnit.MoveAction(this, newId);
            }
        }

        public void Delete()
        {
            m_ParentUnit.DeleteAction(this);
        }

        public void Refresh(bool needWholePanelRefresh)
        {
        }

        public void OnBorderLineDraw(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.DarkGray, 2);
                var point1 = new Point(0, 0);
                var point2 = new Point(Size.Width, 0);
                g.DrawLine(p, point1, point2);
            }
        }

        public Dictionary<string, object> GetJSONFormatted()
        {
            Refresh(true);
            Dictionary<string, object> clickData = new Dictionary<string, object>();
            clickData["type"] = m_ActionType;
            clickData["break"] = m_HaveBreakpoint;

            clickData["condition"] = conditionComboBox.Text;
            clickData["frequency"] = string.IsNullOrEmpty(frequencyTextField.Text) == true ? "0" : frequencyTextField.Text;
            clickData["timeout"] = string.IsNullOrEmpty(timeOutTextBox.Text) == true ? "0" : timeOutTextBox.Text;
            clickData["single"] = singleCheckbox.Checked;

            clickData["displayed"] = displayedCheckbox.Checked;
            clickData["enabled"] = enabledCheckBox.Checked;
            clickData["selected"] = selectedCheckBox.Checked;

            clickData["locator"] = locatorTextBox.Text;
            clickData["value"] = valueTextBox.Text;
            return clickData;
        }

        public void SetData(JToken data)
        {
            m_HaveBreakpoint = (bool)data["break"]!;
            if (m_HaveBreakpoint)
            {
                SetBreakpoint(true);
            }
            else
            {
                SetBreakpoint(false);
            }

            conditionComboBox.Text = (string)data["condition"]!;
            frequencyTextField.Text = (string)data["frequency"]!;
            timeOutTextBox.Text = (string)data["timeout"]!;
            singleCheckbox.Checked = (bool)data["single"]!;

            displayedCheckbox.Checked = (bool)data["displayed"]!;
            enabledCheckBox.Checked = (bool)data["enabled"]!;
            selectedCheckBox.Checked = (bool)data["selected"]!;

            singleCheckbox.Checked = (bool)data["single"]!;

            locatorTextBox.Text = (string)data["locator"]!;
            valueTextBox.Text = (string)data["value"]!;
        }

        public string m_ActionType { get { return "wait_for"; } }
        public IUnit m_ParentUnit { get; set; }
        public bool m_HaveBreakpoint { get; set; }

        public bool m_Single = false;

        // ACTION SPECIFIC FUNCTIONS

        private void breakpointOnPicture_Click(object sender, EventArgs e)
        {
            SetBreakpoint(false);
        }

        private void breakpointOffPicture_Click(object sender, EventArgs e)
        {
            SetBreakpoint(true);
        }

        private void SetBreakpoint(bool active)
        {
            breakpointOnPicture.Visible = active;
            breakpointOffPicture.Visible = !active;
            m_HaveBreakpoint = active;
        }

        private void singleCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (singleCheckbox.Checked)
            {
                singleLabel.Text = "Elemek";
            }
            else
            {
                singleLabel.Text = "Elem";
            }
        }

        private void binImage_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void WaitForAction_SizeChanged(object sender, EventArgs e)
        {
            if (Size.Height < 250)
            {
                Size = new Size(Size.Width, 250);
            }
        }

        public enum WaitForCondition
        {
            loaded = 0,
            alert = 1,
            visible = 2,
            contains = 3,
            Is = 4,
            stale = 5,
            readable = 6
        }
    }
}

