using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WalletPlanifier.Common.Models;
using WalletPlanifier.Common.Models.Pagination;
using WalletPlanifier.Common.Models.Pagination.Contracts;
using WalletPlanifier.DataAccess.Repositories.Contracts;

namespace WalletPlanifier.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity, U> : IDataRepository<TEntity>
        where TEntity : class, IAuditableEntity, new()
        where U : DbContext
    {
        protected readonly U _Context;
        private readonly DbSet<TEntity> _DbSet;

        public RepositoryBase(U context)
        {
            _Context = context;
            _DbSet = _Context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);

            _Context.SaveChanges();

            return entity;
        }

        public virtual void Remove(TEntity entity)
        {
            _DbSet.Attach(entity);
            _Context.Entry<TEntity>(entity).State = EntityState.Deleted;

            _Context.SaveChanges();
        }

        public virtual void Remove(long id)
        {
            TEntity entity = _DbSet.Find(id);

            _Context.Entry<TEntity>(entity).State = EntityState.Deleted;
            _Context.SaveChanges();
        }

        public virtual TEntity Update(TEntity entity)
        {
            _DbSet.Attach(entity);
            _Context.Entry<TEntity>(entity).State = EntityState.Modified;

            _Context.SaveChanges();

            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _DbSet.AsNoTracking().Where(x => x.Active.Value).ToList();
        }

        public IPagedList<TEntity> GetPaged(int startRowIndex, int pageSize)
        {
            return new PagedList<TEntity>(_DbSet.AsNoTracking(), startRowIndex, pageSize);
        }

        public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var results = transform(query);

            return results.ToArray().ToList();
        }

        public IEnumerable<TResult> GetAll<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var results = transform(query);

            return results.ToArray().ToList();
        }

        public int GetCount<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            return transform(query).Count();
        }

        public IPagedList<TEntity> GetPaged(Func<IQueryable<TEntity>, IQueryable<TEntity>> transform, Expression<Func<TEntity, bool>> filter = null, int startRowIndex = -1, int pageSize = -1)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var results = transform(query);

            return new PagedList<TEntity>(results, startRowIndex, pageSize);
        }

        public IPagedList<TResult> GetPaged<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null, int startRowIndex = -1, int pageSize = -1)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            var results = transform(query);

            return new PagedList<TResult>(results, startRowIndex, pageSize);
        }

        public TEntity Get(int id)
        {
            return _DbSet.Find(id);
        }

        public TEntity Get(Guid id)
        {
            return _DbSet.Find(id);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return _DbSet.FirstOrDefault(filter);
        }

        public TResult Get<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> transform, Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet : _DbSet.Where(filter);

            var results = transform(query);

            return results.FirstOrDefault();
        }
        public bool Exists(int id)
        {
            return _DbSet.Find(id) != null;
        }

        public bool Exists(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = filter == null ? _DbSet.AsNoTracking() : _DbSet.AsNoTracking().Where(filter);

            return query.Any();
        }
    }
}
