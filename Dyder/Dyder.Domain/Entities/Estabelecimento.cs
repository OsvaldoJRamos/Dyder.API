using Dyder.Domain.Entities.Base;

namespace Dyder.Domain.Entities
{
    public class Estabelecimento : EntityBase<long>
    {
        public string Nome { get; private set; }

        public Estabelecimento(string nome)
        {
            Nome = nome;
        }
    }
}
