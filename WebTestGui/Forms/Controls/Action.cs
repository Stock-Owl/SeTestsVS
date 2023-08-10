namespace WebTestGui.Forms.Controls
{
    public partial class Action : UserControl
    {
        public Action()
        {
            InitializeComponent();
        }

        public string m_ActionType;

        private void mainPanel_Paint(object sender, PaintEventArgs e)
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
    }

    public class Element
    {
        public string m_Locator;
        public string m_Value;
        public Element m_Element;
    }

    public class GotoAction : Action
    {
        public GotoAction()
        {
            m_ActionType = "goto";
            mainLabel.Text = m_ActionType;
        }

        public string m_Url;
    }

    public class ClickAction : Action
    {
        public ClickAction()
        {
            m_ActionType = "click";
            mainLabel.Text = m_ActionType;
        }

        public Element m_Element;
    }

    public class SendKeysAcion : Action
    {
        public SendKeysAcion()
        {
            m_ActionType = "send_keys";
            mainLabel.Text = m_ActionType;
        }
        public Element m_Element;
    }
}
