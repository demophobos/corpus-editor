using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace API
{
    public class BaseAPI
    {
        protected static HttpClient Client;
        public BaseAPI()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(Properties.Settings.Default.APIBaseUrl)
            };

            Client.DefaultRequestHeaders.Accept.Clear();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Client.DefaultRequestHeaders.Add("x-access-token", AuthAPI.User.Token);
        }
    }
}
