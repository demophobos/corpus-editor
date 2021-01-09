using Model;
using Model.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Process
{
    public class ProjectProcess
    {
        public static async Task<List<ProjectModel>> GetProjects(ProjectQuery query)
        {
            return await API.ProjectAPI.FindByQuery(query);
        }

        public static async Task<ProjectModel> RemoveProject(ProjectModel project)
        {
            return await API.ProjectAPI.Remove(project);
        }

        public static async Task<ProjectModel> Save(ProjectModel project)
        {
            return await API.ProjectAPI.Save(project);
        }

        public static async Task<ProjectModel> GetProject(string projectId)
        {
            return await API.ProjectAPI.FindOne(projectId);
        }
    }
}
