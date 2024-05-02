using Complii.Application.Contracts.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models.Settings;
using Sigim.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sigim.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private JwtSettings _jwtSettings;
        public AuthService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = new JwtSettings
            {
                Key = jwtSettings.Value.Key,
                DurationInMinutes = jwtSettings.Value.DurationInMinutes
            };
        }
        public string GenereteToken(User user)
        {
            var claims = new[]
            {
                new Claim("UserId", user.Id),
                new Claim(JwtRegisteredClaimNames.Name, $"{user.Apellidos}, {user.Nombres}"),
                new Claim(ClaimTypes.Role, user.Rol.Titulo)
            };

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
            claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes ?? 0),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
