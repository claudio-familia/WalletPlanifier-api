using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDataRepository<Wallet> walletRepository;
        private readonly ICurrentUserService currentUserService;

        public DashboardController(IDataRepository<Wallet> walletRepository,
                                   ICurrentUserService currentUserService)
        {
            this.walletRepository = walletRepository;
            this.currentUserService = currentUserService;
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

        [HttpGet("wallet")]
        public IActionResult GetWallet()
        {
            var transactions = walletRepository.GetAll(x => x.Include(x => x.Transactions),
                                                       i => i.UserId == currentUserService.UserId.Value)
                                               .SelectMany(x => x.Transactions)
                                               .OrderByDescending(x => x.CreationTime)
                                               .Select(x => new
                                               {
                                                   Date = x.CreationTime.ToString("MMM-dd"),
                                                   Value = x.FinalWalletValue
                                               })
                                               .Take(5);            

            return Ok(transactions);
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
