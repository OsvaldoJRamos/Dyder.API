using Dyder.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            builder.Entity<EstabelecimentoPagamento>().HasQueryFilter(entity => entity.EstaAtivo);
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
        }
    }
}
