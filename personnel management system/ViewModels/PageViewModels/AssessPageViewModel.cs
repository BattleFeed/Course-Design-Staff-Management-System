using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using PersonnelManagementSystem.ViewModels.PageViewModels;

namespace PersonnelManagementSystem.ViewModels
{
    class AssessPageViewModel : PageViewModel<AssessViewModel>
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
            foreach (AssessViewModel obj in Table)
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
                        statement = string.Format("delete from {2} where StaffNo='{0}' and Date=str_to_date('{1}','%Y-%m-%d')", item.StaffNo, item.Date, tableName);
                }
                else
                {
                    statement = item.toInsert ? string.Format("insert into {3} values('{0}',str_to_date('{1}','%Y-%m-%d'),'{2}')",
                        item.StaffNo, item.Date, item.Score, tableName)
                        : string.Format("update {3} set StaffNo='{0}',Date=str_to_date('{1}','%Y-%m-%d'),Score='{2}' where StaffNo='{0}' and Date=str_to_date('{1}','%Y-%m-%d')",
                        item.StaffNo, item.Date, item.Score, tableName);
                }
                statements.Add(statement);
            }
            service.NonQueryManipulation(statements, connection);
            SelectExecute();
        }

        public override void SelectExecute()
        {
            this.tableName = "Assess";//初始化表名
            statement = searchField == null ? string.Format("select StaffNo,staff.Name as StaffName,date_format(Date,'%Y-%m-%d') as Date,Score from {0},Staff where StaffNo=No", tableName)
                        : string.Format("select StaffNo,staff.Name as StaffName,date_format(Date,'%Y-%m-%d') as Date,Score from {1},Staff where StaffNo=No and staff.Name LIKE '%{0}%'", SearchField, tableName);
            DataTable table = service.QueryManipulation(statement, connection);
            this.Table = DataTableToObservableCollection.ToObservableCollection<AssessViewModel>(table);

            tableLastIndex = searchField == null ? Table.LastOrDefault().StaffNo : tableLastIndex;
            count = Table.Count();
            editedIndexs = new List<int>();
            statements = new List<string>();
        }
    }
}
