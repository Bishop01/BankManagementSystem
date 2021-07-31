using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BankManagementSystem.Database
{
    static class DataVerification
    {
        private static SqlDataReader data;

        public static bool ValidateDBAdmin(int Id, string Password)
        {
            string query = "select Password from DBAdmins where ID = " + Id;
            data = DataHandler.GetRecord(query);
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
        public static bool ValidateLogin(int Id, string Password)
        {
            {
                //CloseDataReader();
                string query = "select Password from Employees where ID = " + Id;
                data = DataHandler.GetRecord(query);
                try
                {
                    if (!data.HasRows)
                    {
                        return false;
                    }
                    else
                    {
                        data.Read();
                        if (!(data["Password"].Equals(Password)))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static bool ValidateReset(int id, string nid, string pass)
        {
            string query = "select * from employees where id=" + id;
            data = DataHandler.GetRecord(query);
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

                if (nid.Equals(Nid) && pass.Equals(Pass))
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
        public static void CloseDataReader()
        {
            if(data != null)
                data.Close();
        }

    }
}
