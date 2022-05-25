using Dyder.Domain.Entities.Base;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Repository.Repositories.Interfaces.Base;

namespace Dyder.Application.Services.Interfaces.Base
{
    public interface IServiceBase<TEntity, TId, TRepository>
         where TEntity : EntityBase<TId>
         where TRepository : IRepositoryBase<TEntity, TId>
    {
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteByIdAsync(TId id, CancellationToken cancellationToken);
        Task DeleteManyAsync(TEntity[] entityArray, CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
