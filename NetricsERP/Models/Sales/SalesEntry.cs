using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class salesEntry
    {
        int saleBillNo { get; set; }
        DateTime? saleDate { get; set; }
        int soId { get; set; }
        int itemId { get; set; }
        string billNo { get; set; }
        float salesQuantity { get; set; }
        float salesAmount { get; set; }
    }
}