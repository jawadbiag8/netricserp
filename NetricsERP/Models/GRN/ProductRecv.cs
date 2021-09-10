using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERPProject.Models
{
    public class ProductRecv
    {
        public int recvId { get; set; }
        public string challlanNum { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? revcDate { get; set; }
        public int custId { get; set; }
        public string recvFrom { get; set; }
        public int recvFromId { get; set; }
        public int PoId { get; set; }
        public string PoNum { get; set; }
        public int? productType { get; set; }
        public string prodtypeName { get; set; }
        public int? processId { get; set; }
        public string processName { get; set; }
        public int unit { get; set; }
        public string unitName { get; set; }
        public int qualityId { get; set; }
        public string quality { get; set; }
        public int sizeId { get; set; }
        public string size { get; set; }
        public int recvQuantity { get; set; }
        public int recvRoll { get; set; }
        public int recvWeight { get; set; }
        public bool isReprocess { get; set; }
        public string vehicleNum { get; set; }
        public string driverName { get; set; }
        public string remarks { get; set; }
        public int? addedBy { get; set; }



    }
}