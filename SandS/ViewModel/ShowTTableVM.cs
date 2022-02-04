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
        public string s { get; set; }
        public ShowTTableVM()
        {

        }
        public DelegateCommand BackCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    base.transitioner = 0;
                });
            }
        }
        public DelegateCommand LoadTtable
        {
            get
            {
                return new DelegateCommand(()=>
                {
                    s = "sdsadsa";
                });
            }
        }
    }
}
