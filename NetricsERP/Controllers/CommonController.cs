﻿using Deltasoft.Library;
using ERPProject.Models;
using NetricsERP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace NetricsERP.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetPo(int custId)
        {
            IEnumerable<SelectListItem> lstPO = DropDownlist.GetAll("PO", custId.ToString());
            JsonResult data = new JsonResult
            {
                Data = new { lstPO }
            };
            return data;
        }
        //public JsonResult AddNewValue(string typeTable, string value, string columnName, string controlId)
        //{
        //    CommonRepository commonRepo = new CommonRepository();
        //    int id = commonRepo.AddNewValue(typeTable, value, columnName, controlId);
        //    JsonResult data = new JsonResult
        //    {
        //        Data = new { id }
        //    };
        //    return data;
        //}
        public string CreateKey()
        {
            int length = 7;
            StringBuilder sb = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                if (random.Next(0, 1) == i || random.Next(1, 2) == i || random.Next(2, 3) == i || random.Next(3, 4) == i)
                    sb.Append((char)random.Next(65, 91));
                else
                    sb.Append(random.Next(0, 9));
            }
            return sb.ToString();
        }
        //public int UploadFiles(List<HttpPostedFileBase> list,string challanNum )//int type, int PersonID
        //{
        //    int AttachmentId = 0;
        //    foreach (var l in list)
        //    {
        //        string folder = "";
        //        //if (type == 1)
        //        //{
        //        //    folder = "Multimedia";
        //        //}
        //        //if (type == 2)
        //        //{
        //        //    folder = "NBMAttach";
        //        //}
        //        //if (type == 3)
        //        //{
        //        //    folder = "STTranscript";
        //        //}
        //        string AttachmentData = string.Empty;
        //        var length = l.ContentLength;
        //        var bytes = new byte[length];
        //        l.InputStream.Flush();
        //        l.InputStream.Read(bytes, 0, length);
        //        var fileName = l.FileName;
        //        var fileSize = l.ContentLength;
        //        var fileType = Path.GetExtension(fileName);
        //        string UploadPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"].ToString();

        //        //---------------------------------Directory Creation End--------------------------------//
        //        string ext = Path.GetExtension(fileName);
        //       // Media media = new Media();
        //        //MediaConverter MediaConverter = new MediaConverter();
        //        //media = MediaConverter.GetConvertedMedia(ext, fileName, bytes);
        //        //if (media.Tag == "Document")
        //        //{
        //        //    string DocumentPath = @UploadPath + "/" + "Attachment" + "/" + folder + "/" + "Document" + "/" + PersonID + "/";
        //        //    string FullDocumentPath = @DocumentPath + "/" + Path.GetFileNameWithoutExtension(fileName) + ext;
        //        //    var enc = new clsEncryption();
        //        //    var normalData = new MemoryStream(media.FileObject);
        //        //    byte[] encryptedData = enc.Encrypt(normalData);
        //        //    DirectoryInfo DocumentDirectoryInfo = new DirectoryInfo(HostingEnvironment.MapPath(DocumentPath));
        //        //    if (!Directory.Exists(DocumentDirectoryInfo.FullName))
        //        //    {
        //        //        Directory.CreateDirectory(DocumentDirectoryInfo.FullName);
        //        //    }
        //        //    if (media.Extension == ".pdf")
        //        //    {
        //        //        System.IO.File.Create(HostingEnvironment.MapPath(FullDocumentPath)).Close();
        //        //        MemoryStream memoryStream = new MemoryStream();
        //        //        memoryStream = AddWatermarkText(bytes, "S E C R E T", "  Generated By: " + iDAT.Accounts.SessionManager.MemberInfo.Login + " on " + DateTime.Now.ToString("dd-MMM-yyyy HHmm") + " hrs");
        //        //        bytes = memoryStream.ToArray();
        //        //        using (FileStream fs = new FileStream(HostingEnvironment.MapPath(FullDocumentPath), FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        //        //        {
        //        //            fs.Write(bytes, 0, bytes.Length);
        //        //        }

        //        //    }
        //        //    else if (media.Extension == ".docx" || media.Extension == ".doc")
        //        //    {
        //        //        watermarkword(bytes, fileName, folder, PersonID);
        //        //    }
        //        //    else
        //        //    {
        //        //        System.IO.File.Create(HostingEnvironment.MapPath(FullDocumentPath)).Close();
        //        //        using (FileStream fs = new FileStream(HostingEnvironment.MapPath(FullDocumentPath), FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        //        //        {
        //        //            fs.Write(bytes, 0, bytes.Length);
        //        //        }
        //        //    }

        //        //    if (System.IO.File.Exists(HostingEnvironment.MapPath(FullDocumentPath)))
        //        //    {
        //        //        Attachment doc = new Attachment();
        //        //        doc.FileName = media.FileName;
        //        //        doc.AttachmentPath = FullDocumentPath;
        //        //        doc.intializationVector = enc.IV;

        //        //        //Text Extraction From Document
        //        //        Stream streamobj = new MemoryStream(media.FileObject);
        //        //        AttachmentData = GetTextFromAllPages(streamobj);

        //        //        AttachmentRepository DocAttachment = new AttachmentRepository();
        //        //        doc.AttachmentID = DocAttachment.InsertAttachDocumentData(PersonID, doc.FileName, doc.AttachmentPath, media.Tag, ext, doc.intializationVector, AttachmentData);
        //        //        AttachmentId = doc.AttachmentID;
        //        //        //After Insertion 
        //        //        AttachmentData = string.Empty;
        //        //        DocAttachment = null;
        //        //    }
        //        //}
        //        if (media.Tag == "Image")
        //        {
        //            string ImagePath = @UploadPath + "/" + "Attachment" + "/" + folder + "/" + "Image" + "/" + challanNum + "/";
        //            DirectoryInfo ImageDirectoryInfo = new DirectoryInfo(HostingEnvironment.MapPath(ImagePath));
        //            if (!Directory.Exists(ImageDirectoryInfo.FullName))
        //            {
        //                Directory.CreateDirectory(ImageDirectoryInfo.FullName);
        //            }
        //            string FullImagePath = @ImagePath + "/" + media.FileName;
        //            System.IO.File.Create(HostingEnvironment.MapPath(FullImagePath)).Close();
        //            var enc = new clsEncryption();
        //            var normalData = new MemoryStream(media.FileObject);
        //            using (FileStream fs = new FileStream(HostingEnvironment.MapPath(FullImagePath), FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        //            {
        //                fs.Write(bytes, 0, bytes.Length);
        //            }
        //            if (System.IO.File.Exists(HostingEnvironment.MapPath(FullImagePath)))
        //            {
        //                Attachment img = new Attachment();
        //                img.FileName = media.FileName;
        //                img.AttachmentPath = FullImagePath;
        //                //img.intializationVector = enc.IV;
        //                AttachmentRepository ImageAttachment = new AttachmentRepository();
        //                img.AttachmentID = ImageAttachment.InsertAttachDocumentData(challanNum, img.FileName, img.AttachmentPath, media.Tag, ext, img.intializationVector);
        //                AttachmentId = img.AttachmentID;
        //                ImageAttachment = null;
        //            }
        //        }

        //        //if (media.Tag == "Audio")
        //        //{
        //        //    string AudioPath = @UploadPath + "/" + "Attachment" + "/" + folder + "/" + "Audio" + "/" + PersonID + "/";
        //        //    DirectoryInfo AudioDirectoryInfo = new DirectoryInfo(HostingEnvironment.MapPath(AudioPath));
        //        //    if (!Directory.Exists(AudioDirectoryInfo.FullName))
        //        //    {
        //        //        Directory.CreateDirectory(AudioDirectoryInfo.FullName);
        //        //    }
        //        //    string FullAudioPath = @AudioPath + "/" + media.FileName;
        //        //    System.IO.File.Create(HostingEnvironment.MapPath(FullAudioPath)).Close();
        //        //    var enc = new clsEncryption();
        //        //    var normalData = new MemoryStream(media.FileObject);
        //        //    using (FileStream fs = new FileStream(HostingEnvironment.MapPath(FullAudioPath), FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        //        //    {
        //        //        fs.Write(bytes, 0, bytes.Length);
        //        //    }
        //        //    if (System.IO.File.Exists(HostingEnvironment.MapPath(FullAudioPath)))
        //        //    {
        //        //        Attachment aud = new Attachment();
        //        //        aud.FileName = media.FileName;
        //        //        aud.AttachmentPath = FullAudioPath;
        //        //        aud.intializationVector = enc.IV;
        //        //        AttachmentRepository AudioAttachment = new AttachmentRepository();
        //        //        aud.AttachmentID = AudioAttachment.InsertAttachDocumentData(PersonID, aud.FileName, aud.AttachmentPath, media.Tag, ext, aud.intializationVector);
        //        //        AttachmentId = aud.AttachmentID;
        //        //        AudioAttachment = null;
        //        //    }
        //        //}
        //        //if (media.Tag == "Video")
        //        //{
        //        //    string VideoPath = @UploadPath + "/" + "Attachment" + "/" + folder + "/" + "Video" + "/" + PersonID + "/";
        //        //    DirectoryInfo VideoDirectoryInfo = new DirectoryInfo(HostingEnvironment.MapPath(VideoPath));
        //        //    if (!Directory.Exists(VideoDirectoryInfo.FullName))
        //        //    {
        //        //        Directory.CreateDirectory(VideoDirectoryInfo.FullName);
        //        //    }

        //        //    string FullVideoPath = @VideoPath + "/" + media.FileName;
        //        //    string outputpath = string.Empty;
        //        //    System.IO.File.Create(HostingEnvironment.MapPath(FullVideoPath)).Close();
        //        //    using (FileStream fs = new FileStream(HostingEnvironment.MapPath(FullVideoPath), FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
        //        //    {
        //        //        fs.Write(media.FileObject, 0, media.FileObject.Length);
        //        //    }
        //        //    if (media.Extension == ".flv" || media.Extension == ".mp4"
        //        //                || media.Extension == ".swf" || media.Extension == ".avi" || media.Extension == ".mkv"
        //        //                || media.Extension == ".mpg" || media.Extension == ".wmv" || media.Extension == ".mov"
        //        //                || media.Extension == ".divx" || media.Extension == ".3gp" || media.Extension == ".mpeg" || media.Extension == ".mpg")
        //        //    {
        //        //        outputpath = @VideoPath + "\\" + Path.GetFileNameWithoutExtension(media.FileName) + ".flv";
        //        //        Convert_toFLV(FullVideoPath, outputpath);
        //        //        var ffMpeg = new FFMpegConverter();
        //        //        string thumbnailJPEGpath = HostingEnvironment.MapPath(@VideoPath + "\\" + Path.GetFileNameWithoutExtension(media.FileName) + ".jpg");
        //        //        ffMpeg.GetVideoThumbnail(HostingEnvironment.MapPath(FullVideoPath), thumbnailJPEGpath);
        //        //    }
        //            //if (System.IO.File.Exists(HostingEnvironment.MapPath(outputpath)))
        //            //{
        //            //    //IF Converted files Exist in .flv than This part will Execute 
        //            //    Attachment vid = new Attachment();
        //            //    vid.AttachmentName = media.FileName;
        //            //    vid.AttachmentPath = outputpath;
        //            //    vid.intializationVector = null;
        //            //    AttachmentRepository VideoAttachment = new AttachmentRepository();
        //            //    vid.AttachmentID = VideoAttachment.InsertAttachDocumentData(PersonID, vid.AttachmentName, vid.AttachmentPath, media.Tag, ext, vid.intializationVector);
        //            //    AttachmentId = vid.AttachmentID;
        //            //    VideoAttachment = null;
        //            //}
        //        }

        //        //MediaConverter = null;
        //    }
        //    return (AttachmentId);
        //}
        public double ConvertUnit(int unitId,double qualityVal,double quantity,string size)
        {
            //unit = KG,MTR,Gram,Oz 
            double result = 0;
            double returnVal = 0;
            

            //Convert gram to LBS
            if (unitId ==1)
            {
                returnVal = GramToLBS(qualityVal);
                result = quantity * returnVal;
            }
            //Convert Kg to LBS
            if (unitId==2)
            {
                 returnVal= KGToLBS(qualityVal);
                result = quantity * returnVal;
            }
            //Convert Ounce to LBS
            if(unitId ==4)
            {
                returnVal = OzToLBS(qualityVal);
                result = quantity * returnVal;
            }
            if(unitId==5)
            {
                returnVal = GSMToLBS(qualityVal,size);
                double lbs = GramToLBS(returnVal);
                result = quantity * lbs;
            }
            return result;
        }
        public double GramToLBS(double gram)
        {
            double res = gram * 2.204 / 1000;
            return res; 
        }
        public double KGToLBS(double Kg)
        {
           double res= Kg * 2.204;
            return res;
        }
        public double OzToLBS(double oz)
        {
            double res = oz * 28.35;
            double val = GramToLBS(res);
            return val;
        }
        public double GSMToLBS(double gsm,string size)
        {
            double res = gsm / 10000;
            string[] splitStr = size.Split('x');
            double grm = res * clsCommon.ParseInt(splitStr[0]) * clsCommon.ParseInt(splitStr[1]);
            return grm;
        }

    }
}