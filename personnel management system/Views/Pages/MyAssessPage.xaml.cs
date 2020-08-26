using PersonnelManagementSystem.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace PersonnelManagementSystem.Views.Pages
{
    /// <summary>
    /// MyAssessPage.xaml 的交互逻辑
    /// </summary>
    public partial class MyAssessPage : Page
    {
        public MyAssessPage()
        {
            InitializeComponent();
            DataContext = new MyAssessPageViewModel();
        }
    }
}
