using System.Collections.Generic;
using System.Linq;

namespace Model.Enum
{
    public class ConditionOperator
    {
        public static TaxonomyItem AND = new TaxonomyItem { Value = 0, Name = "И" };
        public static TaxonomyItem OR = new TaxonomyItem { Value = 1, Name = "ИЛИ" };
        public static TaxonomyItem NOT = new TaxonomyItem { Value = 2, Name = "НЕ" };
        public static TaxonomyItem CB = new TaxonomyItem { Value = 3, Name = ")" };
        public static TaxonomyItem OB = new TaxonomyItem { Value = 4, Name = "(" };
        public static List<TaxonomyItem> Items()
        {
            return new List<TaxonomyItem> {
                AND,
                OR,
                NOT,
                CB,
                OB
            };
        }

        public static TaxonomyItem GetItem(int value)
        {
            return Items().FirstOrDefault(i => i.Value == value);
        }

        public static TaxonomyItem GetItem(string name)
        {
            return Items().FirstOrDefault(i => i.Name == name);
        }
    }
}
