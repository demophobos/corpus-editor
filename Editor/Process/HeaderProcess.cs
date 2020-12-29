using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Process
{
    public class HeaderProcess
    {
        public static async Task<List<HeaderModel>> GetHeaders(string projectId)
        {
            return await API.HeaderAPI.GetHeaders(projectId);
        }

        public static async Task<HeaderModel> RemoveHeader(HeaderModel header)
        {
            return await API.HeaderAPI.Remove(header);
        }

        public static async Task<HeaderModel> SaveHeader(HeaderModel header)
        {
            return await API.HeaderAPI.Save(header);
        }
    }
}
