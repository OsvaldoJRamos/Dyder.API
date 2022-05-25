using Dyder.Application.Services;
using Dyder.Domain.Constants;
using Dyder.Domain.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dyder.API.Controllers
{
    [ApiController]
    [Authorize]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentoController(
            IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        [HttpPost]
        [Route("[controller]")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateAsync([FromBody] CriarEstabelecimentoDto request, CancellationToken cancellationToken)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.CriarAsync(request, cancellationToken);
                return new ObjectResult(estabelecimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
