using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetricsERP.Models.Sales
{
    public class Challan
    {
        public int Id { get; set; }
        public string challanNum { get; set; }
        public DateTime? chDate { get; set; }
        public int custId { get; set; }
        public int? forwardTo { get; set; }
        public int process { get; set; }
        public int? colorId { get; set; }
        public int totalRoll { get; set; }
        public int totalPcs { get; set; }
        public double totalWeight { get; set; }
        public string vehicleNo { get; set; }
        public string remarks { get; set; }


    }
}