using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PersonnelManagementSystem.Services
{
    interface IDataBaseService<T>
    {
        void NonQueryManipulation(List<string> statements,T connection);
        DataTable QueryManipulation(string statement,T connection);
    }
}
