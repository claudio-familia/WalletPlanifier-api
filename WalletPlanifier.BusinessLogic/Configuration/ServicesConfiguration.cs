using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.BusinessLogic.Services.Users;
using WalletPlanifier.Common.Services;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.Domain.Users;

namespace WalletPlanifier.DataAccess.Configuration
{
    public static partial class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICryptographyService, CryptographyService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBaseService<User, UserDto>, UserService>();            
        }
    }
}
