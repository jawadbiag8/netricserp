using Deltasoft.Library;
using ERPProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPProject.Repositories
{
    public class CustomerRepository
    {
        public int AddCustomer(customerDetails cust)
        {
            int custId = 0;
            try
            {
                DbManager manager = DbManager.GetDbManager("ERPConnection");
                SqlParameter[] parameters = new SqlParameter[]
                {
                    manager.MakeInParam("@customerName", SqlDbType.VarChar,20,cust.custName),
                    manager.MakeInParam("@address",SqlDbType.VarChar,500,cust.custAddress),
                    manager.MakeInParam("@contact",SqlDbType.VarChar,20,cust.custContact),
                    //manager.MakeInParam("@AddedBy", SqlDbType.Int, 0, ERPProject.Accounts.SessionManager.MemberInfo.LoginId)
                };

                custId = manager.RunProc("AddCustomer", parameters);

                return custId;
            }

            catch (Exception ex)
            {
                new Deltasoft.Library.SqlLog().InsertSqlLog(0, "CustomerRepositoriy.AddCustomer(customerDetails cust), int ErpId)", ex);
                return 0;
            }
        }
    }
}