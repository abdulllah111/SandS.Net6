using ClosedXML.Excel;
using DevExpress.Mvvm;
using Microsoft.Win32;
using SandS.Model;
using SandS.Resource;
using SandS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SandS.ViewModel
{
    internal class DispatcherVM : ViewModelBase
    {

        private ObservableCollection<Department> DepartmentInDb;
        private ObservableCollection<Group> GroupsInDb;
        private ObservableCollection<Discipline> DisciplinesInDb;
        private ObservableCollection<Teacher> TeachersInDb;
        private ObservableCollection<Office> OfficesInDb;
        private ObservableCollection<Lesson> LessonIdDb;
        private ObservableCollection<WeekDay> WeekDaysInDb;
        private ObservableCollection<Department> DepartmentsInDb;
        private ObservableCollection<TTable> TTablesInDb;
        private ObservableCollection<DisciplineGroupTeacher> DisciplineGroupTeachersInDb;
        public DispatcherVM()
        {
            DepartmentInDb = new SyncApiData<ObservableCollection<Department>>($"{GloabalValues.ApiBaseUrl}department").Get();
            GroupsInDb = new SyncApiData<ObservableCollection<Group>>($"{GloabalValues.ApiBaseUrl}group").Get();
            DisciplinesInDb = new SyncApiData<ObservableCollection<Discipline>>($"{GloabalValues.ApiBaseUrl}discipline").Get();
            TeachersInDb = new SyncApiData<ObservableCollection<Teacher>>($"{GloabalValues.ApiBaseUrl}teacher").Get();
            OfficesInDb = new SyncApiData<ObservableCollection<Office>>($"{GloabalValues.ApiBaseUrl}office").Get();
            LessonIdDb = new SyncApiData<ObservableCollection<Lesson>>($"{GloabalValues.ApiBaseUrl}lesson").Get();
            WeekDaysInDb = new SyncApiData<ObservableCollection<WeekDay>>($"{GloabalValues.ApiBaseUrl}weekday").Get();
            DepartmentsInDb = new SyncApiData<ObservableCollection<Department>>($"{GloabalValues.ApiBaseUrl}department").Get();
            TTablesInDb = new SyncApiData<ObservableCollection<TTable>>($"{GloabalValues.ApiBaseUrl}ttable").Get();
            DisciplineGroupTeachersInDb = new SyncApiData<ObservableCollection<DisciplineGroupTeacher>>($"{GloabalValues.ApiBaseUrl}dgt").Get();
        }
        public DelegateCommand ImportCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    string expath;
                    var dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == false) return;
                    expath = dialog.FileName;
                    var department = Path.GetFileNameWithoutExtension(expath);
                    await ImportAsync(expath);
                });
            }
        }
        private async Task<bool> ImportAsync(string expath)
        {
            try
            {
                DisciplineGroupTeacher? disciplineGroupTeacher = null;
                var GroupsInExcel = new List<Group>();
                var DisciplinesInExcel = new List<Discipline>();
                var TeachersInExcel = new List<Teacher>();
                var OfficesInExcel = new List<Office>();
                var LessonInExcel = new List<Lesson>();
                var WeekDaysInExcel = new List<WeekDay>();
                var DepartmentsInExcel = new List<Department>();
                var TTablesInExcel = new List<TTable>();
                var DisciplineGroupTeacherInExcel = new List<DisciplineGroupTeacher>();
                var group = "";
                var teacher = "";
                var discipline = "";
                var office = "";
                var lesson = "";
                var weekday = "";

                var department = Path.GetFileNameWithoutExtension(expath);
                Department? depname = DepartmentInDb.Where(x => x.Name == department).First();
                if (depname != null)
                {
                    AsyncDeleteApi.Delete($"delete/{depname.IdDepartment}");
                }
                XLWorkbook workbook;
                using (workbook = new XLWorkbook(expath))
                {
                    DepartmentsInExcel.Add(new Department
                    {
                        Name = department.Trim()
                    });
                    foreach (var worksheet in workbook.Worksheets)
                        for (var i = 3; i <= 25; i += 4)
                        {
                            group = worksheet.Row(1).Cell(i).GetString();
                            //Создание листа группы
                            if (group != "")
                                GroupsInExcel.Add(new Group
                                {
                                    Name = group.DeleteErrors()
                                });
                            for (var j = 3; j <= 85; j += 1)
                            {
                                if (j % 2 == 0)
                                {
                                    discipline = worksheet.Row(j).Cell(i).GetString();
                                    //Создание листа дисциплины
                                    if (discipline != "")
                                        DisciplinesInExcel.Add(new Discipline
                                        {
                                            Name = discipline.DeleteErrors()
                                        });
                                    teacher = worksheet.Row(j + 1).Cell(i).GetString();
                                    //Создание листа учителя
                                    if (teacher != "")
                                        TeachersInExcel.Add(new Teacher
                                        {
                                            Name = teacher.DeleteErrors()
                                        });
                                }

                                if (i - 2 == 1 || i - 6 == 1 || i - 10 == 1)
                                {
                                    if ((j >= 3) & (j <= 30))
                                        weekday = "ПОНЕДЕЛЬНИК";
                                    else if ((j >= 31) & (j <= 58))
                                        weekday = "ВТОРНИК";
                                    else if ((j >= 59) & (j <= 86)) weekday = "СРЕДА";
                                }
                                else if (i - 2 == 15 || i - 6 == 15 || i - 10 == 15)
                                {
                                    if ((j >= 3) & (j <= 30))
                                        weekday = "ЧЕТВЕРГ";
                                    else if ((j >= 31) & (j <= 58))
                                        weekday = "ПЯТНИЦА";
                                    else if ((j >= 59) & (j <= 86)) weekday = "СУББОТА";
                                }


                                office = worksheet.Row(j).Cell(i + 3).GetString();
                                if (office == "") office = worksheet.Row(j + 1).Cell(i + 3).GetString();
                                OfficesInExcel.Add(new Office
                                {
                                    OfficeNumber = office.DeleteErrors()
                                });

                                if (i - 1 == 2 || i - 1 == 16)
                                {
                                    var c = worksheet.Row(j).Cell(i - 1);
                                    lesson = worksheet.Row(j).Cell(i - 1).GetString().DeleteErrors();
                                    if (lesson == "") lesson = worksheet.Row(j + 1).Cell(i - 1).GetString().DeleteErrors();
                                }

                                else if (i - 5 == 2 || i - 5 == 16)
                                {
                                    var c = worksheet.Row(j).Cell(i - 5);
                                    lesson = worksheet.Row(j).Cell(i - 5).GetString();
                                    if (lesson == "") lesson = worksheet.Row(j + 1).Cell(i - 5).GetString().DeleteErrors();
                                }
                                else if (i - 9 == 2 || i - 9 == 16)
                                {
                                    var c = worksheet.Row(j).Cell(i - 9);
                                    lesson = worksheet.Row(j).Cell(i - 9).GetString().DeleteErrors();
                                    if (lesson == "") lesson = worksheet.Row(j + 1).Cell(i - 9).GetString().DeleteErrors();
                                }
                                //Создание экземпляра клсса Предмет группа преподаватель

                                if (discipline != "" && teacher != "" && group != "")
                                {
                                    disciplineGroupTeacher = new DisciplineGroupTeacher
                                    {
                                        TeacherName = teacher.DeleteErrors(),
                                        DisciplineName = discipline.DeleteErrors(),
                                        GroupName = group.DeleteErrors()
                                    };
                                    DisciplineGroupTeacherInExcel.Add(disciplineGroupTeacher);
                                }
                                else if (discipline != "" && group != "")
                                {
                                    disciplineGroupTeacher = new DisciplineGroupTeacher
                                    {
                                        TeacherName = teacher.DeleteErrors(),
                                        DisciplineName = discipline.DeleteErrors(),
                                        GroupName = group.DeleteErrors()
                                    };
                                    DisciplineGroupTeacherInExcel.Add(disciplineGroupTeacher);
                                }
                                else
                                {
                                    disciplineGroupTeacher = null;
                                }

                                //Создание экземпляра класса расписание
                                if (disciplineGroupTeacher != null && lesson != "" && weekday != "")
                                {
                                    if (TTablesInExcel.Count == 0)
                                        TTablesInExcel.Add(new TTable
                                        {
                                            WeekDayName = weekday.DeleteErrors(),
                                            LessonName = lesson.DeleteErrors(),
                                            OfficeName = office.DeleteErrors(),
                                            DisciplineGroupTeacher = disciplineGroupTeacher
                                        });
                                    else if (TTablesInExcel.Last().LessonName != lesson &&
                                             TTablesInExcel.Last().WeekDayName == weekday)
                                        TTablesInExcel.Add(new TTable
                                        {
                                            WeekDayName = weekday.DeleteErrors(),
                                            LessonName = lesson.DeleteErrors(),
                                            OfficeName = office.DeleteErrors(),
                                            DisciplineGroupTeacher = disciplineGroupTeacher
                                        });
                                    else if (TTablesInExcel.Last().LessonName != lesson.DeleteErrors() &&
                                             TTablesInExcel.Last().WeekDayName != weekday.DeleteErrors())
                                        TTablesInExcel.Add(new TTable
                                        {
                                            WeekDayName = weekday.DeleteErrors(),
                                            LessonName = lesson.DeleteErrors(),
                                            OfficeName = office.DeleteErrors(),
                                            DisciplineGroupTeacher = disciplineGroupTeacher
                                        });
                                }
                            }

                            if (i == 11) i += 2;
                            ;
                        }

                    IEnumerable<Group>? groups = null;
                    IEnumerable<Teacher>? teachers = null;
                    IEnumerable<Discipline>? disciplines = null;
                    IEnumerable<Office>? offices = null;
                    IEnumerable<Department>? departments = null;
                    IEnumerable<DisciplineGroupTeacher>? disciplinegroupteachers = null;

                    var ttables = new List<TTable>();
                    OfficesInExcel = OfficesInExcel.GroupBy(x => x.OfficeNumber).Select(x => x.First()).ToList();
                    if (OfficesInDb != null)
                        offices = OfficesInExcel.Where(x => !OfficesInDb.Any(x2 => x2.OfficeNumber == x.OfficeNumber));
                    else
                        offices = OfficesInExcel;
                    ;


                    GroupsInExcel = GroupsInExcel.GroupBy(x => x.Name).Select(x => x.First()).ToList();
                    if (GroupsInDb != null)
                        groups = GroupsInExcel.Where(x => !GroupsInDb.Any(x2 => x2.Name == x.Name));
                    else
                        groups = GroupsInExcel;
                    ;
                    TeachersInExcel = TeachersInExcel.GroupBy(x => x.Name).Select(x => x.First()).ToList();
                    if (TeachersInDb != null)
                        teachers = TeachersInExcel.Where(x => !TeachersInDb.Any(x2 => x2.Name == x.Name));
                    else
                        teachers = TeachersInExcel;
                    ;
                    DisciplinesInExcel = DisciplinesInExcel.GroupBy(x => x.Name).Select(x => x.First()).ToList();
                    if (DisciplinesInDb != null)
                        disciplines = DisciplinesInExcel.Where(x => !DisciplinesInDb.Any(x2 => x2.Name == x.Name));
                    else
                        disciplines = DisciplinesInExcel;
                    ;
                    DepartmentsInExcel = DepartmentsInExcel.GroupBy(x => x.Name).Select(x => x.First()).ToList();
                    if (DepartmentsInDb != null)
                        departments = DepartmentsInExcel.Where(x => !DepartmentsInDb.Any(x2 => x2.Name == x.Name));
                    else
                        departments = DepartmentsInExcel;

                    DisciplineGroupTeacherInExcel = DisciplineGroupTeacherInExcel
                        .GroupBy(x => new { x.GroupName, x.DisciplineName }).Select(x => x.First()).ToList();

                    var t = "";
                    foreach (var item in DisciplineGroupTeacherInExcel)
                        t += $"{item.DisciplineName} : {item.GroupName} : {item.TeacherName}\r\n";

                    foreach (var item in teachers)
                    {
                        await AsyncPostApi.Post("teacher", item);
                    }
                    foreach (var item in disciplines)
                    {
                        await AsyncPostApi.Post("discipline", item);
                    }

                    foreach (var item in offices)
                    {
                        await AsyncPostApi.Post("office", item);
                    }

                    foreach (var item in departments)
                    {
                        await AsyncPostApi.Post("department", item);
                    }

                    foreach (var item in groups)
                    {
                        await AsyncPostApi.Post("group", item);
                    }

                    GroupsInDb = new SyncApiData<ObservableCollection<Group>>($"{GloabalValues.ApiBaseUrl}group").Get();
                    DisciplinesInDb = new SyncApiData<ObservableCollection<Discipline>>($"{GloabalValues.ApiBaseUrl}discipline").Get();
                    TeachersInDb = new SyncApiData<ObservableCollection<Teacher>>($"{GloabalValues.ApiBaseUrl}teacher").Get();

                    foreach (var item in DisciplineGroupTeacherInExcel)
                    {
                        item.IdGroup = GroupsInDb.Where(x => x.Name == item.GroupName).First().IdGroup;
                        item.IdDiscipline = DisciplinesInDb.Where(x => x.Name == item.DisciplineName).First().IdDiscipline;
                        item.IdTeacher = item.TeacherName != "" ? TeachersInDb.Where(x => x.Name == item.TeacherName).First().IdTeacher : 0;
                    }

                    if (DisciplineGroupTeachersInDb != null)
                        disciplinegroupteachers = DisciplineGroupTeacherInExcel.Where(l2 =>
                            !DisciplineGroupTeachersInDb.Any(l1 =>
                                l1.IdGroup == l2.IdGroup && l1.IdDiscipline == l2.IdDiscipline)).ToList();
                    else
                        disciplinegroupteachers = DisciplineGroupTeacherInExcel;
                    ;
                    foreach (var item in disciplinegroupteachers)
                    {
                        await AsyncPostApi.Post("dgt", item);

                    }
                    TTablesInExcel = TTablesInExcel
                        .GroupBy(x => new { x.WeekDayName, x.LessonName, x.DisciplineGroupTeacher }).Select(x => x.First())
                        .ToList();
                    var d = "";
                    foreach (var item in TTablesInExcel)
                        d +=
                            $"{item.DisciplineGroupTeacher.GroupName} : {item.DisciplineGroupTeacher.DisciplineName} : {item.WeekDayName}\r\n";
                    WeekDaysInDb = new SyncApiData<ObservableCollection<WeekDay>>($"{GloabalValues.ApiBaseUrl}weekday").Get();
                    OfficesInDb = new SyncApiData<ObservableCollection<Office>>($"{GloabalValues.ApiBaseUrl}office").Get();
                    LessonIdDb = new SyncApiData<ObservableCollection<Lesson>>($"{GloabalValues.ApiBaseUrl}lesson").Get();
                    DisciplineGroupTeachersInDb = new SyncApiData<ObservableCollection<DisciplineGroupTeacher>>($"{GloabalValues.ApiBaseUrl}dgt").Get();

                    foreach (var item in TTablesInExcel)
                    {
                        item.IdWeekDay = WeekDaysInDb.Where(x => x.Name == item.WeekDayName).First().IdWeekDay;
                        item.IdLesson = LessonIdDb.Where(x => x.LessonNumber == item.LessonName).First().IdLesson;
                        item.IdOffice = item.OfficeName != "" ? OfficesInDb.Where(x => x.OfficeNumber == item.OfficeName).First().IdOffice : 0;
                        item.IdDisciplineGroupTeacher = DisciplineGroupTeachersInDb.First(x =>
                                item.DisciplineGroupTeacher.GroupName == x.Group.Name && item.DisciplineGroupTeacher.DisciplineName == x.Discipline.Name).IdDisciplineGroupTeacher;
                    }

                    var tables = TTablesInDb != null
                        ? TTablesInExcel.Where(l2 => !TTablesInDb.Any(l1 =>
                            l1.IdLesson == l2.IdLesson && l1.IdWeekDay == l2.IdWeekDay &&
                            l1.IdDisciplineGroupTeacher == l2.IdDisciplineGroupTeacher)).ToList()
                        : TTablesInExcel;
                    var client = new HttpClient();
                    foreach (var item in tables)
                    {
                        var a = new TTable { IdLesson = item.IdLesson, IdWeekDay = item.IdWeekDay, IdOffice = item.IdOffice, IdDisciplineGroupTeacher = item.IdDisciplineGroupTeacher };
                        
                        await client.PostAsJsonAsync($"{GloabalValues.ApiBaseUrl}ttable", a);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
