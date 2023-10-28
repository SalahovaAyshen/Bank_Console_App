using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_BANK.Utilities.Interfaces
{
    internal interface IAccount
    {
       int AccountId { get; set; }
       decimal Balance { get; set; }

        public void Deposit(double amount);
        public void Withdraw(double amount);

    }
}
