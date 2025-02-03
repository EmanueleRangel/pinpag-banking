using System;
using System.Collections.Generic;
using System.Linq;

namespace pinpag_banking.Models
{
    public class BankAccount
    {
        public string ClientName { get; set; }
        public string CPF { get; set; }
        public decimal Balance { get; set; }

        private static HashSet<string> RegisteredCPFs = new HashSet<string>();
        private List<Transaction> TransactionHistory = new List<Transaction>(); // Adicionando a lista de transações

        public BankAccount(string clientName, string cpf, decimal? initialBalance = null)
        {
            if (!CPFValidation.Validate(cpf))
            {
                throw new ArgumentException("Invalid CPF format.");
            }

            if (RegisteredCPFs.Contains(cpf))
            {
                throw new ArgumentException("This CPF is already registered.");
            }

            ClientName = clientName;
            CPF = cpf;
            RegisteredCPFs.Add(cpf);

            Balance = initialBalance ?? 0;
            if (Balance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative.");
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than 0.");
            }
            Balance += amount;
            TransactionHistory.Add(new Transaction { Amount = amount, Date = DateTime.Now, Type = "Deposit" });
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than 0.");
            }
            if (Balance - amount < 0)
            {
                throw new ArgumentException("Insufficient balance.");
            }
            Balance -= amount;
            TransactionHistory.Add(new Transaction { Amount = amount, Date = DateTime.Now, Type = "Withdrawal" });
        }

        public List<Transaction> GetTransactionHistory()
        {
            return TransactionHistory;
        }

        public List<Transaction> GetTransactionHistory(int pageNumber, int pageSize)
        {
            return TransactionHistory
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
