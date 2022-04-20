using SandS.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
