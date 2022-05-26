using Dyder.Domain.Entities;
using Dyder.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Dyder.Repository
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        DbSet<Estabelecimento> Estabelecimento { get; set; }
        DbSet<FormaPagamento> FormaPagamento { get; set; }
        DbSet<EstabelecimentoPagamento> EstabelecimentoPagamento { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Estabelecimento.Include(x => x.FormasPagamento).ToList();
            EstabelecimentoPagamento.Include(x => x.FormaPagamento).ToList();
            EstabelecimentoPagamento.Include(x => x.Estabelecimento).ToList();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Expression<Func<EntityBase<long>, bool>> filterExpr = bm => bm.EstaAtivo;
            foreach (var mutableEntityType in builder.Model.GetEntityTypes())
            {
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(EntityBase<long>)))
                {
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);

                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }
        }

        public override int SaveChanges()
        {
            UpdateEntity();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntity();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateEntity();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateEntity()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                //TODO TIRAR O TRY E VALIDAR SE entry.CurrentValues["ModificadoEm"] 
                //EXISTE ANTES DE SETAR O VALOR
                try
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues["ModificadoEm"] = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["DeletadoEm"] = DateTime.Now;
                            entry.CurrentValues["EstaAtivo"] = false;
                            break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
