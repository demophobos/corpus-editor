using Model;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Process
{
    public class TaxonomyProcess
    {
        public static List<TaxonomyItem> GetContextTypes(List<string> values)
        {
            return values.Select(i => new TaxonomyItem
            {
                Name = i
            }).ToList();
        }

        public static List<TaxonomyItem> GetMorphCategories()
        {
            var list = new List<TaxonomyItem>
            {
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Pos.ToString(),
                    Value = (int)MorphCategoryEnum.Pos
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Case.ToString(),
                    Value = (int)MorphCategoryEnum.Case
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Degree.ToString(),
                    Value = (int)MorphCategoryEnum.Degree
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Dialect.ToString(),
                    Value = (int)MorphCategoryEnum.Dialect
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Feature.ToString(),
                    Value = (int)MorphCategoryEnum.Feature
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Gender.ToString(),
                    Value = (int)MorphCategoryEnum.Gender
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Lang.ToString(),
                    Value = (int)MorphCategoryEnum.Lang
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Mood.ToString(),
                    Value = (int)MorphCategoryEnum.Mood
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Number.ToString(),
                    Value = (int)MorphCategoryEnum.Number
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Person.ToString(),
                    Value = (int)MorphCategoryEnum.Person
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Tense.ToString(),
                    Value = (int)MorphCategoryEnum.Tense
                },
                new TaxonomyItem
                {
                    Name = MorphCategoryEnum.Voice.ToString(),
                    Value = (int)MorphCategoryEnum.Voice
                }
            };

            return list;
        }

        public static List<TaxonomyItem> GetMorphCategoryItems(MorphCategoryEnum morphCategory)
        {
            var list = new List<TaxonomyItem>();
            switch (morphCategory)
            {
                case MorphCategoryEnum.Pos:
                    return CatList(new string[] { "adj",
                                                    "adv",
                                                    "conj",
                                                    "exclam",
                                                    "noun",
                                                    "numeral",
                                                    "part",
                                                    "prep",
                                                    "pron",
                                                    "verb"});
                case MorphCategoryEnum.Gender:
                    return CatList(new string[] { "fem",
                                                    "masc",
                                                    "neut" });
                case MorphCategoryEnum.Case:
                    return CatList(new string[] {  "abl",
                                                    "acc",
                                                    "dat",
                                                    "gen",
                                                    "nom",
                                                    "voc" });
                case MorphCategoryEnum.Dialect:
                    return CatList(new string[] { string.Empty, "poetic" });
                case MorphCategoryEnum.Person:
                    return CatList(new string[] { "1st",
                                                    "2nd",
                                                    "3rd" });
                case MorphCategoryEnum.Number:
                    return CatList(new string[] { "sg",
                                                    "pl" });
                case MorphCategoryEnum.Tense:
                    return CatList(new string[] { "fut",
                                                    "futperf",
                                                    "imperf",
                                                    "perf",
                                                    "plup",
                                                    "pres" });
                case MorphCategoryEnum.Mood:
                    return CatList(new string[] { "gerundive",
                                                    "imperat",
                                                    "ind",
                                                    "inf",
                                                    "subj",
                                                    "supine" });
                case MorphCategoryEnum.Voice:
                    return CatList(new string[] { "act",
                                                    "pass" });
                case MorphCategoryEnum.Degree:
                    return CatList(new string[] { "comp",
                                                    "superl" });
                case MorphCategoryEnum.Lang:
                    return CatList(new string[] { "lat",
                                                    "grc",
                                                    "rus" });
                default:
                    return list;
            }
        }

        public static List<TaxonomyItem> GetHeaderCodes()
        {
            var list = new List<TaxonomyItem>
            {
                new TaxonomyItem { Name = "Sen. Ep." },
                new TaxonomyItem { Name = "Plin. Ep." },
                new TaxonomyItem { Name = "Plin. Pan." },
                new TaxonomyItem { Name = "Cic. de Orat." },
                new TaxonomyItem { Name = "Cic. Amic." },
                new TaxonomyItem { Name = "Phaedr." },
                new TaxonomyItem { Name = "Caes. Gal." },
                new TaxonomyItem { Name = "Apul. Met." },
                new TaxonomyItem { Name = "Apul. Fl." },
                new TaxonomyItem{ Name = "Apul. Apol."},
                new TaxonomyItem{ Name = "Plat. Phaedr."}
            };
            return list.OrderBy(i => i.Name).ToList();
        }

        public static List<TaxonomyItem> GetEditionTypes()
        {
            return new List<TaxonomyItem> {
                new TaxonomyItem { Name = Enum.GetName(typeof(EditionTypeEnum), EditionTypeEnum.Original), Value =  (int)EditionTypeEnum.Original},
                new TaxonomyItem { Name = Enum.GetName(typeof(EditionTypeEnum), EditionTypeEnum.Interpretation), Value =  (int)EditionTypeEnum.Interpretation }
            };
        }

        public static List<TaxonomyItem> GetEditionTypesString()
        {
            return new List<TaxonomyItem> {
                new TaxonomyItem { Name = EditionTypeStringEnum.Original },
                new TaxonomyItem { Name = EditionTypeStringEnum.Interpretation }
            };
        }

        public static List<TaxonomyItem> GetLanguages()
        {
            return new List<TaxonomyItem> {
                new TaxonomyItem { Name = LangStringEnum.Latin },
                new TaxonomyItem { Name = LangStringEnum.Greek },
                new TaxonomyItem { Name = LangStringEnum.Russian }
            };
        }

        private static List<TaxonomyItem> CatList(string[] items)
        {
            var list = new List<TaxonomyItem>();

            foreach (var item in items)
            {
                list.Add(new TaxonomyItem
                {
                    Name = item
                });
            }

            return list;
        }

        private static List<TaxonomyItem> PosList()
        {
            var list = new List<TaxonomyItem>
            {
                new TaxonomyItem
                {
                    Name = "adj"
                },
                new TaxonomyItem
                {
                    Name = "adv"
                },
                new TaxonomyItem
                {
                    Name = "conj"
                },
                new TaxonomyItem
                {
                    Name = "exclam"
                },
                new TaxonomyItem
                {
                    Name = "noun"
                },
                new TaxonomyItem
                {
                    Name = "numeral"
                },
                new TaxonomyItem
                {
                    Name = "part"
                },
                new TaxonomyItem
                {
                    Name = "prep"
                },
                new TaxonomyItem
                {
                    Name = "pron"
                },
                new TaxonomyItem
                {
                    Name = "verb"
                }
            };

            return list;
        }
    }
}
