using Dyder.Application.Services.Base;
using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services.Interfaces;

namespace Dyder.Application.Services
{
    public class FormaPagamentoService : ServiceBase<FormaPagamento, long, IFormaPagamentoRepository>, IFormaPagamentoService
    {
        public FormaPagamentoService(
    IFormaPagamentoRepository repository)
    : base(repository)
        {
        }
    }
}
