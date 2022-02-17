using SandS.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Services
{
    public static class AsyncDeleteApi
    {
        private static HttpClient client = new HttpClient();
        public static void Delete(string url)
        {
            client.BaseAddress = new Uri($"{GloabalValues.ApiBaseUrl}");
            client.DeleteAsync(url);
        }
    }
}
