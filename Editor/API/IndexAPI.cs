using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    public class IndexAPI : BaseAPI
    {
        public IndexAPI() : base()
        {

        }

        public static async Task<List<IndexModel>> GetIndeces(IQuery query)
        {
            try
            {
                List<IndexModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"indeces?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<IndexModel>>().ConfigureAwait(true);
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

        public static async Task<IndexModel> Remove(IndexModel index)
        {
            try
            {
                IndexModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"indeces/{index.Id}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<IndexModel>().ConfigureAwait(true);
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

        public static async Task<IndexModel> Save(IndexModel index)
        {
            try
            {
                IndexModel report = null;

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(index.Id))
                {

                    response = await Client.PostAsJsonAsync("indeces/", index).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"indeces/{index.Id}", index).ConfigureAwait(true);
                }

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<IndexModel>().ConfigureAwait(true);
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
