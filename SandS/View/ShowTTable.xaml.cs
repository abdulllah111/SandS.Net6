using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using SandS.Model;
using SandS.Model.MoreModel;
using SandS.ViewModel;

namespace SandS.View
{
    /// <summary>
    ///     Логика взаимодействия для ShowTTable.xaml
    /// </summary>
    public partial class ShowTTable : UserControl
    {
        //private BindingList<TTable> FridayList;
        //private BindingList<TTable> MondayList;
        //private BindingList<TTable> SaturdayList;
        //private BindingList<TTable> ThursdayList;
        //private BindingList<TTable> TuesdayList;
        //private BindingList<TTable> WednesdayList;

        internal ShowTTable(ShowTTableVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        public int IdGroup { get; set; }

        //private void AddTTableToList(BindingList<TTable> list, TTable ttable)
        //{
        //    list.Add(ttable);
        //}


        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    IsEnabled = false;
        //}

        //private async void ShowTTableUC_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (IsEnabled == false) return;
        //    MondayList = new BindingList<TTable>();
        //    TuesdayList = new BindingList<TTable>();
        //    WednesdayList = new BindingList<TTable>();
        //    ThursdayList = new BindingList<TTable>();
        //    FridayList = new BindingList<TTable>();
        //    SaturdayList = new BindingList<TTable>();
        //    var client = new HttpClient();
        //    var streamTask = await client.GetStreamAsync($"https://uksivttimetable.000webhostapp.com/public/api/ttable/getforgroup/{IdGroup}");
        //    var data = await JsonSerializer.DeserializeAsync<List<DgtAndTtables>>(streamTask);
        //    foreach (var item in data)
        //    {
        //        foreach (var item2 in item.Ttables)
        //        {
        //            switch (item2.IdWeekDay)
        //            {
        //                case 1:
        //                    AddTTableToList(MondayList, item2);
        //                    break;
        //                case 2:
        //                    AddTTableToList(TuesdayList, item2);
        //                    break;
        //                case 3:
        //                    AddTTableToList(WednesdayList, item2);
        //                    break;
        //                case 4:
        //                    AddTTableToList(ThursdayList, item2);
        //                    break;
        //                case 5:
        //                    AddTTableToList(FridayList, item2);
        //                    break;
        //                case 6:
        //                    AddTTableToList(SaturdayList, item2);
        //                    break;
        //            }
        //        }
        //    }

        //    MondayDataGrid.ItemsSource = MondayList;
        //    TuesdayDataGrid.ItemsSource = TuesdayList;
        //    WednesdayDataGrid.ItemsSource = WednesdayList;
        //    ThursdayDataGrid.ItemsSource = ThursdayList;
        //    FridayDataGrid.ItemsSource = FridayList;
        //    SaturdayDataGrid.ItemsSource = SaturdayList;
        //}
    }
}