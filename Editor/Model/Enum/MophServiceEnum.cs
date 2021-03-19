using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enum
{
    public class MophServiceEnum
    {
        public static TaxonomyModel MorpheusLat = new TaxonomyModel { Id = "lat", Code = "Латинская морфология [Morpheus]", Desc = "Morpheus" };
        public static TaxonomyModel MorpheusGrc = new TaxonomyModel { Id = "grc",  Code = "Греческая морфология [Morpheus]", Desc = "Morpheus" };
        public static TaxonomyModel MyStem = new TaxonomyModel { Id = "rus", Code = "Русская морфология [MyStem]", Desc = "MyStem" };
    }
}
