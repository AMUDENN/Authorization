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

namespace Authorization.ContentPage
{
    /// <summary>
    /// Логика взаимодействия для Content.xaml
    /// </summary>
    public partial class Content : Page
    {
        public Content()
        {
            InitializeComponent();
            MainWindow.ChangeTitle("Main Content");
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LogInPage(this);
        }
    }
}
