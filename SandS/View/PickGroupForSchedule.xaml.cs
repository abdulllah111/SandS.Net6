using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using SandS.Model;
using SandS.Model.MoreModel;
using SandS.ViewModel;

namespace SandS.View
{
    /// <summary>
    ///     Логика взаимодействия для PickGroupForSchedule.xaml
    /// </summary>
    public partial class PickGroupForSchedule : UserControl
    {
        public PickGroupForSchedule()
        {
            InitializeComponent();  
            DataContext = new PickGroupForScheduleVM();
        }
    }
}