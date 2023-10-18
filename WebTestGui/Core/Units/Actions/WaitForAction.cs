﻿using Newtonsoft.Json.Linq;

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
                if (m_ParentUnit.m_ParentForm.Test().m_State == Test.TestState.Break)
                {
                    testRunTimeText.ForeColor = Color.Firebrick;
                }
                else if (m_ParentUnit.m_ParentForm.Test().m_State == Test.TestState.Edit)
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
                if (m_ParentUnit.m_ParentForm.Test().m_State == Test.TestState.Break)
                {
                    testRunTimeText.ForeColor = Color.Firebrick;
                }
                else if (m_ParentUnit.m_ParentForm.Test().m_State == Test.TestState.Edit)
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
            clickData["frequency"] = string.IsNullOrEmpty(frequencyTextField.Text) == true ? 0 : int.Parse(frequencyTextField.Text);
            clickData["timeout"] = string.IsNullOrEmpty(timeOutTextBox.Text) == true ? 0 : int.Parse(timeOutTextBox.Text);
            clickData["logic_modifier"] = logicModifierComboBox.Text;

            Dictionary<string, object> conditionData = new Dictionary<string, object>();

            conditionData["type"] = conditionComboBox.Text;
            conditionData["locator"] = locatorTextBox.Text;
            conditionData["value"] = valueTextBox.Text;

            clickData["condition"] = conditionData;

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

            frequencyTextField.Text = ((int)data["frequency"]!).ToString();
            timeOutTextBox.Text = ((int)data["timeout"]!).ToString();
            logicModifierComboBox.Text = ((string)data["logic_modifier"]!).ToString();

            JToken conditionData = data["condition"]!;

            conditionComboBox.Text = (string)conditionData["type"]!;
            locatorTextBox.Text = (string)conditionData["locator"]!;
            valueTextBox.Text = (string)conditionData["value"]!;
        }

        public string m_ActionType { get { return "waitfor"; } }
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
