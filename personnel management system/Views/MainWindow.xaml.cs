using System;
using System.Windows;
using PersonnelManagementSystem.ViewModels;

namespace PersonnelManagementSystem.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void StaffPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/StaffPage.xaml",UriKind.RelativeOrAbsolute)) ;
        }

        private void MyStaffPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri(string.Format("Views/Pages/MyStaffPage.xaml",Username), UriKind.RelativeOrAbsolute));
        }

        private void AttendancePage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/AttendancePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MyAttendancePage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/MyAttendancePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AssessPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/AssessPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MyAssessPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/MyAssessPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TrainPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/TrainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MyTrainPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(new Uri("Views/Pages/MyTrainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
