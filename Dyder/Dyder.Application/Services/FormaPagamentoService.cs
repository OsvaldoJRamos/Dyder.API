using Dyder.Application.Services.Base;
using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services.Interfaces;
using Dyder.Domain.Dto.Request;

namespace Dyder.Application.Services
{
    public class FormaPagamentoService : ServiceBase<FormaPagamento, long, IFormaPagamentoRepository>, IFormaPagamentoService
    {
        public FormaPagamentoService(IFormaPagamentoRepository repository)
            : base(repository)
        {
        }

        public async Task<FormaPagamento> CriarAsync(CriarFormaPagamentoDto request, CancellationToken cancellationToken)
        {
            var formaPagamento = new FormaPagamento(request.Descricao);

            await _repository.AddAsync(formaPagamento, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return formaPagamento;
        }

        public async Task<bool> ExcluirAsync(long id, CancellationToken cancellationToken)
        {
            await _repository.DeleteByIdAsync(id, cancellationToken);
            return await _repository.SaveChangesAsync(cancellationToken);

        }

        public async Task<IEnumerable<FormaPagamento>> ObterAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
