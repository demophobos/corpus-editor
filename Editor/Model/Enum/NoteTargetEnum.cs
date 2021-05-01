using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enum
{
    public class NoteTargetEnum
    {
        public static TaxonomyModel Words = new TaxonomyModel { Id = "0", Code = "Слова" };
        public static TaxonomyModel Chunk = new TaxonomyModel { Id = "1", Code = "Фрагмент" };

        public static TaxonomyModel GetById(string id) {
            var list = new List<TaxonomyModel>
            {
                Words,
                Chunk
            };

            return list.FirstOrDefault(i => i.Id == id);
        } 
    }
}
