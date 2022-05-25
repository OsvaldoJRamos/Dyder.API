namespace Dyder.Domain.Entities
{
    public class PedidoProduto
    {
        public int Id { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorProduto { get; private set; }
        public decimal ValorTotal { get; private set; }

        private int PedidoId;
        public virtual Pedido Pedido { get; private set; }

        private int ProdutoId;
        public virtual Produto Produto { get; private set; }

        public PedidoProduto(int id, int quantidade, decimal valorProduto, decimal valorTotal, int pedidoId, Pedido pedido, int produtoId, Produto produto)
        {
            Id = id;
            Quantidade = quantidade;
            ValorProduto = valorProduto;
            ValorTotal = valorTotal;
            PedidoId = pedidoId;
            Pedido = pedido;
            ProdutoId = produtoId;
            Produto = produto;
        }
    }
}
