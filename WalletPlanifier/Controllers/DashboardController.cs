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
        private readonly IDataRepository<Debt> debtRepository;
        private readonly ICurrentUserService currentUserService;

        public DashboardController(IDataRepository<Wallet> walletRepository,
                                   IDataRepository<Debt> debtRepository,
                                   ICurrentUserService currentUserService)
        {
            this.walletRepository = walletRepository;
            this.debtRepository = debtRepository;
            this.currentUserService = currentUserService;
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            return Ok(
                new
                {
                    AvailableMoney = GetAvailableMoney(),
                    SpentMoney = GetSpends(),
                    DebtTotal = GetDebtMoney(),
                    Debts = new { PendingDebts = GetPendingDebts(), PaidDebts = GetDebtPaids() },
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
        public IActionResult AvailableMoney()
        {
            decimal response = GetAvailableMoney();

            return Ok(response);
        }

        [HttpGet("spent-money")]
        public IActionResult Spends()
        {
            decimal transactions = GetSpends();

            return Ok(transactions);
        }

        [HttpGet("debt-money")]
        public IActionResult DebtMoney()
        {
            decimal debts = GetDebtMoney();

            return Ok(debts);
        }

        [HttpGet("debts")]
        public IActionResult GetDebts()
        {
            int pendingDebts = GetPendingDebts();

            int paidDebts = GetDebtPaids();

            return Ok(new { PendingDebts = pendingDebts, PaidDebts = paidDebts });
        }

        [HttpGet("incomes")]
        public IActionResult GetIncomes()
        {
            return Ok(new { PendingIncomes = "2", recieveIncomes = "1" });
        }

        private decimal GetAvailableMoney()
        {
            decimal response = 0;

            var wallet = walletRepository.GetAll(x => x, x => x.UserId == currentUserService.UserId.Value).FirstOrDefault();

            if (wallet != null) response = wallet.Total;
            return response;
        }

        private decimal GetSpends()
        {
            return walletRepository.GetAll(x => x.Include(x => x.Transactions),
                                                                   i => i.UserId == currentUserService.UserId.Value)
                                                           .SelectMany(x => x.Transactions)
                                                           .Where(x => x.DebtId.HasValue)
                                                           .Sum(x => x.OriginWalletValue - x.FinalWalletValue);
        }

        private decimal GetDebtMoney()
        {
            return debtRepository.GetAll(x => x.Include(x => x.Transactions),
                                                          i => i.UserId == currentUserService.UserId.Value && !i.Transactions.Any())
                                                   .Sum(x => x.Amount);
        }

        private int GetPendingDebts()
        {
            return debtRepository.GetAll(x => x.Include(x => x.Transactions),
                                                          i => i.UserId == currentUserService.UserId.Value && !i.Transactions.Any())
                                                   .Count();
        }

        private int GetDebtPaids()
        {
            return debtRepository.GetAll(x => x.Include(x => x.Transactions),
                                                          i => i.UserId == currentUserService.UserId.Value && i.Transactions.Any())
                                                   .Count();
        }
        
    }
}
