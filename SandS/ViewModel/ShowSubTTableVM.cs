using DevExpress.Mvvm;
using SandS.Model;
using SandS.Services;

namespace SandS.ViewModel
{
    public class ShowSubTTableVM : ViewModelBase
    {
        public TaskCompletion<SubTTable[]> SubTtable { get; set; }
        public ShowSubTTableVM(TaskCompletion<SubTTable[]> subttable)
        {
            SubTtable = subttable;
        }
    }
}
