using Dyder.Domain.Constants;
using Dyder.Domain.Entities.Base;

namespace Dyder.Domain.Entities
{
    public class Estabelecimento : EntityBase<long>
    {
        public Estabelecimento(string nome)
        {
            Nome = nome;
        }


        public string Nome { get; private set; }
        public DateTime? AbertoAte { get; private set; }
        public DateTime FechadoAte { get; private set; }

        //public bool EstaAberto()
        //{
        //    var dataAtual = DateTime.Now;
        //    var diaDaSemanaAtual = DateTime.Now.DayOfWeek;
        //    var horarioAtual = new TimeOnly().Add(dataAtual.TimeOfDay);

        //    return
        //           (!FechadoTemporariamenteAte.HasValue || dataAtual > FechadoTemporariamenteAte)
        //        && (!AbertoTemporariamenteAte.HasValue || dataAtual < AbertoTemporariamenteAte)
        //        && (HorariosFuncionamento.Any(h => h.DiaSemana == diaDaSemanaAtual && horarioAtual.IsBetween(h.HoraAbertura, h.HoraFechamento)));
        //}

        //public void AbrirTemporariamente(DateTime abrirAte)
        //{
        //    FechadoTemporariamenteAte = null;
        //    AbertoTemporariamenteAte = abrirAte;
        //}

        //public void FecharTemporariamente(DateTime fecharAte)
        //{
        //    FechadoTemporariamenteAte = fecharAte;
        //    AbertoTemporariamenteAte = null;
        //}

        public virtual ICollection<EstabelecimentoPagamento> FormasPagamento { get; private set; }
        public virtual ICollection<HorarioFuncionamento> HorariosFuncionamento { get; private set; }

        public EstabelecimentoPagamento AdicionarFormaPagamento(FormaPagamento formaPagamento)
        {
            var jaExiste = FormasPagamento.FirstOrDefault(f => f.FormaPagamento.Id == formaPagamento.Id);
            if (jaExiste != null)
                return jaExiste;

            var estabelecimentoPagamento = new EstabelecimentoPagamento(this, formaPagamento);
            FormasPagamento.Add(estabelecimentoPagamento);

            return estabelecimentoPagamento;
        }
        public void RemoverFormaPagamento(long formaPagamentoId)
        {
            var formaPagamentoExistente = FormasPagamento.FirstOrDefault(f => f.FormaPagamento.Id == formaPagamentoId);

            if (formaPagamentoExistente != null)
                formaPagamentoExistente.Excluir();
        }

    }

    public class HorarioFuncionamento : EntityBase<long>
    {
        public DayOfWeek DiaSemana { get; private set; }
        public TimeOnly HoraAbertura { get; private set; }
        public TimeOnly HoraFechamento { get; private set; }
        public virtual Estabelecimento Estabelecimento { get; private set; }

    }
}
