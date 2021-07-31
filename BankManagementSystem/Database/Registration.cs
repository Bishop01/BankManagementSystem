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
        public static bool RegisterAccount(Client client)
        {
            string query = "insert into Account() values()";
            int result = DataHandler.ManipulateData(query);
            if (result >= 1)
            {
                return true;
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
