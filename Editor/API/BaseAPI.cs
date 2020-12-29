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
            if (Client == null)
            {
                Client = new HttpClient
                {
                    BaseAddress = new Uri(@"http://localhost:3000/v1/")
                };
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Client.DefaultRequestHeaders.Add("x-access-token", AuthAPI.User.Token);
            }
        }
    }
}
