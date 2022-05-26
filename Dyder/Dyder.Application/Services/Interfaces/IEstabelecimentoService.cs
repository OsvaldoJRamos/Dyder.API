using Dyder.Domain.Dto.Request;
using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services;
using Dyder.Application.Services.Interfaces.Base;

namespace Dyder.Application.Services.Interfaces
{
    public interface IEstabelecimentoService : IServiceBase<Estabelecimento, long, IEstabelecimentoRepository>
    {
        Task<Estabelecimento> CriarAsync(CriarEstabelecimentoDto request, CancellationToken cancellationToken);
        Task<Estabelecimento> AdicionarFormaPagamentoAsync(long formaPagamentoId, long estabelecimentoId, CancellationToken cancellationToken);
        Task<Estabelecimento> ExcluirFormaPagamentoAsync(long formaPagamentoId, long estabelecimentoId, CancellationToken cancellationToken);
    }  
}
