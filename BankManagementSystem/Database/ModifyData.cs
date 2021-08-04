using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Database
{
    static class ModifyData
    {
        public static bool UpdateAccountStatus(Account account, Employee employee, string status)
        {
            string query = "update Accounts set AccountStatus='"+status+"', ClosedBy='"+employee.ID+"' where AccountID="+account.AccountID;
            int result = DataHandler.ManipulateData(query);
            if(result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateBalance(int id, double amount)
        {
            string query = "update Accounts set balance=balance+"+amount+" where AccountID="+id;
            int result = DataHandler.ManipulateData(query);
            if(result >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
