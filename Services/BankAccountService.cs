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

        public List<Transaction> GetTransactionHistory(string cpf)
        {
            var account = _bankAccounts.FirstOrDefault(acc => acc.CPF == cpf);
            if (account == null)
            {
                throw new ArgumentException("Account does not exist.");
            }
            return account.GetTransactionHistory();
        }

        public object GetTransactionReport(string cpf, DateTime startDate, DateTime endDate)
        {
            var account = _bankAccounts.FirstOrDefault(acc => acc.CPF == cpf);
            if (account == null)
            {
                throw new ArgumentException("Account does not exist.");
            }

            var deposits = account.TransactionHistory
                .Where(t => t.Type == "Deposit" && t.Date >= startDate && t.Date <= endDate)
                .Sum(t => t.Amount);

            var withdrawals = account.TransactionHistory
                .Where(t => t.Type == "Withdrawal" && t.Date >= startDate && t.Date <= endDate)
                .Sum(t => t.Amount);

            return new
            {
                TotalDeposits = deposits,
                TotalWithdrawals = withdrawals
            };
        }

        public void AddAccount(BankAccount account)
        {
            _bankAccounts.Add(account);
        }
    }
}
