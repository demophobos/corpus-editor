using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class MorpheusAPI
    {
        public static async Task<string> GetLatinWordAnalysis(string lexema)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://www.perseus.tufts.edu/hopper/");

                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

                try
                {

                    string report;

                    HttpResponseMessage response = await httpClient.GetAsync("xmlmorph?lang=la&lookup=" + lexema).ConfigureAwait(true);

                    if (response.IsSuccessStatusCode)
                    {
                        report = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
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
}
