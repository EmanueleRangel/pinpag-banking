using YourProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourProject.Services
{

    public class AccountDTO
    {
        public string ClientName { get; set; }
        public string CPF { get; set; }
        public decimal InitialBalance { get; set; }
    }

}