using Dyder.Application.Services.Base;
using Dyder.Application.Services.Interfaces;
using Dyder.Domain.Dto.Request;
using Dyder.Domain.Entities;
using Dyder.Repository.Repositories.Interfaces;

namespace Dyder.Application.Services
{
    public class HorarioFuncionamentoService : ServiceBase<HorarioFuncionamento, long, IHorarioFuncionamentoRepository>, IHorarioFuncionamentoService
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public HorarioFuncionamentoService(
            IHorarioFuncionamentoRepository horarioFuncionamentoRepository,
            IEstabelecimentoService estabelecimentoService)
            : base(horarioFuncionamentoRepository)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        public async Task<IEnumerable<HorarioFuncionamento>> CriarAsync(List<CriarHorarioFuncionamentoDto> request, long estabelecimentoId, CancellationToken cancellationToken)
        {
            var estabelecimento = await _estabelecimentoService.GetByIdAsync(estabelecimentoId, cancellationToken);
            if (estabelecimento == null)
                return null;

            var horariosFuncionamentoAntigos = await _repository.GetByEstabelecimentoIdAsync(estabelecimentoId, cancellationToken);
            if (horariosFuncionamentoAntigos != null && horariosFuncionamentoAntigos.Any())
                await _repository.DeleteManyAsync(horariosFuncionamentoAntigos.ToArray(), cancellationToken);

            var novosHorariosFuncionamento = new List<HorarioFuncionamento>();
            foreach (var novoHorario in request)
            {
                var horarioFuncionamento = new HorarioFuncionamento(novoHorario.DiaDaSemana, new TimeOnly(novoHorario.HorarioAbertura.Hora, novoHorario.HorarioAbertura.Minuto), new TimeOnly(novoHorario.HorarioFechamento.Hora, novoHorario.HorarioFechamento.Minuto), estabelecimento);
                novosHorariosFuncionamento.Add(horarioFuncionamento);
            }

            await _repository.AddRangeAsync(novosHorariosFuncionamento, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return novosHorariosFuncionamento;
        }
    }
}

