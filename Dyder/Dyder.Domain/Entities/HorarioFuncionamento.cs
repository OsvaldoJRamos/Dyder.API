using Dyder.Domain.Entities.Base;

namespace Dyder.Domain.Entities
{
    public class HorarioFuncionamento : EntityBase<long>
    {
        public DayOfWeek DiaSemana { get; private set; }
        public TimeOnly HoraAbertura { get; private set; }
        public TimeOnly HoraFechamento { get; private set; }
        public virtual Estabelecimento Estabelecimento { get; private set; }

        public HorarioFuncionamento(DayOfWeek diaSemana, TimeOnly horaAbertura, TimeOnly horaFechamento, Estabelecimento estabelecimento)
        {
            DiaSemana = diaSemana;
            HoraAbertura = horaAbertura;
            HoraFechamento = horaFechamento;
            Estabelecimento = estabelecimento;
        }

        protected HorarioFuncionamento() { }
    }
}
