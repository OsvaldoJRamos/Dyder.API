﻿using Dyder.Domain.Entities.Base;
using Dyder.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Dyder.Repository.Repositories.Interfaces.Base;
using Dyder.Repository.Repositories;

namespace Dyder.Repository.Repositories.Base
{
    public class RepositoryBase<TEntity, TId> : IRepositoryBase<TEntity, TId> where TEntity : EntityBase<TId>
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<TEntity> _dataset;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dataset = _context.Set<TEntity>();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken) =>
            await Task.Run(() => _dataset.Update(entity).Entity);

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken) =>
            await Task.Run(() => _dataset.Add(entity).Entity);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken) =>
            await Task.Run(() => _dataset.AddRangeAsync(entities));

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken) =>
            await Task.Run(() => _dataset.Remove(entity));

        public async Task DeleteByIdAsync(TId id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            await DeleteAsync(entity, cancellationToken);
        }

        public async Task DeleteManyAsync(TEntity[] entityArray, CancellationToken cancellationToken) =>
           await Task.Run(() => _dataset.RemoveRange(entityArray));

        public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken) =>
            await _dataset.FindAsync(id);

        public async Task<bool> ExistsByIdAsync(TId id, CancellationToken cancellationToken) =>
            await _dataset.FindAsync(id) != null;

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken) =>
           await _dataset.ToListAsync(cancellationToken);


        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = _dataset.Where(i => true);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.ToListAsync(cancellationToken);
        }

        //public async Task<Tuple<IQueryable<TEntity>, PaginationResponseDto>> SearchAsync(PaginationRequestDto pagination, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        //{
        //    var result = _dataset.Where(predicate);
        //    var totalItens = result.Count();
        //    var totalPages = totalItens / pagination.PageSize;

        //    var paginationResponse = new PaginationResponseDto(pagination.PageNumber, pagination.PageSize, totalPages, totalItens, pagination.OrderBy, pagination.Desc);


        //    var paginatedResult = result.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
        //    return new Tuple<IQueryable<TEntity>, PaginationResponseDto>(paginatedResult, paginationResponse);
        //}

        public async Task<IQueryable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var result = _dataset.Where(predicate);
            return result;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken) =>
            await _context.SaveChangesAsync(cancellationToken) > 0;

    }
}
