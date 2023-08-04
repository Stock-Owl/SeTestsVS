using System.Text.RegularExpressions;

namespace WebTestGui
{
    public partial class JsCommand : UserControl
    {
        public JsCommand(JsCommandEditor parentEditor)
        {
            InitializeComponent();

            m_ParentEditor = parentEditor;
            idTextBox.KeyPress += OnIdOverride!;

            HighlightJavaScriptSyntax(null!, null!);
            commandConsole.TextChanged += HighlightJavaScriptSyntax!;
        }

        private void HighlightJavaScriptSyntax(object sender, EventArgs e)
        {
            string keywords = @"\b(var|let|const|function|if|else|while|for|return)\b";
            MatchCollection keywordMatches = Regex.Matches(commandConsole.Text, keywords);

            string strings = @"'.+?'|"".+?""";
            MatchCollection stringMatches = Regex.Matches(commandConsole.Text, strings);

            string comments = @"\/\/.*?$|\/\*[\s\S]*?\*\/";
            MatchCollection commentMatches = Regex.Matches(commandConsole.Text, comments, RegexOptions.Multiline);

            int cursorPos = commandConsole.SelectionStart;

            commandConsole.SelectionStart = 0;
            commandConsole.SelectionLength = commandConsole.Text.Length;
            commandConsole.SelectionColor = Color.White;

            foreach (Match m in keywordMatches)
            {
                commandConsole.SelectionStart = m.Index;
                commandConsole.SelectionLength = m.Length;
                commandConsole.SelectionColor = Color.LightBlue;
            }

            foreach (Match m in stringMatches)
            {
                commandConsole.SelectionStart = m.Index;
                commandConsole.SelectionLength = m.Length;
                commandConsole.SelectionColor = Color.LightPink;
            }

            foreach (Match m in commentMatches)
            {
                commandConsole.SelectionStart = m.Index;
                commandConsole.SelectionLength = m.Length;
                commandConsole.SelectionColor = Color.Green;
            }

            commandConsole.SelectionStart = commandConsole.Text.Length;
            commandConsole.SelectionLength = 0;
            commandConsole.SelectionColor = Color.Black;

            commandConsole.SelectionStart = cursorPos;
        }

        public string GetCommandString() { return commandConsole.Text; }
        public void SetCommandString(string text) { commandConsole.Text = text; }
        public void SetCommandId(int id)
        {
            mainLabel.Text = $"Command {id}";
            idTextBox.Text = id.ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            m_ParentEditor.RemoveCommand(this);
            m_ParentEditor.Refresh(true);
        }

        public void OnIdOverride(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (int.TryParse(idTextBox.Text, out int _))
                {
                    int newId = int.Parse(idTextBox.Text);
                    m_ParentEditor.MoveCommand(this, newId);
                }
            }
        }

        JsCommandEditor m_ParentEditor;
    }
}
