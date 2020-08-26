using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.ViewModels
{
    class TrainViewModel : NotificationObject
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
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Type { get; set; }
       
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
