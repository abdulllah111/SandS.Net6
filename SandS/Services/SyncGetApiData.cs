using SandS.Model;
using System.Collections.ObjectModel;

namespace SandS.Services
{
    internal static class SyncGetApiData
    {
        public static Group GetGroupByName(string name) =>
            new SyncApiData<Group>($"group/name", new Group { Name = name }).Post();
        public static Discipline GetDisciplineByName(string name) =>
            new SyncApiData<Discipline>($"discipline/name", new Discipline { Name = name }).Post();
        public static Teacher GetTeacherByName(string name) =>
            new SyncApiData<Teacher>($"teacher/name", new Teacher { Name = name }).Post();
        public static WeekDay GetWeekDayByName(string name) =>
            new SyncApiData<WeekDay>($"weekday/name", new WeekDay { Name = name }).Post();
        public static Lesson GetLessonByName(string name) =>
            new SyncApiData<Lesson>($"lesson/name", new Lesson { LessonNumber = name }).Post();
        public static Office GetOfficeByName(string name) =>
            new SyncApiData<Office>($"office/name", new Office { OfficeNumber = name }).Post();
        public static Department GetDepartmentByName(string name) =>
            new SyncApiData<Department>($"department", new Department { Name = name }).Post();
        public static ObservableCollection<TTable> GetTTable() =>
            new SyncApiData<ObservableCollection<TTable>>($"ttable/fullinfo").Get();
        public static ObservableCollection<SubTTable> GetSubTTable() =>
            new SyncApiData<ObservableCollection<SubTTable>>($"subttable/fullinfo").Get();
        public static ObservableCollection<Office> GetOffice() =>
            new SyncApiData<ObservableCollection<Office>>($"office").Get();
        public static ObservableCollection<DisciplineGroupTeacher> GetDgtForGroup(int id) =>
            new SyncApiData<ObservableCollection<DisciplineGroupTeacher>>($"dgt/getforgroup/{id}").Get();
        public static ObservableCollection<TTable> GetTtableByGroupAndWeekDay(int groupid, int weekday) =>
            new SyncApiData<ObservableCollection<TTable>>($"ttable/getforgroup/{groupid}/{weekday}").Get();
        public static ObservableCollection<SubTTable[]> GetSubTTableByGroupAndDate(int groupid, string date) =>
            new SyncApiData<ObservableCollection<SubTTable[]>>($"subttable/getforgroupanddate/{groupid}/{date}").Get();


    }
}
