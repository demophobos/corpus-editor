using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    public class ProjectAPI : BaseAPI
    {
        public ProjectAPI() : base()
        {

        }

        public static async Task<List<ProjectModel>> FindByQuery()
        {
            try
            {
                List<ProjectModel> report = null;

                HttpResponseMessage response = await Client.GetAsync($"projects?params={new ProjectQuery { creatorId = AuthAPI.User.Id }}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<List<ProjectModel>>().ConfigureAwait(true);
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
        public static async Task<ProjectModel> FindOne(string id)
        {
            try
            {
                ProjectModel report = null;

                HttpResponseMessage response = await Client.GetAsync($"projects/{id}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<ProjectModel>().ConfigureAwait(true);
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
        public static async Task<ProjectModel> Save(ProjectModel project)
        {
            try
            {
                ProjectModel report = null;

                HttpResponseMessage response;

                if (string.IsNullOrEmpty(project.Id))
                {
                    project.CreatorId = AuthAPI.User.Id;
                    project.Created = DateTime.Now;

                    response = await Client.PostAsJsonAsync("projects/", project).ConfigureAwait(true);
                }
                else
                {
                    response = await Client.PutAsJsonAsync($"projects/{project.Id}", project).ConfigureAwait(true);
                }

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<ProjectModel>().ConfigureAwait(true);
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

        public static async Task<ProjectModel> Remove(ProjectModel project)
        {
            try
            {
                ProjectModel report = null;

                HttpResponseMessage response = await Client.DeleteAsync($"projects/{project.Id}").ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<ProjectModel>().ConfigureAwait(true);
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
