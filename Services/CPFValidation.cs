// CPFValidation.cs
using System.Text.RegularExpressions;

public static class CPFValidation
{
    // Method to validate CPF format
    public static bool Validate(string cpf)
    {
        var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        return regex.IsMatch(cpf);
    }
}
