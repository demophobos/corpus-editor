using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    public class ElementAPI : BaseAPI
    {
        public static async Task<List<ElementModel>> GetElements(IQuery query)
        {
            try
            {
                List<ElementModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"elements?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<ElementModel>>().ConfigureAwait(true);
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

        public static async Task<ElementModel> Save(ElementModel element)
        {
            try
            {
                ElementModel report = null;

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(element.Id))
                {

                    response = await Client.PostAsJsonAsync("elements/", element).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"elements/{element.Id}", element).ConfigureAwait(true);
                }

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<ElementModel>().ConfigureAwait(true);
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
