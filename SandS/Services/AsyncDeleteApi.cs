using SandS.Resource;
using System;
using System.Net.Http;

namespace SandS.Services
{
    public class AsyncDeleteApi
    {
        public static void Delete(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{GloabalValues.ApiBaseUrl}");
            client.DeleteAsync($"{url}?api_token={GloabalValues.ApiToken}");
        }
    }
}
