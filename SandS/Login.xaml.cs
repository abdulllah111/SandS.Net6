using System.Configuration;
using System.ServiceProcess;
using System.Windows;
using SandS.Model;
using SandS.Resource;
using SandS.Services;
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
            ApiTokenTextbox.Text = GloabalValues.ApiToken;
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
            //TokenValidation? aunth_api = new SyncApiData<TokenValidation?>($"tokenvalid?api_token={ApiTokenTextbox.Text}").Get();
            if(ApiTokenTextbox.Text == GloabalValues.ApiToken) {
                Visibility = Visibility.Hidden;
                var dispatcher = new Dispatcher();
                dispatcher.Show();
                Close();
            }
            
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