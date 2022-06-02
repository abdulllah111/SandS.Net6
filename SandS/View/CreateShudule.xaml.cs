using SandS.ViewModel;
using System.Windows.Controls;

namespace SandS.View
{
    /// <summary>
    /// Логика взаимодействия для CreateShudule.xaml
    /// </summary>
    public partial class CreateShudule : UserControl
    {
        public CreateShudule()
        {
            InitializeComponent();
            DataContext = new CreateShuduleVM();
        }
    }
}
