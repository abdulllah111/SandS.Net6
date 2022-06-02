using SandS.ViewModel;
using System.Windows.Controls;

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
    }
}