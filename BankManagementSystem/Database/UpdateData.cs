using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Database
{
    static class UpdateData
    {
        public static bool UpdateAccountStatus(Client client, Employee employee, string status)
        {
            string query = "update clients set AccountStatus='"+status+"', ClosedBy='"+employee.ID+"' where AccountNumber="+client.AccountID;
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
    }
}
