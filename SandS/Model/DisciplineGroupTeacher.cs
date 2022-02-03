using SandS.Model.MoreModel;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public string TeacherName { get; set; }
        public string DisciplineName { get; set; }
        public string GroupName { get; set; }
        public Teacher Teacher
        {
            get
            {
                return _Teacher;
            }
        }
        public Discipline Discipline
        {
            get
            {
                return _Discipline;
            }
        }
        public Group Group
        {
            get
            {
                return _Group;
            }
        }
        private Teacher _Teacher => new TaskCompletion<Teacher>(DataWorker.GetTeacher(IdTeacher)).Result;
        private Discipline _Discipline => new TaskCompletion<Discipline>(DataWorker.GetDiscipline(IdDiscipline)).Result;
        private Group _Group => new TaskCompletion<Group>(DataWorker.GetGroup(IdGroup)).Result;
        //private async Task<Teacher> GetTeacher() => IdTeacher != 0 ? await DataWorker.GetTeacher(IdTeacher) : await DataWorker.GetTeacher(TeacherName);
        //private async Task<Group> GetGroup() => IdGroup != 0 ? await DataWorker.GetGroup(IdGroup) : await DataWorker.GetGroup(GroupName);
        //private async Task<Discipline> GetDiscipline() => IdDiscipline != 0 ? await DataWorker.GetDiscipline(IdDiscipline) : await DataWorker.GetDiscipline(DisciplineName);
    }
}
