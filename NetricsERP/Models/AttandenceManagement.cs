using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetricsERP.Models
{
    public class AttandenceManagement
    {
        public int Id { get; set; }
        public int empId { get; set; }
        public int deptId { get; set; }
        public int total_Days { get; set; }
        public int leaves { get; set; }
        public int half_Days { get; set; }
        public string empName { get; set; }
        public string deptName { get; set; }
        public double lates { get; set; }


    }
}