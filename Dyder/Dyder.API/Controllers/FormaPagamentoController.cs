using Dyder.Application.Services.Interfaces;
using Dyder.Domain.Constants;
using Dyder.Domain.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dyder.API.Controllers
{
    [Route("[controller]")]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoService _formaPagamentoService;

        public FormaPagamentoController(
                IFormaPagamentoService formaPagamentoService)
        {
            _formaPagamentoService = formaPagamentoService;
        }

        [HttpPost]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CriarAsync([FromBody] CriarFormaPagamentoDto request, CancellationToken cancellationToken)
        {
            try
            {
                var formaPagamento = await _formaPagamentoService.CriarAsync(request, cancellationToken);
                return new ObjectResult(formaPagamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        //[Authorize(Policy = UserRoles.Admin)]
        public async Task<IActionResult> ExcluirFormaPagamentoAsync(long id, CancellationToken cancellationToken)
        {
            try
            {
                var formaPagamento = await _formaPagamentoService.ExcluirAsync(id, cancellationToken);
                return new ObjectResult(formaPagamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObterAsync(CancellationToken cancellationToken)
        {
            try
            {
                var formasPagamento = await _formaPagamentoService.ObterAsync(cancellationToken);
                return new ObjectResult(formasPagamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
