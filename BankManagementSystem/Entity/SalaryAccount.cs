﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem
{
    class SalaryAccount:Account
    {
        public SalaryAccount()
        {
            accountType = "Salary";
            Console.WriteLine("");
        }
        public string AccountType
        {
            get { return accountType; }
        }
    }
}
