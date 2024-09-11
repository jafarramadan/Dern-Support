using System;
using System.Collections.Generic;

namespace Dern_Support.Models
{
    public class RepairJob
    {
        public int RepairJobId { get; set; } // Primary Key
        public string JobDescription { get; set; }
        public bool Completed { get; set; }
        public String ScheduledDate { get; set; } // Added for scheduling

       
    }
}
