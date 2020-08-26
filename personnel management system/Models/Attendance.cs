using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Models
{
    class Attendance
    {
        public int StaffNo { get; set; }
        public string Date { get; set; }
        public string CheckInTime { get; set; }
        public string LeaveTime { get; set; }
        public string Status { get; set; }
    }
}
