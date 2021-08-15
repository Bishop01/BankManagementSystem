using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BankManagementSystem.Entity;

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
                employee.NID = Convert.ToInt32(data["NID"]);
                employee.PhoneNumber = Convert.ToInt64(data["PhoneNumber"]);
                employee.Gender = data["Gender"].ToString();
                employee.Address = data["Address"].ToString();

                return employee;
            }
            else
            {
                return null;
            }
        }
        public static Client GetClientByAccountID(int id)
        {
            string query = "select * from Clients where ClientID=(select ClientID from Accounts where AccountID="+id+")";
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

                    client.ClientID = (int)data["ClientID"];
                    client.Firstname = data["FirstName"].ToString();
                    client.Lastname = data["LastName"].ToString();
                    client.Email = data["Email"].ToString();
                    client.Gender = data["Gender"].ToString();
                    client.DOB = data["DateOfBirth"].ToString();
                    client.NID = (int)data["NID"];
                    client.PhoneNumber = (int)data["PhoneNumber"];
                    client.Nationality = data["Nationality"].ToString();
                    client.Occupation = data["Occupation"].ToString();
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
        public static List<Account> GetAccountsByNID(int nid)
        {
            string query = "select * from Accounts where ClientID=(select ClientID from clients where NID="+nid+")";
            List<Account> accounts = new List<Account>();
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
                    while (data.Read())
                    {
                        Account account = new Account();
                        account.Balance = Convert.ToDouble(data["Balance"]);
                        account.AccountID = (int)data["AccountID"];
                        account.AccountStatus = data["AccountStatus"].ToString();
                        account.AccountType = data["AccountType"].ToString();
                        accounts.Add(account);
                        //client.Firstname = data["FirstName"].ToString();
                        //client.Lastname = data["LastName"].ToString();
                        //client.Email = data["Email"].ToString();
                        //client.Gender = data["Gender"].ToString();
                        //client.DOB = data["DateOfBirth"].ToString();
                        //client.NID = data["NID"].ToString();
                        //client.PhoneNumber = data["PhoneNumber"].ToString();
                        //client.Nationality = data["Nationality"].ToString();
                        //client.Occupation = data["Occupation"].ToString();
                        //client.AccountStatus = data["AccountStatus"].ToString();
                        //client.AccountType = data["AccountType"].ToString();
                        //client.ImageDir = data["ImageDirectory"].ToString();
                        //client.Address = data["Address"].ToString();
                        //clients.Add(client);
                    }

                    return accounts;

                }
                catch (Exception)
                {
                    data.Close();
                    return null;
                }
            }
        }
        public static Account GetAccount(int id)
        {
            Account account = new Account();
            string query = "select * from Accounts where AccountID="+id;
            data = DataHandler.GetRecord(query);
            if (data.HasRows)
            {
                data.Read();
                account.AccountID = (int)data["AccountID"];
                account.AccountStatus = data["AccountStatus"].ToString();
                account.AccountType = data["AccountType"].ToString();
                account.Balance = Convert.ToDouble(data["Balance"]);
                account.CreateDate = data["CreationDate"].ToString();

                return account;
            }
            else
            {
                return null;
            }
        }
        public static Client GetClientByNID(int nid)
        {
            Client client = new Client();
            string query = "select * from Clients where NID='"+nid+"'";
            data = DataHandler.GetRecord(query);
            if (data.HasRows)
            {
                data.Read();

                client.Firstname = data["FirstName"].ToString();
                client.Lastname = data["LastName"].ToString();
                client.Email = data["Email"].ToString();
                client.Gender = data["Gender"].ToString();
                client.DOB = data["DateOfBirth"].ToString();
                client.NID = (int)data["NID"];
                client.PhoneNumber = (int)data["PhoneNumber"];
                client.Nationality = data["Nationality"].ToString();
                client.Occupation = data["Occupation"].ToString();
                client.ImageDir = data["ImageDirectory"].ToString();
                client.Address = data["Address"].ToString();
                client.ClientID = (int)data["ClientID"];

                return client;
            }
            else
            {
                return null;
            }
        }
        public static Account GetLastCreatedAccount()
        {
            Account account = new Account();
            string q = "select * from accounts where AccountID=(select MAX(AccountID) from accounts)";
            data = DataHandler.GetRecord(q);
            data.Read();
            account.AccountID = (int)data["AccountID"];
            account.AccountStatus = data["AccountStatus"].ToString();
            account.Balance = Convert.ToDouble(data["Balance"]);
            account.AccountType = data["AccountType"].ToString();
            account.CreateDate = data["CreationDate"].ToString();
            account.Due = Convert.ToDouble(data["Due"]);

            return account;
        }
        public static Manager GetManager(int id)
        {
            string query = "select * from Manager where ID="+id;
            data = DataHandler.GetRecord(query);
            if (data.HasRows)
            {
                data.Read();
                Manager manager = new Manager();
                manager.ID = (int)data["ID"];
                manager.Name = data["Name"].ToString();
                return manager;
            }
            else
            {
                return null;
            }
        }
        public static List<Employee> GetAllEmployees()
        {
            string query = "select * from employees";
            List<Employee> employees = new List<Employee>();
            data = DataHandler.GetRecord(query);
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Employee emp = new Employee();
                    emp.Name = data["Name"].ToString();
                    //Console.WriteLine(emp.Name);
                    emp.ID = (int)data["ID"];
                    emp.PhoneNumber = Convert.ToInt64(data["PhoneNumber"]);
                    emp.Address = data["Address"].ToString();
                    emp.DOB = data["DateOfBirth"].ToString();
                    emp.NID = Convert.ToInt32(data["NID"]);
                    emp.Gender = data["Gender"].ToString();
                    emp.Email = data["Email"].ToString();

                    employees.Add(emp);
                }
                return employees;
            }
            else
            {
                return null;
            }
        }
        public static List<Transactions> GetTransactionHistory(int id)
        {
            List<Transactions> transactions = new List<Transactions>();
            string query = "select * from TransactionHistory where EmployeeID="+id;
            data = DataHandler.GetRecord(query);
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Transactions t = new Transactions();
                    t.ID = (int)data["TransactionID"];
                    t.EmployeeID = (int)data["EmployeeID"];
                    t.AccountID = (int)data["AccountID"];
                    t.TransactionType = data["TransactionType"].ToString();

                    transactions.Add(t);
                }
                return transactions;
            }
            else
            {
                return null;
            }
        }
    }
}
