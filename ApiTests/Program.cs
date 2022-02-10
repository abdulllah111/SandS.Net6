// See https://aka.ms/new-console-template for more information


using ApiTests.Model;
using System.Text.Json;


var data = get("http://abdul-arabp.ru/public/api/subttable/getforgroupanddate/1172/2021-10-01");
Console.WriteLine(data.Result);
Console.ReadKey();



static async Task<SubTTable[]> get(string url)
{
    HttpClient cl = new HttpClient();
    var streamTask = cl.GetStreamAsync(url);
    var data = await JsonSerializer.DeserializeAsync<SubTTable[]>(await streamTask);
    return data;
}