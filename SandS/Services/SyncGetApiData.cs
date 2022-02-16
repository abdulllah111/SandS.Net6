using SandS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Services
{
    internal static class SyncGetApiData
    {
        public static Group GetGroupByName(string name) => new SyncApiData<Group>($"http://abdul-arabp.ru/public/api/group/name/{name}").Get();
        public static Discipline GetDisciplineByName(string name) => new SyncApiData<Discipline>($"http://abdul-arabp.ru/public/api/discipline/name/{name}").Get();
        public static Teacher GetTeacherByName(string name) => new SyncApiData<Teacher>($"http://abdul-arabp.ru/public/api/teacher/name/{name}").Get();
        public static WeekDay GetWeekDayByName(string name) => new SyncApiData<WeekDay>($"http://abdul-arabp.ru/public/api/weekday/name/{name}").Get();
        public static Lesson GetLessonByName(string name) => new SyncApiData<Lesson>($"http://abdul-arabp.ru/public/api/lesson/name/{name}").Get();
        public static Office GetOfficeByName(string name) => new SyncApiData<Office>($"http://abdul-arabp.ru/public/api/office/name/{name}").Get();
    }
}
