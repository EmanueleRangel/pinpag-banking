using Microsoft.AspNetCore.Mvc;
using YourProject.Models;
using YourProject.Services;
using System;
using System.Collections.Generic;

namespace YourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // Corrigindo a declaração da lista para List<Account> (não ListAccount)
        private static List<Account> Accounts = new List<Account>();

        // Corrigindo o ponto e vírgula extra na assinatura do método CreateAccount
        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountDTO accountDto)
        {
            try
            {
                // Usando a classe Account em vez de Account
                var account = new Account(accountDto.ClientName, accountDto.CPF, accountDto.InitialBalance);
                Accounts.Add(account);
                return CreatedAtAction(nameof(GetAccount), new { cpf = account.CPF }, account);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{cpf}")]
        public IActionResult GetAccount(string cpf)
        {
            var account = Accounts.Find(acc => acc.CPF == cpf);
            if (account == null)
            {
                return NotFound(new { message = "Account not found." });
            }
            return Ok(account);
        }
    }

    public class AccountDTO
    {
        public string ClientName { get; set; }
        public string CPF { get; set; }
        public decimal InitialBalance { get; set; }
    }
}
