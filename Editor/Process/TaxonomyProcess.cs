using API;
using Model;
using Model.Enum;
using Model.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Process
{
    public class TaxonomyProcess
    {
        public static List<TaxonomyModel> GetMorphServices()
        {
            return new List<TaxonomyModel> {
            MophServiceEnum.MorpheusLat,
            MophServiceEnum.MorpheusGrc,
            MophServiceEnum.MyStem
            };
        }

        public static List<TaxonomyModel> GetNoteTypes() {
            return new List<TaxonomyModel>
            {
                NoteTypeEnum.Real,
                NoteTypeEnum.Linguistic,
                NoteTypeEnum.Critical
            };
        }

        public static List<TaxonomyModel> GetNoteTargets()
        {
            return new List<TaxonomyModel>
            {
                NoteTargetEnum.Words,
                NoteTargetEnum.Chunk
            };
        }

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
