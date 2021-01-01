using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class ChunkProcess
    {
        public static async Task<ChunkModel> GetChunk(string indextId)
        {
            var query = new ChunkByIndexQuery { indexId = indextId };

            return await API.ChunkAPI.GetChunk(query);
        }

        public static async Task<ChunkModel> RemoveChunk(ChunkModel chunk)
        {
            return await API.ChunkAPI.Remove(chunk);
        }

        public static async Task<ChunkModel> SaveChunk(ChunkModel chunk)
        {
            return await API.ChunkAPI.Save(chunk);
        }
    }
}
