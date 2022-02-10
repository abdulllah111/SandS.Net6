using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using SandS.Model;
using SandS.ViewModel;

namespace SandS.View
{
    /// <summary>
    ///     Логика взаимодействия для PickDateForShedule.xaml
    /// </summary>
    public partial class PickDateForShedule : UserControl
    {

        public PickDateForShedule()
        {
            InitializeComponent();
            DataContext = new PickDateForShuduleVM();
        }
    }
}