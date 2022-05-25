namespace Dyder.Domain.Entities
{
    public class PedidoProdutoAdicional
    {
        public int Id { get; private set; }
        public int Quantidade { get; private set; }
        public decimal? Valor { get; private set; }

        private int PedidoProdutoId;
        public virtual PedidoProduto PedidoProduto { get; private set; }
        
        private int ProdutoAdicionalId;
        public virtual ProdutoAdicional ProdutoAdicional { get; private set; }

        public PedidoProdutoAdicional(int id, int quantidade, decimal? valor, int pedidoProdutoId, PedidoProduto pedidoProduto, int produtoAdicionalId, ProdutoAdicional produtoAdicional)
        {
            Id = id;
            Quantidade = quantidade;
            Valor = valor;
            PedidoProdutoId = pedidoProdutoId;
            PedidoProduto = pedidoProduto;
            ProdutoAdicionalId = produtoAdicionalId;
            ProdutoAdicional = produtoAdicional;
        }
    }
}
