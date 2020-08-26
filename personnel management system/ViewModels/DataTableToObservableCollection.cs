using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;

namespace PersonnelManagementSystem.ViewModels
{
    class DataTableToObservableCollection
    {
        static public ObservableCollection<T> ToObservableCollection<T>(DataTable dt) where T : class, new()
        {
            Type t = typeof(T);
            PropertyInfo[] PropertyInfo = t.GetProperties();
            ObservableCollection<T> collection = new ObservableCollection<T>();

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
                collection.Add(obj);
            }
            return collection;
        }
    }
}
