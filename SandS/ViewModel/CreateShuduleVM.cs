using DevExpress.Mvvm;
using SandS.Model;
using SandS.Resource;
using SandS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SandS.ViewModel
{
    internal class CreateShuduleVM : ViewModelBase
    {
        public TaskCompletion<ObservableCollection<Group>> Groups { get; set; }
        public TaskCompletion<ObservableCollection<Lesson>> Lessons { get; set; }
        public TaskCompletion<ObservableCollection<Department>> Departments { get; set; }
        public ObservableCollection<TTable> Disciplines { get; set; }
        public ObservableCollection<Office> Offices { get; set; }
        public Department SelectedDepartment { get; set; }
        public TTable SelectedDiscipline { get; set; }
        public Group SelectedGroup { get; set; }
        public Office SelectedOffice { get; set; }
        public DateTime SelectedDate { get; set; }
        public Lesson SelectedLesson { get; set; }
        public bool DepartmentsIsEnabled { get; set; }
        public bool DateIsEnabled { get; set; }
        public bool LessonsIsEnabled { get; set; }
        public bool GroupsIsEnabled { get; set; }
        public bool DisciplinesIsEnabled { get; set; }
        public bool OfficesIsEnabled { get; set; }
        public bool AddButtonIsEnabled { get; set; }
        public bool Loading { get; set; }
        public string Result { get; set; }
        public CreateShuduleVM()
        {
            
        }
        public DelegateCommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Departments = AsyncGetApiData.GetDepartments();
                    Lessons = AsyncGetApiData.GetLessons();
                    Loading = false;
                    GroupsIsEnabled = false;
                    DisciplinesIsEnabled = false;
                    AddButtonIsEnabled = false;
                    OfficesIsEnabled = false;
                    DepartmentsIsEnabled = true;
                    DateIsEnabled = true;
                    LessonsIsEnabled = true;
                });
            }
        }
        public DelegateCommand DepartmentsSelectedChangedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectedDepartment != null)
                    {
                        Groups = AsyncGetApiData.GroupsByDepartment(SelectedDepartment.IdDepartment);
                        GroupsIsEnabled = true;
                    }
                    else
                    {
                        GroupsIsEnabled = false;
                    }
                });
            }
        }
        public DelegateCommand SeartchValuesSelectedChangedCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    DisciplinesIsEnabled = false;
                    OfficesIsEnabled = false;
                    if (SelectedGroup == null || SelectedDate.Date == default || SelectedLesson == null) { return; }
                    Loading = true;
                    DepartmentsIsEnabled = false;
                    GroupsIsEnabled = false;
                    DateIsEnabled = false;
                    LessonsIsEnabled = false;
                    AddButtonIsEnabled = false;
                    await Task.Run(ShowFreeDisciplies).ContinueWith(_ => { 
                        Loading = false; 
                        DisciplinesIsEnabled = true;
                        OfficesIsEnabled = true;
                        DepartmentsIsEnabled = true;
                        GroupsIsEnabled = true;
                        DateIsEnabled = true;
                        LessonsIsEnabled = true;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                });
            }
        }
        public DelegateCommand SelectedValuesSelectedChangedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if(SelectedDiscipline == null || SelectedOffice == null) { AddButtonIsEnabled = false; return; }
                    AddButtonIsEnabled = true;
                });
            }
        }
        public DelegateCommand AddButtonCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    ObservableCollection<SubTTable> allSubTTable = SyncGetApiData.GetSubTTable();
                    string date = SelectedDate.DateStr();
                    bool a = allSubTTable.Any(x => x.GetDisciplineGroupTeacher.IdGroup == SelectedDiscipline.GetDisciplineGroupTeacher.IdGroup && x.Date == date);
                    if(a) { Result = "Замена существует"; return; }
                    Loading = true;
                    DisciplinesIsEnabled = false;
                    OfficesIsEnabled = false;
                    DepartmentsIsEnabled = false;
                    GroupsIsEnabled = false;
                    DateIsEnabled = false;
                    LessonsIsEnabled = false;
                    AddButtonIsEnabled = false;
                    await Task.Run(AddSubTTable).ContinueWith(_ => {
                        Loading = false;
                        DisciplinesIsEnabled = true;
                        OfficesIsEnabled = true;
                        DepartmentsIsEnabled = true;
                        GroupsIsEnabled = true;
                        DateIsEnabled = true;
                        LessonsIsEnabled = true;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                });
            }
        }
        private async Task<bool> ShowFreeDisciplies()
        {
            var client = new HttpClient();
            await client.GetAsync($"{GloabalValues.ApiBaseUrl}teacher");
            var TTablesInDb = SyncGetApiData.GetTTable();
            var subTTablesInDb = SyncGetApiData.GetSubTTable().ToList();
            var AllOfficesInDb = SyncGetApiData.GetOffice().ToList();
            var DayOfWeek = (int)SelectedDate.DayOfWeek;

            //Все дисциплины у данной группы
            var dgtforgroup = SyncGetApiData.GetDgtForGroup(SelectedGroup.IdGroup);

            //Получаем все дисциплины, которые ведут преподаватели данной группы
            var AllDusciplinesInTTable = TTablesInDb.Where(x => dgtforgroup.Any(x2 => x.GetDisciplineGroupTeacher.IdTeacher == x2.IdTeacher)).ToList();

            //Получем все дисциплины из замен, которые ведут преподаватели данной группы
            var AllDisciplineInSubTTable = subTTablesInDb != null
                ? subTTablesInDb
                    .Where(x => dgtforgroup.Any(x2 => x.GetDisciplineGroupTeacher.IdTeacher == x2.IdTeacher)).ToList()
                : null;

            //Получем препродавателей, которые не доступны на указанную пару и день недели
            var NoAvailableTeachers = AllDusciplinesInTTable.Where(x => x.IdLesson == SelectedLesson.IdLesson
                                                                        && x.IdWeekDay == DayOfWeek).ToList();

            //Удалить из недоступных преподавтелей тех, которые своболны из-за замен
            if (AllDisciplineInSubTTable != null)
                NoAvailableTeachers.RemoveAll(x => AllDisciplineInSubTTable
                    .Any(x2 => x.IdLesson == x2.IdLesson && x.IdWeekDay == x2.IdWeekDay &&
                               x.GetDisciplineGroupTeacher.IdGroup == x2.GetDisciplineGroupTeacher.IdGroup));

            //Удаляем всех недоступных преподавателей по расписанию
            AllDusciplinesInTTable.RemoveAll(x => NoAvailableTeachers.Any(x2 =>
                x.GetDisciplineGroupTeacher.IdTeacher == x2.GetDisciplineGroupTeacher.IdTeacher));

            //Получаем недоступных преподавателей на текущий день недели и пару по заменам
            var NoAvailableTeachersInSubTTable = AllDisciplineInSubTTable != null
                ? AllDisciplineInSubTTable.Where(x => x.IdLesson == SelectedLesson.IdLesson
                                                      && x.Date == SelectedDate.DateStr()).ToList()
                : null;

            //Удаляем всех недоаступных преподавателей по заменам
            if (NoAvailableTeachersInSubTTable != null)
                AllDusciplinesInTTable.RemoveAll(x => NoAvailableTeachersInSubTTable.Any(x2 =>
                    x.GetDisciplineGroupTeacher.IdTeacher == x2.GetDisciplineGroupTeacher.IdTeacher));

            //Получем все доступные для замены предметы для данной группы
            var AvailableDisciplinesForGroup = AllDusciplinesInTTable.Where(x =>
                x.GetDisciplineGroupTeacher.IdGroup == SelectedGroup.IdGroup);

            //Полуаем недоступные кабинеты по расписанию
            var NoAvailableOfficesInTtable = TTablesInDb != null
                ? TTablesInDb.Where(x => x.IdWeekDay == DayOfWeek
                                         && x.IdLesson == SelectedLesson.IdLesson)
                : null;

            //Получаем недоступные кабинеты по заменам
            var NoAvailableOfficesInSubTTable = subTTablesInDb != null
                ? subTTablesInDb.Where(x => x.IdWeekDay == DayOfWeek
                                            && x.IdLesson == SelectedLesson.IdLesson)
                : null;

            var f = "";
            foreach (var item in NoAvailableOfficesInTtable) f += $"{item.Office.OfficeNumber}\n\r";
            var h = "";
            foreach (var item in NoAvailableTeachersInSubTTable) h += $"{item.Office.OfficeNumber}\n\r";

            if (NoAvailableOfficesInTtable != null)
                AllOfficesInDb.RemoveAll(x => NoAvailableOfficesInTtable.Any(x2 => x2.IdOffice == x.IdOffice));
            if (NoAvailableOfficesInSubTTable != null)
                AllOfficesInDb.RemoveAll(x => NoAvailableOfficesInSubTTable.Any(x2 => x2.IdOffice == x.IdOffice));

            var AvailableOffices = AllOfficesInDb;

            AvailableOffices = AvailableOffices.GroupBy(x => x.IdOffice).Select(x => x.First()).ToList();
            AvailableDisciplinesForGroup = AvailableDisciplinesForGroup
                .GroupBy(x => x.GetDisciplineGroupTeacher.IdDiscipline).Select(x => x.First()).ToList();
            
            Disciplines = new ObservableCollection<TTable>(AvailableDisciplinesForGroup.ToList());
            Offices = new ObservableCollection<Office>(AvailableOffices);
            return true;
        }
        private async Task<bool> AddSubTTable()
        {
            try
            {
                var client = new HttpClient();
                var c = new SubTTable { IdLesson = SelectedLesson.IdLesson, IdWeekDay = (int)SelectedDate.DayOfWeek, IdOffice = SelectedOffice.IdOffice, IdDisciplineGroupTeacher = SelectedDiscipline.IdDisciplineGroupTeacher, Date = SelectedDate.DateStr() };
                await client.PostAsJsonAsync($"{GloabalValues.ApiBaseUrl}subttable", c);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}