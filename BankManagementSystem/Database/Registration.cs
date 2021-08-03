using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Employee employee = FetchData.GetEmployee(eid);
            int id = employee.ID;
            try
            {
                string query1 = "insert into Clients(FirstName, LastName, Address, Email, PhoneNumber, DateOfBirth, Nationality, Gender, NID, Occupation, ImageDirectory, RegisteredBy) " +
                    "values('"+c.Firstname+"','"+c.Lastname+"','"+c.Address+"','"+c.Email+"','"+c.PhoneNumber+"','"+c.DOB+"'" +
                    ",'"+c.Nationality+"','"+c.Gender+"','"+c.NID+"','"+c.Occupation+"','"+c.ImageDir+"',"+id+")";
                int result1 = DataHandler.ManipulateData(query1);
                string query2 = "insert into Accounts(AccountType) values('" + account.AccountType + "')";
                int result2 = DataHandler.ManipulateData(query2);
                if (result1 >= 1 && result2 >= 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {
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