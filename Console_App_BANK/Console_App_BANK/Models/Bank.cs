using Console_App_BANK.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Console_App_BANK.Models
{
    internal class Bank
    {
        public string Name { get; set; }    
        List<Account> Accounts=new List<Account>();

        public Bank(string name)
        {
            Name= name;
        }
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
                throw new AccountNotFoundException("Account not found");
            }
            else
            {
                Account account = Accounts.Find(x => x.AccountId == id);
                account.Withdrawal(amount);
            }
        }

        public void TransferMoney (int fromAccountId, int toAccountId, decimal amount)
        {
            if(!CheckAccount(fromAccountId))
            {
                throw new AccountNotFoundException("Account not found");
            }
            if (!CheckAccount(toAccountId))
            {
                throw new AccountNotFoundException("Account not found");
            }

            Account fromAccount = Accounts.Find(x => x.AccountId == fromAccountId);
            Account toAccount = Accounts.Find(x => x.AccountId == toAccountId);

            if (fromAccount == toAccount)
            {
                throw new SameAccountException("You can't transfer the money to yourself");
            }
            else
            {
                fromAccount.Withdrawal(amount);
                toAccount.Deposit(amount);
            }
        }


        public void GetAllAccounts()
        {
            if (Accounts.Count == 0)
            {
                Console.WriteLine($"{Name} bank is empty");
            }
            else
            {
                Accounts.ForEach(x=>Console.WriteLine(x));
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
