using PF.Banking.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;




namespace PF.Banking.BL
{
    //a.	Load method – returns a list of customer objects.
   public class Customers : List<Customer>
    {
        delegate int GetNextId(int x);
        public int GetNewId()
        {
            GetNextId getNextId = delegate (int x)
            {
                x = x + 1;
                return x;
            };
            return getNextId(this.Max(c => c.CustomerID));
        }
        public void GetAll()
        {
            try
            {
                Database db = new Database();
                DataTable customers = new DataTable();

                // Retrieve the data
                string sql = "SELECT * FROM tblCustomers";
                customers = db.Select(sql);

                this.Clear();

                // Loop through the recordset and insert into the list
                foreach (DataRow dr in customers.Rows)
                {
                    Customer customer = new Customer();
                    customer.CustomerID = Convert.ToInt32(dr["Id"]);
                    customer.FirstName = dr["FirstName"].ToString();
                    customer.LastName = dr["LastName"].ToString();
                    customer.SSN = dr["SSN"].ToString();
                    customer.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
                  
                  //  customer.ItemType = (ItemType.Category)(dr["ItemType"]);

                    // Load my own software per computer id
                   // customer.Softwares.LoadByComputerId(customer.CustomerID);

                    this.Add(customer);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}



//list of customer