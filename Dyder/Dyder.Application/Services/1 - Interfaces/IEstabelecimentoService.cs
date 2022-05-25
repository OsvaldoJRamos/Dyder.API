using Dyder.Application.Services._1___Interfaces;
using Dyder.Domain.Dto.Request;
using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;

namespace Dyder.Application.Services
{
    public interface IEstabelecimentoService : IServiceBase<Estabelecimento, long, IEstabelecimentoRepository>
    {
        Task<Estabelecimento> CriarAsync(CriarEstabelecimentoDto request, CancellationToken cancellationToken);
    }
}
