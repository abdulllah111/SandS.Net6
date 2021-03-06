using System.Text.Json.Serialization;

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
        public string Date { get; set; }
        [JsonPropertyName("weekday")]
        public WeekDay WeekDay { get; set; }
        [JsonPropertyName("lesson")]
        public Lesson Lesson { get; set; }
        [JsonPropertyName("office")]
        public Office Office { get; set; }
        [JsonPropertyName("discipline_group_teacher")]
        public DisciplineGroupTeacher GetDisciplineGroupTeacher { get; set; }
        //public async Task<DisciplineGroupTeacher> GetDisciplineGroupTeacher() => (IdDisciplineGroupTeacher != 0) ? await AsyncGetApiData.GetDisciplineGroupTeacher(IdDisciplineGroupTeacher) : await AsyncGetApiData.GetDisciplineGroupTeacher(DisciplineGroupTeacher);
        //public async Task<WeekDay> WeekDay() => (IdWeekDay != 0) ? await AsyncGetApiData.GetWeekDay(IdWeekDay) : await AsyncGetApiData.GetWeekDay(WeekDayName);
        //public async Task<Lesson> Lesson() => (IdLesson != 0) ? await AsyncGetApiData.GetLesson(IdLesson) : await AsyncGetApiData.GetLesson(LessonName);
        //public async Task<Office> Office() => (IdOffice != 0) ? await AsyncGetApiData.GetOffice(IdOffice) : await AsyncGetApiData.GetOffice(OfficeName);
    }
}
