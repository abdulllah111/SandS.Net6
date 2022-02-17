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
    public static class AsyncPostApi<T>
    {
        private static HttpClient client = new HttpClient();
        public static void Post(string url, object model)
        {
            if (!string.IsNullOrEmpty(url))
            {
                client.BaseAddress = new Uri($"{GloabalValues.ApiBaseUrl}");
                client.PostAsJsonAsync(url, model);
            }
        }
    }
}
