using Microsoft.AspNetCore.Http;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Application.Models.Settings;

namespace Sigim.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public TokenPayload GetTokenPayload()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims.ToDictionary(a => a.Type, a => a.Value);
            return new TokenPayload
            {
                UserId = claims.GetValueOrDefault("UserId") ?? "",
                Name = claims.GetValueOrDefault("name") ?? ""
            };
        }
    }
}
