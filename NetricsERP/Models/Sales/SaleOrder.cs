using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class saleOrder
    {
        int soId { get; set; }
        DateTime? soDate { get; set; }
        int custId { get; set; }
        int itemId { get; set; }
        float quantity { get; set; }
        float price { get; set; }
        float? grossAmount { get; set; }
        float? taxAmount { get; set; }
        float? netAmount { get; set; }
    }
}