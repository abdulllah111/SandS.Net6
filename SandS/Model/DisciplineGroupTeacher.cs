namespace SandS.Model
{
    public class DisciplineGroupTeacher
    {
        public int IdDisciplineGroupTeacher { get; set; }
        public int IdTeacher { get; set; }
        public int IdDiscipline { get; set; }
        public int IdGroup { get; set; }
        public string TeacherName { get; set; }
        public string DisciplineName { get; set; }
        public string GroupName { get; set; }
        public Teacher Teacher => IdTeacher != 0 ? DataWorker.GetTeacher(IdTeacher) : DataWorker.GetTeacher(TeacherName);
        public Group Group => IdGroup != 0 ? DataWorker.GetGroup(IdGroup) : DataWorker.GetGroup(GroupName);
        public Discipline Discipline => IdDiscipline != 0 ? DataWorker.GetDiscipline(IdDiscipline) : DataWorker.GetDiscipline(DisciplineName);
    }
}
