using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using PersonnelManagementSystem.ViewModels.PageViewModels;

namespace PersonnelManagementSystem.ViewModels
{
    class StaffPageViewModel : PageViewModel<StaffViewModel>
    {
        private int toEditNo;
        public override void OnEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int i = e.Row.GetIndex();
            if (editedIndexs.Contains(i)) return;
            editedIndexs.Add(i);
            //新增行,toInsert=false时默认sql语句为update
            if (i >= count)
            {
                if (Table[i].No == 0)
                {
                    Table[i].No = toEditNo;
                    toEditNo += 1;
                }
                Table[i].toInsert = true;
            }
        }

        public override void SubmitExecute()
        {
            //修补bug:只点击复选框无法触发CellEditEnding事件
            foreach (StaffViewModel obj in Table)
            {
                //为索引列表添加漏掉的编号
                int i = Table.IndexOf(obj);
                if (!editedIndexs.Contains(i) && obj.ToDelete)
                    editedIndexs.Add(i);
            }

            //sql非查询语句
            foreach (int index in editedIndexs)
            {
                item = Table[index];
                if (item.ToDelete)
                {
                    if (item.toInsert)
                        continue;
                    else
                        statement = string.Format("delete from {1} where No='{0}'", item.No,tableName);
                }
                else
                {
                    statement = item.toInsert ? string.Format("insert into {12} values('{0}','{1}','{2}',str_to_date('{3}','%Y-%m-%d'),'{4}','{5}',str_to_date('{6}','%Y-%m-%d'),str_to_date('{7}','%Y-%m-%d'),'{8}','{9}','{10}','{11}')",
                        item.No, item.Name, item.Gender, item.Birthday, item.Department, item.Position, item.EntryDate, item.ContractDate, item.Username, item.Password, item.Authority, item.Status,tableName)
                        : string.Format("update {12} set Name='{1}',Gender='{2}',Birthday=str_to_date('{3}','%Y-%m-%d'),Department='{4}',Position='{5}',EntryDate=str_to_date('{6}','%Y-%m-%d'),ContractDate=str_to_date('{7}','%Y-%m-%d'),Username='{8}',Password='{9}',Authority='{10}',Status='{11}' where No='{0}'",
                        item.No, item.Name, item.Gender, item.Birthday, item.Department, item.Position, item.EntryDate, item.ContractDate, item.Username, item.Password, item.Authority, item.Status,tableName);
                }
                statements.Add(statement);
            }
            service.NonQueryManipulation(statements, connection);
            SelectExecute();
        }

        public override void SelectExecute()
        {
            this.tableName = "staff";
            statement = searchField == null ? string.Format("select No, Name, Gender, date_format(Birthday, '%Y-%m-%d') as Birthday, Department, Position, date_format(EntryDate, '%Y-%m-%d') as EntryDate,date_format(ContractDate, '%Y-%m-%d') as ContractDate, Username, Password, Authority, Status from {0}", tableName)
                        : string.Format("select No, Name, Gender, date_format(Birthday, '%Y-%m-%d') as Birthday, Department, Position, date_format(EntryDate, '%Y-%m-%d') as EntryDate, date_format(ContractDate, '%Y-%m-%d') as ContractDate, Username, Password, Authority, Status from {1} WHERE Name LIKE '%{0}%'", SearchField, tableName);
            DataTable table = service.QueryManipulation(statement, connection);
            this.Table = DataTableToObservableCollection.ToObservableCollection<StaffViewModel>(table);

            tableLastIndex = searchField == null ? Table.LastOrDefault().No : tableLastIndex;
            toEditNo = tableLastIndex + 1;
            count = Table.Count();
            editedIndexs = new List<int>();
            statements = new List<string>();
        }
    }
}