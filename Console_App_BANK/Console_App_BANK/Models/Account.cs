﻿using Console_App_BANK.Utilities.Exceptions;
using Console_App_BANK.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_BANK.Models
{
    internal class Account : IAccount
    {
        static int Count;
        public string Name;
        public string Surname;
        public byte Age;
        public int AccountId { get; set; }
        public decimal Balance { get; set; }

        List<Transaction> Transactions=new List<Transaction>();

        public Account(string name, string surname, byte age)
        {
            Count++;
            AccountId = Count;
            Balance = 0;
            Name = name;
            Surname = surname;
            Age = age;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Transactions.Add(new Transaction(amount, true));
            }
            else
            {
                throw new InvalidAmountException("The entered amount is incorrect");
            }
        }

        public void Withdrawal(decimal amount)
        {
            if (amount > 0)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    Transactions.Add(new Transaction(amount, false));

                }
                else
                {
                    throw new InsufficientFundsException("Your balance is less than the entered amount");
                }
            }
            else
            {
                throw new InvalidAmountException("The entered amount is incorrect");
            }
        }

        public override string ToString()
        {
            return $"Account ID: {AccountId} \nBalance: {Balance}";
        }

    }
}
