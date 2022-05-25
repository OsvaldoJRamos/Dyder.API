using Microsoft.AspNetCore.Identity;

namespace Dyder.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public decimal? Troco { get; private set; }
        public decimal ValorPedido { get; private set; }
        public decimal? ValorEntrega { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime? DataFim { get; private set; }

        private int UsuarioId;
        public virtual IdentityUser Usuario { get; private set; }

        private int EstabelecimentoId;
        public virtual Estabelecimento Estabelecimento { get; private set; }

        private int EnderecoId;
        public virtual Endereco Endereco { get; private set; }

        private int FormaPagamentoId;
        public virtual FormaPagamento FormaPagamento { get; private set; }

        private int StatusPedidoId;
        public virtual StatusPedido StatusPedido { get; private set; }

        public Pedido(int id, decimal? troco, decimal valorPedido, decimal? valorEntrega, decimal valorTotal, DateTime dataInicio, DateTime? dataFim, int usuarioId, IdentityUser usuario, int estabelecimentoId, Estabelecimento estabelecimento, int enderecoId, Endereco endereco, int formaPagamentoId, FormaPagamento formaPagamento, int statusPedidoId, StatusPedido statusPedido)
        {
            Id = id;
            Troco = troco;
            ValorPedido = valorPedido;
            ValorEntrega = valorEntrega;
            ValorTotal = valorTotal;
            DataInicio = dataInicio;
            DataFim = dataFim;
            UsuarioId = usuarioId;
            Usuario = usuario;
            EstabelecimentoId = estabelecimentoId;
            Estabelecimento = estabelecimento;
            EnderecoId = enderecoId;
            Endereco = endereco;
            FormaPagamentoId = formaPagamentoId;
            FormaPagamento = formaPagamento;
            StatusPedidoId = statusPedidoId;
            StatusPedido = statusPedido;
        }
    }
}
