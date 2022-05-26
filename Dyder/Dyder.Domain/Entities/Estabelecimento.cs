using Dyder.Domain.Entities.Base;

namespace Dyder.Domain.Entities
{
    public class Estabelecimento : EntityBase<long>
    {
        public Estabelecimento(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }

        public virtual ICollection<EstabelecimentoPagamento> FormasPagamento { get; private set; }

        public EstabelecimentoPagamento AdicionarFormaPagamento(FormaPagamento formaPagamento)
        {
            var jaExiste = FormasPagamento.FirstOrDefault(f => f.FormaPagamento.Id == formaPagamento.Id);
            if (jaExiste != null)
                return jaExiste;

            var estabelecimentoPagamento = new EstabelecimentoPagamento(this, formaPagamento);
            FormasPagamento.Add(estabelecimentoPagamento);

            return estabelecimentoPagamento;
        }

        public void RemoverFormaPagamento(long formaPagamentoId)
        {
            var formaPagamentoExistente = FormasPagamento.FirstOrDefault(f => f.FormaPagamento.Id == formaPagamentoId);
            
            if (formaPagamentoExistente != null)
                formaPagamentoExistente.Excluir();
        }
    }
}
