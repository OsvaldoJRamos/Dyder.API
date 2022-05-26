using Dyder.Domain.Entities.Base;

namespace Dyder.Domain.Entities
{
    public class FormaPagamento : EntityBase<long>
    {
        public string Descricao { get; private set; }

        public FormaPagamento(string descricao)
        {
            Descricao = descricao;
        }
    }
}
