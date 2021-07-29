using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WalletPlanifier.BusinessLogic.Services.Contracts;
using WalletPlanifier.Common.Models;
using WalletPlanifier.DataAccess.Repositories.Contracts;

namespace WalletPlanifier.BusinessLogic.Services
{
    public class BaseService<T, Dto> : IBaseService<T, Dto> 
        where T : class, IAuditableEntity, new()
        where Dto : class, new()
    {
        protected readonly IDataRepository<T> repository;
        private readonly IMapper _mapper;

        public BaseService(IDataRepository<T> _repository,
                           IMapper mapper)
        {
            repository = _repository;
            this._mapper = mapper;
        }

        public virtual T Add(Dto newEntity)
        {
            try
            {
                var entity = _mapper.Map<T>(newEntity);

                entity.IsDeleted = false;

                return repository.Add(entity);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public T Delete(T entity)
        {
            entity.IsDeleted = true;

            return repository.Update(entity);
        }

        public virtual bool Exists(int id)
        {
            return repository.Exists(id);
        }

        public virtual bool Exists(Expression<Func<T, bool>> filter = null)
        {
            return repository.Exists(filter);
        }

        public virtual Dto Get(int id)
        {
            var result = repository.Get(id);

            return _mapper.Map<Dto>(result);
        }

        public virtual Dto Get(Guid id)
        {
            var result = repository.Get(id);

            return _mapper.Map<Dto>(result);
        }

        public virtual TResult Get<TResult>(Func<IQueryable<T>, IQueryable<TResult>> transform, Expression<Func<T, bool>> filter = null)
        {
            return repository.Get(transform, filter);
        }

        public virtual IEnumerable<Dto> GetAll()
        {
            var result = repository.GetAll();

            return _mapper.Map<IEnumerable<Dto>>(result);
        }

        public virtual IEnumerable<Dto> GetAll(Func<IQueryable<T>, IQueryable<T>> transform, Expression<Func<T, bool>> filter = null)
        {
            var result = repository.GetAll(transform, filter);

            return _mapper.Map<IEnumerable<Dto>>(result);
        }

        public T GetEntity(int id)
        {
            return repository.Get(id);
        }

        public virtual T Update(Dto entity)
        {
            try
            {
                var entityToBeUpdated = _mapper.Map<T>(entity);

                return repository.Update(entityToBeUpdated);                
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
