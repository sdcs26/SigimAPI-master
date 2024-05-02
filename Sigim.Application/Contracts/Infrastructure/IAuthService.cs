using Sigim.Domain;

namespace Complii.Application.Contracts.Infrastructure
{
    public interface IAuthService
    {
        string GenereteToken(User user);
    }
}

