using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WalletPlanifier.Common.Models;

namespace WalletPlanifier.BusinessLogic.Services.Contracts
{
    public interface IBaseService<T, Dto>
    {
        T Add(Dto entity);
        T Update(Dto entity);
        IEnumerable<Dto> GetAll();
        IEnumerable<Dto> GetAll(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null);
        Dto Get(int id);
        T GetEntity(int id);
        Dto Get(Guid id);
        TResult Get<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null);
        bool Exists(int id);
        bool Exists(Expression<Func<T, bool>> filter = null);
        T Delete(T entity);
    }
}
