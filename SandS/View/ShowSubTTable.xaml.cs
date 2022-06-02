using SandS.ViewModel;
using System.Windows.Controls;

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