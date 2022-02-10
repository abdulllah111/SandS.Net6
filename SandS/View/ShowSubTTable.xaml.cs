using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using SandS.Model;
using SandS.ViewModel;

namespace SandS.View
{
    /// <summary>
    ///     Логика взаимодействия для ShowSubTTable.xaml
    /// </summary>
    public partial class ShowSubTTable : UserControl
    {
        public ShowSubTTable(ShowSubTTableVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}