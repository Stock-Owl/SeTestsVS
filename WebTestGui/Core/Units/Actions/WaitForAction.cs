using Newtonsoft.Json.Linq;
using System.Drawing.Drawing2D;

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

            logicOperatorComboBox.Items.AddRange(TypeHelpers.GetEnumTypes<LogicOperators>());

            foreach (object nameObj in TypeHelpers.GetAllSubClassesFromInterface<IWaitForCondition>())
            {
                string nameStr = ((string)nameObj).Split("WaitForCondition")[0];
                conditionTypesComboBox.Items.Add(nameStr);
            }
            m_WaitForConditions = new WaitForConditions(this);
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
                    if (m_ParentUnit != null)
                    {
                        m_ParentUnit.MoveAction(this, newId);
                    }
                }
            }
        }

        private void OnUIdTextBoxFocusLeave(object sender, EventArgs e)
        {
            if (int.TryParse(idTextBox.Text, out int _))
            {
                int newId = int.Parse(idTextBox.Text);
                if (m_ParentUnit != null)
                {
                    m_ParentUnit.MoveAction(this, newId);
                }
            }
        }

        public void Delete()
        {
            if (m_ParentUnit != null)
            {
                m_ParentUnit.DeleteAction(this);
            }
        }

        public void Refresh(bool needWholePanelRefresh)
        {
        }

        public void OnBreakpointHit()
        {
            mainPanel.BackColor = Color.FromArgb(255, 129, 27, 40);
        }
        public void OnBreakpointLeave()
        {
            mainPanel.BackColor = Color.FromArgb(255, 45, 45, 50);
        }

        long m_ChromeRunTimeInMicroseconds = 0;
        long m_FirefoxRunTimeInMicroseconds = 0;

        public void SetChromeRunTime(long chromeRunTimeInMicroseconds)
        {
            if (m_ParentUnit != null)
            {
                m_ChromeRunTimeInMicroseconds = chromeRunTimeInMicroseconds;

                testRunTimeText.Text =
                    m_ChromeRunTimeInMicroseconds.ToString() + " / " + m_FirefoxRunTimeInMicroseconds.ToString() + " ms";
                if (m_ParentUnit.m_ParentForm.GetMainTest().m_State == Test.TestState.Break)
                {
                    testRunTimeText.ForeColor = Color.Firebrick;
                }
                else if (m_ParentUnit.m_ParentForm.GetMainTest().m_State == Test.TestState.Edit)
                {
                    testRunTimeText.ForeColor = Color.DimGray;
                }
            }
        }
        public void SetFirefoxRunTime(long firefoxRunTimeInMicroseconds)
        {
            if (m_ParentUnit != null)
            {
                m_FirefoxRunTimeInMicroseconds = firefoxRunTimeInMicroseconds;

                testRunTimeText.Text =
                    m_ChromeRunTimeInMicroseconds.ToString() + " / " + m_FirefoxRunTimeInMicroseconds.ToString() + " ms";
                if (m_ParentUnit.m_ParentForm.GetMainTest().m_State == Test.TestState.Break)
                {
                    testRunTimeText.ForeColor = Color.Firebrick;
                }
                else if (m_ParentUnit.m_ParentForm.GetMainTest().m_State == Test.TestState.Edit)
                {
                    testRunTimeText.ForeColor = Color.DimGray;
                }
            }
        }
        public Tuple<int, int> GetRunTime()
        {
            return new Tuple<int, int>(
                int.Parse(testRunTimeText.Text.Split(" ")[0]), int.Parse(testRunTimeText.Text.Split(" ")[2]));
        }

        public void OnBorderLineDraw(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.FromArgb(255, 75, 75, 70), 2);
                int cornerRadius = 20; // Az oldalak lekerekítési sugara

                GraphicsPath path = new GraphicsPath();

                // Készíti a lekerekített négyzetet
                path.AddArc(0, 0, 2 * cornerRadius, 2 * cornerRadius, 180, 90); // Bal felső sarok
                path.AddLine(cornerRadius, 0, Size.Width - cornerRadius, 0); // Felső él
                path.AddArc(Size.Width - 2 * cornerRadius, 0, 2 * cornerRadius, 2 * cornerRadius, 270, 90); // Jobb felső sarok
                path.AddLine(Size.Width, cornerRadius, Size.Width, Size.Height - cornerRadius); // Jobb oldal
                path.AddArc(Size.Width - 2 * cornerRadius, Size.Height - 2 * cornerRadius, 2 * cornerRadius, 2 * cornerRadius, 0, 90); // Jobb alsó sarok
                path.AddLine(Size.Width - cornerRadius, Size.Height, cornerRadius, Size.Height); // Alsó él
                path.AddArc(0, Size.Height - 2 * cornerRadius, 2 * cornerRadius, 2 * cornerRadius, 90, 90); // Bal alsó sarok
                path.AddLine(0, Size.Height - cornerRadius, 0, cornerRadius); // Bal oldal

                g.DrawPath(p, path);
            }
        }

        public Dictionary<string, object> GetJSONFormatted()
        {
            Refresh(true);
            Dictionary<string, object> clickData = new Dictionary<string, object>();
            clickData["type"] = m_ActionType;
            clickData["break"] = m_HaveBreakpoint;

            // Logic operator deduction code
            string logicOperatorOutString;
            if (oppOperatorCheckbox.Checked)
                logicOperatorOutString = "! " + logicOperatorComboBox.Text;
            else
                logicOperatorOutString = logicOperatorComboBox.Text;
            clickData["logic_operator"] = logicOperatorOutString;

            // Condition list
            clickData["condition_list"] = m_WaitForConditions.GetWaitForConditionsJSON();

            clickData["frequency"] = int.Parse(frequencyTextBox.Text);
            clickData["timeout"] = int.Parse(timeoutTextBox.Text);

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

            // Logic operator induction code
            bool isInverted = ((string)data["logic_operator"]!).Contains("!");
            if (isInverted)
            {
                oppOperatorCheckbox.Checked = true;
                logicOperatorComboBox.Text = ((string)data["logic_operator"]!).Split("!")[1];
            }
            else
                logicOperatorComboBox.Text = (string)data["logic_operator"]!;

            // Condition list
            m_WaitForConditions.SetData(data["condition_list"]!);
            RefreshConditionListPanel();

            frequencyTextBox.Text = (string)data["frequency"]!;
            timeoutTextBox.Text = (string)data["timeout"]!;
        }

        public string m_ActionType { get { return "wait_for"; } }
        public IUnit m_ParentUnit { get; set; }
        public bool m_HaveBreakpoint { get; set; }

        public bool m_Single = false;

        // ACTION SPECIFIC FUNCTIONS

        public WaitForConditions m_WaitForConditions;

        public void RefreshConditionListPanel()
        {
            conditionListPanel.Controls.Clear();
            foreach (IWaitForCondition waitForCondition in m_WaitForConditions.m_WaitForConditions)
            {
                conditionListPanel.Controls.Add((Control)waitForCondition);
            }
        }

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

        private void conditionTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedConditionTypeRaw =
                conditionTypesComboBox.GetItemText(conditionTypesComboBox.SelectedItem)!;
            string selectedConditionType = selectedConditionTypeRaw + "WaitForCondition";

            IWaitForCondition condition = WaitForConditions.CreateWaitForConditionByType(selectedConditionType);
            condition.m_ParentClass = m_WaitForConditions;
            m_WaitForConditions.m_WaitForConditions.Add(condition);

            RefreshConditionListPanel();
        }

        public enum LogicOperators
        {
            all = 0,
            any = 1,
            n = 2,
            minn = 3,
            maxn = 4
        }
    }
}

