using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class InterpAPI : BaseAPI
    {
        public InterpAPI() : base()
        {

        }

        public static async Task<List<InterpModel>> GetInterps(IQuery query)
        {
            try
            {
                List<InterpModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"interps?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<InterpModel>>().ConfigureAwait(true);
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

        public static async Task<InterpModel> Save(InterpModel interp)
        {
            try
            {
                InterpModel report = null;

                HttpResponseMessage response = await Client.PostAsJsonAsync("interps/", interp).ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<InterpModel>().ConfigureAwait(true);
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

        public static async Task<InterpModel> Remove(InterpModel header)
        {
            try
            {
                InterpModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync("interps/" + header.Id).ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<InterpModel>().ConfigureAwait(true);
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
