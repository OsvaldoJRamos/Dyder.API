using Dyder.Application.Services.Interfaces.Base;
using Dyder.Domain.Dto.Request;
using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;

namespace Dyder.Application.Services.Interfaces
{
    public interface IHorarioFuncionamentoService : IServiceBase<HorarioFuncionamento, long, IHorarioFuncionamentoRepository>
    {
        Task<IEnumerable<HorarioFuncionamento>> CriarAsync(List<CriarHorarioFuncionamentoDto> request, long estabelecimentoId, CancellationToken cancellationToken);
    }
}
