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
        internal ShowTTable(ShowTTableVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}