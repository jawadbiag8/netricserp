using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class Godown
    {
        public int Id { get; set; }
        public string name { get; set; }
        // managedby is the employee who manages godown
        public int manageby { get; set; }

    }
}