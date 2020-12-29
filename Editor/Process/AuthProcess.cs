using Model;
using System.Threading.Tasks;

namespace Process
{
    public class AuthProcess
    {
        public static UserModel User { get; set; }

        public static async Task<bool> Login(UserModel user)
        {
            var report = await API.AuthAPI.LoginAsync(user);

            if (report.status == 200)
            {
                User = API.AuthAPI.User;

                return true;
            }
            return false;
        }
    }
}
