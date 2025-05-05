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
using System.Windows.Shapes;
using MyProjectCursovay.Data.Context;
using MyProjectCursovay.Sourse;

namespace MyProjectCursovay.Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("/Desktop/Pages/PageSettingsPerson.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("/Desktop/Pages/PagePlayerCreated.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var editWindow = new SearchPlayer();
            editWindow.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Uri("/Desktop/Pages/PageSetingsSkill.xaml", UriKind.Relative));
        }
    }
}
