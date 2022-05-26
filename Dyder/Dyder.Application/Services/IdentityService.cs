using Dyder.Application.Services.Interfaces;
using Dyder.Domain.Constants;
using Dyder.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dyder.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEstabelecimentoService _estabelecimentoService;

        public IdentityService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IEstabelecimentoService estabelecimentoService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _estabelecimentoService = estabelecimentoService;
        }

        public async Task<JwtSecurityToken> LoginAsync(LoginModel model, CancellationToken cancellationToken)
        {
            IdentityUser user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userClaims = await _userManager.GetClaimsAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var claim in userClaims)
                {
                    authClaims.Add(new Claim(claim.Type, claim.Value));
                }

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return token;
            }

            return null;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<string> RegisterAsync(RegisterModel model, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return "Usuario ja existe";

            var user = new IdentityUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return "Erro ao criar usuário";

            return "Usuario Criado com sucesso";
        }

        public async Task<string> RegisterAdminAsync(RegisterModel model, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return "Usuario ja existe";

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return "Erro ao criar usuário";

            await AddUserToRoles(user, new List<string> { UserRoles.Admin, UserRoles.User });

            return "Usuario Criado com sucesso";
        }


        public async Task<string> RegisterEstabelecimentoAsync(RegisterModelEstabelecimento model, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return "Usuario ja existe";

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return "Erro ao criar usuário";

            if (model.EstabelecimentoId.HasValue)
            {
                var estabelecimentoInformadoExiste = await _estabelecimentoService.ExistsByIdAsync(model.EstabelecimentoId.Value, cancellationToken);
                if (!estabelecimentoInformadoExiste)
                    return "Usuario criado, porém estabelecimento informado não foi encontrado!";

                await _userManager.AddClaimAsync(user, new Claim(UserClaims.EstabelecimentoId, model.EstabelecimentoId.Value.ToString()));
            }

            await AddUserToRoles(user, new List<string> { UserRoles.Estabelecimento, UserRoles.User });

            return "Usuario Criado com sucesso";
        }

        private async Task AddUserToRoles(IdentityUser user, List<string> roles)
        {
            await CreateRolesIfNotExists(roles);

            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                    await _userManager.AddToRoleAsync(user, role);
            }
        }

        private async Task CreateRolesIfNotExists(IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
