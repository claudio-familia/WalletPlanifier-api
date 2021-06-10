using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Controllers.Base;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishListsController : BaseController<WishList, WishListDto>
    {
        public WishListsController(IBaseService<WishList, WishListDto> baseService) : base(baseService)
        {
        }
    }
}
