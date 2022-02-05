using DevExpress.Mvvm;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using SandS.Model;
using SandS.Model.MoreModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SandS.ViewModel
{
    internal class ShowTTableVM : ViewModelBase
    {
        public TaskCompletion<ObservableCollection<TTable>> FridayList { get; set; }
        public TaskCompletion<ObservableCollection<TTable>> MondayList { get; set; }
        public TaskCompletion<ObservableCollection<TTable>> SaturdayList { get; set; }
        public TaskCompletion<ObservableCollection<TTable>> ThursdayList { get; set; }
        public TaskCompletion< ObservableCollection<TTable>> TuesdayList { get; set; }
        public TaskCompletion<ObservableCollection<TTable>> WednesdayList { get; set; }
        private Group SelectedGroup;
        public ShowTTableVM(Group selectedGroup)
        {
            SelectedGroup = selectedGroup;
        }
        public DelegateCommand LoadTtable
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    if (SelectedGroup != null)
                    {
                        MondayList = new TaskCompletion<ObservableCollection<TTable>>(DataWorker.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 1));
                        TuesdayList = new TaskCompletion<ObservableCollection<TTable>>(DataWorker.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 2));
                        WednesdayList = new TaskCompletion<ObservableCollection<TTable>>(DataWorker.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 3));
                        ThursdayList = new TaskCompletion<ObservableCollection<TTable>>(DataWorker.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 4));
                        FridayList = new TaskCompletion<ObservableCollection<TTable>>(DataWorker.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 5));
                        SaturdayList = new TaskCompletion<ObservableCollection<TTable>>(DataWorker.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 6));
                     
                    }
                });
            }
        }
        private void AddTTableToList(ObservableCollection<TTable> list, TTable ttable)
        {
            list.Add(ttable);
        }
    }
}
