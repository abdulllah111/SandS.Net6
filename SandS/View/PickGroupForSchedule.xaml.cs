using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using SandS.Model;

namespace SandS.View
{
    /// <summary>
    ///     Логика взаимодействия для PickGroupForSchedule.xaml
    /// </summary>
    public partial class PickGroupForSchedule : UserControl
    {
        private BindingList<Department> Departments;
        private BindingList<Group> Groups;

        public PickGroupForSchedule()
        {
            InitializeComponent();
        }

        public int GroupId { get; private set; }
        public MainWindow Windoww { get; set; }

        private void ShowButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (GroupCombobox.SelectedItem != null)
            {
                /*Windoww.Visibility = Visibility.Hidden;
                ScheduleForThisWeek a = new ScheduleForThisWeek((int)GroupCombobox.SelectedValue);
                a.ShowDialog();
                Windoww.Visibility = Visibility.Visible;*/
            }
        }

        private void PickGroupForScheduleViev_Loaded(object sender, RoutedEventArgs e)
        {
            Departments = new BindingList<Department>();
            DB.Open();
            var cmd = new MySqlCommand("SELECT * FROM `department`;", DB.GetCon);
            var dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false)
            {
                return;
            }

            while (dbReader.Read())
                Departments.Add(new Department
                {
                    IdDepartment = (int)dbReader[0],
                    Name = (string)dbReader[1]
                });
            DepartmentCombobox.ItemsSource = Departments;
            dbReader.Close();
            DB.Close();
        }

        private void DepartmentCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DepartmentCombobox.SelectedValue != null)
            {
                Groups = new BindingList<Group>();
                GroupCombobox.IsEnabled = true;
                using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
                {
                    var cmd = new MySqlCommand(
                        $"SELECT * FROM `group` WHERE `iddepartment` = '{DepartmentCombobox.SelectedValue}';", conn);
                    conn.Open();
                    var dbReader = cmd.ExecuteReader();
                    if (dbReader.HasRows == false)
                    {
                        return;
                    }

                    while (dbReader.Read())
                        Groups.Add(new Group
                        {
                            IdGroup = (int)dbReader[0],
                            Name = (string)dbReader[1],
                            IdDepartment = (int)dbReader[2]
                        });
                    GroupCombobox.ItemsSource = Groups;
                    dbReader.Close();
                    DB.Close();
                }

                return;
            }

            GroupCombobox.IsEnabled = false;
        }

        private void GroupCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupCombobox.SelectedValue != null)
            {
                ShowButton.IsEnabled = true;
                return;
            }

            ShowButton.IsEnabled = false;
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            showttable.IdGroup = (int)GroupCombobox.SelectedValue;
            showttable.IsEnabled = true;
        }
    }
}