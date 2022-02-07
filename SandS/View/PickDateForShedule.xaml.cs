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
        //private void DepartmentCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (DepartmentCombobox.SelectedValue != null)
        //    {
        //        Groups = new BindingList<Group>();
        //        GroupCombobox.IsEnabled = true;
        //        using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
        //        {
        //            var cmd = new MySqlCommand(
        //                $"SELECT * FROM `group` WHERE `iddepartment` = '{DepartmentCombobox.SelectedValue}';", conn);
        //            conn.Open();
        //            var dbReader = cmd.ExecuteReader();
        //            if (dbReader.HasRows == false)
        //            {
        //                return;
        //            }

        //            while (dbReader.Read())
        //                Groups.Add(new Group
        //                {
        //                    IdGroup = (int)dbReader[0],
        //                    Name = (string)dbReader[1],
        //                    IdDepartment = (int)dbReader[2]
        //                });
        //            GroupCombobox.ItemsSource = Groups;
        //            dbReader.Close();
        //            DB.Close();
        //        }

        //        return;
        //    }

        //    GroupCombobox.IsEnabled = false;
        //}

        //private void PickDateForShedule1_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Departments = new BindingList<Department>();
        //    DB.Open();
        //    var cmd = new MySqlCommand("SELECT * FROM `department`;", DB.GetCon);
        //    var dbReader = cmd.ExecuteReader();
        //    if (dbReader.HasRows == false)
        //    {
        //        return;
        //    }

        //    while (dbReader.Read())
        //        Departments.Add(new Department
        //        {
        //            IdDepartment = (int)dbReader[0],
        //            Name = (string)dbReader[1]
        //        });
        //    DepartmentCombobox.ItemsSource = Departments;
        //    dbReader.Close();
        //    DB.Close();
        //}

        //private void GroupCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (GroupCombobox.SelectedValue != null && DateBox.SelectedDate != null)
        //    {
        //        var SubTTables = new BindingList<SubTTable>();
        //        using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
        //        {
        //            conn.Open();
        //            var cmd = new MySqlCommand("SELECT `sub_ttable`.* FROM `sub_ttable`, `discipline-group-teacher`" +
        //                                       "WHERE `sub_ttable`.iddisciplinegroupteacher = `discipline-group-teacher`.`iddiscipline-group-teacher`" +
        //                                       $"AND `discipline-group-teacher`.idgroup = '{GroupCombobox.SelectedValue}'  AND `date` = '{DateBox.SelectedDate.Value.DateStr()}' ORDER BY `idlesson` ASC; ",
        //                conn);
        //            var dbReader = cmd.ExecuteReader();
        //            if (dbReader.HasRows == false)
        //            {
        //                var result = MessageBox.Show("Замен нет");
        //                return;
        //            }

        //            while (dbReader.Read())
        //                SubTTables.Add(new SubTTable
        //                {
        //                    IdSubTTable = (int)dbReader[0],
        //                    IdWeekDay = (int)dbReader[1],
        //                    IdLesson = (int)dbReader[2],
        //                    IdOffice = dbReader[3] != DBNull.Value ? (int)dbReader[3] : 0,
        //                    IdDisciplineGroupTeacher = (int)dbReader[4],
        //                    Date = (DateTime)dbReader[5]
        //                });
        //            showsubttable.SubTTables = SubTTables;
        //            showsubttable.IsEnabled = true;
        //        }

        //        ShowButton.IsEnabled = true;
        //        return;
        //    }

        //    ShowButton.IsEnabled = false;
        //}

        //private void ShowButton_Click(object sender, RoutedEventArgs e)
        //{
        //}
    }
}