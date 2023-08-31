using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public partial class ParentLogPathOption : UserControl, IOption
    {
        public ParentLogPathOption()
        {
            InitializeComponent();

            m_OptionName = "parent_log_path";
        }

        // INTERFACE FUNCTIONS AND MEMBERS

        public object GetData()
        {
            return folderPath.Text;
        }

        public void SetData(JToken jSondata)
        {
            folderPath.Text = (string)jSondata!;
        }

        public string m_OptionName { get; set; }
        public MainForm m_ParentForm { get; set; }

        // OPTION SPECIFIC FUNCTIONS AND MEMBERS

        public string GetRootLogPath()
        {
            return folderPath.Text;
        }

        public void SetRootLogPath(string rootLogPath)
        {
            folderPath.Text = rootLogPath;
        }

        private void folderIcon_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    folderPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void searchForFolderButton_Click(object sender, EventArgs e)
        {
            folderIcon_Click(null!, null!);
        }
    }
}
