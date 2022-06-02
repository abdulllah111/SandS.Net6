﻿using SandS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SandS.View
{
    /// <summary>
    /// Логика взаимодействия для PrintView.xaml
    /// </summary>
    public partial class PrintView : UserControl
    {
        public PrintView()
        {
            InitializeComponent();
            DataContext = new PrintViewVM();
        }
    }
}
