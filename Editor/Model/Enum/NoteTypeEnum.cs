using System.Collections.Generic;
using System.Linq;

namespace Model.Enum
{
    public class NoteTypeEnum
    {
        public static TaxonomyModel Real = new TaxonomyModel { Id = "0", Code = "Реальный" };
        public static TaxonomyModel Linguistic = new TaxonomyModel { Id = "1", Code = "Лингвистический" };
        public static TaxonomyModel Critical = new TaxonomyModel { Id = "2", Code = "Критический" };

        public static TaxonomyModel GetById(string id)
        {
            var list = new List<TaxonomyModel>
            {
                Real,
                Linguistic,
                Critical
            };

            return list.FirstOrDefault(i => i.Id == id);
        }
    }
}
