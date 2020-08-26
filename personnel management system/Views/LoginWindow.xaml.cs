using PersonnelManagementSystem.ViewModels;
using System.Windows;

namespace PersonnelManagementSystem.Views
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
            WindowManager.Register<MainWindow>("MainWindow");
            WindowManager.Register<MainWindowLimited>("MainWindowLimited");
        }
    }
}
