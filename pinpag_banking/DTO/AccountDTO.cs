using System.ComponentModel.DataAnnotations;

namespace pinpag_banking.DTOs
{
    public class AccountDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "O nome do cliente deve ter no máximo 100 caracteres.")]
        public string ClientName { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos numéricos.")]
        public string CPF { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O saldo inicial não pode ser negativo.")]
        public decimal InitialBalance { get; set; }
    }
}
