using System.Data;
using System.Windows.Controls;

namespace PersonnelManagementSystem.ViewModels.PageViewModels
{
    class MyAssessPageViewModel : PageViewModel<AssessViewModel>
    {
        public MyAssessPageViewModel()
        {
            SelectExecute();
        }

        public override void OnEditEnding(object sender, DataGridCellEditEndingEventArgs e) { }
        public override void SubmitExecute() { }

        public override void SelectExecute()
        {
            this.tableName = "Assess";
            statement = string.Format("select StaffNo,date_format(Date,'%Y-%m-%d') as Date,Score from {0} where StaffNo={1}", tableName, App.No);
            DataTable table = service.QueryManipulation(statement, connection);
            this.Table = DataTableToObservableCollection.ToObservableCollection<AssessViewModel>(table);
        }
    }
}
