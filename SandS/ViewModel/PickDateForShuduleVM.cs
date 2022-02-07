using DevExpress.Mvvm;
using SandS.Model;
using SandS.Model.MoreModel;
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
        public PickDateForShuduleVM()
        {
            GroupsIsEndable = false;
        }
        public DelegateCommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Departments = new TaskCompletion<ObservableCollection<Department>>(DataWorker.GetDepartments());
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
                        Groups = new TaskCompletion<ObservableCollection<Group>>(DataWorker.GroupsByDepartment(SelectedDepartment.IdDepartment));
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
