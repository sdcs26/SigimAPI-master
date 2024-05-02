using MediatR;
using Sigim.Application.Models;
using Sigim.Application.Models.Identity;

namespace Sigim.Application.Features.AuthFeature.commands.LoginUser
{
    public class LoginUserCommand : IRequest<ApiResult<AuthResponse>>
    {
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
    }
}
