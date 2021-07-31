using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BankManagementSystem.Database
{
    static class DataHandler
    {
        private static SqlConnection sqlConnection;
        private static SqlCommand sqlCommand;
        private static SqlDataReader data;
        static SqlConnection GetConnection()
        {
            if(sqlConnection != null)
            {
                return sqlConnection;
            }
            else
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SKS"].ConnectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
        }

        public static SqlDataReader GetRecord(string query)
        {
            try
            {
                sqlConnection = GetConnection();
                sqlCommand = new SqlCommand(query, sqlConnection);
                return sqlCommand.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static int ManipulateData(string query)
        {
            sqlConnection = GetConnection();
            sqlCommand = new SqlCommand(query, sqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
