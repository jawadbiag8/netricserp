using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class items
    {
        int itemId { get; set; }
        string itemName { get; set; }
        int size { get; set; }
        int unit { get; set; }
        bool isMaterial { get; set; }
        
    }
}