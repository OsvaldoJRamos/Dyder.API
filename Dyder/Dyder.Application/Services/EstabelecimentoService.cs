using Dyder.Application.Services.Base;
using Dyder.Domain.Dto.Request;
using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services.Interfaces;

namespace Dyder.Application.Services
{
    public class EstabelecimentoService : ServiceBase<Estabelecimento, long, IEstabelecimentoRepository>, IEstabelecimentoService
    {
        private readonly IFormaPagamentoService _formaPagamentoService;

        public EstabelecimentoService(
            IEstabelecimentoRepository estabelecimentoRepository,
            IFormaPagamentoService formaPagamentoService)
            : base(estabelecimentoRepository)
        {
            _formaPagamentoService = formaPagamentoService;
        }


        public async Task<Estabelecimento> CriarAsync(CriarEstabelecimentoDto request, CancellationToken cancellationToken)
        {
            var estabelecimento = new Estabelecimento(request.Nome);

            await _repository.AddAsync(estabelecimento, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return estabelecimento;
        }

        public async Task<Estabelecimento> AdicionarFormaPagamentoAsync(long formaPagamentoId, long estabelecimentoId, CancellationToken cancellationToken)
        {
            var formaPagamento = await _formaPagamentoService.GetByIdAsync(formaPagamentoId, cancellationToken);
            var estabelecimento = await GetByIdAsync(estabelecimentoId, cancellationToken);

            if (estabelecimento == null || formaPagamento == null)
                return null;

            estabelecimento.AdicionarFormaPagamento(formaPagamento);

            await _repository.UpdateAsync(estabelecimento, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return estabelecimento;
        }

        public async Task<Estabelecimento> ExcluirFormaPagamentoAsync(long formaPagamentoId, long estabelecimentoId, CancellationToken cancellationToken)
        {
            var estabelecimento = await GetByIdAsync(estabelecimentoId, cancellationToken);

            if (estabelecimento == null)
                return null;

            estabelecimento.RemoverFormaPagamento(formaPagamentoId);

            await _repository.UpdateAsync(estabelecimento, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return estabelecimento;
        }
    }
}
