using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.Banking.PL;

namespace PF.Banking.BL
{

    /*
    Customer (Derives from Person)
    a.	CustomerId (int)
    b.	Save method to call the DataServices.Save method. This is used for updates.
    c.	Insert method to call the DataServices.Save method.  This is used for inserts.
    d.	Delete method to call the DataServices.Delete method.
    e.	Depost property method (generic list of Deposit Objects)
    f.	Withdrawals property (generic list of Withdrawal Objects)
    */
    class Customer
    {
        private int customerid;

        public int CustomerID
        {
            get { return customerid; }
            set { customerid = value; }
        }

        public bool Insert()
        {
            try
            {
                Database db = new Database();
                SqlCommand sqlCommand = new SqlCommand();
                string sql = "insert into tblItemType (Id, Description) " +
                             " VALUES (@Id, @Description)";

                sqlCommand.CommandText = sql;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Description", description);

                int result = db.Insert(sqlCommand);
                db = null;

                return (result == 0 ? false : true);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Update()
        {

            try
            {
                Database db = new Database();
                SqlCommand sqlCommand = new SqlCommand();
                string sql = "UPDATE tblItemType SET Description = @Description " +
                             " WHERE Id = @Id";

                sqlCommand.CommandText = sql;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Description", description);

                int result = db.Update(sqlCommand);
                db = null;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public int Delete()
        {
            try
            {
                Database db = new Database();
                SqlCommand sqlCommand = new SqlCommand();
                string sql = "DELETE FROM tblItemType WHERE Id = @Id";

                sqlCommand.CommandText = sql;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                int result = db.Delete(sqlCommand);
                db = null;

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}