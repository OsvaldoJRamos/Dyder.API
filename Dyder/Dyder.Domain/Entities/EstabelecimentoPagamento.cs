namespace Dyder.Domain.Entities
{
    public class EstabelecimentoPagamento
    {
        public int Id { get; private set; }
        
        private int EstabelecimentoId;
        public virtual Estabelecimento Estabelecimento { get; private set; }

        private int FormaPagamentoId;
        public virtual FormaPagamento FormaPagamento { get; private set; }

        public EstabelecimentoPagamento(int id, int estabelecimentoId, Estabelecimento estabelecimento, int formaPagamentoId, FormaPagamento formaPagamento)
        {
            Id = id;
            EstabelecimentoId = estabelecimentoId;
            Estabelecimento = estabelecimento;
            FormaPagamentoId = formaPagamentoId;
            FormaPagamento = formaPagamento;
        }
    }
}
