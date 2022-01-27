using System;

namespace SandS.Model
{
    public class SubTTable
    {
        public int IdSubTTable { get; set; }
        public int IdWeekDay { get; set; }
        public int IdLesson { get; set; }
        public int IdOffice { get; set; }
        public string WeekDayName { get; set; }
        public string LessonName { get; set; }
        public string OfficeName { get; set; }
        public int IdDisciplineGroupTeacher { get; set; }
        public DateTime Date { get; set; }
        public DisciplineGroupTeacher DisciplineGroupTeacher { get; set; }

        public DisciplineGroupTeacher GetDisciplineGroupTeacher => (IdDisciplineGroupTeacher != 0) ? DataWorker.GetDisciplineGroupTeacher(IdDisciplineGroupTeacher) : DataWorker.GetDisciplineGroupTeacher(DisciplineGroupTeacher);
        public WeekDay WeekDay => (IdWeekDay != 0) ? DataWorker.GetWeekDay(IdWeekDay) : DataWorker.GetWeekDay(WeekDayName);
        public Lesson Lesson => (IdLesson != 0) ? DataWorker.GetLesson(IdLesson) : DataWorker.GetLesson(LessonName);
        public Office Office => (IdOffice != 0) ? DataWorker.GetOffice(IdOffice) : DataWorker.GetOffice(OfficeName);
    }
}
