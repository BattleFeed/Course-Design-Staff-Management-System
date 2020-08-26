using System.Windows.Controls;
using PersonnelManagementSystem.ViewModels.PageViewModels;

namespace PersonnelManagementSystem.Views.Pages
{
    /// <summary>
    /// MyStaffPage.xaml 的交互逻辑
    /// </summary>
    public partial class MyStaffPage : Page
    {
        public MyStaffPage()
        {
            InitializeComponent();
            DataContext = new MyStaffPageViewModel();
        }
    }
}
