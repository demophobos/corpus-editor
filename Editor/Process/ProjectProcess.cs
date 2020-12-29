using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Process
{
    public class ProjectProcess
    {
        public static async Task<List<ProjectModel>> GetProjects()
        {
            return await API.ProjectAPI.FindByQuery();
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
