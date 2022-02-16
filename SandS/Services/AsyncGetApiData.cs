using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SandS.Services;

namespace SandS.Model
{
    public static class AsyncGetApiData
    {
        public static TaskCompletion<SubTTable[]> GetSubTTableByGroupAndDate(int groupid, string date) =>
            ApiData<SubTTable[]>.Get($"http://uksivttimetable.000webhostapp.com/api/subttable/getforgroupanddate/{groupid}/{date}");

        public static TaskCompletion<ObservableCollection<TTable>> GetTtableByGroupAndWeekDay(int groupid, int weekday) =>
            ApiData<ObservableCollection<TTable>>.Get($"http://uksivttimetable.000webhostapp.com/api/ttable/getforgroup/{groupid}/{weekday}");
        
        public static TaskCompletion<ObservableCollection<Group>> GroupsByDepartment(int DepartmentId) =>
            ApiData<ObservableCollection<Group>>.Get($"http://uksivttimetable.000webhostapp.com/api/department/{DepartmentId}/groups");

        public static TaskCompletion<Teacher> GetTeacher(int? id) => 
            ApiData<Teacher>.Get($"https://uksivttimetable.000webhostapp.com/public/api/teacher/{id}");

        public static TaskCompletion<Teacher> GetTeacher(string name) =>
            ApiData<Teacher>.Get($"https://uksivttimetable.000webhostapp.com/public/api/teacher/name/{name}");

        public static TaskCompletion<ObservableCollection<Teacher>> GetTeachers() =>
            ApiData<ObservableCollection<Teacher>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/teacher");


        public static TaskCompletion<Discipline> GetDiscipline(int id) =>
            ApiData<Discipline>.Get($"https://uksivttimetable.000webhostapp.com/public/api/discipline/{id}");

        public static TaskCompletion<Discipline> GetDiscipline(string name) =>
            ApiData<Discipline>.Get($"https://uksivttimetable.000webhostapp.com/public/api/discipline/name/{name}");

        public static TaskCompletion<ObservableCollection<Discipline>> GetDisciplines() =>
            ApiData<ObservableCollection<Discipline>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/discipline");
        public static TaskCompletion<Group> GetGroup(int id) =>
            ApiData<Group>.Get($"https://uksivttimetable.000webhostapp.com/public/api/group/{id}");

        public static TaskCompletion<ObservableCollection<Group>> GetGroups() => 
            ApiData<ObservableCollection<Group>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/group");

        public static TaskCompletion<Group> GetGroup(string name) =>
            ApiData<Group>.Get($"https://uksivttimetable.000webhostapp.com/public/api/group/name/{name}");

        public static TaskCompletion<WeekDay> GetWeekDay(int id) =>
            ApiData<WeekDay>.Get($"https://uksivttimetable.000webhostapp.com/public/api/weekday/{id}");

        public static TaskCompletion<ObservableCollection<WeekDay>> GetWeekDays() =>
            ApiData<ObservableCollection<WeekDay>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/weekday");

        //public static async Task<WeekDay> GetWeekDay(string name)
        //{
        //    var a = await GetWeekDays();
        //    return a.Where(x => x.Name == name).First();
        //}

        public static TaskCompletion<Lesson> GetLesson(int id) =>
            ApiData<Lesson>.Get($"https://uksivttimetable.000webhostapp.com/public/api/lesson/{id}");

        //public static async Task<Lesson> GetLesson(int number)
        //{
        //    var a = await GetLessons();
        //    return a.Where(x => x.LessonNumber == number).First();
        //}
        public static TaskCompletion<ObservableCollection<Lesson>> GetLessons() =>
            ApiData<ObservableCollection<Lesson>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/lesson");


        public static TaskCompletion<Office> GetOffice(int? id) =>
            ApiData<Office>.Get($"https://uksivttimetable.000webhostapp.com/public/api/office/{id}");


        //public static async Task<Office> GetOffice(string number)
        //{
        //    var a = await GetOffices();
        //    return a.Where(x => x.OfficeNumber == number).First();
        //}
        public static TaskCompletion<ObservableCollection<Office>> GetOffices() =>
            ApiData<ObservableCollection<Office>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/office");

        public static TaskCompletion<Department> GetDepartment(int id) =>
            ApiData<Department>.Get($"https://uksivttimetable.000webhostapp.com/public/api/department/{id}");

        //public async static Task<Department> GetDepartment(string name)
        //{
        //    //var a = await GetDepartments();
        //    //return a.Where(x => x.Name == name).First();
        //}

        public static TaskCompletion<ObservableCollection<Department>> GetDepartments() =>
            ApiData<ObservableCollection<Department>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/department");

        public static TaskCompletion<ObservableCollection<TTable>> GetTTables() =>
            ApiData<ObservableCollection<TTable>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/ttable");

        public static TaskCompletion<ObservableCollection<SubTTable>> GetSubTtables() =>
            ApiData<ObservableCollection<SubTTable>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/subttables");

        public static TaskCompletion<ObservableCollection<DisciplineGroupTeacher>> GetDisciplineGroupTeachers() =>
            ApiData<ObservableCollection<DisciplineGroupTeacher>>.Get($"https://uksivttimetable.000webhostapp.com/public/api/dgt");

        public static TaskCompletion<DisciplineGroupTeacher> GetDisciplineGroupTeacher(int id) =>
            ApiData<DisciplineGroupTeacher>.Get($"https://uksivttimetable.000webhostapp.com/public/api/dgt/{id}");

        public static TaskCompletion<DisciplineGroupTeacher> GetDisciplineGroupTeacher(DisciplineGroupTeacher disciplineGroupTeacher) =>
            ApiData<DisciplineGroupTeacher>.Get($"https://uksivttimetable.000webhostapp.com/public/api/dgt");
    }
}