using DevExpress.Mvvm;
using SandS.Model;
using SandS.Model.MoreModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SandS.ViewModel
{
    internal class PickGroupForScheduleVM : ViewModelBase
    {
        private readonly ObservableCollection<Group> _groups;

        public ObservableCollection<Group> Groups { get; set; }
        public Department SelectedDepartment { get; set; }
        public bool GroupsIsEndable { get; set; }
        public bool Loading { get; set; }
        public TaskCompletion<ObservableCollection<Department>> Departments { get; set; }
        public PickGroupForScheduleVM()
        {
            _groups = new TaskCompletion<ObservableCollection<Group>>(DataWorker.GetGroups()).Result;
        }
        public DelegateCommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {;
                    GroupsIsEndable = false;
                    Departments = new TaskCompletion<ObservableCollection<Department>>(DataWorker.GetDepartments());
                    Loading = false;
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
                        Groups = new ObservableCollection<Group>(_groups.Where(x => x.IdDepartment == SelectedDepartment.IdDepartment).ToList());
                        GroupsIsEndable = true;
                    }
                    else
                    {
                        GroupsIsEndable = false;
                    }
                });
            }
        }

    }
}
