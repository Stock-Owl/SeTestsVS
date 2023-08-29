using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace WebTestGui
{
    public partial class GotoAction : UserControl, IAction
    {
        public GotoAction()
        {
            InitializeComponent();
            mainPanel.Paint += OnBorderLineDraw!;
            idTextBox.KeyPress += OnIdOverride!;

            mainLabel.Text = "Goto";
            actionTypeLabel.Text = "action:" + m_ActionType;
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
            if (needWholePanelRefresh)
            {
                m_ParentUnit.Refresh();
            }
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
        public void SetFirefoxRunTime(long firefoxRunTimeInMicroseconds)
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
            var gotoData = new Dictionary<string, object>();
            gotoData["type"] = m_ActionType;
            gotoData["break"] = m_HaveBreakpoint;

            gotoData["url"] = urlTextField.Text;
            return gotoData;
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

            urlTextField.Text = (string)data["url"]!;

            Refresh(true);
        }

        public string m_ActionType { get { return "goto"; } }
        public IUnit m_ParentUnit { get; set; }
        public bool m_HaveBreakpoint { get; set; }

        // ACTION SPECIFIC FUNCTIONS AND MEMBERS

        public void SetGotoUrl(string gotoUrl)
        {
            urlTextField.Text = gotoUrl;
        }

        private void webSearchButton_Click(object sender, EventArgs e)
        {
            string executable = MainForm.s_IsChromeChecked ? BrowserHelper.GetChromeExecutablePath() : BrowserHelper.GetFirefoxExecutablePath();
            string url = string.IsNullOrEmpty(urlTextField.Text) ? "google.com" : urlTextField.Text;
            Process.Start($"{executable}", url);
        }

        private void pictureBox3_Click(object sender, EventArgs e) { webSearchButton_Click(sender, e); }

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

        private void overlayButton_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = Color.Transparent;
        }

        private void overlayButton_MouseLeave(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.Transparent;
        }
    }
}

