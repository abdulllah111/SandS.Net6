using SandS.Resource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SandS.Services
{
    public class SyncApiData<T>
    {

        private static HttpClient cl = new HttpClient();
        private static string _url = "";
        private static object _model = null!;
        public SyncApiData(string url)
        {
            _url = $"{GloabalValues.ApiBaseUrl}{url}?api_token={GloabalValues.ApiToken}";
        }
        public SyncApiData(string url, object model)
        {
            _url = $"{GloabalValues.ApiBaseUrl}{url}?api_token={GloabalValues.ApiToken}";
            _model = model;
        }
        public T Get()
        {
            try
            {
                var stream = Task.Run(get).Result;
                var data = JsonSerializer.Deserialize<T>(stream);
                return data;
            }
            catch
            {
                return default(T);
            }
        }

        public T Post()
        {
            var stream = Task.Run(post).Result;
            var data = JsonSerializer.Deserialize<T>(stream);
            return data;
        }
        public T Delete()
        {
            var stream = Task.Run(delete).Result;
            var data = JsonSerializer.Deserialize<T>(stream);
            return data;
        }
        private static async Task<Stream> get()
        {
            var streamTask = await cl.GetAsync(_url);
            return await streamTask.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }
        private static async Task<Stream> post()
        {
            var streamTask = await cl.PostAsJsonAsync(_url, _model);
            return await streamTask.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }
        private static async Task<Stream> delete()
        {
            var streamTask = await cl.DeleteAsync(_url);
            return await streamTask.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }
    }
}
