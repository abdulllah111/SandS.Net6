using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SandS.Model.MoreModel;

namespace SandS.Model
{
    public class DataWorker
    {
        private static HttpClient client = new HttpClient();
        public static async Task<Teacher> GetTeacher(int? id)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/teacher/{id}");
            var data = await JsonSerializer.DeserializeAsync<Teacher>(await streamTask);
            return data;
        }
        public static async Task<Teacher> GetTeacher(string name)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/teacher/name/{name}");
            var data = await JsonSerializer.DeserializeAsync<Teacher>(await streamTask);
            return data;
        }
        public static async Task<List<Teacher>> GetTeachers()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/teacher");
            var data = await JsonSerializer.DeserializeAsync<List<Teacher>>(await streamTask);
            return data;
        }

        public static async Task<Discipline> GetDiscipline(int id)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/discipline/{id}");
            var data = await JsonSerializer.DeserializeAsync<Discipline>(await streamTask);
            return data;
        }

        public static async Task<Discipline> GetDiscipline(string name)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/discipline/name/{name}");
            var data = await JsonSerializer.DeserializeAsync<Discipline>(await streamTask);
            return data;
        }
        public static async Task<List<Discipline>> GetDisciplines()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/discipline");
            var data = await JsonSerializer.DeserializeAsync<List<Discipline>>(await streamTask);
            return data;
        }
        public static async Task<Group> GetGroup(int id)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/group/{id}");
            var data = await JsonSerializer.DeserializeAsync<Group>(await streamTask);
            return data;
        }

        public static async Task<ObservableCollection<Group>> GetGroups()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/group");
            var data = await JsonSerializer.DeserializeAsync<ObservableCollection<Group>>(await streamTask);
            return data;
        }

        public async static Task<Group> GetGroup(string name)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/group/name/{name}");
            var data = await JsonSerializer.DeserializeAsync<Group>(await streamTask);
            return data;
        }

        public static async Task<WeekDay> GetWeekDay(int id)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/weekday/{id}");
            var data = await JsonSerializer.DeserializeAsync<WeekDay>(await streamTask);
            return data;
        }
        public static async Task<List<WeekDay>> GetWeekDays()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/weekday");
            var data = await JsonSerializer.DeserializeAsync<List<WeekDay>>(await streamTask);
            return data;
        }

        public static async Task<WeekDay> GetWeekDay(string name)
        {
            var a = await GetWeekDays();
            return a.Where(x => x.Name == name).First();
        }

        public static async Task<Lesson> GetLesson(int id)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/lesson/{id}");
            var data = await JsonSerializer.DeserializeAsync<Lesson>(await streamTask);
            var a = data;
            return data;
        }

        public static async Task<Lesson> GetLesson(string number)
        {
            var a = await GetLessons();
            return a.Where(x => x.LessonNumber == number).First();
        }
        public static async Task<List<Lesson>> GetLessons()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/lesson");
            var data = await JsonSerializer.DeserializeAsync<List<Lesson>>(await streamTask).ConfigureAwait(false);
            return data;
        }


        public static async Task<Office> GetOffice(int? id)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/office/{id}");
            var data = await JsonSerializer.DeserializeAsync<Office>(await streamTask);
            return data;
        }

        public static async Task<Office> GetOffice(string number)
        {
            var a = await GetOffices();
            return a.Where(x => x.OfficeNumber == number).First();
        }
        public static async Task<List<Office>> GetOffices()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/office");
            var data = await JsonSerializer.DeserializeAsync<List<Office>>(await streamTask);
            return data;
        }

        public static async Task<Department> GetDepartment(int id)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/department/{id}");
            var data = await JsonSerializer.DeserializeAsync<Department>(await streamTask);
            return data;
        }

        public async static Task<Department> GetDepartment(string name)
        {
            var a = await GetDepartments();
            return a.Where(x => x.Name == name).First();
        }


        public static async Task<ObservableCollection<Department>> GetDepartments()
        {
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/department");
            var data = await JsonSerializer.DeserializeAsync<ObservableCollection<Department>>(await streamTask);
            return data;
        }

        public static async Task<List<TTable>> GetTTables()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/ttable");
            var data = await JsonSerializer.DeserializeAsync<List<TTable>>(await streamTask);
            return data;
        }

        public static async Task<List<SubTTable>> GetSubTtables()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/subttables");
            var data = await JsonSerializer.DeserializeAsync<List<SubTTable>>(await streamTask);
            return data;
        }

        public static async Task<List<DisciplineGroupTeacher>> GetDisciplineGroupTeachers()
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/dgt");
            var data = await JsonSerializer.DeserializeAsync<List<DisciplineGroupTeacher>>(await streamTask);
            return data;
        }

        public async static Task<DisciplineGroupTeacher> GetDisciplineGroupTeacher(int id)
        {
            
            var streamTask = client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/dgt/{id}");
            var data = await JsonSerializer.DeserializeAsync<DisciplineGroupTeacher>(await streamTask);
            return data;
        }

        public async static Task<DisciplineGroupTeacher> GetDisciplineGroupTeacher(DisciplineGroupTeacher disciplineGroupTeacher)
        {
            var a = await GetDisciplineGroupTeachers();
            return a.Where(x => x.IdGroup == disciplineGroupTeacher.IdGroup
            && x.IdDiscipline == disciplineGroupTeacher.IdDiscipline).First();
        }
    }
}