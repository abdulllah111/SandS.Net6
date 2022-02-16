using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiTests
{
    public class ApiData<T>
    {

        private static HttpClient cl = new HttpClient();
        private static string _url = "";
        public ApiData(string url)
        {
            _url = url;
        }

        private static async Task<Stream> get()
        {
            var streamTask = await cl.GetAsync(_url);
            return await streamTask.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }
        public  IEnumerable<T?> GetCollection()
        {
            var data_stream = Task.Run(get).Result;
            var data_reader = new StreamReader(data_stream);
            while(!data_reader.EndOfStream){
                yield return JsonSerializer.Deserialize<T>(data_reader.ReadLine());
            }
        }
    }
}
