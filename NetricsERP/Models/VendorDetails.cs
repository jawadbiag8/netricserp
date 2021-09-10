using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class vendorDetails
    {
        public int vendId { get; set; }
        public string vendName { get; set; }
        public string vendAddress { get; set; }
        public string vendContact { get; set; }
        public string regNum { get; set; }
        public bool isReg { get; set; }
    }
}