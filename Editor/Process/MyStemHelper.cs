using Model;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class MyStemHelper
    {
        public static void ConvertToMorphModel(string gr, MorphModel model)
        {
            if (gr.StartsWith("S,"))
            {
                model.Pos = PosEnum.Noun;
            }

            if (gr.StartsWith("SPRO,") || 
                gr.StartsWith("SPRO="))
            {
                model.Pos = PosEnum.Pron;
            }

            if (gr.StartsWith("PART=") || 
                gr.StartsWith("PART,"))
            {
                model.Pos = PosEnum.Particle;
            }

            if (gr.StartsWith("A=") ||
                gr.StartsWith("A,") ||
                gr.StartsWith("ANUM,") ||
                gr.StartsWith("ANUM=") ||
                gr.StartsWith("APRO=") ||
                gr.StartsWith("APRO,"))
            {
                model.Pos = PosEnum.Adj;
            }
            if (gr.StartsWith("ADV,") || 
                gr.StartsWith("ADV=") || 
                gr.StartsWith("ADVPRO=") || 
                gr.StartsWith("ADVPRO,"))
            {
                model.Pos = PosEnum.Adv;
            }

            if (gr.StartsWith("CONJ=") || 
                gr.StartsWith("CONJ,"))
            {
                model.Pos = PosEnum.Conj;
            }

            if (gr.StartsWith("INTJ=") || 
                gr.StartsWith("INTJ,"))
            {
                model.Pos = PosEnum.Exclam;
            }

            if (gr.StartsWith("NUM=") || 
                gr.StartsWith("NUM,"))
            {
                model.Pos = PosEnum.Numeral;
            }

            if (gr.StartsWith("PR=") ||
                gr.StartsWith("PR,"))
            {
                model.Pos = PosEnum.Prep;
            }

            if (gr.StartsWith("V,") ||
                gr.StartsWith("V="))
            {
                model.Pos = PosEnum.Verb;
            }

            if (string.IsNullOrEmpty(model.Pos))
            {
                Debug.WriteLine($"Неизвестный тип: {model.Form}: {gr}");
            }

            ConvertPosAttributes(model, gr);
        }

        public static void ConvertPosAttributes(MorphModel model, string attributes)
        {
            var attrArray = attributes.Split(new[] { ',', '=' });

            model.Gender = ConvertGender(attrArray);
            model.Case = ConvertCase(attrArray);
            model.Number = ConvertNumber(attrArray);
            model.Person = ConvertPerson(attrArray);
            model.Voice = ConvertVoice(attrArray);
            model.Mood = ConvertMood(attrArray);
            model.Degree = ConvertDegree(attrArray);
            model.Feature = ConvertFeature(attrArray);
            model.Tense = ConvertTense(attrArray);

            model.Feature = !string.IsNullOrEmpty(model.Feature.Trim(',')) ? model.Feature.Trim(',') : null;
        }

        private static string ConvertTense(string[] attrArray)
        {
            if (attrArray.Contains("praes")) return "pres";
            if (attrArray.Contains("praet")) return "praet";
            if (attrArray.Contains("inpraes")) return "impraet";
            return null;
        }

        private static string ConvertFeature(string[] attrArray)
        {
            var result = string.Empty;
            //Adj
            if (attrArray.Contains("brev")) result += "brev,";
            if (attrArray.Contains("plen")) result += "plen,";
            if (attrArray.Contains("poss")) result += "poss,";
            //Verb
            if (attrArray.Contains("tran")) result += "tran,";
            if (attrArray.Contains("intr")) result += "intr,";

            if (attrArray.Contains("ipf")) result +=  "ipf,";
            if (attrArray.Contains("pf")) result +=  "pf,";

            //Noun
            if (attrArray.Contains("anim")) result +=  "anim,";
            if (attrArray.Contains("inan")) result +=  "inan,";

            //Other
            if (attrArray.Contains("parenth")) result +=  "parenth,"; //вводное слово
            if (attrArray.Contains("geo")) result +=  "geo,"; //географическое название
            if (attrArray.Contains("awkw")) result +=  "awkw,"; //образование формы затруднено
            if (attrArray.Contains("persn")) result +=  "persn,"; //имя собственное
            if (attrArray.Contains("dist")) result +=  "dist,"; //искаженная форма
            if (attrArray.Contains("obsc")) result +=  "obsc,"; //обсценная лексика
            if (attrArray.Contains("patrn")) result +=  "patrn,"; //отчество
            if (attrArray.Contains("praed")) result +=  "praed,"; //предикатив
            if (attrArray.Contains("inform")) result +=  "inform,"; //разговорная форма
            if (attrArray.Contains("rare")) result +=  "rare,"; //редко встречающееся слово
            if (attrArray.Contains("abbr")) result +=  "abbr,"; //сокращение
            if (attrArray.Contains("obsol")) result +=  "obsol,"; //устаревшая форма
            if (attrArray.Contains("famn")) result +=  "famn,";//фамилия
            return result;
        }

        private static string ConvertDegree(string[] attrArray)
        {
            if (attrArray.Contains("comp")) return "comp";
            if (attrArray.Contains("supr")) return "superl";
            return null;
        }

        private static string ConvertMood(string[] attrArray)
        {
            if (attrArray.Contains("imper")) return "imperat";
            if (attrArray.Contains("indic")) return "ind";
            if (attrArray.Contains("inf")) return "inf";
            if (attrArray.Contains("partcp")) return "part";
            if (attrArray.Contains("ger")) return "gerundive";

            return null;
        }

        private static string ConvertVoice(string[] attrArray)
        {
            if (attrArray.Contains("act")) return "act";
            if (attrArray.Contains("pass")) return "pass";

            return null;
        }

        private static string ConvertPerson(string[] attrArray)
        {
            if (attrArray.Contains("1p")) return "1st";
            if (attrArray.Contains("2p")) return "2nd";
            if (attrArray.Contains("3p")) return "3rd";

            return null;
        }

        private static string ConvertNumber(string[] attrArray)
        {
            if (attrArray.Contains("sg")) return "sg";
            if (attrArray.Contains("pl")) return "pl";

            return null;
        }

        private static string ConvertCase(string[] attrArray)
        {
            if (attrArray.Contains("nom")) return CaseEnum.Nomativus;
            if (attrArray.Contains("loc")) return CaseEnum.Genetivus;
            if (attrArray.Contains("gen")) return CaseEnum.Genetivus;
            if (attrArray.Contains("part")) return CaseEnum.Genetivus;
            if (attrArray.Contains("dat")) return CaseEnum.Dativus;
            if (attrArray.Contains("abl")) return CaseEnum.Ablativus;
            if (attrArray.Contains("ins")) return CaseEnum.Ablativus;
            if (attrArray.Contains("acc")) return CaseEnum.Accusativus;
            if (attrArray.Contains("voc")) return CaseEnum.Vocativus;

            return null;
        }

        private static string ConvertGender(string[] attrArray)
        {
            if (attrArray.Contains("m")) return GenderEnum.Masculinum;
            if (attrArray.Contains("f")) return GenderEnum.Femininum;
            if (attrArray.Contains("n")) return GenderEnum.Neutrum;
            if (attrArray.Contains("mf")) return GenderEnum.Commune;
            return null;
        }
    }
}
