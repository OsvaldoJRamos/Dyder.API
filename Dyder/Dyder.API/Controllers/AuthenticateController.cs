using Dyder.API.ViewModels;
using Dyder.Application.Services;
using Dyder.Application.Services.Interfaces;
using Dyder.Domain.Constants;
using Dyder.Domain.Entities.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dyder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthenticateController(
            IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken cancellationToken)
        {
            var token = await _identityService.LoginAsync(model, cancellationToken);

            if (token != null)
            {
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model, CancellationToken cancellationToken)
        {
            var user = await _identityService.RegisterAsync(model, cancellationToken);

            if (user != "Usuario Criado com sucesso")
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new AuthResponse { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model, CancellationToken cancellationToken)
        {
            var user = await _identityService.RegisterAdminAsync(model, cancellationToken);

            if (user != "Usuario Criado com sucesso")
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new AuthResponse { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-estabelecimento")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterEstabelecimentoAsync([FromBody] RegisterModelEstabelecimento model, CancellationToken cancellationToken)
        {
            var user = await _identityService.RegisterEstabelecimentoAsync(model, cancellationToken);

            if (user != "Usuario Criado com sucesso")
                return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new AuthResponse { Status = "Success", Message = "User created successfully!" });
        }
    }
}
