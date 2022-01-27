using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using SandS.Model;

namespace SandS.View
{
    /// <summary>
    ///     Логика взаимодействия для ShowTTable.xaml
    /// </summary>
    public partial class ShowTTable : UserControl
    {
        private BindingList<TTable> FridayList;
        private BindingList<TTable> MondayList;
        private BindingList<TTable> SaturdayList;
        private BindingList<TTable> ThursdayList;
        private BindingList<TTable> TuesdayList;
        private BindingList<TTable> WednesdayList;

        public ShowTTable()
        {
            InitializeComponent();
        }

        public int IdGroup { get; set; }

        private void AddTTableToList(BindingList<TTable> list, MySqlDataReader dbReader)
        {
            list.Add(new TTable
            {
                IdTimeTable = (int)dbReader[0],
                IdWeekDay = (int)dbReader[1],
                IdLesson = (int)dbReader[2],
                IdOffice = dbReader[3] != DBNull.Value ? (int)dbReader[3] : 0,
                IdDisciplineGroupTeacher = (int)dbReader[4]
            });
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
        }

        private void ShowTTableUC_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsEnabled == false) return;
            MondayList = new BindingList<TTable>();
            TuesdayList = new BindingList<TTable>();
            WednesdayList = new BindingList<TTable>();
            ThursdayList = new BindingList<TTable>();
            FridayList = new BindingList<TTable>();
            SaturdayList = new BindingList<TTable>();
            using (var conn = new MySqlConnection("server=localhost;user=root;database=timetable;password=root;"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT ttable.* FROM ttable, `discipline-group-teacher`" +
                                           " WHERE `ttable`.iddisciplinegroupteacher = `discipline-group-teacher`.`iddiscipline-group-teacher` " +
                                           $"AND `discipline-group-teacher`.idgroup = '{IdGroup}' ORDER BY `idlesson` ASC;",
                    conn);
                var dbReader = cmd.ExecuteReader();
                if (dbReader.HasRows == false) return;
                while (dbReader.Read())
                    switch (dbReader[1])
                    {
                        case 1:
                            AddTTableToList(MondayList, dbReader);
                            break;
                        case 2:
                            AddTTableToList(TuesdayList, dbReader);
                            break;
                        case 3:
                            AddTTableToList(WednesdayList, dbReader);
                            break;
                        case 4:
                            AddTTableToList(ThursdayList, dbReader);
                            break;
                        case 5:
                            AddTTableToList(FridayList, dbReader);
                            break;
                        case 6:
                            AddTTableToList(SaturdayList, dbReader);
                            break;
                    }

                MondayDataGrid.ItemsSource = MondayList;
                TuesdayDataGrid.ItemsSource = TuesdayList;
                WednesdayDataGrid.ItemsSource = WednesdayList;
                ThursdayDataGrid.ItemsSource = ThursdayList;
                FridayDataGrid.ItemsSource = FridayList;
                SaturdayDataGrid.ItemsSource = SaturdayList;
            }
        }
    }
}