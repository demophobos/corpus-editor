using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    public class TaxonomyAPI : BaseAPI
    {
        public static async Task<List<TaxonomyModel>> GetTaxonomyItems(IQuery query)
        {
            try
            {
                List<TaxonomyModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"taxonomy-items?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<TaxonomyModel>>().ConfigureAwait(true);
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
