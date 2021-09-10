using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class purchaseProducts
    {
        int Id { get; set; }
        public DateTime? recvDate { get; set; }
        public string challanNum { get; set; }
        public DateTime? reqDate { get; set; }
        public int vendId { get; set; }
        public int chemId { get; set; }
        public double quantity { get; set; }
        public int unit { get; set; }
        public double price { get; set; }
        public double? grossAmount { get; set; }
        public double? taxAmount { get; set; }
        public double? netAmount { get; set; }
        public bool isChemical { get; set; }
        public bool chemType { get; set; }
    }
}