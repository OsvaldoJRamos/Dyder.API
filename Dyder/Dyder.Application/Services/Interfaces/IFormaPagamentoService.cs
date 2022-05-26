using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services.Interfaces.Base;

namespace Dyder.Application.Services.Interfaces
{
    public interface IFormaPagamentoService : IServiceBase<FormaPagamento, long, IFormaPagamentoRepository>
    {
    }
}
