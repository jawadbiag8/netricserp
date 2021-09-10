using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class employeeDetails
    {
        public int empId { get; set; }
        public string empName { get; set; }
        public int dptId { get; set; }
        public string phoneNum { get; set; }
        public int gender { get; set; }
        public string email { get; set; }
        public string permanenAddress { get; set; }
        public string tempAddress { get; set; }
        public string empUniqueId { get; set; }


    }
}