using Dyder.Domain.Dto;

namespace Dyder.API.ViewModels
{
    public class HorarioFuncionamentoViewModel
    {
        public DayOfWeek DiaSemana { get; set; }
        public TimeOnlyDto HoraAbertura { get; set; }
        public TimeOnlyDto HoraFechamento { get; set; }
    }
}
