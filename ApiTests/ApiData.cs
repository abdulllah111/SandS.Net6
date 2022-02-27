using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiTests
{
    public class ApiData<T>
    {

        private static HttpClient cl = new HttpClient();
        private static string _url = "";
        private static object _model = null!;
        public ApiData(string url)
        {
            _url = url;
        }
        public ApiData(string url, object model)
        {
            _url = url;
            _model = model;
        }
        public T Get()
        {
            var stream = Task.Run(get).Result;
            var data = JsonSerializer.Deserialize<T>(stream);
            return data;
        }

        public T Post()
        {
            var stream = Task.Run(post).Result;
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
    }
}
