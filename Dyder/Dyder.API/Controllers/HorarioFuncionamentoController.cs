using Dyder.Application.Services.Interfaces;
using Dyder.Domain.Constants;
using Dyder.Domain.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dyder.API.Controllers
{
    [ApiController]
    [Authorize]
    public class HorarioFuncionamentoController : ControllerBase
    {
        private readonly IHorarioFuncionamentoService _horarioFuncionamentoService;

        public HorarioFuncionamentoController(
            IHorarioFuncionamentoService horarioFuncionamentoService)
        {
            _horarioFuncionamentoService = horarioFuncionamentoService;
        }

        [HttpPost("Estabelecimento/{estabelecimentoId}/[controller]")]
        [AllowAnonymous]
        //[Authorize(Roles = UserRoles.Estabelecimento)]
        public async Task<IActionResult> CreateAsync([FromBody] List<CriarHorarioFuncionamentoDto> request, long estabelecimentoId, CancellationToken cancellationToken)
        {
            try
            {
                var estabelecimento = await _horarioFuncionamentoService.CriarAsync(request, estabelecimentoId, cancellationToken);
                return new ObjectResult(estabelecimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
