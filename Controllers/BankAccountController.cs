using Microsoft.AspNetCore.Mvc;
using pinpag-banking.Models;
using pinpag-banking.DTO;
using pinpag-banking.Services;
using System;
using System.Collections.Generic;

namespace pinpag-banking.Controllers
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

        [HttpGet("transactions/{cpf}")]
        public IActionResult GetTransactionHistory(string cpf)
        {
            var history = _bankAccountService.GetTransactionHistory(cpf);
            if (history == null || history.Count == 0)
            {
                return NotFound(new { message = "No transactions found for this account." });
            }
            return Ok(history);
        }

        [HttpGet("report/{cpf}")]
        public IActionResult GetTransactionReport(string cpf, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var report = _bankAccountService.GetTransactionReport(cpf, startDate, endDate);
            return Ok(report);
        }

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
