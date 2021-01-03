using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class ElementProcess
    {
        public static async Task<List<ElementModel>> GetElements(string chunkId)
        {
            var query = new ElementByChunkQuery { chunkId = chunkId };

            return await API.ElementAPI.GetElements(query);
        }

        public static async Task<ElementModel> SaveModel(ElementModel element)
        {
            return await API.ElementAPI.Save(element);
        }
    }
}
