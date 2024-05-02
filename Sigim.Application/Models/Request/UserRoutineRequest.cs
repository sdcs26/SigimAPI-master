namespace Sigim.Application.Models.Request
{
    public class UserRoutineRequest
    {
        public string IdUsuario { get; set; } = string.Empty;
        public string IdRutina { get; set; } = string.Empty;
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
    }
}
