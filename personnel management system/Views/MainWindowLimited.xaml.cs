using PersonnelManagementSystem.ViewModels;
using System;
using System.Windows;

namespace PersonnelManagementSystem.Views
{
    /// <summary>
    /// MainWindowLimited.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowLimited : Window
    {

        public MainWindowLimited()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void MyStaffPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri(string.Format("Views/Pages/MyStaffPage.xaml", Username), UriKind.RelativeOrAbsolute));
        }

        private void MyAttendancePage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/MyAttendancePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MyAssessPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/MyAssessPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MyTrainPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/MyTrainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}