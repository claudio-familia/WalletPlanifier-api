using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletPlanifier.BusinessLogic.Dto;
using WalletPlanifier.BusinessLogic.Services;
using WalletPlanifier.BusinessLogic.Services.Contracts;
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

            services.AddScoped<IBaseService<Debt, DebtDto>, BaseService<Debt, DebtDto>>();
            services.AddScoped<IBaseService<Income, IncomeDto>, BaseService<Income, IncomeDto>>();
            services.AddScoped<IBaseService<Frecuency, FrecuencyDto>, BaseService<Frecuency, FrecuencyDto>>();
            services.AddScoped<IBaseService<Transaction, TransactionDto>, BaseService<Transaction, TransactionDto>>();
            services.AddScoped<IBaseService<Wallet, WalletDto>, BaseService<Wallet, WalletDto>>();
        }
    }
}
