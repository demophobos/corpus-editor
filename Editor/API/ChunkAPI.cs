using Model;
using Model.Query;
using Model.View;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    public class ChunkAPI : BaseAPI
    {
        public static async Task<ChunkViewModel> GetChunkByQuery(IQuery query)
        {
            try
            {
                List<ChunkViewModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"chunks?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<ChunkViewModel>>().ConfigureAwait(true);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }

                return report.Count > 0 ? report[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<List<ChunkViewModel>> GetChunksByQuery(ChunkQuery query)
        {
            try
            {
                List<ChunkViewModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"chunks?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<ChunkViewModel>>().ConfigureAwait(true);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }

                return report;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<ChunkModel> GetChunk(string chunkId)
        {
            try
            {
                ChunkModel report = null;

                HttpResponseMessage response = await Client.GetAsync($"chunks/{chunkId}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<ChunkModel>().ConfigureAwait(true);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }

                return report;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<ChunkModel> Remove(ChunkModel chunk)
        {
            try
            {
                ChunkModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"chunks/{chunk.Id}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<ChunkModel>().ConfigureAwait(true);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }

                return report;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<ChunkModel> Save(ChunkModel chunk)
        {
            try
            {
                ChunkModel report = null;

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(chunk.Id))
                {

                    response = await Client.PostAsJsonAsync("chunks/", chunk).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"chunks/{chunk.Id}", chunk).ConfigureAwait(true);
                }

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<ChunkModel>().ConfigureAwait(true);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }

                return report;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
