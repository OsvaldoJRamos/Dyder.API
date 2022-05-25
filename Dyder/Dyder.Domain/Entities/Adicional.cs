namespace Dyder.Domain.Entities
{
    public class Adicional
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        private int EstabelecimentoId;
        public virtual Estabelecimento Estabelecimento { get; private set; }

        public Adicional(int id, string descricao, int estabelecimentoId, Estabelecimento estabelecimento)
        {
            Id = id;
            Descricao = descricao;
            EstabelecimentoId = estabelecimentoId;
            Estabelecimento = estabelecimento;
        }
    }
}
