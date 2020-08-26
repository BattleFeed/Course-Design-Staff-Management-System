using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagementSystem.Models
{
    class Transfer
    {
        public int StaffNo { get; set; }
        public string Date { get; set; }
        public string OriginalDepartment { get; set; }
        public string OriginalPosition { get; set; }
        public string PresentDepartment { get; set; }
        public string PersentPosition { get; set; }
        public string Type { get; set; }
    }
}
