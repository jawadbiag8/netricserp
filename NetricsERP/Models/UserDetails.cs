using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class userDetails
    {
        int userId { get; set; }
        string userName { get; set; }
        string password { get; set; }
        int desigId { get; set; }
        int deptId { get; set; }
        string desgName { get; set; }
        int deptName { get; set; }
    }
}