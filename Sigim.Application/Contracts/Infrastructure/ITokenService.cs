using Sigim.Application.Models.Settings;

namespace Sigim.Application.Contracts.Infrastructure
{
    public interface ITokenService
    {
        TokenPayload GetTokenPayload();
    }
}
