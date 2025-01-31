using System;
using YourProject.Models;
using YourProject.Services;

public class Program
{
    public static void Main()
    {
        try
        {
            var account = new Account("John Silva", "123.456.789-00", 500);
            account.DisplayAccountInfo();

            var duplicateAccount = new Account("Maria Oliveira", "123.456.789-00", 1000);
            duplicateAccount.DisplayAccountInfo();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
