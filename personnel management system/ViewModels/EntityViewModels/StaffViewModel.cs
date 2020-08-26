using PersonnelManagementSystem.Models;
using System;

namespace PersonnelManagementSystem.ViewModels
{
    class StaffViewModel:NotificationObject
    {
        private int no;
        public int No
        {
            get { return no; }
            set
            {
                no = value;
                this.RaisePropertyChanged("No");
            }
        }

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string EntryDate { get; set; }
        public string ContractDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; }
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
