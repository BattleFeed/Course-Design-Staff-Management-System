using System.Data;
using System.Windows.Controls;

namespace PersonnelManagementSystem.ViewModels.PageViewModels
{
    class MyTrainPageViewModel : PageViewModel<TrainViewModel>
    {
        public MyTrainPageViewModel()
        {
            SelectExecute();
        }

        public override void OnEditEnding(object sender, DataGridCellEditEndingEventArgs e) { }
        public override void SubmitExecute() { }

        public override void SelectExecute()
        {
            this.tableName = "Train";
            statement = string.Format("select StaffNo,date_format(StartDate,'%Y-%m-%d') as StartDate,date_format(EndDate,'%Y-%m-%d') as EndDate,Type from {0} where StaffNo={1}", tableName, App.No);
            DataTable table = service.QueryManipulation(statement, connection);
            this.Table = DataTableToObservableCollection.ToObservableCollection<TrainViewModel>(table);
        }
    }
}
