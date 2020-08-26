using PersonnelManagementSystem.ViewModels;
using System.Windows.Controls;

namespace PersonnelManagementSystem.Views.Pages
{
    /// <summary>
    /// StaffPage.xaml 的交互逻辑
    /// </summary>
    public partial class StaffPage : Page
    {
        public StaffPage()
        {
            InitializeComponent();
            this.DataContext = new StaffPageViewModel();
        }
    }
}
