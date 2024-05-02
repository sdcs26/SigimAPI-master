using MediatR;
using Sigim.Application.Models;

namespace Sigim.Application.Features.AuthFeature.commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<ApiResult<bool>>
    {
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string ConfirmarContrasena { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }

    }
}
