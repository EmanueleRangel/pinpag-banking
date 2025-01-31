using YourProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourProject.Services
{
    public class BankAccountService
    {
        private readonly List<BankAccount> _bankAccounts;

        public BankAccountService()
        {
            _bankAccounts = new List<BankAccount>();
        }

        public BankAccount Deposit(string cpf, decimal amount)
        {
            var account = _bankAccounts.FirstOrDefault(acc => acc.CPF == cpf);
            if (account == null)
            {
                throw new ArgumentException("Account does not exist.");
            }
            account.Deposit(amount);
            return account;
        }

        public BankAccount Withdraw(string cpf, decimal amount)
        {
            var account = _bankAccounts.FirstOrDefault(acc => acc.CPF == cpf);
            if (account == null)
            {
                throw new ArgumentException("Account does not exist.");
            }
            account.Withdraw(amount);
            return account;
        }

        public void AddAccount(BankAccount account)
        {
            _bankAccounts.Add(account);
        }

        public class BankAccountTransactionDTO
        {
            public decimal Amount { get; set; }
        }

        public class TransactionHistoryDTO
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
