using SandS.ViewModel;
using System.Windows.Controls;

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