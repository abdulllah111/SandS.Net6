using SandS.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Services
{
    public static class AsyncPostApi
    {
        public static async Task Post(string url, object model)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{GloabalValues.ApiBaseUrl}");
            await client.PostAsJsonAsync($"{url}", model);
        }
    }
}
