namespace Dyder.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        private int EstabelecimentoId;
        public virtual Estabelecimento Estabelecimento { get; private set; }

        public Categoria(int id, string nome, int estabelecimentoId, Estabelecimento estabelecimento)
        {
            Id = id;
            Nome = nome;
            EstabelecimentoId = estabelecimentoId;
            Estabelecimento = estabelecimento;
        }
    }
}
