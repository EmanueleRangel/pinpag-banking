using System.Text.RegularExpressions;

namespace YourProject.Services
{
    public static class CPFValidation
    {
        public static bool Validate(string cpf)
        {
            var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
            return regex.IsMatch(cpf);
        }
    }
}
