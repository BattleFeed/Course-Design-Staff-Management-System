using System.Data;
using System.Windows.Controls;

namespace PersonnelManagementSystem.ViewModels.PageViewModels
{
    class MyAttendancePageViewModel:PageViewModel<AttendanceViewModel>
    {
        public MyAttendancePageViewModel()
        {
            SelectExecute();
        }

        public override void OnEditEnding(object sender, DataGridCellEditEndingEventArgs e) { }
        public override void SubmitExecute() { }

        public override void SelectExecute()
        {
            this.tableName = "Attendance";
            statement = string.Format("select StaffNo,date_format(Date,'%Y-%m-%d') as Date,time_format(CheckInTime,'%H:%i:%s') as CheckInTime,time_format(LeaveTime,'%H:%i:%s') as LeaveTime,{0}.Status from {0} where StaffNo={1}", tableName, App.No);
            DataTable table = service.QueryManipulation(statement, connection);
            this.Table = DataTableToObservableCollection.ToObservableCollection<AttendanceViewModel>(table);
        }
    }
}
