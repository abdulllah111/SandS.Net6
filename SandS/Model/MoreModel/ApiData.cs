using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SandS.Model.MoreModel
{
    internal static class ApiData<T>
    {
        private static HttpClient cl = new HttpClient();
        public static async Task<T> Get(string url)
        {
            var streamTask = cl.GetStreamAsync(url);
            var data = await JsonSerializer.DeserializeAsync<T>(await streamTask);
            return data;
        }
    }
}