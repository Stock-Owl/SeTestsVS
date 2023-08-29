using Newtonsoft.Json.Linq;
using System;

namespace WebTestGui
{
    public partial class UnitPanel : UserControl, IUnit
    {
        public UnitPanel()
        {
            InitializeComponent();
            mainPanel.Paint += OnBorderLineDraw!;
            idTextBox.KeyPress += OnUIdOverride!;
            unitNameTextField.KeyPress += OnUnitNameTextFieldLeave!;

            object[] actionClasses = TypeHelpers.GetAllSubClassesFromInterface<IAction>();
            addActionComboBox.Items.AddRange(actionClasses);

            m_Actions = new Actions();
            OnExpandActionsButttonClick(null!, null!);
        }

        // ACTION INTERFACE FUNCTIONS AND MEMBERS

        public void SetUId(int uid)
        {
            idTextBox.Text = uid.ToString();
        }

        public int GetUId()
        {
            return int.Parse(idTextBox.Text);
        }

        public void OnUIdOverride(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (int.TryParse(idTextBox.Text, out int _))
                {
                    int newId = int.Parse(idTextBox.Text);
                    m_ParentForm.MoveUnit(this, newId);
                }
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Biztosan törölni szeretné ezt a Unitot?\n ('{m_UnitName}' visszafordíthatatlanul elveszik...)",
                "Törlés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                m_ParentForm.DeleteUnit(this);
                Refresh();
            }
        }

        public void DeleteAction(IAction action)
        {
            DialogResult result = MessageBox.Show($"Biztosan törölni szeretné ezt a '{action.m_ActionType}' típusú Actiont?",
                "Törlés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                m_Actions.m_Actions.Remove(action);
                OnExpandActionsButttonClick(null!, null!);
            }
        }

        public void MoveAction(IAction action, int newId)
        {
            m_Actions.MoveElement(action, newId);
            Refresh();
        }

        public void Refresh()
        {
            Control[] controls = new Control[m_Actions.m_Actions.Count];

            for (int i = 0; i < controls.Length; i++)
            {
                m_Actions.m_Actions[i].SetId(i);
                controls[i] = (Control)m_Actions.m_Actions[i];
            }

            if (!m_IsCollapsed)
            {
                actionsPanel.SuspendLayout();

                actionsPanel.Controls.Clear();
                actionsPanel.Controls.AddRange(controls);

                int totalHeight = 74;
                int counter = 0;
                foreach (Control control in actionsPanel.Controls)
                {
                    totalHeight += ((control.Height) + (counter * 2));
                    counter++;
                }

                actionsPanel.Height = totalHeight;
                Size = new Size(Size.Width, totalHeight);

                actionsPanel.ResumeLayout();
            }

            unitNameTextField.Text = m_UnitName;
            if (m_Bindings != null)
            {
                bindingsLabel.Text = m_Bindings.m_UnitName;
            }
            if (m_BackupOf != null)
            {
                backupOfLabel.Text = m_BackupOf.m_UnitName;
            }

            SetUnitBindings();
            SetUnitBackupOf();
        }

        public void OnBreakpointHit(int actionIndex)
        {
            OnExpandActionsButttonClick(null!, null!);

            mainPanel.BackColor = Color.FromArgb(255, 129, 27, 40);
            actionsPanel.BackColor = Color.FromArgb(255, 109, 27, 40);

            m_Actions.m_Actions[actionIndex].OnBreakpointHit();
        }

        public void OnBreakpointLeave()
        {
            mainPanel.BackColor = Color.FromArgb(255, 45, 45, 50);
            actionsPanel.BackColor = Color.FromArgb(255, 45, 45, 50);

            foreach (IAction action in m_Actions.m_Actions)
            {
                action.OnBreakpointLeave();
            }
            Refresh();
        }

        public void SetRunTime()
        {
            // Must call only after the actions times set
            int chromeSum = 0;
            int firefoxSum = 0;
            foreach (IAction action in m_Actions.m_Actions)
            {
                Tuple<int, int> sum = action.GetRunTime();
                chromeSum += sum.Item1;
                firefoxSum += sum.Item2;
            }
            testRunTimeText.Text = (chromeSum.ToString() + " / " + firefoxSum.ToString() + " ms");
            if (m_ParentForm.Test().m_State == Test.TestState.Break)
            {
                testRunTimeText.ForeColor = Color.Firebrick;
            }
            else if (m_ParentForm.Test().m_State == Test.TestState.Edit)
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
            Refresh();

            Dictionary<string, object> data = new Dictionary<string, object>();
            data["bindings"] = m_Bindings != null ? m_Bindings.m_UnitName : null!;
            data["backup_of"] = m_BackupOf != null ? m_BackupOf.m_UnitName : null!;

            Dictionary<string, object> actionsData = new Dictionary<string, object>();
            foreach (IAction action in m_Actions.m_Actions)
            {
                actionsData[action.GetId().ToString()] = action.GetJSONFormatted();
            }
            data["actions"] = actionsData;

            return data;
        }

        public void SetData(JToken data)
        {
            if (data["bindings"]! != null)
            {
                bindingsLabel.Text = (string)data["bindings"]!;
            }
            if (bindingsLabel.Text == "")
            {
                bindingsLabel.Text = "null";
            }
            if (data["backup_of"]! != null)
            {
                backupOfLabel.Text = (string)data["backup_of"]!;
            }
            if (backupOfLabel.Text == "")
            {
                backupOfLabel.Text = "null";
            }

            JToken actionsData = data["actions"]!;
            foreach (JToken actionRawData in actionsData.Children())
            {
                JToken actionData = actionRawData.First!;
                string actionType = (string)actionRawData.First!.First!;

                IAction action = Actions.CreateActionByType(actionType);
                action.m_ParentUnit = this;
                action.SetData(actionData);
                m_Actions.m_Actions.Add(action);
            }
        }

        public void SetUnitBindings()
        {
            if (bindingsLabel.Text != "null")
            {
                for (int i = 0; i < m_ParentForm.Test().m_Units.m_Units.Count; i++)
                {
                    if (bindingsLabel.Text == m_ParentForm.Test().m_Units.m_Units[i].m_UnitName)
                    {
                        m_Bindings = m_ParentForm.Test().m_Units.m_Units[i];
                    }
                }
                //Refresh();
            }
        }

        public void SetUnitBackupOf()
        {
            if (backupOfLabel.Text != "null")
            {
                for (int i = 0; i < m_ParentForm.Test().m_Units.m_Units.Count; i++)
                {
                    if (backupOfLabel.Text == m_ParentForm.Test().m_Units.m_Units[i].m_UnitName)
                    {
                        m_BackupOf = m_ParentForm.Test().m_Units.m_Units[i];
                    }
                }
                //Refresh();
            }
        }

        public MainForm m_ParentForm { get; set; }
        public Actions m_Actions { get; set; }

        public string m_UnitName { get; set; }
        public IUnit m_Bindings { get; set; }
        public IUnit m_BackupOf { get; set; }

        // UNIT PANEL SPECIFIC METHODS AND MEMBERS

        private void OnActionComboBoxItemSelect(object sender, EventArgs e)
        {
            string selected = addActionComboBox.GetItemText(addActionComboBox.SelectedItem)!;
            addActionComboBox.Text = "";
            Type actionType = TypeHelpers.GetClassFromString(selected);
            IAction action = (IAction)Activator.CreateInstance(actionType)!;
            action.m_ParentUnit = this;

            action.SetId(actionsPanel.Controls.Count);
            m_Actions.m_Actions.Add(action);
            OnExpandActionsButttonClick(sender, e);
            Refresh();
        }

        private void OnUnitBindingsComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            bindingsLabel.Text = unitBindingsComboBox.GetItemText(unitBindingsComboBox.SelectedItem)!;
            unitBindingsComboBox.Text = "";
            SetUnitBindings();
        }

        private void OnUnitBackupComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            backupOfLabel.Text = unitBackupComboBox.GetItemText(unitBackupComboBox.SelectedItem)!;
            unitBackupComboBox.Text = "";
            SetUnitBackupOf();
        }

        private void OnUnitBindingsComboBoxDropDown(object sender, EventArgs e)
        {
            unitBindingsComboBox.Items.Clear();
            string[] unitNames = new string[m_ParentForm.Test().m_Units.m_Units.Count];
            for (int i = 0; i < unitNames.Length; i++)
            {
                unitNames[i] = m_ParentForm.Test().m_Units.m_Units[i].m_UnitName;
            }

            unitBindingsComboBox.Items.AddRange(unitNames);
        }

        private void OnUnitBackupComboBoxDropDown(object sender, EventArgs e)
        {
            unitBackupComboBox.Items.Clear();
            string[] unitNames = new string[m_ParentForm.Test().m_Units.m_Units.Count];
            for (int i = 0; i < unitNames.Length; i++)
            {
                unitNames[i] = m_ParentForm.Test().m_Units.m_Units[i].m_UnitName;
            }

            unitBackupComboBox.Items.AddRange(unitNames);
        }

        private void OnCollapseActionsButtonClick(object sender, EventArgs e)
        {
            Size = new Size(1000, 97);
            actionsPanel.Controls.Clear();
            m_IsCollapsed = true;

            collapseActionsButton.Visible = false;
            expandActionsButtton.Visible = true;
        }

        private void OnExpandActionsButttonClick(object sender, EventArgs e)
        {
            m_IsCollapsed = false;
            Refresh();

            collapseActionsButton.Visible = true;
            expandActionsButtton.Visible = false;
        }

        public void OnUnitNameTextFieldLeave(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                OnUnitNameTextFieldChanged(sender, e);
            }
        }

        private void OnUnitNameTextFieldChanged(object sender, EventArgs e)
        {
            m_UnitName = unitNameTextField.Text;
            m_ParentForm.RefreshEditor();
        }

        private void OnUIdTextBoxFocusLeave(object sender, EventArgs e)
        {
            if (int.TryParse(idTextBox.Text, out int _))
            {
                int newId = int.Parse(idTextBox.Text);
                m_ParentForm.MoveUnit(this, newId);
            }
        }

        public bool m_IsCollapsed = false;

        private void resetBindingButton_Click(object sender, EventArgs e)
        {
            m_Bindings = null!;
            bindingsLabel.Text = "null";
        }

        private void resetBackupOfButton_Click(object sender, EventArgs e)
        {
            m_BackupOf = null!;
            backupOfLabel.Text = "null";
        }
    }
}

