using System.Data;
using System.Data.SqlClient;

namespace Ask.DAL
{
    /// <summary>
    /// Class treats with the database
    /// </summary>
    class DataAccessLayer
    {
        private SqlConnection sqlConnection;
        
        public DataAccessLayer()
        {
            // Intialize the connection object
            sqlConnection = new SqlConnection(@"Server = .\SQLEXPRESS01 ; Database = QuesAns_DB; Integrated Security = true");
        }

        /// <summary>
        /// Open the connection between the program and the Database
        /// </summary>
        private void open()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        /// <summary>
        /// Close the connection between the program and the Database
        /// </summary>
        private void close()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Read data from the Database
        /// </summary>
        /// <param name="stored_procedure"> stored procedure in the Database </param>
        /// <param name="param"> parameters of the stored procedure </param>
        public DataTable selectData(string stored_procedure, SqlParameter[] param)
        {
            open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            close();
            return dataTable;
        }

        /// <summary>
        /// Insert, Update and Delete Data from Database
        /// </summary>
        /// <param name="stored_procedure"> stored procedure in the Database </param>
        /// <param name="param"> parameters of the stored procedure </param>
        public void executeCommand(string stored_procedure, SqlParameter[] param)
        {
            open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
            close();
        }
    }
}