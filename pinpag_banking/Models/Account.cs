using System;
using pinpag_banking.Services;
using System.Collections.Generic;

namespace pinpag_banking.Models
{
    public class Account
    {
        public string ClientName { get; set; }
        public string CPF { get; set; }
        public decimal Balance { get; set; }

        private static HashSet<string> RegisteredCPFs = new HashSet<string>();

        public Account(string clientName, string cpf, decimal? initialBalance = null)
        {
            if (!CPFValidation.Validate(cpf))
            {
                throw new ArgumentException("Invalid CPF format. It should be 'xxx.xxx.xxx-xx'.");
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
    }
}
