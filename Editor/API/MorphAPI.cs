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
    public class MorphAPI: BaseAPI
    {
        public MorphAPI() : base()
        {

        }

        public static async Task<List<MorphModel>> GetMorphItems(IQuery query)
        {
            try
            {
                List<MorphModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"morph-items?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<MorphModel>>().ConfigureAwait(true);
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

        public static async Task<MorphModel> GetMorphItem(string id)
        {
            try
            {
                MorphModel report = null;

                HttpResponseMessage response = await Client.GetAsync($"morph-items/{id}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<MorphModel>().ConfigureAwait(true);
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

        public static async Task<MorphModel> Remove(MorphModel morph)
        {
            try
            {
                MorphModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"morph-items/{morph.Id}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<MorphModel>().ConfigureAwait(true);
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

        public static async Task<MorphModel> Save(MorphModel morph)
        {
            try
            {
                MorphModel report = null;

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(morph.Id))
                {

                    response = await Client.PostAsJsonAsync("morph-items/", morph).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"morph-items/{morph.Id}", morph).ConfigureAwait(true);
                }

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<MorphModel>().ConfigureAwait(true);
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
