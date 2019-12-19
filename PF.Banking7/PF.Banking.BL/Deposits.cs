using PF.Banking.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//a.	Load method – uses PL.Database.Select to return a generic list of deposit objects.

namespace PF.Banking.BL
{
    public class Deposits
    {
        public void GetAll()
        {
            try
            {
                Database db = new Database();
                DataTable deposits = new DataTable();

                // Retrieve the data
                string sql = "SELECT * FROM tblDeposits";
                deposits = db.Select(sql);

                this.Clear();

                // Loop through the recordset and insert into the list
                foreach (DataRow dr in deposits.Rows)
                {
                    Deposit deposit = new Deposit();
                    deposit.CustomerId = Convert.ToInt32(dr["Id"]);
                    deposit.DepositId =  Convert.ToInt32(dr["CustomerId"]);
                    deposit.DepositAmount = Convert.ToDecimal(dr["Amount"]);
                    deposit.DepositDate= Convert.ToDateTime(dr["TransDate"]);

                    this.Add(deposit);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
