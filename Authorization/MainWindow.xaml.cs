using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new LogInPage.LogIn();
        }
        public static void ChangeTitle(string title)
        {
            Application.Current.MainWindow.Title = title;
        }
        public static void LogInPage(Page ths)
        {
            ths.NavigationService.Navigate(new LogInPage.LogIn());
        }
        public static void RegistrationPage(Page ths)
        {
            ths.NavigationService.Navigate(new RegistrationPage.Registration());
        }
        public static void ContentPage(Page ths)
        {
            ths.NavigationService.Navigate(new ContentPage.Content());
        }
    }
}
