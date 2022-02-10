﻿using SandS.Services;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SandS.Model
{
    public class TTable
    {
        [JsonPropertyName("idttable")]
        public int IdTimeTable { get; set; }
        [JsonPropertyName("idweekday")]
        public int IdWeekDay { get; set; }
        [JsonPropertyName("idlesson")]
        public int IdLesson { get; set; }
        [JsonPropertyName("idoffice")]
        public int? IdOffice { get; set; }
        public string WeekDayName { get; set; }
        public string LessonName { get; set; }
        public string OfficeName { get; set; }
        [JsonPropertyName("iddisciplinegroupteacher")]
        public int IdDisciplineGroupTeacher { get; set; }
        public DisciplineGroupTeacher DisciplineGroupTeacher { get; set; }
        [JsonPropertyName("discipline_group_teacher")]
        public DisciplineGroupTeacher GetDisciplineGroupTeacher { get; set; }
        [JsonPropertyName("weekday")]
        public WeekDay WeekDay { get; set; }
        [JsonPropertyName("lesson")]
        public Lesson Lesson { get; set; }
        [JsonPropertyName("office")]
        public Office Office { get; set; }
        //public TaskCompletion<DisciplineGroupTeacher> GetDisciplineGroupTeacher => new TaskCompletion<DisciplineGroupTeacher>(DataWorker.GetDisciplineGroupTeacher(IdDisciplineGroupTeacher));
        //public TaskCompletion<WeekDay> WeekDay => new TaskCompletion<WeekDay>(DataWorker.GetWeekDay(IdWeekDay));
        //public TaskCompletion<Lesson> Lesson => new TaskCompletion<Lesson>(DataWorker.GetLesson(IdLesson));
        //public TaskCompletion<Office> Office => new TaskCompletion<Office>(DataWorker.GetOffice(IdOffice));

        //private async Task<DisciplineGroupTeacher> GeDisciplineGroupTeacher() => (IdDisciplineGroupTeacher != 0) ? await DataWorker.GetDisciplineGroupTeacher(IdDisciplineGroupTeacher) : await DataWorker.GetDisciplineGroupTeacher(DisciplineGroupTeacher);
        //private async Task<WeekDay> GetWeekDay() => (IdWeekDay != 0) ? await DataWorker.GetWeekDay(IdWeekDay) : await DataWorker.GetWeekDay(WeekDayName);
        //private async Task<Lesson> GetLesson() => (IdLesson != 0) ? await DataWorker.GetLesson(IdLesson) : await DataWorker.GetLesson(LessonName);
        //private async Task<Office> GetOffice() => (IdOffice != 0) ? await DataWorker.GetOffice(IdOffice) : await DataWorker.GetOffice(OfficeName);

    }
}
