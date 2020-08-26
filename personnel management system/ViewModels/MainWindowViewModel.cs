using PersonnelManagementSystem.Models;

namespace PersonnelManagementSystem.ViewModels
{
    class MainWindowViewModel
    {
        public User User { get; set; }
        public MainWindowViewModel()
        {
            User = new User
            {
                Username = App.Username
            };
        }
    }
}
