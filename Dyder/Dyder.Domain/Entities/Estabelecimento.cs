namespace Dyder.Domain.Entities
{
    public class Estabelecimento
    {
        public int Id { get; private set; }
        public bool Ativo { get; private set; }
        public string Nome { get; private set; }

        public Estabelecimento(int id, bool ativo, string nome)
        {
            Id = id;
            Ativo = ativo;
            Nome = nome;    
        }
    }
}
