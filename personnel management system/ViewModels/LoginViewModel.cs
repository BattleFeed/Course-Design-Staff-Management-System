using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using Prism.Commands;
using PersonnelManagementSystem.Models;
using PersonnelManagementSystem.Services;

namespace PersonnelManagementSystem.ViewModels
{
    class LoginViewModel : NotificationObject
    {
        private string statement;
        private MySqlConnection connection;
        private MySQLService service;

        public DelegateCommand LoginCommand { get; set; }

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                this.RaisePropertyChanged("User");
            }
        }

        private bool toClose = false;
        public bool ToClose
        {
            get { return toClose; }
            set
            {
                toClose = value;
                if (toClose) { this.RaisePropertyChanged("ToClose"); }
            }
        }

        public LoginViewModel()
        {
            this.User = new User();
            this.LoginCommand = new DelegateCommand(new Action(LoginExecute));
            this.connection = new MySqlConnection(
                "server=localhost;User Id=admin;password=admin;Database=hr");
            this.service = new MySQLService();
        }

        private void LoginExecute()
        {
            //未做防注入
            statement = string.Format("select * from staff where Username='{0}' and Password='{1}'",User.Username,User.Password);
            DataTable table = service.QueryManipulation(statement, connection);
            if (table == null) return;
            if (table.Rows.Count != 0)
            {
                App.Username = User.Username;
                App.No = (int)table.Rows[0]["No"];
                //为主窗体提供用户名并关闭登录窗体
                MainWindowViewModel vm = new MainWindowViewModel();
                if ((string)table.Rows[0]["Authority"] == "Admin")
                { WindowManager.Show("MainWindow", vm); }
                else
                { WindowManager.Show("MainWindowLimited",vm); }
                ToClose = true;
            }
            else
                MessageBox.Show("用户名或密码错误!");
        }
    }
}