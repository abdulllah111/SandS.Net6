﻿using SandS.Model.MoreModel;
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
        public DisciplineGroupTeacher GetDisciplineGroupTeacher { get{ return GeDisciplineGroupTeacher; } }
        public WeekDay WeekDay { get { return GetWeekDay; } }
        public Office Office { get { return GetOffice; } }
        public DisciplineGroupTeacher DisciplineGroupTeacher { get; set; }
        private DisciplineGroupTeacher GeDisciplineGroupTeacher => new TaskCompletion<DisciplineGroupTeacher>(DataWorker.GetDisciplineGroupTeacher(IdDisciplineGroupTeacher)).Result;
        private WeekDay GetWeekDay => new TaskCompletion<WeekDay>(DataWorker.GetWeekDay(IdWeekDay)).Result;
        private Lesson GetLesson => new TaskCompletion<Lesson>(DataWorker.GetLesson(IdLesson)).Result;
        private Office GetOffice => new TaskCompletion<Office>(DataWorker.GetOffice(IdOffice)).Result;
        //private async Task<DisciplineGroupTeacher> GeDisciplineGroupTeacher() => (IdDisciplineGroupTeacher != 0) ? await DataWorker.GetDisciplineGroupTeacher(IdDisciplineGroupTeacher) : await DataWorker.GetDisciplineGroupTeacher(DisciplineGroupTeacher);
        //private async Task<WeekDay> GetWeekDay() => (IdWeekDay != 0) ? await DataWorker.GetWeekDay(IdWeekDay) : await DataWorker.GetWeekDay(WeekDayName);
        //private async Task<Lesson> GetLesson() => (IdLesson != 0) ? await DataWorker.GetLesson(IdLesson) : await DataWorker.GetLesson(LessonName);
        //private async Task<Office> GetOffice() => (IdOffice != 0) ? await DataWorker.GetOffice(IdOffice) : await DataWorker.GetOffice(OfficeName);

    }
}