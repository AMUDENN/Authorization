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

namespace Authorization.LogInPage
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            MainWindow.ChangeTitle("Log In");
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            Exception LogInEx = AuthorizationClass.LogIn(LoginText.Text, PasswordText.Text);
            if(LogInEx == null)
            {
                MainWindow.ContentPage(this);
            }
            else
            {
                MessageBox.Show(LogInEx.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.RegistrationPage(this);
        }
    }
}
