using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SandS.Services
{
    public class SyncApiData<T>
    {

        private static HttpClient cl = new HttpClient();
        private static string _url = "";
        public SyncApiData(string url)
        {
            _url = url;
        }

        public T Get()
        {
            var stream = Task.Run(get).Result;
            var data = JsonSerializer.Deserialize<T>(stream);
            return data;
        }
        private static async Task<Stream> get()
        {
            var streamTask = await cl.GetAsync(_url);
            return await streamTask.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }
    }
}
