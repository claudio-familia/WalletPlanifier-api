using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletPlanifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public DashboardController()
        {
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            return Ok(
                new
                {
                    AvailableMoney = "1,345.00",
                    SpentMoney = "236.00",
                    DebtTotal = "398.00",
                    Debts = new { PendingDebts = "4", PaidDebts = "2" },
                    Incomes = new { PendingIncomes = "2", recieveIncomes = "1" },
                });
        }

        [HttpGet("available-money")]
        public IActionResult GetAvailableMoney()
        {
            return Ok("1,345.00");
        }

        [HttpGet("spent-money")]
        public IActionResult GetSpends()
        {
            return Ok("236.00");
        }

        [HttpGet("debt-money")]
        public IActionResult GetDebtMoney()
        {
            return Ok("398.00");
        }

        [HttpGet("debts")]
        public IActionResult GetDebts()
        {
            return Ok(new { PendingDebts = "4", PaidDebts = "2" });
        }

        [HttpGet("incomes")]
        public IActionResult GetIncomes()
        {
            return Ok(new { PendingIncomes = "2", recieveIncomes = "1" });
        }
    }
}
