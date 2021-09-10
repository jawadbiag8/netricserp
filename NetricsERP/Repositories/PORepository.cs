using Deltasoft.Library;
using ERPProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NetricsERP.Repositories
{
    public class PORepository
    {
        public int AddPO(PO model)
        {
            int poId = 0;
            
            try
            {
                DataTable sizeTable = new DataTable();
                sizeTable.Columns.Add("Name");
                DataTable quality_gsm = new DataTable();
                quality_gsm.Columns.Add("Name");

                if (model.sizes != null & model.sizes != string.Empty)
                {
                    var sizeArr = model.sizes.Split(',');
                    foreach (string val in sizeArr)
                    {
                        sizeTable.Rows.Add(val);
                    }
                }
                if (model.quality != null & model.quality != string.Empty)
                {
                    var qauleArr = model.quality.Split(',');
                    foreach (string val in qauleArr)
                    {
                        quality_gsm.Rows.Add(val);
                    }
                }

                DbManager manager = DbManager.GetDbManager("ERPConnection");
                SqlParameter[] parameters = new SqlParameter[]
                {
                    manager.MakeInParam("@poNum", SqlDbType.VarChar,20,model.PoNumber),
                    manager.MakeInParam("@poDate",SqlDbType.DateTime,0,model.poDate),
                    manager.MakeInParam("@product",SqlDbType.Int,0,model.productId),
                    manager.MakeInParam("@dtquality",SqlDbType.Structured,0,quality_gsm),
                    manager.MakeInParam("@quantity",SqlDbType.Float,0,model.quantity),
                    manager.MakeInParam("@units",SqlDbType.Int,0,model.units),
                    manager.MakeInParam("@dtsizes",SqlDbType.Structured,0,sizeTable),
                    //manager.MakeInParam("@sizes",SqlDbType.VarChar,100,model.sizes),
                    manager.MakeInParam("@wPercent",SqlDbType.VarChar,20,model.wasteagepercent),
                    manager.MakeInParam("@process",SqlDbType.Int,0,model.processId),
                    manager.MakeInParam("@rates",SqlDbType.Float,20,model.Rate),
                    manager.MakeInParam("@custId",SqlDbType.Int,0,model.custId),
                    manager.MakeInParam("@remarks",SqlDbType.VarChar,500,model.remarks),


                    //manager.MakeInParam("@AddedBy", SqlDbType.Int, 0, ERPProject.Accounts.SessionManager.MemberInfo.LoginId)
                };

                poId = manager.RunProc("UP_AddPO", parameters);

                return poId;
            }

            catch (Exception ex)
            {
                new Deltasoft.Library.SqlLog().InsertSqlLog(0, "PORepositoriy.AddPo(PO model), int ErpId)", ex);
                return 0;
            }
            
        }
        public List<PO> getPOList()
        {
            List<PO> poLst = new List<PO>();
            try
            {
                DbManager manager = DbManager.GetDbManager("ERPConnection");
                //SqlParameter[] parameters = new SqlParameter[]
                //{

                //    //manager.MakeInParam("@EducationId",SqlDbType.Int,0, clsCommon.ParseDBNullInt( edu.EducationId)),
                //    manager.MakeInParam("@TgtId",SqlDbType.Int,0, clsCommon.ParseDBNullInt(tgtId))
                //};
                var reader = manager.GetDataReader("GetAllPO", null);
                int index = 1;
                while(reader.Read())
                {
                    poLst.Add(new PO
                    {
                        serial = index++,
                        poId = clsCommon.ParseDBNullInt(reader["poId"]),
                        PoNumber =clsCommon.ParseDBNullString(reader["PoNumber"]),
                        poDate = clsCommon.ParseDBNullDateTime(reader["poDate"]),
                        productName = clsCommon.ParseDBNullString(reader["prodName"]),
                        customerName = clsCommon.ParseDBNullString(reader["client"])
                    });
                    
                }




            }
            catch(Exception ex)
            {
                new Deltasoft.Library.SqlLog().InsertSqlLog(0, "PORepositoriy.getPOList(), int ErpId)", ex);
            }
            return poLst;
        }
        public List<PO> getPObyClientId(int custId)
        {
            List<PO> nwlst = new List<PO>();
            try
            {
                DbManager db = DbManager.GetDbManager("ERPConnection");
                SqlParameter[] parameters = new SqlParameter[]
                {
                    db.MakeInParam("@custId",SqlDbType.Int,0,custId)
                };
                var reader = db.GetDataReader("GetPOByCustId",parameters);
                while(reader.Read())
                {
                    int index = 1;
                    nwlst.Add(new PO
                    {
                        serial = index++,
                        poId = clsCommon.ParseDBNullInt(reader["poId"]),
                        PoNumber = clsCommon.ParseDBNullString(reader["PoNumber"]),
                        poDate = clsCommon.ParseDBNullDateTime(reader["poDate"]),
                        productName = clsCommon.ParseDBNullString(reader["prodName"]),
                        customerName = clsCommon.ParseDBNullString(reader["client"])
                    });
                }
            }
            catch(Exception ex)
            {
                new Deltasoft.Library.SqlLog().InsertSqlLog(0, "PORepositoriy.getPObyClientId(int custId), int ErpId)", ex);
            }
            return nwlst;
        }
        public PO getPOById (int Id)
        {
            PO model = new PO();
            try
            {
                DbManager db = DbManager.GetDbManager("ERPConnetion");
                SqlParameter[] parameters = new SqlParameter[]
            {
                   db.MakeInParam("@Id",SqlDbType.Int,0, Id)
            };
                var reader = db.GetDataReader("getPoById", parameters);
                while(reader.Read())
                {
                    model.poId = clsCommon.ParseDBNullInt(reader["poId"]);
                    model.PoNumber = clsCommon.ParseDBNullString(reader["poNum"]);
                    model.poDate = clsCommon.ParseDBNullDateTime(reader["poDate"]);
                    model.custId = clsCommon.ParseDBNullInt(reader["custId"]);
                    model.productId = clsCommon.ParseDBNullInt(reader["productId"]);
                    model.processId = clsCommon.ParseDBNullInt(reader["processId"]);
                    model.units = clsCommon.ParseDBNullInt(reader["units"]);
                    //model.quality = clsCommon.ParseDBNullDouble(reader["quality"]);
                    model.quantity = clsCommon.ParseDBNullDouble(reader["quantity"]);
                    model.sizes = clsCommon.ParseDBNullString(reader["sizes"]);
                    model.wasteagepercent = clsCommon.ParseDBNullString(reader["wasteagepercent"]);
                    model.remarks = clsCommon.ParseDBNullString(reader["remarks"]);
                    model.Rate = clsCommon.ParseDBNullDouble(reader["Rate"]);
                }
                return model;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
    }
}