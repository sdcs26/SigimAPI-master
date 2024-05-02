using Sigim.Domain.common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigim.Domain
{
    [Table("rutina")]
    public class Routine : BaseDomainModel
    {
        [Key, Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        public virtual ICollection<RoutineExercise> RoutineExercises { get; set; }

        public virtual ICollection<UserRoutine> UserRoutines { get; set; }

        public Routine()
        {
            RoutineExercises = new HashSet<RoutineExercise>();
            UserRoutines = new HashSet<UserRoutine>();
        }
    }
}
