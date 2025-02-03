using System;

namespace pinpag_banking.Models
{
    public class Transaction
    {
        public string Type { get; set; } // "Deposit" or "Withdrawal"
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string type, decimal amount)
        {
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }
    }
}
