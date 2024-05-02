namespace Sigim.Application.Models
{
    public class UserRoutineResult
    {
        public string Id { get; set; } = string.Empty;
        public DateTime FechaAsignacion { get; set; }
        public bool Lunes {  get; set; }
        public bool Martes {  get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public virtual RoutineResult? Rutina { get; set; }
    }
}
