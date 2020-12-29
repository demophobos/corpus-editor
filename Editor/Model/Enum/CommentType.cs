using System.Collections.Generic;
using System.Linq;

namespace Model.Enum
{
    public static class CommentType
    {
        public static TaxonomyItem Real = new TaxonomyItem { Value = 0, Name = "Реальный" };
        public static TaxonomyItem Linguistical = new TaxonomyItem { Value = 1, Name = "Лингвистический" };
        public static TaxonomyItem Critical = new TaxonomyItem { Value = 2, Name = "Критический" };
        public static TaxonomyItem Vocabulary = new TaxonomyItem { Value = 3, Name = "Словарь" };
        public static TaxonomyItem Dubio = new TaxonomyItem { Value = 4, Name = "Сомнительно" };
        public static List<TaxonomyItem> Items()
        {
            return new List<TaxonomyItem> {
                Real,
                Linguistical,
                //Vocabulary,
                //Critical,
                Dubio
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
