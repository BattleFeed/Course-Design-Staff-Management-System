using MySql.Data.MySqlClient;
using PersonnelManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.ViewModels.PageViewModels
{
    class MyStaffPageViewModel
    {
        public StaffViewModel Me { get; set; }
        private string statement;
        private MySqlConnection connection;
        private MySQLService service;
        public MyStaffPageViewModel()
        {
            Me = new StaffViewModel();
            Me.Username = App.Username;
            statement = string.Format("select No, Name, Gender, date_format(Birthday, '%Y-%m-%d') as Birthday, Department, Position, date_format(EntryDate, '%Y-%m-%d') as EntryDate," +
                " date_format(ContractDate, '%Y-%m-%d') as ContractDate, Username, Password, Authority, Status from staff where Username='{0}'",Me.Username);
            connection = new MySqlConnection(
                "server=localhost;User Id=admin;password=admin;Database=hr");
            service = new MySQLService();
            DataTable table = service.QueryManipulation(statement, connection);
            Me.No = (int)table.Rows[0]["No"];
            Me.Name = (string)table.Rows[0]["Name"];
            Me.Gender = (string)table.Rows[0]["Gender"];
            Me.Birthday = (string)table.Rows[0]["Birthday"];
            Me.Department = (string)table.Rows[0]["Department"];
            Me.Position = (string)table.Rows[0]["Position"];
            Me.EntryDate = (string)table.Rows[0]["EntryDate"];
            Me.ContractDate = (string)table.Rows[0]["ContractDate"];
            Me.Status = (string)table.Rows[0]["Status"];
        }
    }
}
