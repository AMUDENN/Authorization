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
        public static string password;
        public static string confirmpassword;
        public Registration()
        {
            InitializeComponent();
            MainWindow.ChangeTitle("Registration");
            password = "";
            confirmpassword = "";
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Exception RegistrationEx = AuthorizationClass.Registration(LoginText.Text, password, confirmpassword);
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
        public void PasswordKeyPress(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Back && PasswordText.Text.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
            }
            if (args.Key == Key.Delete && PasswordText.Text.Length > 0)
            {
                password = password.Remove(PasswordText.SelectionStart, 1);
            }
            if (args.Key == Key.Enter)
            {
                args.Handled = true;
            }
        }
        public void PasswordTextChanged(object sender, TextCompositionEventArgs args)
        {
            password += args.Text;
            PasswordText.Text += '*';
            args.Handled = true;
            PasswordText.SelectionStart = PasswordText.Text.Length;
        }
        public void ConfirmPasswordKeyPress(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Back && ConfirmPasswordText.Text.Length > 0)
            {
                confirmpassword = confirmpassword.Substring(0, confirmpassword.Length - 1);
            }
            if (args.Key == Key.Delete && ConfirmPasswordText.Text.Length > 0)
            {
                confirmpassword = confirmpassword.Remove(ConfirmPasswordText.SelectionStart, 1);
            }
            if (args.Key == Key.Enter)
            {
                args.Handled = true;
            }
        }
        public void ConfirmPasswordTextChanged(object sender, TextCompositionEventArgs args)
        {
            confirmpassword += args.Text;
            ConfirmPasswordText.Text += '*';
            args.Handled = true;
            ConfirmPasswordText.SelectionStart = ConfirmPasswordText.Text.Length;
        }
    }
}
