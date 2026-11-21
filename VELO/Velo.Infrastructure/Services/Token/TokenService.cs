using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Velo.Application.Common.Settings;
using Velo.Application.Interfaces.Services.Token;
using Velo.Domain.Entities.Identity;

namespace Velo.Infrastructure.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwt;
        private readonly UserManager<ApplicationUser> _userManager;
        public TokenService(IOptions<JwtSettings> options, UserManager<ApplicationUser> userManager)
        {
            _jwt = options.Value;
            _userManager = userManager;
        }

        public async Task<string> GenerateTokenAsync(ApplicationUser user,CancellationToken cancellationToken)
        {


            var UserClaims = new List<Claim>()
            {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.FullName ?? string.Empty)
            };

            var Roles = await _userManager.GetRolesAsync(user);
            UserClaims.AddRange(Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var myKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));

            var credentials = new SigningCredentials(myKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwt.ExpiryInMinutes),
                claims: UserClaims,
                signingCredentials: credentials
                );
            var myToken = new JwtSecurityTokenHandler().WriteToken(token);

            return myToken;

        }
    }
}
