using System;
using System.Data.SqlClient;
using System.Configuration;

namespace BankManagementSystem.Database
{
    static class DataHandler
    {
        private static SqlConnection sqlConnection;
        private static SqlCommand sqlCommand;
        private static SqlDataReader data;

        static DataHandler()
        {
            EstablishConnection();
        }
        static void EstablishConnection()
        {
            if(sqlConnection != null)
                sqlConnection.Close();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SKS"].ConnectionString);
            sqlConnection.Open();
        }
        public static SqlDataReader GetRecord(string query)
        {
            EstablishConnection();
            try
            {
                sqlCommand = new SqlCommand(query, sqlConnection);
                data = sqlCommand.ExecuteReader();
                return data;
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
                return null;
            }
        }
        public static int ManipulateData(string query)
        {
            EstablishConnection();
            sqlCommand = new SqlCommand(query, sqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }
        public static int GetScalarData(string query)
        {
            EstablishConnection();
            sqlCommand = new SqlCommand(query, sqlConnection);
            return (int)sqlCommand.ExecuteScalar();
        }
        public static void CloseConnection()
        {
            if(sqlConnection != null)
                sqlConnection.Close();
        }
    }
}
