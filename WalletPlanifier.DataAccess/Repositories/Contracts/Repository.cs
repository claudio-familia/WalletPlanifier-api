using WalletPlanifier.Common.Models;

namespace WalletPlanifier.DataAccess.Repositories.Contracts
{
    public class Repository<TEntity> : RepositoryBase<TEntity, WalletPlanifierDBContext> where TEntity : class, IAuditableEntity, new()
    {
        public Repository(WalletPlanifierDBContext context) : base(context) { }
    }
}
