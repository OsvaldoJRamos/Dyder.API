using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces.Base;

namespace Dyder.Repository.Repositories.Interfaces
{
    public interface IHorarioFuncionamentoRepository : IRepositoryBase<HorarioFuncionamento, long>
    {
        Task<IQueryable<HorarioFuncionamento>> GetByEstabelecimentoIdAsync(long estabelecimentoId, CancellationToken cancellationToken);
    }
}
