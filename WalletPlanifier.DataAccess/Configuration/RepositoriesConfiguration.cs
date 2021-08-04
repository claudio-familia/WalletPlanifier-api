using WalletPlanifier.DataAccess.Repositories;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WalletPlanifier.DataAccess.Configuration
{
    public static partial class RepositoriesConfiguration
    {
        public static void AddRespositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WalletPlanifierDBContext>(m =>
            {
                m.UseMySQL(configuration.GetConnectionString("WalletPlanifier"));
            });

            services.AddScoped<IDataRepositoryFactory, DataRepositoryFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IDataRepository<>), typeof(Repository<>));
        }
    }
}
