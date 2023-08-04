using System.Text.RegularExpressions;

namespace WebTestGui
{
    internal class TextboxFormatter
    {
        public TextboxFormatter(RichTextBox console)
        {
            m_Console = console;
        }

        public void Print(string text)
        {
            m_RawContent += text;

            Color originalColor = m_Console.ForeColor;

            Regex regex = new Regex(@"{([^}]*)}\s*\[([^]]*)\]");
            MatchCollection matches = regex.Matches(text);

            int currentIndex = 0;
            foreach (Match match in matches)
            {
                string color = match.Groups[1].Value;
                string word = match.Groups[2].Value;

                int startIndex = match.Index - currentIndex;
                int wordIndex = text.IndexOf(word, startIndex);
                int wordLength = word.Length;

                try
                {
                    m_Console.AppendText(SanitizeTextToTextBox(text.Substring(currentIndex, wordIndex - currentIndex)));
                }
                catch
                {
                	
                }

                if (Color.FromName(color).IsKnownColor)
                {
                    m_Console.SelectionColor = Color.FromName(color);
                }
                else
                {
                    m_Console.SelectionColor = originalColor;
                }

                m_Console.SelectionLength = 0;
                m_Console.AppendText(SanitizeTextToTextBox(word));

                m_Console.SelectionColor = originalColor;

                currentIndex = wordIndex + wordLength;
            }

            m_Console.AppendText(SanitizeTextToTextBox(text.Substring(currentIndex)));
        }

        private static string SanitizeTextToTextBox(string text)
        {
            int startIndex = text.IndexOf('{');
            int endIndex = text.IndexOf('}');

            if (startIndex != -1 && endIndex != -1 && startIndex < endIndex)
            {
                string result = text.Substring(0, startIndex) + text.Substring(endIndex + 1);
                text = result;
            }

            text = text.Replace("[", "");
            text = text.Replace("]", "");

            return text;
        }

        private RichTextBox m_Console;
        private string m_RawContent = "";
        public string GetRawContent() { return m_RawContent; }
        public void SetRawContent(string text)
        {
            m_Console.Clear();
            m_RawContent = "";

            Print(text);
        }
    }
}
