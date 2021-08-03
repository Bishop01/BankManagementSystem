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
        public static string GetEmployeeName(int id)
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
        public static Employee GetEmployee(int id)
        {
            Employee employee = new Employee();
            string query = "select * from Employees where ID=" + id;
            data = DataHandler.GetRecord(query);
            if (data.HasRows)
            {
                data.Read();
                employee.ID = id;
                employee.Name = data["Name"].ToString();
                employee.Email = data["Email"].ToString();
                employee.DOB = data["DateOfBirth"].ToString();
                employee.NID = data["NID"].ToString();
                employee.PhoneNumber = data["PhoneNumber"].ToString();
                employee.Gender = data["Gender"].ToString();
                employee.Address = data["Address"].ToString();

                return employee;
            }
            else
            {
                return null;
            }
        }
        public static Client GetClient(int id)
        {
            string query = "select * from Clients where AccountNumber=" + id;
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
                    Client client = new Client();
                    data.Read();

                    client.Firstname = data["FirstName"].ToString();
                    client.Lastname = data["LastName"].ToString();
                    client.Email = data["Email"].ToString();
                    client.AccountID = (int)data["AccountNumber"];
                    client.Gender = data["Gender"].ToString();
                    client.DOB = data["DateOfBirth"].ToString();
                    client.NID = data["NID"].ToString();
                    client.PhoneNumber = data["PhoneNumber"].ToString();
                    client.Nationality = data["Nationality"].ToString();
                    client.Occupation = data["Occupation"].ToString();
                    client.AccountStatus = data["AccountStatus"].ToString();
                    client.AccountType = data["AccountType"].ToString();
                    client.ImageDir = data["ImageDirectory"].ToString();
                    client.Address = data["Address"].ToString();

                    return client;

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
