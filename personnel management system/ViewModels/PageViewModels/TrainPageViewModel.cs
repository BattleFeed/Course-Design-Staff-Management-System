using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using PersonnelManagementSystem.ViewModels.PageViewModels;

namespace PersonnelManagementSystem.ViewModels
{
    class TrainPageViewModel : PageViewModel<TrainViewModel>
    {
        public override void OnEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int i = e.Row.GetIndex();
            if (editedIndexs.Contains(i)) return;
            editedIndexs.Add(i);
            //新增行,toInsert=false时默认sql语句为update
            if (i >= count)
            { Table[i].toInsert = true; }
        }

        public override void SubmitExecute()
        {
            //修补bug:只点击复选框无法触发CellEditEnding事件
            foreach (TrainViewModel obj in Table)
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
                        statement = string.Format("delete from {2} where StaffNo='{0}' and StartDate=str_to_date('{1}','%Y-%m-%d')", item.StaffNo, item.StartDate, tableName);
                }
                else
                {
                    statement = item.toInsert ? string.Format("insert into {4} values('{0}',str_to_date('{1}','%Y-%m-%d'),str_to_date('{2}','%Y-%m-%d'),'{3}')",
                        item.StaffNo, item.StartDate, item.EndDate, item.Type, tableName)
                        : string.Format("update {4} set EndDate=str_to_date('{2}','%Y-%m-%d'),Type='{3}' where StaffNo='{0}' and StartDate=str_to_date('{1}','%Y-%m-%d')",
                        item.StaffNo, item.StartDate, item.EndDate, item.Type, tableName);
                }
                statements.Add(statement);
            }
            service.NonQueryManipulation(statements, connection);
            SelectExecute();
        }

        public override void SelectExecute()
        {
            this.tableName = "Train";//初始化表名
            statement = searchField == null ? string.Format("select StaffNo,staff.Name as StaffName,date_format(StartDate,'%Y-%m-%d') as StartDate,date_format(EndDate,'%Y-%m-%d') as EndDate,Type from {0},Staff where StaffNo=No", tableName)
                        : string.Format("select StaffNo,staff.Name as StaffName,date_format(StartDate,'%Y-%m-%d') as StartDate,date_format(EndDate,'%Y-%m-%d') as EndDate,Type from {1},Staff where StaffNo=No and staff.Name LIKE '%{0}%'", SearchField, tableName);
            DataTable table = service.QueryManipulation(statement, connection);
            this.Table = DataTableToObservableCollection.ToObservableCollection<TrainViewModel>(table);

            tableLastIndex = searchField == null ? Table.LastOrDefault().StaffNo : tableLastIndex;
            count = Table.Count();
            editedIndexs = new List<int>();
            statements = new List<string>();
        }
    }
}
