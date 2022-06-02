using SandS.Services;
using System.Collections.ObjectModel;

namespace SandS.Model
{
    public static class AsyncGetApiData
    {
        public static TaskCompletion<SubTTable[]> GetSubTTableByGroupAndDate(int groupid, string date) =>
            ApiData<SubTTable[]>.Get($"subttable/getforgroupanddate/{groupid}/{date}");

        public static TaskCompletion<ObservableCollection<TTable>> GetTtableByGroupAndWeekDay(int groupid, int weekday) =>
            ApiData<ObservableCollection<TTable>>.Get($"ttable/getforgroup/{groupid}/{weekday}");

        public static TaskCompletion<ObservableCollection<Group>> GroupsByDepartment(int DepartmentId) =>
            ApiData<ObservableCollection<Group>>.Get($"department/{DepartmentId}/groups");

        public static TaskCompletion<Teacher> GetTeacher(int? id) =>
            ApiData<Teacher>.Get($"teacher/{id}");

        public static TaskCompletion<Teacher> GetTeacher(string name) =>
            ApiData<Teacher>.Get($"teacher/name/{name}");

        public static TaskCompletion<ObservableCollection<Teacher>> GetTeachers() =>
            ApiData<ObservableCollection<Teacher>>.Get($"teacher");


        public static TaskCompletion<Discipline> GetDiscipline(int id) =>
            ApiData<Discipline>.Get($"discipline/{id}");

        public static TaskCompletion<Discipline> GetDiscipline(string name) =>
            ApiData<Discipline>.Get($"discipline/name/{name}");

        public static TaskCompletion<ObservableCollection<Discipline>> GetDisciplines() =>
            ApiData<ObservableCollection<Discipline>>.Get($"discipline");
        public static TaskCompletion<Group> GetGroup(int id) =>
            ApiData<Group>.Get($"group/{id}");

        public static TaskCompletion<ObservableCollection<Group>> GetGroups() =>
            ApiData<ObservableCollection<Group>>.Get($"group");

        public static TaskCompletion<Group> GetGroup(string name) =>
            ApiData<Group>.Get($"group/name/{name}");

        public static TaskCompletion<WeekDay> GetWeekDay(int id) =>
            ApiData<WeekDay>.Get($"weekday/{id}");

        public static TaskCompletion<ObservableCollection<WeekDay>> GetWeekDays() =>
            ApiData<ObservableCollection<WeekDay>>.Get($"weekday");

        //public static async Task<WeekDay> GetWeekDay(string name)
        //{
        //    var a = await GetWeekDays();
        //    return a.Where(x => x.Name == name).First();
        //}

        public static TaskCompletion<Lesson> GetLesson(int id) =>
            ApiData<Lesson>.Get($"lesson/{id}");

        //public static async Task<Lesson> GetLesson(int number)
        //{
        //    var a = await GetLessons();
        //    return a.Where(x => x.LessonNumber == number).First();
        //}
        public static TaskCompletion<ObservableCollection<Lesson>> GetLessons() =>
            ApiData<ObservableCollection<Lesson>>.Get($"lesson");


        public static TaskCompletion<Office> GetOffice(int? id) =>
            ApiData<Office>.Get($"office/{id}");


        //public static async Task<Office> GetOffice(string number)
        //{
        //    var a = await GetOffices();
        //    return a.Where(x => x.OfficeNumber == number).First();
        //}
        public static TaskCompletion<ObservableCollection<Office>> GetOffices() =>
            ApiData<ObservableCollection<Office>>.Get($"office");

        public static TaskCompletion<Department> GetDepartment(int id) =>
            ApiData<Department>.Get($"department/{id}");

        //public async static Task<Department> GetDepartment(string name)
        //{
        //    //var a = await GetDepartments();
        //    //return a.Where(x => x.Name == name).First();
        //}

        public static TaskCompletion<ObservableCollection<Department>> GetDepartments() =>
            ApiData<ObservableCollection<Department>>.Get($"department");

        public static TaskCompletion<ObservableCollection<TTable>> GetTTables() =>
            ApiData<ObservableCollection<TTable>>.Get($"ttable");

        public static TaskCompletion<ObservableCollection<SubTTable>> GetSubTtables() =>
            ApiData<ObservableCollection<SubTTable>>.Get($"subttables");

        public static TaskCompletion<ObservableCollection<DisciplineGroupTeacher>> GetDisciplineGroupTeachers() =>
            ApiData<ObservableCollection<DisciplineGroupTeacher>>.Get($"dgt");

        public static TaskCompletion<DisciplineGroupTeacher> GetDisciplineGroupTeacher(int id) =>
            ApiData<DisciplineGroupTeacher>.Get($"dgt/{id}");

        public static TaskCompletion<DisciplineGroupTeacher> GetDisciplineGroupTeacher(DisciplineGroupTeacher disciplineGroupTeacher) =>
            ApiData<DisciplineGroupTeacher>.Get($"dgt");
    }
}