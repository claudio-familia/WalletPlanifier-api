using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Controllers.Base;
using WalletPlanifier.Domain.Transactions;

namespace WalletPlanifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DebtsController : BaseController<Debt, DebtDto>
    {
        private readonly IDebtService baseService;

        public DebtsController(IDebtService baseService) : base(baseService)
        {            
            this.baseService = baseService;
        }

        [HttpPost("{id}/transaction")]
        public IActionResult ApplyTransaction(int id)
        {
            return Ok(baseService.AddTransaction(id));
        }

    }
}
