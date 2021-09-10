using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class Lot
    {
        public int lotId { get; set; }
        public string prodUniqueId { get; set; }
        public float quantity { get; set; }
        public int poId { get; set; }
    }
}