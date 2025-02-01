using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace pinpag-banking.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static List<Account> Accounts = new List<Account>();

        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountDTO accountDto)
        {
            try
            {
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
}
