using SandS.ViewModel;
using System.Windows;

namespace SandS.View
{
    /// <summary>
    /// Логика взаимодействия для Dispatcher.xaml
    /// </summary>
    public partial class Dispatcher : Window
    {
        public Dispatcher()
        {
            InitializeComponent();
            DataContext = new DispatcherVM();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
            Close();
        }
    }
}
