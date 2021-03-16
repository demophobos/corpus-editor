using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Common.Helper
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void HighlightText(this RichTextBox richTextBox, string word, Color color)
        {

            if (word == string.Empty)
                return;

            int s_start = richTextBox.SelectionStart, startIndex = 0, index;

            while ((index = richTextBox.Text.IndexOf(word, startIndex, StringComparison.InvariantCultureIgnoreCase)) != -1)
            {
                richTextBox.Select(index, word.Length);
                richTextBox.SelectionColor = color;
                richTextBox.SelectionFont = new Font("Palatino Linotype", (float)14.25, FontStyle.Underline);
                startIndex = index + word.Length;
            }

            richTextBox.SelectionStart = s_start;
            richTextBox.SelectionLength = 0;
            richTextBox.SelectionColor = Color.Black;
        }

        public static void HighlightTextRegExp(this RichTextBox richTextBox, string word, Color foreColor, Color backColor)
        {
            string pattern = $@"\b({word})\b";

            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach (Match find in reg.Matches(richTextBox.Text))
            {
                richTextBox.Select(find.Index, find.Length);

                richTextBox.SelectionColor = foreColor;

                richTextBox.SelectionBackColor = backColor;

                richTextBox.Select(find.Index, 0);
            }
        }
    }
}
