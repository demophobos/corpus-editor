using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class MorphProcess
    {
        public async Task<List<MorphModel>> GetMorphItems(MorphQuery query)
        {
            return await API.MorphAPI.GetMorphItems(query);
        }

        public async Task<MorphModel> GetMorphItem(string id)
        {
            return await API.MorphAPI.GetMorphItem(id);
        }

        public async Task<MorphModel> SaveMorph(MorphModel morph)
        {
            return await API.MorphAPI.Save(morph);
        }

        public async Task<MorphModel> DeleteMorph(MorphModel morph)
        {
            return await API.MorphAPI.Remove(morph);
        }
    }
}
