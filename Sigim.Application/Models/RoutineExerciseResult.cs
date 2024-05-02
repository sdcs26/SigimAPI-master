using Sigim.Domain;

namespace Sigim.Application.Models
{
    public class RoutineExerciseResult
    {
        public string Id { get; set; } = string.Empty;
        public int Series { get; set; }
        public int Cantidad { get; set; }
        public bool IsTime { get; set; }
        public virtual ExerciseResult? Exercises { get; set; }
    }
}
