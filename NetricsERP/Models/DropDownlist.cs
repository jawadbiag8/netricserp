using Deltasoft.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPProject.Models
{
    public class DropDownlist
    {
        public static IEnumerable<SelectListItem> GetAll(string name, string param = null)
        {
            string procName = string.Empty;
            string paramVal = param;

            switch (name)
            {
                case "Units":
                    procName = "up_GetAllUnits";
                    break;
                case "Customer":
                    procName = "up_GetAllCustomers";
                    break;
                case "ProcessType":
                    procName = "up_GetAllProcessType";
                    break;
                //case "Product":
                //    procName = "up_GetAllProduct";
                //    break;
                case "Sizes":
                    procName = "up_GetAllSizesByPO";
                    break;
                case "Quality":
                    procName = "up_GetAllQualityByPO";
                    break;
                case "ForwardTo":
                    procName = "up_GetAllForwardToByCustId";
                    break;
                case "ProductType":
                    procName = "up_GetAllProductType";
                    break;
                case "ChemType":
                    procName = "up_GetAllChemType";
                    break;
                case "Vendor":
                    procName = "up_GetAllVendor";
                    break;
                case "PO":
                    procName = "up_GetAllPOByCust";
                    break;
                case "QualityUnit":
                    procName = "up_GetAllQualityUnits";
                    break;
                //case "BloodGroup":
                //    procName = "up_GetAllBloodGroup";
                //    break;
                //case "Sect":
                //    procName = "up_GetAllSect";
                //    break;
                //case "Religion":
                //    procName = "up_GetAllReligion";
                //    break;
                //case "Caste":
                //    procName = "up_GetAllCaste";
                //    break;
                //case "CaseType":
                //    procName = "up_GetAllCaseType";
                //    break;
                //case "AttachmentType":
                //    procName = "UP_GetAllFormats";
                //    break;
                default:
                    break;


            }

            return GetList(procName, paramVal);
        }

        private static IEnumerable<SelectListItem> GetList(string procName, string param)
        {
            try
            {
                List<SelectListItem> list = new List<SelectListItem>();

                using (DbManager db = DbManager.GetDbManager("ERPConnection"))
                {
                    IDataReader reader;
                    if (param != null)
                    {
                        var prams = new SqlParameter[1];

                        prams[0] = db.MakeInParam("@Id", SqlDbType.VarChar, 0, param);

                        reader = db.GetDataReader(procName, prams);
                    }
                    else
                    {
                        SqlParameter[] prams = null;
                        reader = db.GetDataReader(procName, prams);
                    }

                    while (reader.Read())
                    {
                        list.Add(new SelectListItem
                        {
                            Value = clsCommon.ParseDBNullInt(reader[0]).ToString(),
                            Text = clsCommon.ParseDBNullString(reader[1]),
                            Selected = false
                        });
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                new SqlLog().InsertSqlLog(0, "IEnumerable<SelectListItem> GetList(string procName, string param)", e);
                return new List<SelectListItem>();
            }
        }
    }
}