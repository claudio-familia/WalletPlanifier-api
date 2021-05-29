using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletPlanifier.Common.Services;
using WalletPlanifier.Common.Services.Contracts;

namespace WalletPlanifier.DataAccess.Configuration
{
    public static partial class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();            
        }
    }
}
