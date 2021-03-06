using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.BusinessLogic.Services.Transactions;
using WalletPlanifier.BusinessLogic.Services.Users;
using WalletPlanifier.Common.Services;
using WalletPlanifier.Common.Services.Contracts;
using WalletPlanifier.Domain.Transactions;
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
            services.AddScoped<IBaseService<WishList, WishListDto>, BaseService<WishList, WishListDto>>();

            services.AddScoped<IDebtService, DebtService>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IBaseService<Frecuency, FrecuencyDto>, BaseService<Frecuency, FrecuencyDto>>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IBaseService<Wallet, WalletDto>, WalletService>();
        }
    }
}
