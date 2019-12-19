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
    public class Customer : Person
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
                string sql = "insert into tblCustomer (Id, FirstName, LastName, SSN, BirthDate) " +
                             " VALUES (@Id, @FirstName, @LastName, @SSN, @BirthDate)";

                sqlCommand.CommandText = sql;

                sqlCommand.Parameters.AddWithValue("@Id", this.CustomerID);
                sqlCommand.Parameters.AddWithValue("@FirstName", this.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", this.LastName);
                sqlCommand.Parameters.AddWithValue("@SSN", this.SSN);
                sqlCommand.Parameters.AddWithValue("@BirthDate", this.BirthDate);
                

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
                string sql = "UPDATE tblCustomer SET FirstName = @FirstName, LastName = @FirstName, SSN = @SSN, " +
                             "BirthDate= @BirthDate " +
                             " WHERE Id = @Id";

                sqlCommand.CommandText = sql;

                sqlCommand.Parameters.AddWithValue("@Id", this.CustomerID);
                sqlCommand.Parameters.AddWithValue("@FirstName", this.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", this.LastName);
                sqlCommand.Parameters.AddWithValue("@SSN", this.SSN);
                sqlCommand.Parameters.AddWithValue("@BirthDate", this.BirthDate);

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
                string sql = "DELETE FROM tblCustomer WHERE Id = @Id";

                sqlCommand.CommandText = sql;

                sqlCommand.Parameters.AddWithValue("@Id", this.CustomerID);

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