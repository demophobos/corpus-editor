using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process.Helper
{
    internal class RusCorporaMapper
    {
        internal static string ConvertPos(ChunkValueItemModel chunkValueItem)
        {
            string result;
            switch (chunkValueItem.Pos)
            {
                case "verb":
                case "part":
                    result = $"V{ConvertPosAttributes(chunkValueItem)}";
                    break;
                case "noun":
                    result = $"S{ConvertPosAttributes(chunkValueItem)}";
                    break;
                case "adj":
                    result = $"A{ConvertPosAttributes(chunkValueItem)}";
                    break;
                case "adv":
                    result = $"ADV{ConvertPosAttributes(chunkValueItem)}";
                    break;
                case "pron":
                    result = $"PRO{ConvertPosAttributes(chunkValueItem)}";
                    break;
                case "conj":
                    result = "CONJ";
                    break;
                case "exclam":
                    result = "INTJ";
                    break;
                case "prep":
                    result = "PR";
                    break;
                case "numeral":
                    result = $"NUM{ConvertPosAttributes(chunkValueItem)}";
                    break;
                default:
                    result = chunkValueItem.Pos;
                    break;
            }

            return result;
        }

        private static string ConvertPosAttributes(ChunkValueItemModel chunkValueItem)
        {
            var sb = new StringBuilder();

            switch (chunkValueItem.Pos)
            {
                case "verb":
                    if (chunkValueItem.Mood == "gerundive")
                    {
                        sb.Append($"{ConvertMood(chunkValueItem.Mood)},{ConvertGender(chunkValueItem.Gender)},{chunkValueItem.Case},{chunkValueItem.Number}");
                    }
                    else
                    {
                        sb.Append($"{ConvertTense(chunkValueItem.Tense)},{ConvertMood(chunkValueItem.Mood)},{chunkValueItem.Voice},{chunkValueItem.Number},{ConverPerson(chunkValueItem.Person)}");
                    }
                    break;
                case "part":
                    sb.Append($"partcp,{chunkValueItem.Voice},{ConvertTense(chunkValueItem.Tense)},{ConvertGender(chunkValueItem.Gender)},{chunkValueItem.Case},{chunkValueItem.Number}");
                    break;
                case "numeral":
                    sb.Append($"{ConvertGender(chunkValueItem.Gender)},{chunkValueItem.Case},{chunkValueItem.Number}");
                    break;
                case "adv":
                    sb.Append($"{ConvertDegree(chunkValueItem.Degree)}");
                    break;
                case "noun":
                    sb.Append($"{ConvertGender(chunkValueItem.Gender)},{chunkValueItem.Case},{chunkValueItem.Number}");
                    break;
                case "pron":
                    sb.Append($"{ConvertGender(chunkValueItem.Gender)},{chunkValueItem.Case},{chunkValueItem.Number}");
                    break;
                case "adj":
                    sb.Append($"{ConvertGender(chunkValueItem.Gender)},{chunkValueItem.Case},{chunkValueItem.Number},{ConvertDegree(chunkValueItem.Degree)}");
                    break;
                default:
                    break;
            }

            var result = sb.ToString().TrimEnd(',', new char()).TrimEnd(':', new char());

            return !string.IsNullOrEmpty(result) ? $"={result}" : result;
        }

        private static object ConvertTense(string input)
        {
            switch (input)
            {
                case "pres":
                    return "praes";
                default:
                    return input;
            }
        }

        private static string ConvertDegree(string input)
        {
            switch (input)
            {
                case "comp":
                    return "comp";
                case "superl":
                    return "supr";
                default:
                    return input;
            }
        }

        private static string ConvertGender(string input)
        {
            switch (input)
            {
                case "masc":
                    return "m";
                case "fem":
                    return "f";
                case "neut":
                    return "n";
                default:
                    return input;
            }
        }

        private static string ConvertMood(string input)
        {
            switch (input)
            {
                case "ind":
                    return "indic";
                case "imperat":
                    return "imper";
                default:
                    return input;
            }
        }

        private static string ConverPerson(string input)
        {
            switch (input)
            {
                case "1st":
                    return "1p";
                case "2nd":
                    return "2p";
                case "3rd":
                    return "3p";
                default:
                    return input;
            }
        }

        internal static string ConvertLang(string input)
        {
            switch (input)
            {
                case "lat":
                    return "la";
                case "rus":
                    return "ru";
                default:
                    return input;
            }
        }
    }
}
