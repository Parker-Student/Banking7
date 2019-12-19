using PF.Banking.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.Banking.BL
{
    //a.	Load method – uses PL.Database.Select to return a generic list of withdrawal objects.
    public class Withdrawls : List<Withdrawl>
    {
        public void GetAll()
        {
            try
            {
                Database db = new Database();
                DataTable withdrawls = new DataTable();

                // Retrieve the data
                string sql = "SELECT * FROM tblWithdrawals";
                withdrawls = db.Select(sql);

                this.Clear();

                // Loop through the recordset and insert into the list
                foreach (DataRow dr in withdrawls.Rows)
                {
                    Withdrawl withdrawl = new Withdrawl();
                    withdrawl.CustomerId = Convert.ToInt32(dr["Id"]);
                    withdrawl.WithdrawlId = Convert.ToInt32(dr["CustomerId"]);
                    withdrawl.WithdrawlAmount = Convert.ToDecimal(dr["Amount"]);
                    withdrawl.WithdrawlDate = Convert.ToDateTime(dr["TransDate"]);

                    this.Add(withdrawl);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
