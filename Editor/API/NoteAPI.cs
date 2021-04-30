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
    public class NoteAPI : BaseAPI
    {
        public static async Task<List<NoteModel>> GetNotes(NoteQuery query)
        {
            try
            {
                List<NoteModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"notes?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<NoteModel>>().ConfigureAwait(true);
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

        public static async Task<NoteModel> Remove(NoteModel note)
        {
            try
            {
                NoteModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"notes/{note.Id}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<NoteModel>().ConfigureAwait(true);
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

        public static async Task<NoteModel> RemoveByQuery(NoteQuery query)
        {
            try
            {
                NoteModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"notes/{0}?params={query}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<NoteModel>().ConfigureAwait(true);
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

        public static async Task<NoteModel> Save(NoteModel note)
        {
            try
            {
                NoteModel report = null;

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(note.Id))
                {

                    response = await Client.PostAsJsonAsync("notes/", note).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"notes/{note.Id}", note).ConfigureAwait(true);
                }

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<NoteModel>().ConfigureAwait(true);
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
