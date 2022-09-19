using Authorization.LogInPage;
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

namespace Authorization.RegistrationPage
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            MainWindow.ChangeTitle("Registration");
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Exception RegistrationEx = AuthorizationClass.Registration(LoginText.Text, PasswordText.Text, ConfirmPasswordText.Text);
            if (RegistrationEx == null)
            {
                MainWindow.ContentPage(this);
            }
            else
            {
                MessageBox.Show(RegistrationEx.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LogInPage(this);
        }
    }
}
