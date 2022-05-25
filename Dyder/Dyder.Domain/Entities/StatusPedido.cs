namespace Dyder.Domain.Entities
{
    public class StatusPedido
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public StatusPedido(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
