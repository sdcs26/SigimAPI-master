
namespace Sigim.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Documento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
