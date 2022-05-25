namespace Dyder.Domain.Entities
{
    public class FormaPagamento
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public FormaPagamento(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
