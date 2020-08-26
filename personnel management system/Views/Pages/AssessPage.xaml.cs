using PersonnelManagementSystem.ViewModels;
using System.Windows.Controls;

namespace PersonnelManagementSystem.Views.Pages
{
    /// <summary>
    /// AssessPage.xaml 的交互逻辑
    /// </summary>
    public partial class AssessPage : Page
    {
        public AssessPage()
        {
            InitializeComponent();
            this.DataContext = new AssessPageViewModel();
        }
    }
}
