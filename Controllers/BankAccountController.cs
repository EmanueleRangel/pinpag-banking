using Microsoft.AspNetCore.Mvc;
using pinpag_banking.Models;
using pinpag_banking.Services;
using System;
using System.Collections.Generic;

namespace pinpag_banking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
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
            try
            {
                var history = _bankAccountService.GetTransactionHistory(cpf);
                return Ok(history);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("report/{cpf}")]
        public IActionResult GetTransactionReport(string cpf, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var report = _bankAccountService.GetTransactionReport(cpf, startDate, endDate);
                return Ok(report);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{cpf}")]
        public IActionResult GetAccount(string cpf)
        {
            var account = _bankAccountService.GetAccountByCpf(cpf);
            if (account == null)
            {
                return NotFound(new { message = "Account not found." });
            }
            return Ok(account);
        }
    }
}
