using Newtonsoft.Json.Linq;
using System;

namespace WebTestGui
{
    public partial class TerminalModeOption : UserControl, IOption
    {
        public TerminalModeOption()
        {
            InitializeComponent();

            m_OptionName = "terminal_mode";
        }

        // INTERFACE FUNCTIONS AND MEMBERS

        public object GetData()
        {
            return mainCheckbox.Checked;
        }

        public void SetData(JToken jSondata)
        {
            mainCheckbox.Checked = (bool)jSondata!;
        }

        public string m_OptionName { get; set; }
        public MainForm m_ParentForm { get; set; }

        // OPTION SPECIFIC FUNCTIONS AND MEMBERS

        private void mainCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (mainCheckbox.Checked)
            {
                mainCheckbox.Text = "Igen";
            }
            else
            {
                mainCheckbox.Text = "Nem";
            }
        }
    }
}
