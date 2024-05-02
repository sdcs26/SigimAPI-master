using Sigim.Domain;

namespace Sigim.Application.Models
{
    public class RoutineResult
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public virtual ICollection<RoutineExerciseResult> RoutineExercises { get; set; }
        public RoutineResult()
        {
            RoutineExercises = new HashSet<RoutineExerciseResult>();
        }
    }
}
