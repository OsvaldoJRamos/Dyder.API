using Dyder.Domain.Entities.Base;
using Dyder.Repository.Repositories.Interfaces;

namespace Dyder.Application.Services._1___Interfaces
{
    public interface IServiceBase<TEntity, TId, TRepository>
         where TEntity : EntityBase
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
