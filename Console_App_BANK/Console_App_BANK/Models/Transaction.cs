using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_BANK.Models
{
    internal class Transaction
    {
        static int Count;
        public int TransactionId { get;}
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool TransactionType { get; set; }  //true - DEPOSIT, false - WITHDRAWAL

        public Transaction(decimal amount, bool transactiontype)
        {
            Count++;
            TransactionId = Count;
            Amount = amount;
            TransactionDate=DateTime.Now;
            TransactionType = transactiontype;
        }
    }
}
