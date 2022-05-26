using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Repository.Repositories.Base;

namespace Dyder.Repository.Repositories
{
    public class FormaPagamentoRepository : RepositoryBase<FormaPagamento, long>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
