using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class ExecuteJsAction : UserControl, IAction
    {
        public ExecuteJsAction()
        {
            InitializeComponent();
            mainPanel.Paint += OnBorderLineDraw!;
            idTextBox.KeyPress += OnIdOverride!;

            mainLabel.Text = "Execute JS";
            actionTypeLabel.Text = "action:" + m_ActionType;

            m_CommandEditor = new JsCommandEditor(this);
            mainPanel.Controls.Add(m_CommandEditor);
            m_CommandEditor.Location = new Point(100, 38);
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
            m_CommandEditor.m_ParentForm = m_ParentForm;
            m_CommandEditor.Refresh(needWholePanelRefresh);
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
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["type"] = m_ActionType;
            data["break"] = m_HaveBreakpoint;

            data["commmands"] = m_CommandEditor.GetCommands();

            return data;
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

            m_CommandEditor.SetCommands(data["commmands"]!);
        }

        public string m_ActionType { get { return "js_execute"; } }
        public MainForm m_ParentForm { get; set; }
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

        JsCommandEditor m_CommandEditor;
    }
}

