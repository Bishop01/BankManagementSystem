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
                data.Close();
                return null;
            }
            else
            {
                try
                {
                    data.Close();
                    return (string)data["Name"];
                }
                catch (Exception)
                {
                    data.Close();
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
        public static bool ValidateReset(int id, string nid, string pass)
        {
            sql = GetConnection();
            string query = "select * from employees where id=" + id;
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
                string Nid = (string)data["NID"];
                string Pass = (string)data["Password"];

                if(nid.Equals(Nid) && pass.Equals(Pass))
                {
                    data.Close();
                    return true;
                }
                else
                {
                    data.Close();
                    return false;
                }
            }
        }
        public static bool UpdatePassword(int id, string pass)
        {
            sql = GetConnection();
            string query = "update employees set password='"+ pass +"' where id=" + id;
            sqlCommand = new SqlCommand(query, sql);
            int result = sqlCommand.ExecuteNonQuery();
            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
