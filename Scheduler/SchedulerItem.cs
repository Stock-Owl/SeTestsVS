namespace WebTestGui
{
    public partial class SchedulerItem : UserControl
    {
        public SchedulerItem(Scheduler.Scheduler parent)
        {
            InitializeComponent();

            m_Parent = parent;
        }

        public void OnTestStart()
        {

        }

        public void OnTestEnd(bool successful)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Teszt betöltése...";
            of.Filter = $"Teszt fájl|*{AppConsts.s_AppDefaultFileExtension}|Any File|*.*";
            if (of.ShowDialog() == DialogResult.OK)
            {
                m_TestRawJson = File.ReadAllText(of.FileName);
                m_TestPath = of.FileName;
                m_TestName = Path.GetFileNameWithoutExtension(of.FileName);

                m_IsTestLoaded = true;
                mainLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
                mainLabel.ForeColor = Color.White;
                testFilePathTextBox.Text = m_TestPath;
                mainLabel.Text = m_TestName;
            }
        }

        private void locatorTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = locatorTextBox.GetItemText(locatorTextBox.SelectedItem)!;
            locatorTextBox.Text = selected;
            if (selected == "Az előző teszt után egyből...")
            {
                timeTypeTextBox.Visible = false;
                timeTypeLabel.Visible = false;
                msLabel.Visible = false;
            }
            else
            {
                timeTypeTextBox.Visible = true;
                timeTypeLabel.Visible = true;
                msLabel.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            m_IsTestLoaded = false;
            mainLabel.Text = "Teszt neve...";
            testFilePathTextBox.Text = "";
            mainLabel.Font = new Font("Segoe UI", 15F, FontStyle.Italic, GraphicsUnit.Point);
            mainLabel.ForeColor = Color.DimGray;
        }

        #region ID logic

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
                    m_Parent.MoveElement(this, newId);
                }
            }
        }

        private void OnUIdTextBoxFocusLeave(object sender, EventArgs e)
        {
            if (int.TryParse(idTextBox.Text, out int _))
            {
                int newId = int.Parse(idTextBox.Text);
                m_Parent.MoveElement(this, newId);
            }
        }

        #endregion

        public Scheduler.Scheduler m_Parent;
        public bool m_IsTestLoaded = false;

        public string m_TestName;
        public string m_TestPath;

        string m_TestRawJson;
    }
}

