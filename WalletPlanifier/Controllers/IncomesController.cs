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
    public class IncomesController : BaseController<Income, IncomeDto>
    {
        public IncomesController(IBaseService<Income, IncomeDto> baseService) : base(baseService)
        {
        }
    }
}
