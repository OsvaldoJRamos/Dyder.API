namespace Dyder.Domain.Entities
{
    public class FormaPagamento
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public FormaPagamento(string descricao)
        {
            Descricao = descricao;
        }
    }
}
