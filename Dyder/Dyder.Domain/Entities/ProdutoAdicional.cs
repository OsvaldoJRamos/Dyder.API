namespace Dyder.Domain.Entities
{
    public class ProdutoAdicional
    {
        public int Id { get; private set; }
        public decimal? Valor { get; private set; }

        private int ProdutoId;
        public virtual Produto Produto { get; private set; }
        
        private int AdicionalId;
        public virtual Adicional Adicional { get; private set; }

        public ProdutoAdicional(int id, decimal valor, int produtoId, Produto produto, int adicionalId, Adicional adicional)
        {
            Id = id;
            Valor = valor;
            ProdutoId = produtoId;
            Produto = produto;
            AdicionalId = adicionalId;
            Adicional = adicional;
        }
    }
}
