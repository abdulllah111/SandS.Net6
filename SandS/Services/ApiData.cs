using SandS.Resource;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SandS.Services
{
    internal static class ApiData<T>
    {
        private static HttpClient cl = new HttpClient();
        private static async Task<T> get(string url)
        {
            var streamTask = cl.GetStreamAsync($"{GloabalValues.ApiBaseUrl}{url}");
            var data = await JsonSerializer.DeserializeAsync<T>(await streamTask);
            return data;
        }
        public static TaskCompletion<T> Get(string url)
        {
            return new TaskCompletion<T>(get(url));
        }
    }

}