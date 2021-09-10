using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetricsERP.Models
{
    public class SalaryManagement
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int deptId { get; set; }
        public string month { get; set; }
        public string EmpName { get; set; }
        public string deptName { get; set; }
        public double basicPay { get; set; }
        public double allowance { get; set; }
        public double bonus { get; set; }
        public double deduction { get; set; }
        public double totalPay { get; set; }
        public string desig { get; set; }

    }
}