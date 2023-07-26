using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class WaitAction : UserControl, IAction
    {
        public WaitAction()
        {
            InitializeComponent();
            mainPanel.Paint += OnBorderLineDraw!;
            idTextBox.KeyPress += OnIdOverride!;

            mainLabel.Text = "Wait";
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
                    m_ParentForm.MoveAction(this, newId);
                }
            }
        }

        public void Delete()
        {
            m_ParentForm.DeleteAction(this);
        }

        public void Refresh(bool needWholePanelRefresh)
        {
            if (needWholePanelRefresh)
            {
                m_ParentForm.RefreshActionsPanel();
            }
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

            gotoData["amount"] = string.IsNullOrEmpty(amountTextField.Text) == true ? "0" : amountTextField.Text;
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
            Refresh(true);

            amountTextField.Text = (string)data["amount"]!;
        }

        public string m_ActionType { get { return "wait"; } }
        public MainForm m_ParentForm { get; set; }
        public bool m_HaveBreakpoint { get; set; }

        // ACTION SPECIFIC FUNCTIONS AND MEMBERS

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

