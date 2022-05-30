using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Repository.Repositories.Base;

namespace Dyder.Repository.Repositories
{
    public class HorarioFuncionamentoRepository : RepositoryBase<HorarioFuncionamento, long>, IHorarioFuncionamentoRepository
    {
        public HorarioFuncionamentoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IQueryable<HorarioFuncionamento>> GetByEstabelecimentoIdAsync(long estabelecimentoId, CancellationToken cancellationToken)
        {
            return _dataset.Where(h => h.Estabelecimento.Id == estabelecimentoId);
        }
    }
}
