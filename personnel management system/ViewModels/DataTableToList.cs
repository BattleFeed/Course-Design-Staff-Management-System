using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.ViewModels
{
    class DataTableToList
    {
        static public List<T> Tolist<T>(DataTable dt) where T : class, new()
        {
            Type t = typeof(T);
            PropertyInfo[] PropertyInfo = t.GetProperties();
            List<T> list = new List<T>();

            string typeName = string.Empty;
            foreach (DataRow item in dt.Rows)
            {
                T obj = new T();
                foreach (PropertyInfo s in PropertyInfo)
                {
                    typeName = s.Name;
                    if (dt.Columns.Contains(typeName))
                    {
                        if (!s.CanWrite) continue;

                        object value = item[typeName];
                        if (value == DBNull.Value) continue;

                        if (s.PropertyType == typeof(string))
                        {
                            s.SetValue(obj, value.ToString(), null);
                        }
                        else
                        {
                            s.SetValue(obj, value, null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
