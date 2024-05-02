namespace Sigim.Application.Models.Request
{
    public class RoutineExerciseRequest
    {
        public string EjercicioId { get; set; } = string.Empty;
        public string RutinaId { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Cantidad { get; set; }
        public bool IsTime { get; set; }
    }
}
