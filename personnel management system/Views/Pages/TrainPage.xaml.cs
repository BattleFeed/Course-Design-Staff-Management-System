using PersonnelManagementSystem.ViewModels;
using System.Windows.Controls;

namespace PersonnelManagementSystem.Views.Pages
{
    /// <summary>
    /// TrainPage.xaml 的交互逻辑
    /// </summary>
    public partial class TrainPage : Page
    {
        public TrainPage()
        {
            InitializeComponent();
            this.DataContext = new TrainPageViewModel();
        }
    }
}
