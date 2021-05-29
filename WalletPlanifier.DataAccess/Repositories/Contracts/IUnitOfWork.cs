using Microsoft.EntityFrameworkCore.Storage;

namespace WalletPlanifier.DataAccess.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IDbContextTransaction CreateTransaction();
        int SaveChanges();
    }
}
