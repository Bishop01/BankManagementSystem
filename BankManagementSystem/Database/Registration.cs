using System;
using System.Data.SqlClient;

namespace BankManagementSystem.Database
{
    static class Registration
    {
        public static bool RegisterEmployee(Employee employee)
        {
            string query = "insert into Employees(Name, Password, Email, Address, Gender, NID, PhoneNumber, DateOfBirth)" +
                " values('" + employee.Name + "','" + employee.Password + "','" + employee.Email + "','" + employee.Address + "','" + employee.Gender + "','" + employee.NID + "','" + employee.PhoneNumber + "','" + employee.DOB + "')";
            try
            {
                int result = DataHandler.ManipulateData(query);
                if (result <= 0)
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
        public static bool RegisterAccount(Client c, Account account, int eid)
        {
            try
            {
                string query1 = "insert into Clients(FirstName, LastName, Address, Email, PhoneNumber, DateOfBirth, Nationality, Gender, NID, Occupation, ImageDirectory) " +
                    "values('"+c.Firstname+"','"+c.Lastname+"','"+c.Address+"','"+c.Email+"',"+c.PhoneNumber+",'"+c.DOB+"','"+c.Nationality+"','"+c.Gender+"',"+c.NID+",'"+c.Occupation+"','"+c.ImageDir+"')";
                int result1 = DataHandler.ManipulateData(query1);
                
                Client client = FetchData.GetClientByNID(Convert.ToInt32(c.NID));
                c.ClientID = client.ClientID;
                string query2 = "insert into Accounts(ClientID, AccountType, RegisteredBy) values('" + client.ClientID + "','"+account.AccountType+"','"+eid+"')";
                int result2 = DataHandler.ManipulateData(query2);
                if (result1 >= 1 && result2 >= 1)
                {
                    return true;
                }
            }
            catch (Exception fe)
            {
                Console.WriteLine(fe.Message);
                return false;
            }
            return false;
            
        }
        public static bool UpdatePassword(int id, string pass)
        {
            string query = "update employees set password='" + pass + "' where id=" + id;
            int result = DataHandler.ManipulateData(query);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

    }
}