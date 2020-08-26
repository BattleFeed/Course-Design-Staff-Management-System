using PersonnelManagementSystem.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace PersonnelManagementSystem.Views.Pages
{
    /// <summary>
    /// MyTrainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MyTrainPage : Page
    {
        public MyTrainPage()
        {
            InitializeComponent();
            DataContext = new MyTrainPageViewModel();
        }
    }
}
