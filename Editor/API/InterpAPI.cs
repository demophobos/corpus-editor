using Model;
using Model.Query;
using Model.View;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    public class InterpAPI : BaseAPI
    {
        public InterpAPI() : base()
        {

        }

        public static async Task<List<InterpViewModel>> GetInterps(InterpQuery query)
        {
            try
            {
                List<InterpViewModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"interps?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<InterpViewModel>>().ConfigureAwait(true);
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

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(interp.Id))
                {

                    response = await Client.PostAsJsonAsync("interps/", interp).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"interps/{interp.Id}", interp).ConfigureAwait(true);
                }

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

        public static async Task<InterpModel> Remove(InterpModel interp)
        {
            try
            {
                InterpModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync("interps/" + interp.Id).ConfigureAwait(true);

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

        public static async Task<InterpModel> RemoveByQuery(InterpQuery query)
        {
            try
            {
                InterpModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"interps/{0}?params={query}").ConfigureAwait(true);

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
