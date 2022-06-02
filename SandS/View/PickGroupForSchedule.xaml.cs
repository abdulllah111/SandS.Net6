using SandS.ViewModel;
using System.Windows.Controls;

namespace SandS.View
{
    /// <summary>
    ///     Логика взаимодействия для PickGroupForSchedule.xaml
    /// </summary>
    public partial class PickGroupForSchedule : UserControl
    {
        public PickGroupForSchedule()
        {
            InitializeComponent();
            DataContext = new PickGroupForScheduleVM();
        }
    }
}