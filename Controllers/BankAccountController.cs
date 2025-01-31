using Microsoft.AspNetCore.Mvc;
using YourProject.Models;
using YourProject.DTO;
using YourProject.Services;
using System;
using System.Collections.Generic;

namespace YourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private static List<BankAccount> bankAccounts = new List<BankAccount>();
        private readonly BankAccountService _bankAccountService;

        public BankAccountController(BankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        // Endpoint para realizar depósito
        [HttpPost("deposit/{cpf}")]
        public IActionResult Deposit(string cpf, [FromBody] BankAccountTransactionDTO transactionDto)
        {
            try
            {
                var account = _bankAccountService.Deposit(cpf, transactionDto.Amount);
                return Ok(account);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Endpoint para realizar saque
        [HttpPost("withdraw/{cpf}")]
        public IActionResult Withdraw(string cpf, [FromBody] BankAccountTransactionDTO transactionDto)
        {
            try
            {
                var account = _bankAccountService.Withdraw(cpf, transactionDto.Amount);
                return Ok(account);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Endpoint para obter a conta bancária
        [HttpGet("{cpf}")]
        public IActionResult GetAccount(string cpf)
        {
            var account = bankAccounts.Find(acc => acc.CPF == cpf);
            if (account == null)
            {
                return NotFound(new { message = "Account not found." });
            }
            return Ok(account);
        }
    }
}
