using DevExpress.Mvvm;
using SandS.Model;
using SandS.Resource;
using SandS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.ViewModel
{
    internal class CreateShuduleVM : ViewModelBase
    {
        public TaskCompletion<ObservableCollection<Group>> Groups { get; set; }
        public TaskCompletion<ObservableCollection<Department>> Departments { get; set; }
        public Department SelectedDepartment { get; set; }
        public Group SelectedGroup { get; set; }
        public bool GroupsIsEnabled { get; set; }
        public bool DisciplinesIsEnabled { get; set; }
        public bool OfficesIsEnabled { get; set; }
        public CreateShuduleVM()
        {
            GroupsIsEnabled = false;
            DisciplinesIsEnabled = false;
            OfficesIsEnabled = false;
        }
        public DelegateCommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Departments = AsyncGetApiData.GetDepartments();
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
        //private async Task<bool> ShowFreeDisciplies()
        //{

        //    var TTablesInDb = AsyncGetApiData.GetTTables();
        //    var dgtforgroup = new SyncApiData<ObservableCollection<DisciplineGroupTeacher>>($"{GloabalValues.ApiBaseUrl}dgt/getforgroup/").Get();
        //    var subTTablesInDb = AsyncGetApiData.GetSubTtables();
        //    var AllOfficesInDb = AsyncGetApiData.GetOffices();

        //    //Все дисциплины у данной группы

        //    var DayOfWeek = (int)DateBox.SelectedDate.Value.DayOfWeek;
        //    //Получаем все дисциплины, которые ведут преподаватели данной группы
        //    var AllDusciplinesInTTable = TTablesInDb.Result
        //        .Where(x => dgtforgroup.Any(x2 => x.GetDisciplineGroupTeacher().IdTeacher == x2.IdTeacher)).ToList();

        //    //Получем все дисциплины из замен, которые ведут преподаватели данной группы
        //    var AllDisciplineInSubTTable = subTTablesInDb != null
        //        ? subTTablesInDb
        //            .Where(x => dgtforgroup.Any(x2 => x.GetDisciplineGroupTeacher().Result.IdTeacher == x2.IdTeacher)).ToList()
        //        : null;

        //    //Получем препродавателей, которые не доступны на указанную пару и день недели
        //    var NoAvailableTeachers = AllDusciplinesInTTable.Where(x => x.IdLesson == (int)LessonCombobox.SelectedValue
        //                                                                && x.IdWeekDay == DayOfWeek).ToList();

        //    //Удалить из недоступных преподавтелей тех, которые своболны из-за замен
        //    if (AllDisciplineInSubTTable != null)
        //        NoAvailableTeachers.RemoveAll(x => AllDisciplineInSubTTable
        //            .Any(x2 => x.IdLesson == x2.IdLesson && x.IdWeekDay == x2.IdWeekDay &&
        //                       x.GetDisciplineGroupTeacher().IdGroup == x2.GetDisciplineGroupTeacher().Result.IdGroup));

        //    //Удаляем всех недоступных преподавателей по расписанию
        //    AllDusciplinesInTTable.RemoveAll(x => NoAvailableTeachers.Any(x2 =>
        //        x.GetDisciplineGroupTeacher().IdTeacher == x2.GetDisciplineGroupTeacher().IdTeacher));

        //    //Получаем недоступных преподавателей на текущий день недели и пару по заменам
        //    var NoAvailableTeachersInSubTTable = AllDisciplineInSubTTable != null
        //        ? AllDisciplineInSubTTable.Where(x => x.IdLesson == (int)LessonCombobox.SelectedValue
        //                                              && x.Date == DateBox.SelectedDate.Value).ToList()
        //        : null;

        //    //Удаляем всех недоаступных преподавателей по заменам
        //    if (NoAvailableTeachersInSubTTable != null)
        //        AllDusciplinesInTTable.RemoveAll(x => NoAvailableTeachersInSubTTable.Any(x2 =>
        //            x.GetDisciplineGroupTeacher().IdTeacher == x2.GetDisciplineGroupTeacher().Result.IdTeacher));

        //    //Получем все доступные для замены предметы для данной группы
        //    var AvailableDisciplinesForGroup = AllDusciplinesInTTable.Where(x =>
        //        x.GetDisciplineGroupTeacher().IdGroup == (int)GroupCombobox.SelectedValue);

        //    //Полуаем недоступные кабинеты по расписанию
        //    var NoAvailableOfficesInTtable = TTablesInDb != null
        //        ? TTablesInDb.GetAwaiter().GetResult().Where(x => x.IdWeekDay == (int)DateBox.SelectedDate.Value.DayOfWeek
        //                                 && x.IdLesson == (int)LessonCombobox.SelectedValue)
        //        : null;

        //    //Получаем недоступные кабинеты по заменам
        //    var NoAvailableOfficesInSubTTable = subTTablesInDb != null
        //        ? subTTablesInDb.Where(x => x.IdWeekDay == (int)DateBox.SelectedDate.Value.DayOfWeek
        //                                    && x.IdLesson == (int)LessonCombobox.SelectedValue)
        //        : null;

        //    var f = "";
        //    foreach (var item in NoAvailableOfficesInTtable) f += $"{item.Office.OfficeNumber}\n\r";
        //    var h = "";
        //    foreach (var item in NoAvailableTeachersInSubTTable) h += $"{item.Office.OfficeNumber}\n\r";

        //    if (NoAvailableOfficesInTtable != null)
        //        AllOfficesInDb.RemoveAll(x => NoAvailableOfficesInTtable.Any(x2 => x2.IdOffice == x.IdOffice));
        //    if (NoAvailableOfficesInSubTTable != null)
        //        AllOfficesInDb.RemoveAll(x => NoAvailableOfficesInSubTTable.Any(x2 => x2.IdOffice == x.IdOffice));

        //    var AvailableOffices = AllOfficesInDb;

        //    AvailableOffices = AvailableOffices.GroupBy(x => x.IdOffice).Select(x => x.First()).ToList();
        //    AvailableDisciplinesForGroup = AvailableDisciplinesForGroup
        //        .GroupBy(x => x.GetDisciplineGroupTeacher().IdDiscipline).Select(x => x.First()).ToList();
        //    DisciplineCombobox.IsEnabled = true;
        //    OfficeCombobox.IsEnabled = true;
        //    DisciplineCombobox.ItemsSource = AvailableDisciplinesForGroup;
        //    OfficeCombobox.ItemsSource = AvailableOffices;
        //}
    }
}