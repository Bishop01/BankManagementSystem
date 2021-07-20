using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BankManagementSystem
{
    static class DatabaseHandler
    {
        private static SqlConnection sql;
        private static SqlCommand sqlCommand;
        private static SqlDataReader data;
        public static SqlConnection GetConnection()
        {
            if(sql == null)
            {
                sql = new SqlConnection(ConfigurationManager.ConnectionStrings["SKS"].ConnectionString);
                sql.Open();
                return sql;
            }
            else
            {
                return sql;
            }
            
        }
        public static bool ValidateDBAdmin(int Id, string Password)
        {
            sql = GetConnection();
            string query = "select Password from DBAdmins where ID = " + Id;
            sqlCommand = new SqlCommand(query, sql);
            data = sqlCommand.ExecuteReader();
            if (!data.HasRows)
            {
                data.Close();
                return false;
            }
            else
            {
                data.Read();
                if (!(data["Password"].Equals(Password)))
                {
                    data.Close();
                    return false;
                }
                else
                {
                    data.Close();
                    return true;
                }
            }
        }
        public static bool RegisterEmployee(Employee employee)
        {
            sql = GetConnection();
            string query = "insert into Employees(Name, Password, Email, Address, Gender, NID, PhoneNumber, DateOfBirth)" +
                " values('"+employee.Name+"','"+employee.Password+"','"+employee.Email+"','"+employee.Address+"','"+employee.Gender+"','"+employee.NID+"','"+employee.PhoneNumber+"','"+employee.DOB+"')";
            try
            {
                sqlCommand = new SqlCommand(query, sql);
                int result = sqlCommand.ExecuteNonQuery();
                if(result <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ValidateLogin(int Id, string Password)
        {
            {
                sql = GetConnection();
                string query = "select Password from Employees where ID = " + Id;
                sqlCommand = new SqlCommand(query, sql);
                data = sqlCommand.ExecuteReader();
                if (!data.HasRows)
                {
                    data.Close();
                    return false;
                }
                else
                {
                    data.Read();
                    if (!(data["Password"].Equals(Password)))
                    {
                        data.Close();
                        return false;
                    }
                    else
                    {
                        data.Close();
                        return true;
                    }
                }
            }
        }
        public static string GetEmployee(int id)
        {
            string query = "select name from Employees where ID="+id;
            sqlCommand = new SqlCommand(query, sql);
            data = sqlCommand.ExecuteReader();
            if (!data.HasRows)
            {
                return null;
            }
            else
            {
                data.Read();
                try
                {
                    return (string)data["Name"];
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public static bool RegisterAccount(Client client)
        {
            sql = GetConnection();
            string query = "insert into Account() values()";
            sqlCommand = new SqlCommand(query, sql);
            if (sqlCommand.ExecuteNonQuery() >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
