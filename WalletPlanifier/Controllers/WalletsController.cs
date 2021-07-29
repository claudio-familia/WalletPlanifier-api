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
    public class WalletsController : BaseController<Wallet, WalletDto>
    {
        public WalletsController(IBaseService<Wallet, WalletDto> baseService) : base(baseService)
        {
        }
    }
}
