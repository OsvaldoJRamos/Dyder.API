using Dyder.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dyder.Domain.Entities
{
    public class EstabelecimentoPagamento : EntityBase<long>
    {
        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual FormaPagamento FormaPagamento { get; private set; }

        public EstabelecimentoPagamento(Estabelecimento estabelecimento, FormaPagamento formaPagamento)
        {
            Estabelecimento = estabelecimento;
            FormaPagamento = formaPagamento;
        }

        protected EstabelecimentoPagamento() { }
    }
}
