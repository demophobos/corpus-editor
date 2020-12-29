using System.Collections.Generic;
using System.Linq;

namespace Model.Enum
{
    public class MorphRuleMatchType
    {
        public static TaxonomyItem Full = new TaxonomyItem { Value = 0, Name = "Полное" };
        public static TaxonomyItem StartsWith = new TaxonomyItem { Value = 1, Name = "Начинается с" };
        public static TaxonomyItem EndsWith = new TaxonomyItem { Value = 1, Name = "Заканчивается на" };
        public static List<TaxonomyItem> Items()
        {
            return new List<TaxonomyItem> {
                Full,
                StartsWith,
                EndsWith
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
