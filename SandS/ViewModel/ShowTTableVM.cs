using DevExpress.Mvvm;
using SandS.Model;
using SandS.Services;
using System.Collections.ObjectModel;

namespace SandS.ViewModel
{
    internal class ShowTTableVM : ViewModelBase
    {
        public TaskCompletion<ObservableCollection<TTable>> FridayList { get; set; }
        public TaskCompletion<ObservableCollection<TTable>> MondayList { get; set; }
        public TaskCompletion<ObservableCollection<TTable>> SaturdayList { get; set; }
        public TaskCompletion<ObservableCollection<TTable>> ThursdayList { get; set; }
        public TaskCompletion<ObservableCollection<TTable>> TuesdayList { get; set; }
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
                return new DelegateCommand(() =>
                {
                    if (SelectedGroup != null)
                    {
                        MondayList = AsyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 1);
                        TuesdayList = AsyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 2);
                        WednesdayList = AsyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 3);
                        ThursdayList = AsyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 4);
                        FridayList = AsyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 5);
                        SaturdayList = AsyncGetApiData.GetTtableByGroupAndWeekDay(SelectedGroup.IdGroup, 6);

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
