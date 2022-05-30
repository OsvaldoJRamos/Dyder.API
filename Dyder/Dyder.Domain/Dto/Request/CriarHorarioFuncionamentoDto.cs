namespace Dyder.Domain.Dto.Request
{
    public class CriarHorarioFuncionamentoDto
    {
        public DayOfWeek DiaDaSemana { get; set; }
        public TimeOnlyDto HorarioAbertura { get; set; }
        public TimeOnlyDto HorarioFechamento { get; set; }
    }
}
