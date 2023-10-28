using Console_App_BANK.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_BANK.Models
{
    internal class Bank
    {
        public string Name { get; set; }    
        List<Account> Accounts=new List<Account>(); 

        public void CreateAccount()
        {
            Accounts.Add(new Account());
        }

        public void DepositMoney(int id, decimal amount)
        {
            if(!CheckAccount(id))
            {
                throw new AccountNotFoundException("Account doesn't found");
            }
            else
            {
                Account account = Accounts.Find(x=>x.AccountId == id);
                account.Deposit(amount);
            }

        }

        public void WithDrawal(int id, decimal amount)
        {
            if (!CheckAccount(id))
            {
                throw new AccountNotFoundException("Account doesn't found");
            }
            else
            {
                Account account = Accounts.Find(x => x.AccountId == id);
                account.Withdrawal(amount);
            }
        }



        public bool CheckAccount(int id)
        {
            Account account = Accounts.Find(x => x.AccountId == id);

            if (account == null)
            {
                return false;
            }

            return true;
        }
    }
}
