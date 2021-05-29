using WalletPlanifier.Common.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WalletPlanifier.Common.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var currentContext = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(currentContext)) UserId = int.Parse(currentContext);
            else UserId = 0;
            IsAuthenticated = UserId.HasValue && UserId.Value != 0;
        }

        public int? UserId { get; }
        public bool IsAuthenticated { get; }        
    }
}
