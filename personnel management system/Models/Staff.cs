using System;

namespace PersonnelManagementSystem.Models
{
    class Staff:User
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string EntryDate { get; set; }
        public string ContractDate { get; set; }
        public string Authority { get; set; }
        public string Status { get; set; }
    }
}
