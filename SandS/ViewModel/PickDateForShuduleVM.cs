using DevExpress.Mvvm;
using SandS.Model;
using SandS.Services;
using SandS.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.ViewModel
{
    internal class PickDateForShuduleVM : ViewModelBase
    {
        public DateTime Date { get; set; }
        public TaskCompletion<ObservableCollection<Department>> Departments { get; set; }
        public TaskCompletion<ObservableCollection<Group>> Groups { get; set; }
        public Department SelectedDepartment { get; set; }
        public Group SelectedGroup { get; set; }
        public bool GroupsIsEndable { get; set; }
        public bool ShowButtonisEnable { get; set; }
        public int transitioner { get; set; }
        public ShowSubTTable ShowSubTtableUk { get; set; }
        public PickDateForShuduleVM()
        {
            Date = DateTime.Today;
            transitioner = 0;
            GroupsIsEndable = false;
        }
        public DelegateCommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Departments = DataWorker.GetDepartments();
                    GroupsIsEndable = false;
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
                        GroupsIsEndable = true;
                        Groups = DataWorker.GroupsByDepartment(SelectedDepartment.IdDepartment);
                    }
                    else
                    {
                        GroupsIsEndable = false;
                    }
                });
            }
        }
        public DelegateCommand ShowSubTtableCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var date = Date.DateStr();
                    var vm = new ShowSubTTableVM(SelectedGroup, Date);
                    ShowSubTtableUk = new ShowSubTTable(vm);
                    transitioner = 1;
                });
            }
        }
        public DelegateCommand GroupsSelectedChangedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if(SelectedGroup != null)
                    {
                        ShowButtonisEnable = true;
                    }
                    else
                    {
                        ShowButtonisEnable = false;
                    }
                });
            }
        }
    }
}
