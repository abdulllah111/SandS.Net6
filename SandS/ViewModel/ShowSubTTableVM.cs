using DevExpress.Mvvm;
using SandS.Model;
using SandS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.ViewModel
{
    public class ShowSubTTableVM : ViewModelBase
    {
        public TaskCompletion<SubTTable> SubTtable { get; set; }
        public ShowSubTTableVM(Group selectedgroup, DateTime date)
        {
            SubTtable = DataWorker.GetSubTTableByGroupAndDate(selectedgroup.IdGroup, date.DateStr());
        }
        public DelegateCommand LoadSubTtable
        {
            get
            {
                return new DelegateCommand(() =>
                {
                   

                });
            }
        }
    }
}
