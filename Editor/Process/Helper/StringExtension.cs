using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Process.Helper
{
    public static class StringExtension
    {
        public static string Truncate(this string value, int maxLength, bool ellipsis)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var result = value.Length <= maxLength ? value : value.Substring(0, maxLength);

            return ellipsis && value.Length > maxLength ? $"{result}..." : result;
        }

        public static string[] Split(this string str, string splitter)
        {
            return str.Split(new[] { splitter }, StringSplitOptions.None);
        }

        public static IEnumerable<string> TextElements(this string s)
        {
            if (s == null)
                yield break;
            var enumerator = StringInfo.GetTextElementEnumerator(s);
            while (enumerator.MoveNext())
                yield return enumerator.GetTextElement();
        }

        public static IEnumerable<string> SplitByWordsAndOtherSymbols(this string s)
        {
            if (s == null)
                return null;
            return Regex.Split(s.Trim(), @"(?=[\p{P}\p{S}\s]|\b)").Where(i => i.Length > 0);
        }

        public static string Reverse(this string s)
        {
            if (s == null)
                return null;
            return s.TextElements().Reverse().Aggregate(new StringBuilder(s.Length), (sb, c) => sb.Append(c)).ToString();
        }

        public static IEnumerable<string> ToLines(this string text)
        {
            if (text == null)
                yield break;
            using (var sr = new StringReader(text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static string ToText(this IEnumerable<string> lines)
        {
            if (lines == null)
                return null;
            return lines.Aggregate(new StringBuilder(), (sb, l) => sb.AppendLine(l)).ToString();
        }

        public static string ReverseLines(this string s)
        {
            if (s == null)
                return null;
            return s.ToLines().Reverse().Select(l => l.Reverse()).ToText();
        }
    }
}
