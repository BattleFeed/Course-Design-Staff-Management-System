using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.ViewModels
{
    class AttendanceViewModel : NotificationObject
    {
        private int staffNo;
        public int StaffNo
        {
            get { return staffNo; }
            set
            {
                staffNo = value;
                this.RaisePropertyChanged("StaffNo");
            }
        }

        public string StaffName { get; set; }
        public string Date { get; set; }
        public string CheckInTime { get; set; }
        public string LeaveTime { get; set; }
        public string Status { get; set; }       

        public bool toInsert = false;
        private bool toDelete = false;
        public bool ToDelete
        {
            get { return toDelete; }
            set
            {
                toDelete = value;
                this.RaisePropertyChanged("ToDelete");
            }
        }
    }
}
