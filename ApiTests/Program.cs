// See https://aka.ms/new-console-template for more information


using ApiTests;
using ApiTests.Model;
using System.Net.Http.Json;
//using Namespace;
//using System.Collections.ObjectModel;
//using System.Net.Http.Json;
//using System.Text.Json;

//var a = new TTable { IdLesson = 1, IdWeekDay = 1, IdOffice = 4065, IdDisciplineGroupTeacher = 5888 };
//AsyncPost.Post("ttable", a);
Console.WriteLine();


//var client = new HttpClient();
//var p = new Department() { Name = "asasasasa" };
//client.BaseAddress = new Uri("http://localhost:8080/api/");
//client.PostAsJsonAsync("department", p);


var ttable = new ApiData<IEnumerable<TTable>>($"http://localhost:8080/api/ttable/getforgroup/1188/2").Get();

Console.ReadKey();

//namespace Namespace
//{



//static class AsyncPost
//{
//    public static void Post(string url, object model)
//    {
//        var client = new HttpClient();
//        client.BaseAddress = new Uri("http://localhost:8080/api/");
//        client.PostAsJsonAsync($"{url}", model);
//    }
//}



//}
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


