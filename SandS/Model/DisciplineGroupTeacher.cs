using System.Text.Json.Serialization;

namespace SandS.Model
{
    public class DisciplineGroupTeacher
    {
        [JsonPropertyName("iddiscipline-group-teacher")]
        public int IdDisciplineGroupTeacher { get; set; }
        [JsonPropertyName("idteacher")]
        public int? IdTeacher { get; set; }
        [JsonPropertyName("iddiscipline")]
        public int IdDiscipline { get; set; }
        [JsonPropertyName("idgroup")]
        public int IdGroup { get; set; }
        public string? TeacherName { get; set; }
        public string? DisciplineName { get; set; }
        public string GroupName { get; set; }

        [JsonPropertyName("teacher")]
        public Teacher Teacher { get; set; }
        [JsonPropertyName("discipline")]
        public Discipline Discipline { get; set; }
        [JsonPropertyName("group")]
        public Group Group { get; set; }

        //private async Task<Teacher> GetTeacher() => IdTeacher != 0 ? await AsyncGetApiData.GetTeacher(IdTeacher) : await AsyncGetApiData.GetTeacher(TeacherName);
        //private async Task<Group> GetGroup() => IdGroup != 0 ? await AsyncGetApiData.GetGroup(IdGroup) : await AsyncGetApiData.GetGroup(GroupName);
        //private async Task<Discipline> GetDiscipline() => IdDiscipline != 0 ? await AsyncGetApiData.GetDiscipline(IdDiscipline) : await AsyncGetApiData.GetDiscipline(DisciplineName);
    }
}
