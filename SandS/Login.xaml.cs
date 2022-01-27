using System.ServiceProcess;
using System.Windows;
using SandS.View;

namespace SandS
{
    /// <summary>
    ///     Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            var service = new ServiceController("MySQL80");
            if (service.Status != ServiceControllerStatus.Stopped)
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
            }

            if (service.Status != ServiceControllerStatus.Running)
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);
            }
        }

        private void LoginStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void LoginDispatcherButton_Click(object sender, RoutedEventArgs e)
        {
            /*DB.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM `users` WHERE `login` = '{LoginTextBox.Text}' AND `password` = '{PasswordTextBox.Password}'", DB.GetCon);
            MySqlDataReader dbReader = cmd.ExecuteReader();
            if (dbReader.HasRows == false)
            {
                MessageBoxResult result = MessageBox.Show("Не правильный логин или пороль!", "Ошбика!");
                return;
            }
            else
            {
                DB.Close();
*/
            Visibility = Visibility.Hidden;
            //var dispatcher = new Dispatcher();
            //dispatcher.Show();
            Close(); /*
            }*/
        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            Title = "Авторизация диспетчера";
        }

        private void Grid_GotFocus_1(object sender, RoutedEventArgs e)
        {
            Title = "Авторизация студента";
        }
    }
}