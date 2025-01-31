// Program.cs
using System;

public class Program
{
    public static void Main()
    {
        try
        {
            // Creating a new bank account
            var account = new BankAccount("John Silva", "123.456.789-00", 500);
            account.DisplayAccountInfo();

            // Trying to create an account with a duplicate CPF
            var duplicateAccount = new BankAccount("Maria Oliveira", "123.456.789-00", 1000);
            duplicateAccount.DisplayAccountInfo();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
