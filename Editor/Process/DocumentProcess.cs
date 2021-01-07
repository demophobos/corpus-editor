using Model;
using Model.Enum;
using Model.Query;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Process
{
    public class DocumentProcess
    {
        public HeaderModel Header { get; private set; }
        public DocumentProcess(HeaderModel header)
        {
            Header = header;
        }

        public async Task<List<IndexModel>> GetIndecesByName(string name)
        {
            var query = new IndexQuery { headerId = Header.Id, name = name };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<List<IndexModel>> GetIndecesByHeader()
        {
            var query = new IndexQuery { headerId = Header.Id };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<List<IndexModel>> GetIndecesByHeader(string headerId)
        {
            var query = new IndexQuery { headerId = headerId };

            return await API.IndexAPI.GetIndeces(query);
        }

        public async Task<List<IndexModel>> GetIndecesByParent(string parentId)
        {
            var query = new IndexQuery { parentId = parentId };

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

        public async Task<List<InterpModel>> GetInterpsBySource(string chunkId) {

            var query = new InterpQuery { sourceId = chunkId };

            return await API.InterpAPI.GetInterps(query);
        }

        public async Task<List<InterpModel>> GetInterpsByInterp(string chunkId)
        {

            var query = new InterpQuery { interpId = chunkId };

            return await API.InterpAPI.GetInterps(query);
        }

        public async Task<InterpModel> SaveInterp(InterpModel interp)
        {
            return await API.InterpAPI.Save(interp);
        }

        public async Task<List<ChunkModel>> LoadJsonChunks(string fileName)
        {
            var chunks = new List<ChunkModel>();

            JObject data = JObject.Parse(File.ReadAllText(fileName));

            foreach (var row in data["rows"])
            {
                var indeces = await GetIndecesByName(row[1].ToString()).ConfigureAwait(true);

                if (indeces.Count == 1)
                {
                    var index = indeces[0];

                    var chunk = await ChunkProcess.GetChunk(index.Id);

                    if (chunk == null)
                    {
                        var newChunk = new ChunkModel
                        {
                            IndexId = index.Id,
                            Value = row[2].ToString()
                        };

                        var savedChunk = await ChunkProcess.SaveChunkAndElements(newChunk).ConfigureAwait(true);

                        chunks.Add(savedChunk);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            return chunks;
        }

        public async Task<List<InterpModel>> BindInterps()
        {
            var projectHeaders = await HeaderProcess.GetHeaders(Header.ProjectId).ConfigureAwait(true);

            var interps = projectHeaders.Where(i => i.EditionType == EditionTypeStringEnum.Interpretation);

            foreach (var header in interps)
            {
                var query = new IndexQuery { headerId = header.Id };

                var indeces = await API.IndexAPI.GetIndeces(query).ConfigureAwait(true);


            }

            return new List<InterpModel>();
        }
    }
}
