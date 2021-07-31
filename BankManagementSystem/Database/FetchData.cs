using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BankManagementSystem.Database
{
    class FetchData
    {
        private static SqlDataReader data;
        public static string GetEmployee(int id)
        {
            string query = "select name from Employees where ID=" + id;
            data = DataHandler.GetRecord(query);
            if (!data.HasRows)
            {
                data.Close();
                return null;
            }
            else
            {
                try
                {
                    data.Read();
                    return data["Name"].ToString();
                }
                catch (Exception)
                {
                    data.Close();
                    return null;
                }
            }
        }
    }
}
