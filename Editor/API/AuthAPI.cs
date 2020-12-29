using Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API
{
    public class AuthAPI
    {
        public static UserModel User { get; private set; }

        private static HttpClient _anonymousClient;

        private static void createAnonymousClient()
        {
            if (_anonymousClient == null)
            {
                _anonymousClient = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:3000/")
                };
                _anonymousClient.DefaultRequestHeaders.Accept.Clear();
                _anonymousClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

        }

        public static async Task<AuthResponseModel> LoginAsync(UserModel user)
        {

            createAnonymousClient();

            try
            {
                AuthResponseModel report = null;

                HttpResponseMessage response = await _anonymousClient.PostAsJsonAsync("auth/login/", user).ConfigureAwait(true);

                if (response.IsSuccessStatusCode)
                {
                    report = await response.Content.ReadAsAsync<AuthResponseModel>().ConfigureAwait(true);

                    if (report.status == 200)
                    {
                        User = report.user;
                        User.Token = report.token;
                        APIRegister.InitAPIs();
                    }
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
