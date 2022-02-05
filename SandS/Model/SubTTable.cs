using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SandS.Model
{
    public class SubTTable
    {
        [JsonPropertyName("idsub_ttable")]
        public int IdSubTTable { get; set; }
        [JsonPropertyName("idweekday")]
        public int IdWeekDay { get; set; }
        [JsonPropertyName("idlesson")]
        public int IdLesson { get; set; }
        [JsonPropertyName("idoffice")]
        public int? IdOffice { get; set; }
        public string WeekDayName { get; set; }
        public int LessonName { get; set; }
        public string OfficeName { get; set; }
        [JsonPropertyName("iddisciplinegroupteacher")]
        public int IdDisciplineGroupTeacher { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        public DisciplineGroupTeacher DisciplineGroupTeacher { get; set; }

        public async Task<DisciplineGroupTeacher> GetDisciplineGroupTeacher() => (IdDisciplineGroupTeacher != 0) ? await DataWorker.GetDisciplineGroupTeacher(IdDisciplineGroupTeacher) : await DataWorker.GetDisciplineGroupTeacher(DisciplineGroupTeacher);
        public async Task<WeekDay> WeekDay() => (IdWeekDay != 0) ? await DataWorker.GetWeekDay(IdWeekDay) : await DataWorker.GetWeekDay(WeekDayName);
        public async Task<Lesson> Lesson() => (IdLesson != 0) ? await DataWorker.GetLesson(IdLesson) : await DataWorker.GetLesson(LessonName);
        public async Task<Office> Office() => (IdOffice != 0) ? await DataWorker.GetOffice(IdOffice) : await DataWorker.GetOffice(OfficeName);
    }
}
