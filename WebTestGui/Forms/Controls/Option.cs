﻿using WebTestGui.Utils;

namespace WebTestGui.Forms.Controls
{
    public partial class Option : UserControl
    {
        public Option()
        {
            InitializeComponent();

            m_InfoBox = new InfoBox();
        }

        public void SetMainLabel(string text, int size = 13)
        {
            mainLabel.Text = text;
            mainLabel.Font = new Font(mainLabel.Font.FontFamily, size, mainLabel.Font.Style);
        }

        public void SetMainTextbox(string text, string defaultValue = "")
        {
            mainComboBox.Visible = false;
            mainCheckbox.Visible = false;
            mainTextBox.PlaceholderText = text;
            mainTextBox.Text = defaultValue;
        }

        public void SetMainCombobox<T>(string text, int defaultIndex = 0)
        {
            mainTextBox.Visible = false;
            mainCheckbox.Visible = false;
            mainComboBox.Text = text;

            mainComboBox.Items.AddRange(TypeHelpers.GetEnumTypes<T>());
            mainComboBox.SelectedIndex = defaultIndex;

            infoBox.Location = new Point(194, infoBox.Location.Y);
        }

        public void SetMainCheckbox(bool defaultValue)
        {
            mainTextBox.Visible = false;
            mainComboBox.Visible = false;
            mainCheckbox.Checked = defaultValue;

            infoBox.Location = new Point(105, infoBox.Location.Y);
        }

        public void SetSubLabel(string text)
        {
            subLabel.Text = text;
        }

        public void SetSubTextbox(string text, string defaultValue = "")
        {
            subTextBox.PlaceholderText = text;
            subTextBox.Text = defaultValue;
        }

        public void SetSubElementsVisible(bool visible)
        {
            subLabel.Visible = visible;
            subTextBox.Visible = visible;

            if (!visible)
            {
                if (hintLabel.Visible)
                {
                    Size = new Size(Size.Width, 74);
                }
                else
                {
                    Size = new Size(Size.Width, 61);
                }
            }
        }

        public void GiveHint(string text)
        {
            hintLabel.Visible = true;
            hintLabel.Text = text;

            if (!subLabel.Visible)
            {
                Size = new Size(Size.Width, 74);
            }
        }

        public void SetInfoBox(string mainLabel, string description, InfoBox.InfoBoxType type)
        {
            m_InfoBox = new InfoBox(mainLabel, description, type);
        }
        public void SetInfoBox(InfoBox infoBox)
        {
            m_InfoBox = infoBox;
        }

        public void AddFolderDialog()
        {
            folderIcon.Visible = true;
            searchForFolderButton.Visible = true;

            Size = new Size(Size.Width, 92);
        }

        public string GetMainTextboxValue() { return mainTextBox.Text; }
        public string GetMainComboboxValue() { return mainComboBox.Text; }
        public bool GetMainCheckboxValue() { return mainCheckbox.Checked; }
        public string GetSubTextboxValue() { return subTextBox.Text; }

        private void infoBox_Click(object sender, EventArgs e)
        {
            m_InfoBox.ShowDialog();
        }

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
        private void searchForFolderButton_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    mainTextBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        private InfoBox m_InfoBox;
    }
}
