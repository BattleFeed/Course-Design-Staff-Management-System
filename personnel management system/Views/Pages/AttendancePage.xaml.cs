using System.Windows.Controls;
using PersonnelManagementSystem.ViewModels;

namespace PersonnelManagementSystem.Views.Pages
{
    /// <summary>
    /// AttendancePage.xaml 的交互逻辑
    /// </summary>
    public partial class AttendancePage : Page
    {
        public AttendancePage()
        {
            InitializeComponent();
            this.DataContext = new AttendancePageViewModel();
        }
    }
}
