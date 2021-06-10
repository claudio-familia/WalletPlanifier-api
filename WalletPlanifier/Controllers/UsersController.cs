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
    public class UsersController : BaseController<User, UserDto>
    {
        public UsersController(IBaseService<User, UserDto> baseService) : base(baseService)
        {
        }

        [AllowAnonymous]
        public override IActionResult Post(UserDto entity)
        {
            return base.Post(entity);
        }
    }
}
