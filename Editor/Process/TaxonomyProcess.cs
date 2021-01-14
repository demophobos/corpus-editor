using API;
using Model;
using Model.Enum;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Process
{
    public class TaxonomyProcess
    {

        public static async Task<List<TaxonomyModel>> GetAuthWorks()
        {
            return await TaxonomyAPI.GetTaxonomyItems(new TaxonomyQuery { CategoryCode = TaxonomyCategoryEnum.AuthWork });
        }

        public static async Task<List<TaxonomyModel>> GetEditionTypes()
        {
            return await TaxonomyAPI.GetTaxonomyItems(new TaxonomyQuery { CategoryCode = TaxonomyCategoryEnum.EditionType });
        }

        public static async Task<List<TaxonomyModel>> GetPos()
        {
            return await TaxonomyAPI.GetTaxonomyItems(new TaxonomyQuery { CategoryCode = TaxonomyCategoryEnum.Pos });
        }


        public static async Task<List<TaxonomyModel>> GetPosAttributes()
        {
            return await TaxonomyAPI.GetTaxonomyItems(new TaxonomyQuery { CategoryCode = TaxonomyCategoryEnum.PosAttribute });
        }

        public static async Task<List<TaxonomyModel>> GetPosAttributeValues(string attributeCode)
        {
            return await TaxonomyAPI.GetTaxonomyItems(new TaxonomyQuery { CategoryCode = attributeCode });
        }

        public static async Task<List<TaxonomyModel>> GetLanguages()
        {
            return await TaxonomyAPI.GetTaxonomyItems(new TaxonomyQuery { CategoryCode = TaxonomyCategoryEnum.Language });
        }
    }
}
