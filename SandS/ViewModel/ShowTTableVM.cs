using DevExpress.Mvvm;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.ViewModel
{
    internal class ShowTTableVM : PickGroupForScheduleVM
    {

        public DelegateCommand BackCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    ShowTtableIsEnable = false;
                    base.transitioner = 0;
                });
            }
        }
    }
}
