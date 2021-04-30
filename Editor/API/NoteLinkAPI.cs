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
    public class NoteLinkAPI: BaseAPI
    {
        public static async Task<List<NoteLinkModel>> GetNoteLinks(NoteLinkQuery query)
        {
            try
            {
                List<NoteLinkModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"note-links?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<NoteLinkModel>>().ConfigureAwait(true);
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

        public static async Task<NoteLinkModel> RemoveByQuery(NoteLinkQuery query)
        {
            try
            {
                NoteLinkModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"note-links/{0}?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<NoteLinkModel>().ConfigureAwait(true);
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

        public static async Task<NoteLinkModel> Remove(NoteLinkModel note)
        {
            try
            {
                NoteLinkModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"note-links/{note.Id}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<NoteLinkModel>().ConfigureAwait(true);
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

        public static async Task<NoteLinkModel> Save(NoteLinkModel note)
        {
            try
            {
                NoteLinkModel report = null;

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(note.Id))
                {

                    response = await Client.PostAsJsonAsync("note-links/", note).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"note-links/{note.Id}", note).ConfigureAwait(true);
                }

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<NoteLinkModel>().ConfigureAwait(true);
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
