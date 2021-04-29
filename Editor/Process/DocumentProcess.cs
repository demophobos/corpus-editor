using API;
using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Process
{
    public class DocumentProcess
    {
        public HeaderModel Header { get; private set; }
        public List<IndexModel> Indeces { get; set; }
        public List<NoteModel> Notes { get; set; }
        public DocumentProcess(HeaderModel header)
        {
            Header = header;

            Indeces = new List<IndexModel>();

            Notes = new List<NoteModel>();
        }

        public async Task<List<IndexModel>> GetIndecesByName(string name)
        {
            var query = new IndexQuery { HeaderId = Header.Id, Name = name };

            return await IndexAPI.GetIndeces(query);
        }

        public async Task<List<IndexModel>> GetIndecesByHeader()
        {
            var query = new IndexQuery { HeaderId = Header.Id };

            return await IndexAPI.GetIndeces(query);
        }

        public async Task<List<IndexModel>> GetIndecesByHeader(string headerId)
        {
            var query = new IndexQuery { HeaderId = headerId };

            return await IndexAPI.GetIndeces(query);
        }

        public async Task<List<NoteModel>> GetNotesByHeader()
        {
            var query = new NoteQuery { HeaderId = Header.Id };

            Notes = await NoteAPI.GetNotes(query);

            return Notes;
        }

        public async Task<List<ChunkViewModel>> GetChunksByHeader()
        {
            var query = new ChunkQuery { HeaderId = Header.Id };

            return await ChunkAPI.GetChunksByQuery(query);
        }

        public async Task<List<ChunkViewModel>> GetChunksByHeader(string chunkStatus)
        {
            var query = new ChunkQuery { HeaderId = Header.Id, Status = chunkStatus };

            return await ChunkAPI.GetChunksByQuery(query);
        }

        public async Task<List<ChunkViewModel>> GetChunksByHeader(HeaderModel header)
        {
            var query = new ChunkQuery { HeaderId = header.Id };

            return await ChunkAPI.GetChunksByQuery(query);
        }

        public async Task<List<IndexModel>> GetIndecesByParent(string parentId)
        {
            var query = new IndexQuery { ParentId = parentId };

            return await IndexAPI.GetIndeces(query);
        }

        public async Task<IndexModel> SaveIndex(IndexModel index)
        {
            return await IndexAPI.Save(index);
        }

        public async Task<IndexModel> DeleteIndex(IndexModel index)
        {
            return await IndexAPI.Remove(index);
        }

        public async Task<HeaderModel> DeleteHeader(HeaderModel header)
        {
            return await HeaderAPI.Remove(header);
        }

        public async Task<List<InterpViewModel>> GetInterpsByQueryView(InterpViewQuery query)
        {
            return await InterpAPI.GetInterpsView(query);
        }

        public async Task<List<InterpModel>> GetInterpsByQueryTable(InterpTableQuery query)
        {
            return await InterpAPI.GetInterpsTable(query);
        }

        public async Task<InterpModel> SaveInterp(InterpModel interp)
        {
            return await InterpAPI.Save(interp);
        }

        public async Task<InterpModel> DeleteInterp(InterpModel interp)
        {
            return await InterpAPI.Remove(interp);
        }

        public async Task<ChunkModel> DeleteChunksByQuery(ChunkQuery query)
        {
            return await ChunkAPI.RemoveByQuery(query);
        }

        public async Task<ElementModel> DeleteElementsByQuery(ElementQuery query)
        {
            return await ElementAPI.RemoveByQuery(query);
        }

        public async Task<InterpModel> DeleteInterpsByQuery(InterpViewQuery query)
        {
            return await InterpAPI.RemoveByQuery(query);
        }

        public async Task<IndexModel> DeleteIndecesByQuery(IndexQuery query)
        {
            return await IndexAPI.RemoveByQuery(query);
        }

    }
}
