using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.Banking.PL
{
    /*
    Open – Used to check if the database connection is open and, if not, open it.
    Select – Takes a SQLCommand object as argument and returns a DataTable object.
    Update – Takes a SQLCommand object as argument and returns integer value indicating how many rows were affected.
    Insert – Takes a SQLCommand object as argument and returns integer value indicating how many rows were affected.
    ExecuteSQL – Executes an Insert, Update, or Delete sql that is sent to it.
    Delete - Takes a SQLCommand object as argument and returns integer value indicating how many rows were affected.
    */
   public class Database
    {
        SqlConnection connection;
        string connstr = "Data Source = (localdb)\\ProjectsV13;Initial Catalog = PF.Banking.DB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public ConnectionState Open()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = connstr;
                connection.Open();
                return connection.State;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Insert(SqlCommand sqlCommand)
        {
            try
            {
                return ExecuteSQL(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Close()
        {
            try
            {
                connection.Close();
                connection = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int ExecuteSQL(SqlCommand sqlCommand)
        {
            try
            {
                if (ConnectionState.Open == Open())
                {
                    sqlCommand.Connection = connection;
                    int iRowsAffected = sqlCommand.ExecuteNonQuery();
                    Close();
                    return iRowsAffected;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Delete(SqlCommand sqlCommand)
        {
            try
            {
                return ExecuteSQL(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int Update(SqlCommand sqlCommand)
        {
            try
            {
                return ExecuteSQL(sqlCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Select(SqlCommand sqlCommand)
        {
            try
            {
                DataTable dataTable = new DataTable();

                if (ConnectionState.Open == Open())
                {
                    sqlCommand.Connection = connection;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    Close();
                }
                return dataTable;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Select(string sql)
        {
            try
            {
                DataTable dataTable = new DataTable();

                if (ConnectionState.Open == Open())
                {
                    SqlCommand sqlCommand = new SqlCommand(sql, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    Close();
                }
                return dataTable;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
