using Sigim.Domain;

namespace Sigim.Application.Models
{
    public class UserResult
    {
        public string Id { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public bool Verificacion { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public bool Banned { get; set; } = false;
        public string RolId { get; set; } = string.Empty;
        public virtual RolResult? Rol { get; set; }
        public virtual ICollection<UserRoutineResult> UserRoutines { get; set; }
        public UserResult()
        {
            UserRoutines = new List<UserRoutineResult>();
        }
    }
}
