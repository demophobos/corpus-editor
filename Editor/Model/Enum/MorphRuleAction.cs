using System.Collections.Generic;
using System.Linq;

namespace Model.Enum
{
    public class MorphRuleAction
    {
        public static TaxonomyItem AcceptMorphDefinition = new TaxonomyItem { Value = 0, Name = "Принять" };
        public static TaxonomyItem RejectMorphDefinition = new TaxonomyItem { Value = 1, Name = "Отменить" };
        public static List<TaxonomyItem> Items()
        {
            return new List<TaxonomyItem> {
                AcceptMorphDefinition,
                RejectMorphDefinition
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
