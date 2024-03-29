﻿using Dyder.Domain.Entities.Base;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services.Interfaces.Base;
using Dyder.Repository.Repositories.Interfaces.Base;

namespace Dyder.Application.Services.Base
{
    public abstract class ServiceBase<TEntity, TId, TRepository> : IServiceBase<TEntity, TId, TRepository>
                                     where TEntity : EntityBase<TId>
                                     where TRepository : IRepositoryBase<TEntity, TId>
    {

        protected readonly TRepository _repository;

        public ServiceBase(TRepository repositorio)
        {
            _repository = repositorio;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var item = await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return item;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            //entity.Validate();
            var item = await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return item;
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteByIdAsync(TId id, CancellationToken cancellationToken)
        {
            await _repository.DeleteByIdAsync(id, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteManyAsync(TEntity[] entityArray, CancellationToken cancellationToken)
        {
            await _repository.DeleteManyAsync(entityArray, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }  
        
        public async Task<bool> ExistsByIdAsync(TId id, CancellationToken cancellationToken)
        {
            return await _repository.ExistsByIdAsync(id, cancellationToken);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}