using System.Text.RegularExpressions;

public static class JsonSyntaxHighlighter
{
    public static void HighlightJsonSyntax(RichTextBox richTextBox)
    {
        Color keywordColor = Color.Blue;
        Color stringColor = Color.White;
        Color numberColor = Color.Wheat;
        Color booleanColor = Color.Magenta;
        Color nullColor = Color.Gray;

        string jsonText = richTextBox.Text;
        richTextBox.SuspendLayout();

        richTextBox.SelectionStart = 0;
        richTextBox.SelectionLength = richTextBox.TextLength;
        richTextBox.SelectionColor = Color.LightBlue;

        HighlightPattern(@"(?<key>""(?:[^""\\]|\\.)*"")\s*:", keywordColor, richTextBox);
        HighlightPattern(@"""(?:[^""\\]|\\.)*""\s*:", stringColor, richTextBox);
        HighlightPattern(@"\b(?:true|false)\b", booleanColor, richTextBox);
        HighlightPattern(@"\bnull\b", nullColor, richTextBox);
        HighlightPattern(@"\b[-+]?(?:\d*\.)?\d+\b", numberColor, richTextBox);

        richTextBox.ResumeLayout();
    }

    private static void HighlightPattern(string pattern, Color color, RichTextBox richTextBox)
    {
        MatchCollection matches = Regex.Matches(richTextBox.Text, pattern);

        foreach (Match match in matches)
        {
            richTextBox.SelectionStart = match.Index;
            richTextBox.SelectionLength = match.Length;
            richTextBox.SelectionColor = color;
        }
    }
}