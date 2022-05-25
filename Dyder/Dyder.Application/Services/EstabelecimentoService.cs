using Dyder.Application.Services.Base;
using Dyder.Domain.Dto.Request;
using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services.Interfaces;

namespace Dyder.Application.Services
{
    public class EstabelecimentoService : ServiceBase<Estabelecimento, long, IEstabelecimentoRepository>, IEstabelecimentoService
    {
        public EstabelecimentoService(
            IEstabelecimentoRepository estabelecimentoRepository)
            : base(estabelecimentoRepository)
        {
        }

        public async Task<Estabelecimento> CriarAsync(CriarEstabelecimentoDto request, CancellationToken cancellationToken)
        {
            var estabelecimento = new Estabelecimento(request.Nome);

            await _repository.AddAsync(estabelecimento, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return estabelecimento;
        }
    }
}
