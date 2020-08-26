using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace PersonnelManagementSystem.Services
{
    class MySQLService : IDataBaseService<MySqlConnection>
    {
        public void NonQueryManipulation(List<string> statements,MySqlConnection connection)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                { connection.Open(); }
                foreach (string statement in statements)
                {
                    MySqlCommand nonQueryCommand = new MySqlCommand(statement, connection);
                    nonQueryCommand.ExecuteNonQuery();
                }
                connection.Close();
                MessageBox.Show("提交成功!");
            }
            catch (MySqlException e)
            {
                MessageBox.Show(string.Format("数据库错误!\n{0}\n{1}", e.Message,e.StackTrace));
            }
        }

        public DataTable QueryManipulation(string statement,MySqlConnection connection)
        {
            try
            {
                MySqlCommand queryCommand = new MySqlCommand(statement, connection);
                DataTable table = new DataTable();

                if (connection.State != ConnectionState.Open)
                {   connection.Open(); }
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryCommand);
                adapter.Fill(table);
                connection.Close();
                return table;
            }
            catch(MySqlException e)
            {
                MessageBox.Show(string.Format("数据库错误!\n{0}\n{1}", e.Message, e.StackTrace));
                return null;
            }            
        }
    }
}