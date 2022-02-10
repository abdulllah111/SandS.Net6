using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiTests.Model
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
    }
}
