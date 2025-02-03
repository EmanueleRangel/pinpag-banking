namespace pinpag_banking.DTO
{
    public class BankAccountTransactionDTO
    {
        public decimal Amount { get; set; }  // Valor da transação (depósito ou saque)
        public string Type { get; set; }     // Tipo da transação (por exemplo, "deposit" ou "withdraw")
        public DateTime Date { get; set; }   // Data da transação
    }
}
