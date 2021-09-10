using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productUniqueId { get; set; }
        //public string Name { get; set; }
        public string size { get; set; }
        public int? units { get; set; }
        public int? custId { get; set; }
        public int? addedBy { get; set; }
        public int prodType { get; set; }
    }
}