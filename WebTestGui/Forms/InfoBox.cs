namespace WebTestGui
{
    public partial class InfoBox : Form
    {
        public InfoBox(string mainlabel, string description, InfoBoxType boxType)
        {
            InitializeComponent();

            switch (boxType)
            {
                case InfoBoxType.Info:
                    informationPicture.Visible = true;
                    informationPicture.BackColor = Color.Transparent;
                    break;
                case InfoBoxType.Warning:
                    warningIcon.Visible = true;
                    warningIcon.BackColor = Color.Transparent;
                    break;
                case InfoBoxType.Error:
                    errorIcon.Visible = true;
                    errorIcon.BackColor = Color.Transparent;
                    break;
            }

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);

            Text = mainlabel;
            mainLabel.Text = mainlabel;
            descriptionLabel.Text = description;
        }

        public InfoBox()
        {
            InitializeComponent();

            informationPicture.Visible = true;
            informationPicture.BackColor = Color.Transparent;

            DarkTitleBarManager.UseImmersiveDarkMode(Handle, true);
            BackColor = Color.FromArgb(255, 50, 50, 53);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public enum InfoBoxType
        {
            Info = 0,
            Warning = 1,
            Error = 2,
        }
    }
}
