namespace Dyder.Domain.Entities
{
    public class Bairro
    {
        public int Id { get; private set; }
        public decimal ValorEntrega { get; private set; }
        public string Nome { get; private set; }

        private int EstabelecimentoId;
        public virtual Estabelecimento Estabelecimento { get; private set; }

        public Bairro(int id, decimal valorEntrega, string nome, int estabelecimentoId, Estabelecimento estabelecimento)
        {
            Id = id;
            ValorEntrega = valorEntrega;
            Nome = nome;
            EstabelecimentoId = estabelecimentoId;
            Estabelecimento = estabelecimento;
        }
    }
}
