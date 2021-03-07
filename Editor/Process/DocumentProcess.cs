using Model;
using Model.Query;
using Model.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Process
{
    public class DocumentProcess
    {
        public HeaderModel Header { get; private set; }

        public List<IndexModel> Indeces { get; set; }
        public DocumentProcess(HeaderModel header)
        {
            Header = header;

            Indeces = new List<IndexModel>();
        }

        public async Task<List<IndexModel>> GetIndecesByName(string name)
        {
            var query = new IndexQuery { HeaderId = Header.Id, Name = name };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<List<IndexModel>> GetIndecesByHeader()
        {
            var query = new IndexQuery { HeaderId = Header.Id };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<List<IndexModel>> GetIndecesByHeader(string headerId)
        {
            var query = new IndexQuery { HeaderId = headerId };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<List<ChunkViewModel>> GetChunksByHeader()
        {
            var query = new ChunkQuery { HeaderId = Header.Id };

            return await API.ChunkAPI.GetChunksByQuery(query);
        }

        public async Task<List<IndexModel>> GetIndecesByParent(string parentId)
        {
            var query = new IndexQuery { ParentId = parentId };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<IndexModel> SaveIndex(IndexModel index)
        {
            return await API.IndexAPI.Save(index);
        }

        public async Task<IndexModel> DeleteIndex(IndexModel index)
        {
            return await API.IndexAPI.Remove(index);
        }

        public async Task<HeaderModel> DeleteHeader(HeaderModel header)
        {
            return await API.HeaderAPI.Remove(header);
        }

        public async Task<List<InterpViewModel>> GetInterpsByQuery(InterpQuery query)
        {
            return await API.InterpAPI.GetInterps(query);
        }

        public async Task<InterpModel> SaveInterp(InterpModel interp)
        {
            return await API.InterpAPI.Save(interp);
        }

        public async Task<InterpModel> DeleteInterp(InterpModel interp)
        {
            return await API.InterpAPI.Remove(interp);
        }

        public async Task<ChunkModel> DeleteChunksByQuery(ChunkQuery query)
        {
            return await API.ChunkAPI.RemoveByQuery(query);
        }

        public async Task<ElementModel> DeleteElementsByQuery(ElementQuery query)
        {
            return await API.ElementAPI.RemoveByQuery(query);
        }

        public async Task<InterpModel> DeleteInterpsByQuery(InterpQuery query)
        {
            return await API.InterpAPI.RemoveByQuery(query);
        }

        public async Task<IndexModel> DeleteIndecesByQuery(IndexQuery query)
        {
            return await API.IndexAPI.RemoveByQuery(query);
        }

    }
}
