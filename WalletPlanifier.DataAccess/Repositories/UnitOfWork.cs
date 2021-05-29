using Microsoft.EntityFrameworkCore.Storage;
using WalletPlanifier.DataAccess.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace WalletPlanifier.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly WalletPlanifierDBContext _DataContext;

        public UnitOfWork(WalletPlanifierDBContext dataContext)
        {
            _DataContext = dataContext;
        }

        public IDbContextTransaction CreateTransaction()
        {
            return this._DataContext.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return _DataContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_DataContext != null)
            {
                _DataContext.Dispose();
            }
        }
    }
}
