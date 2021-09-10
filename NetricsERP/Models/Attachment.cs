using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetricsERP.Models
{
    public class Attachment
    {
        public int AttachmentID { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentName { get; set; }
        public string OriginalAttachmentExtension { get; set; }
        public string AttachmentType { get; set; }
        public int Serial { get; set; }
        public string TagsID { get; set; }
        public string TagName { get; set; }
        public string FileName { get; set; }
        public int? FileTypeId { get; set; }
        public string FileTypeName { get; set; }
        public int PoId { get; set; }
        public string PoNum { get; set; }
        public string challanNum { get; set; }
        public bool isRecv { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime AddedOn { get; set; }
    }
}