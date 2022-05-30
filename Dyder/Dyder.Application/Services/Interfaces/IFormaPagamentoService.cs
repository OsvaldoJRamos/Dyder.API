using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services.Interfaces.Base;
using Dyder.Domain.Dto.Request;

namespace Dyder.Application.Services.Interfaces
{
    public interface IFormaPagamentoService : IServiceBase<FormaPagamento, long, IFormaPagamentoRepository>
    {
        Task<FormaPagamento> CriarAsync(CriarFormaPagamentoDto request, CancellationToken cancellationToken);
        Task<bool> ExcluirAsync(long id, CancellationToken cancellationToken);
        Task<IEnumerable<FormaPagamento>> ObterAsync(CancellationToken cancellationToken);
    }
}
