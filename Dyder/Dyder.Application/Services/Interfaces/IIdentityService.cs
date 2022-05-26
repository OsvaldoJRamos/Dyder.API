using Dyder.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Dyder.Application.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<JwtSecurityToken> LoginAsync(LoginModel model, CancellationToken cancellationToken);
        Task<string> RegisterAsync(RegisterModel model, CancellationToken cancellationToken);
        Task<string> RegisterAdminAsync(RegisterModel model, CancellationToken cancellationToken);
        Task<string> RegisterEstabelecimentoAsync(RegisterModelEstabelecimento model, CancellationToken cancellationToken);
    }
}
