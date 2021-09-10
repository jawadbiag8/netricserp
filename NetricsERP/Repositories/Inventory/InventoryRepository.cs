using Deltasoft.Library;
using ERPProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NetricsERP.Repositories.Inventory
{
    public class InventoryRepository
    {
        public int Add_Vendor(vendorDetails model)
        {
            int newID = 0;
            try
            {
                DbManager manager = DbManager.GetDbManager("ERPConnection");
                SqlParameter[] parameters = new SqlParameter[]
                {
                    manager.MakeInParam("@Name", SqlDbType.VarChar,20,model.vendName),
                    manager.MakeInParam("@vendAddress",SqlDbType.VarChar,500,model.vendAddress),
                    manager.MakeInParam("@vendContact",SqlDbType.VarChar,50,model.vendContact),
                    manager.MakeInParam("@isReg",SqlDbType.Int,0,model.isReg),
                    manager.MakeInParam("@regNum",SqlDbType.VarChar,50,model.regNum),

                    //manager.MakeInParam("@AddedBy", SqlDbType.Int, 0, ERPProject.Accounts.SessionManager.MemberInfo.LoginId)
                };

                newID = manager.RunProc("up_AddVendorDetails", parameters);

                return newID;
            }
            catch(Exception ex)
            {
                new Deltasoft.Library.SqlLog().InsertSqlLog(0, "InventoryRepositoriy.Add_Vendor(vendorDetails model), int ErpId)", ex);
                return 0;
            }
            return newID;
        }
        //public int Add_ChemRecv()
    }
}