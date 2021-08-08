using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Entity
{
    class Transactions
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string TransactionType { get; set; }
        public int AccountID { get; set; }
    }
}
