// See https://aka.ms/new-console-template for more information


using ApiTests;
using ApiTests.Model;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text.Json;


Console.WriteLine();
var client = new HttpClient();
var p = new Department() { Name = "sdsdssdsds21wqasdsdsds" };
client.BaseAddress = new Uri("http://abdul-arabp.ru/public");
client.PostAsJsonAsync("api/department", p);
Console.ReadKey();

//static ObservableCollection<Group> GetGroup()
//{
//    var stream = Task.Run(get).Result;
//    var data = JsonSerializer.Deserialize<ObservableCollection<Group>>(stream);
//    return data;
//}
//static async Task<Stream> get()
//{
//    HttpClient cl = new HttpClient();
//    var streamTask = await cl.GetAsync("http://abdul-arabp.ru/public/api/group");
//    return await streamTask.Content.ReadAsStreamAsync().ConfigureAwait(false);
//}


