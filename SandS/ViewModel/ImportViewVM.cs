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
    internal class ImportViewVM : ViewModelBase
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
        private string expath;
        public bool Loading { get; set; }
        public bool ImportByttunIsEnable { get; set; }

        public ImportViewVM()
        {
            ImportByttunIsEnable = true;
        }
        public DelegateCommand ImportCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    var dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == false) return;
                    expath = dialog.FileName;
                    var department = Path.GetFileNameWithoutExtension(expath);
                    try
                    {
                        ImportByttunIsEnable = false;
                        Loading = true;
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

                        await Task.Run(ImportAsync).ContinueWith(_ => { Loading = false; ImportByttunIsEnable = true; }, TaskScheduler.FromCurrentSynchronizationContext());
                        //await ImportAsync();  
                    }
                    catch
                    {
                        return;
                    }
                });
            }
        }
        private async Task<bool> ImportAsync()
        {
            TTable f = null;
            try
            {
                DisciplineGroupTeacher? disciplineGroupTeacher = null;
                var GroupsInExcel = new ObservableCollection<Group>();
                var DisciplinesInExcel = new ObservableCollection<Discipline>();
                var TeachersInExcel = new ObservableCollection<Teacher>();
                var OfficesInExcel = new ObservableCollection<Office>();
                var LessonInExcel = new ObservableCollection<Lesson>();
                var WeekDaysInExcel = new ObservableCollection<WeekDay>();
                var DepartmentsInExcel = new ObservableCollection<Department>();
                var TTablesInExcel = new ObservableCollection<TTable>();
                var DisciplineGroupTeacherInExcel = new ObservableCollection<DisciplineGroupTeacher>();
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
                    var delete = new AsyncDeleteApi();
                    AsyncDeleteApi.Delete($"delete/{depname.IdDepartment}");
                }
                else
                {
                    depname = SyncGetApiData.GetDepartmentByName(department);
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
                                    Name = group.DeleteErrors(),
                                    IdDepartment = depname.IdDepartment
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

                    ObservableCollection<Group>? groups = null;
                    ObservableCollection<Teacher>? teachers = null;
                    ObservableCollection<Discipline>? disciplines = null;
                    ObservableCollection<Office>? offices = null;
                    ObservableCollection<Department>? departments = null;
                    ObservableCollection<DisciplineGroupTeacher>? disciplinegroupteachers = null;

                    var ttables = new List<TTable>();
                    OfficesInExcel = new ObservableCollection<Office>(OfficesInExcel.GroupBy(x => x.OfficeNumber).Select(x => x.First()).ToList());
                    if (OfficesInDb.Count != 0)
                        offices = new ObservableCollection<Office>(OfficesInExcel.Where(x => !OfficesInDb.Any(x2 => x2.OfficeNumber == x.OfficeNumber)));
                    if (OfficesInDb.Count != 0 && offices.Count == 0)
                        offices = OfficesInDb;
                    else if (offices.Count == 0 && OfficesInDb.Count == 0)
                        offices = OfficesInExcel;
                    ;


                    GroupsInExcel = new ObservableCollection<Group>(GroupsInExcel.GroupBy(x => x.Name).Select(x => x.First()).ToList());
                    if (GroupsInDb.Count != 0)
                        groups = new ObservableCollection<Group>(GroupsInExcel.Where(x => !GroupsInDb.Any(x2 => x2.Name == x.Name)));
                    if (groups.Count == 0 || groups == null && GroupsInDb.Count != 0)
                        groups = GroupsInDb;
                    else if (groups.Count == 0 || groups == null && GroupsInDb.Count == 0)
                        groups = GroupsInExcel;
                    ;
                    TeachersInExcel = new ObservableCollection<Teacher>(TeachersInExcel.GroupBy(x => x.Name).Select(x => x.First()).ToList());
                    if (TeachersInDb.Count != 0)
                        teachers = new ObservableCollection<Teacher>(TeachersInExcel.Where(x => !TeachersInDb.Any(x2 => x2.Name == x.Name)));
                    if (teachers.Count == 0 || teachers == null && TeachersInDb.Count != 0)
                        teachers = TeachersInDb;
                    else if (teachers.Count == 0 || teachers == null && TeachersInDb.Count == 0)
                        teachers = TeachersInExcel;
                    ;
                    DisciplinesInExcel = new ObservableCollection<Discipline>(DisciplinesInExcel.GroupBy(x => x.Name).Select(x => x.First()).ToList());
                    if (DisciplinesInDb.Count != 0)
                        disciplines = new ObservableCollection<Discipline>(DisciplinesInExcel.Where(x => !DisciplinesInDb.Any(x2 => x2.Name == x.Name)));
                    if (disciplines.Count == 0 || disciplines == null && DisciplinesInDb.Count != 0)
                        disciplines = DisciplinesInDb;
                    else if (disciplines.Count == 0 || disciplines == null && DisciplinesInDb.Count == 0)
                        disciplines = DisciplinesInExcel;
                    ;
                    DepartmentsInExcel = new ObservableCollection<Department>(DepartmentsInExcel.GroupBy(x => x.Name).Select(x => x.First()).ToList());
                    if (DepartmentsInDb.Count != 0)
                        departments = new ObservableCollection<Department>(DepartmentsInExcel.Where(x => !DepartmentsInDb.Any(x2 => x2.Name == x.Name)));
                    if (departments.Count == 0 || departments == null && DepartmentInDb.Count != 0)
                        departments = DepartmentsInDb;
                    else if (departments.Count == 0 || departments == null && DepartmentInDb.Count == 0)
                        departments = DepartmentsInExcel;


                    DisciplineGroupTeacherInExcel = new ObservableCollection<DisciplineGroupTeacher>(DisciplineGroupTeacherInExcel
                        .GroupBy(x => new { x.GroupName, x.DisciplineName }).Select(x => x.First()).ToList());

                    var t = "";
                    foreach (var item in DisciplineGroupTeacherInExcel)
                        t += $"{item.DisciplineName} : {item.GroupName} : {item.TeacherName}\r\n";

                    foreach (var item in teachers)
                    {
                        item.IdTeacher = item.IdTeacher == 0 ? new SyncApiData<Teacher>($"{GloabalValues.ApiBaseUrl}teacher", item).Post().IdTeacher : item.IdTeacher;
                    }
                    foreach (var item in disciplines)
                    {
                        item.IdDiscipline = item.IdDiscipline == 0 ? new SyncApiData<Discipline>($"{GloabalValues.ApiBaseUrl}discipline", item).Post().IdDiscipline : item.IdDiscipline;
                    }

                    foreach (var item in offices)
                    {
                        item.IdOffice = item.IdOffice == 0 ? new SyncApiData<Office>($"{GloabalValues.ApiBaseUrl}office", item).Post().IdOffice : item.IdOffice;
                    }

                    foreach (var item in departments)
                    {
                        item.IdDepartment = item.IdDepartment == 0 ? new SyncApiData<Department>($"{GloabalValues.ApiBaseUrl}department", item).Post().IdDepartment : item.IdDepartment;
                    }

                    foreach (var item in groups)
                    {
                        item.IdGroup = item.IdGroup == 0 ? new SyncApiData<Group>($"{GloabalValues.ApiBaseUrl}group", item).Post().IdGroup : item.IdGroup;
                    }

                    foreach (var item in DisciplineGroupTeacherInExcel)
                    {
                        item.IdGroup = groups.Where(x => x.Name == item.GroupName).First().IdGroup;
                        item.IdDiscipline = disciplines.Where(x => x.Name == item.DisciplineName).First().IdDiscipline;
                        item.IdTeacher = item.TeacherName != "" ? teachers.Where(x => x.Name == item.TeacherName).First().IdTeacher : 0;
                    }
                    string a = "";
                    if (DisciplineGroupTeachersInDb.Count != 0)
                        disciplinegroupteachers = new ObservableCollection<DisciplineGroupTeacher>(DisciplineGroupTeacherInExcel.Where(l2 =>
                            !DisciplineGroupTeachersInDb.Any(l1 =>
                                l1.IdGroup == l2.IdGroup && l1.IdDiscipline == l2.IdDiscipline)).ToList());
                    if (disciplinegroupteachers?.Count > 0)
                    {
                        foreach (var item in disciplinegroupteachers)
                        {
                            //a += $"{item.DisciplineName} : {item.GroupName} : {item?.TeacherName}\n\r";
                            _ = new SyncApiData<DisciplineGroupTeacher>($"{GloabalValues.ApiBaseUrl}dgt", item).Post();
                        }
                    }
                    else if (disciplinegroupteachers?.Count == 0 || disciplinegroupteachers == null && DisciplineGroupTeachersInDb.Count != 0)
                    {
                        disciplinegroupteachers = DisciplineGroupTeachersInDb;
                    }
                    else if (disciplinegroupteachers?.Count == 0 || disciplinegroupteachers == null && DisciplineGroupTeachersInDb.Count == 0)
                    {
                        disciplinegroupteachers = DisciplineGroupTeacherInExcel;
                        foreach (var item in disciplinegroupteachers)
                        {
                            a += $"{item.DisciplineName} : {item.GroupName} : {item.TeacherName}\n\r";
                            _ = new SyncApiData<DisciplineGroupTeacher>($"{GloabalValues.ApiBaseUrl}dgt", item).Post();
                        }
                    }


                    TTablesInExcel = new ObservableCollection<TTable>(TTablesInExcel
                        .GroupBy(x => new { x.WeekDayName, x.LessonName, x.DisciplineGroupTeacher }).Select(x => x.First())
                        .ToList());
                    var d = "";
                    foreach (var item in TTablesInExcel)
                    {
                        d += $"{item.DisciplineGroupTeacher.GroupName} : {item.DisciplineGroupTeacher.DisciplineName} : {item.WeekDayName}\r\n";
                    }
                    disciplinegroupteachers = new SyncApiData<ObservableCollection<DisciplineGroupTeacher>>($"{GloabalValues.ApiBaseUrl}dgt").Get();
                    foreach (var item in disciplinegroupteachers)
                    {
                        a += $"{item.Discipline.Name} : {item.Group.Name} : {item.Teacher.Name}\n\r";
                    }
                    string b = "";
                    foreach (var item in TTablesInExcel)
                    {
                        f = item;
                        item.IdWeekDay = WeekDaysInDb.Where(x => x.Name == item.WeekDayName).First().IdWeekDay;
                        item.IdLesson = LessonIdDb.Where(x => x.LessonNumber == item.LessonName).First().IdLesson;
                        item.IdOffice = item.OfficeName != "" ? offices.Where(x => x.OfficeNumber == item.OfficeName).First().IdOffice : 0;
                        item.IdDisciplineGroupTeacher = disciplinegroupteachers.Where(x =>
                                item.DisciplineGroupTeacher.GroupName == x.Group.Name && item.DisciplineGroupTeacher.DisciplineName == x.Discipline.Name).First().IdDisciplineGroupTeacher;

                    }
                    var tables = TTablesInExcel;
                    var client = new HttpClient();
                    foreach (var item in tables)
                    {
                        var c = new TTable { IdLesson = item.IdLesson, IdWeekDay = item.IdWeekDay, IdOffice = item.IdOffice, IdDisciplineGroupTeacher = item.IdDisciplineGroupTeacher };

                        await client.PostAsJsonAsync($"{GloabalValues.ApiBaseUrl}ttable", c);
                    }
                }
                return true;
            }
            catch (Exception a)
            {
                var ff = f;
                var dd = a.Message;
                if (ff != null)
                {
                    throw;
                }
                throw;
            }
        }
    }
}
