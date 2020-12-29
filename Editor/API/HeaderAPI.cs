using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    public class HeaderAPI : BaseAPI
    {
        public HeaderAPI() : base()
        {

        }
        public static async Task<List<HeaderModel>> GetHeaders(string projectId)
        {
            try
            {
                List<HeaderModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"headers?params={new HeaderQuery { projectId = projectId }}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<HeaderModel>>().ConfigureAwait(true);
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

        public static async Task<HeaderModel> Save(HeaderModel header)
        {
            try
            {
                HeaderModel report = null;

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(header.Id))
                {

                    response = await Client.PostAsJsonAsync("headers/", header).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"headers/{header.Id}", header).ConfigureAwait(true);
                }

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<HeaderModel>().ConfigureAwait(true);
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

        public static async Task<HeaderModel> Remove(HeaderModel header)
        {
            try
            {
                HeaderModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync("headers/" + header.Id).ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<HeaderModel>().ConfigureAwait(true);
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
