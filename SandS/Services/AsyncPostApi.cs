using SandS.Resource;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SandS.Services
{
    public static class AsyncPostApi
    {
        public static async Task Post(string url, object model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{GloabalValues.ApiBaseUrl}");
            await client.PostAsJsonAsync($"{url}?api_token={GloabalValues.ApiToken}", model);
        }
    }
}
