using DevExpress.Mvvm;
using MaterialDesignThemes.Wpf.Transitions;
using SandS.Model;
using SandS.Model.MoreModel;
using SandS.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SandS.ViewModel
{
    internal class PickGroupForScheduleVM : ViewModelBase
    {
        public Department SelectedDepartment { get; set; }
        public Group SelectedGroup { get; set; }
        public bool GroupsIsEndable { get; set; }
        public bool ShowTtableIsEnable { get; set; }    
        public bool ShowTtableButtonIsEnable { get; set; }
        public bool Loading { get; set; }
        public TaskCompletion<ObservableCollection<Group>> Groups { get; set; }
        public TaskCompletion<ObservableCollection<Department>> Departments { get; set; }
        public int transitioner { get; set; }
        public UserControl ShowttableUk { get; set; } 
        public PickGroupForScheduleVM()
        {
            GroupsIsEndable = false;
            ShowTtableButtonIsEnable = false;
            transitioner= 0;
        }
        public DelegateCommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {;
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
                        Groups = new TaskCompletion<ObservableCollection<Group>>(DataWorker.GroupsByDepartment(SelectedDepartment.IdDepartment));
                        GroupsIsEndable = true;
                    }
                    else
                    {
                        GroupsIsEndable = false;
                        ShowTtableButtonIsEnable = false;
                    }
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
                        ShowTtableButtonIsEnable = true;
                        
                    }
                    else
                    {
                        ShowTtableButtonIsEnable = false;
                    }
                });
            }
        }
        public DelegateCommand ShowTtableCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (ShowTtableButtonIsEnable != false)
                    {
                        var vm = new ShowTTableVM(SelectedGroup);
                        ShowttableUk = new ShowTTable(vm);
                        transitioner = 1;
                    }
                });
            }
        }
    }
}
