using Deltasoft.Library;
using NetricsERP.Models.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NetricsERP.Repositories.Sales
{
    public class ProductOutRepository
    {
        public int outChallan(Challan model)
        {
            int newId = 0;
            try
            {
                DbManager manager = DbManager.GetDbManager("ERPConnection");
                SqlParameter[] parameters = new SqlParameter[]
                {
                    manager.MakeInParam("@challanNum", SqlDbType.VarChar,20,model.challanNum),
                    manager.MakeInParam("@date",SqlDbType.DateTime,0,model.chDate),
                    manager.MakeInParam("@custId",SqlDbType.Int,0,model.custId),
                    manager.MakeInParam("@forwardTo",SqlDbType.Int,0,model.forwardTo),
                    manager.MakeInParam("@processId",SqlDbType.Int,0,model.process),
                    manager.MakeInParam("@color",SqlDbType.Int,0,model.colorId),
                    manager.MakeInParam("@totalRoll",SqlDbType.Int,0,model.totalRoll),
                    //manager.MakeInParam("@sizes",SqlDbType.VarChar,100,model.sizes),
                    manager.MakeInParam("@totalPcs",SqlDbType.Int,20,model.totalPcs),
                    manager.MakeInParam("@totalWeight",SqlDbType.Float,0,model.totalWeight),
                    manager.MakeInParam("@vehicleNo",SqlDbType.VarChar,20,model.vehicleNo),
                    manager.MakeInParam("@remarks",SqlDbType.VarChar,500,model.remarks),


                    //manager.MakeInParam("@AddedBy", SqlDbType.Int, 0, ERPProject.Accounts.SessionManager.MemberInfo.LoginId)
                };
                newId = manager.RunProc("UP_AddChallan", parameters);

                return newId;
            }
            catch(Exception ex)
            {
                new Deltasoft.Library.SqlLog().InsertSqlLog(0, "ProductOutRepositoriy.outChallan(Challan model), int ErpId)", ex);
                return 0;
            }
            return 0;
        }
    }
}