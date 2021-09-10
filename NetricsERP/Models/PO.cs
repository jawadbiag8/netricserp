using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class PO
    {
        public int poId { get; set; }
        public string PoNumber { get; set; }
        public int? custId { get; set; }
        public int productId { get; set; }
        public double quantity { get; set; }
        public int? units { get; set; }
        public string quality { get; set; }
        public int? qualityUnit { get; set; }
        public int? qualityId { get; set; }
        public string sizes { get; set; }
        public int? sizeId { get; set; }
        public int? processId { get; set; }
        public string wasteagepercent { get; set; }
        public string remarks { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? poDate { get; set; }
        public double Rate { get; set; }
        public int serial { get; set; }
        public string customerName { get; set; }
        public string unitName { get; set; }
        public string process { get; set; }
        public string productName { get; set; }
        public string color { get; set; }
        public string design { get; set; }

    }
}