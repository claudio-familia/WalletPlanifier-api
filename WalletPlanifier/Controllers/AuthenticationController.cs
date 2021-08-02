using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services.Contracts;

namespace WalletPlanifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost("login")]        
        public IActionResult Login(LoginDto user)
        {
            var authenticatedUser = _authService.Login(user.UserName, user.Password);

            if (authenticatedUser == null) return Unauthorized("Invalid username or password");

            return Ok(new { AccessToken = _authService.GenerateJWT(authenticatedUser) });
        }

        [HttpPost("user")]
        public IActionResult UserData()
        {
            string token = Request.Headers["Authorization"].ToString().Split(" ")[1];
            
            var tokenData = _authService.GetData(token);

            if (tokenData == null) return Unauthorized("User is not authenticated");

            return Ok(tokenData);
        }
    }
}
