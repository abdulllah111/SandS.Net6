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
        //private BindingList<Department> Departments;
        //private BindingList<Group> Groups;

        public PickGroupForSchedule()
        {
            InitializeComponent();  
            DataContext = new PickGroupForScheduleVM();
        }

        //public int GroupId { get; private set; }
        public MainWindow Windoww { get; set; }

        //private void ShowButton_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (GroupCombobox.SelectedItem != null)
        //    {
        //        /*Windoww.Visibility = Visibility.Hidden;
        //        ScheduleForThisWeek a = new ScheduleForThisWeek((int)GroupCombobox.SelectedValue);
        //        a.ShowDialog();
        //        Windoww.Visibility = Visibility.Visible;*/
        //    }
        //}

        //private async void PickGroupForScheduleViev_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Departments = new BindingList<Department>(await DataWorker.GetDepartments());
        //    DepartmentCombobox.ItemsSource = Departments;
        //}

        //private async void DepartmentCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var a = await DataWorker.GetGroups();
        //    Groups = new BindingList<Group>(a.Where(x => x.IdDepartment == (int)DepartmentCombobox.SelectedValue).ToList());
        //    if (Groups.Count != 0)
        //    {
        //        GroupCombobox.IsEnabled = true;
        //        GroupCombobox.ItemsSource = Groups;
        //    }
        //    else
        //    {
        //        GroupCombobox.IsEnabled = false;
        //    }
        //}

        //private void GroupCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (GroupCombobox.SelectedValue != null)
        //    {
        //        ShowButton.IsEnabled = true;
        //        return;
        //    }

        //    ShowButton.IsEnabled = false;
        //}

        //private void ShowButton_Click(object sender, RoutedEventArgs e)
        //{
        //    showttable.IdGroup = (int)GroupCombobox.SelectedValue;
        //    showttable.IsEnabled = true;
        //}
    }
}