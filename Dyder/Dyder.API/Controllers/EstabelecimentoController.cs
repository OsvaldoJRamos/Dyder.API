﻿using Dyder.Application.Services;
using Dyder.Domain.Constants;
using Dyder.Domain.Dto.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dyder.Application.Services.Interfaces;
using AutoMapper;
using Dyder.API.ViewModels;

namespace Dyder.API.Controllers
{
    [ApiController]
    [Authorize]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoService _estabelecimentoService;
        private readonly IMapper _mapper;

        public EstabelecimentoController(
            IEstabelecimentoService estabelecimentoService, IMapper mapper)
        {
            _estabelecimentoService = estabelecimentoService;
            _mapper = mapper;
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

        [HttpPut]
        [Route("[controller]/{estabelecimentoId}/FormaPagamento/{formaPagamentoId}")]
        //TODO TROCAR PARA ESTABELECIMENTO
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AdicionarFormaPagamentoAsync(long formaPagamentoId, long estabelecimentoId, CancellationToken cancellationToken)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.AdicionarFormaPagamentoAsync(formaPagamentoId, estabelecimentoId, cancellationToken);
                return new ObjectResult(estabelecimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[controller]/{estabelecimentoId}/FormaPagamento/{formaPagamentoId}")]
        //TODO TROCAR PARA ESTABELECIMENTO
        [Authorize(Policy = UserRoles.Admin)]
        public async Task<IActionResult> ExcluirFormaPagamentoAsync(long formaPagamentoId, long estabelecimentoId, CancellationToken cancellationToken)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.ExcluirFormaPagamentoAsync(formaPagamentoId, estabelecimentoId, cancellationToken);
                return new ObjectResult(estabelecimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(long id, CancellationToken cancellationToken)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.GetByIdAsync(id, cancellationToken);
                var viewModel = _mapper.Map<EstabelecimentoViewModel>(estabelecimento);
                return new ObjectResult(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
