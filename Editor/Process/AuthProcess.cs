using Model;
using System.Threading.Tasks;

namespace Process
{
    public class AuthProcess
    {
        public static UserModel User { get; set; }

        public static async Task<bool> Login(UserModel user, string url)
        {
            var report = await API.AuthAPI.LoginAsync(user, url);

            if (report.status == 200)
            {
                User = API.AuthAPI.User;

                return true;
            }
            return false;
        }
    }
}
