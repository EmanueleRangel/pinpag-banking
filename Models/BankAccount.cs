// BankAccount.cs
using System;
using System.Collections.Generic;

public class BankAccount
{
    public string ClientName { get; set; }
    public string CPF { get; set; }
    public decimal Balance { get; set; }

    private static HashSet<string> RegisteredCPFs = new HashSet<string>();

    // Constructor to create the bank account
    public BankAccount(string clientName, string cpf, decimal? initialBalance = null)
    {
        // Validate the CPF using CPFValidation class
        if (!CPFValidation.Validate(cpf))
        {
            throw new ArgumentException("Invalid CPF format. It should be 'xxx.xxx.xxx-xx'.");
        }

        // Check CPF uniqueness
        if (RegisteredCPFs.Contains(cpf))
        {
            throw new ArgumentException("This CPF is already registered.");
        }

        // Assign values
        ClientName = clientName;
        CPF = cpf;
        RegisteredCPFs.Add(cpf); // Add CPF to the registered list

        // Validate the initial balance (if provided)
        Balance = initialBalance ?? 0;
        if (Balance < 0)
        {
            throw new ArgumentException("Initial balance cannot be negative.");
        }
    }

    // Method to display account information
    public void DisplayAccountInfo()
    {
        Console.WriteLine($"Name: {ClientName}");
        Console.WriteLine($"CPF: {CPF}");
        Console.WriteLine($"Balance: {Balance:C}");
    }
}
