using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class ProductOut
    {
        public int Id { get; set; }
        public DateTime? sendDate { get; set; }
        public int custId { get; set; }
        public int prodId { get; set; }
        public int? lotId { get; set; }
        public float quantity { get; set; }
        public string challanNum { get; set; }
        public int forwardTo { get; set; }
        public int? poId { get; set; }
        public int processId { get; set; }
        public int? addedBy { get; set; }
    }
}