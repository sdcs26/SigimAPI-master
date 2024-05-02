using Sigim.Domain.common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigim.Domain
{
    [Table("ejercicio")]
    public class Exercise : BaseDomainModel
    {
        [Key, Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [Column("enlaceanimacion")]
        public string EnlaceAnimacion { get; set; } = string.Empty;

        public virtual ICollection<RoutineExercise> RoutineExercises { get; set; }

        public Exercise()
        {
            RoutineExercises = new HashSet<RoutineExercise>();
        }

    }
}
