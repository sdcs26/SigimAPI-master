using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Sigim.Domain.common;

namespace Sigim.Domain
{
    [Table("rutina_ejercicio")]
    public class RoutineExercise : BaseDomainModel
    {
        [Key, Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("idejercicio")]
        public string IdEjercicio { get; set; } = string.Empty;

        [Column("idrutina")]
        public string IdRutina { get; set; } = string.Empty;

        [Column("series")]
        public int Series { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("istime")]
        public bool IsTime { get; set; }

        public virtual Exercise? Exercises { get; set; }
        public virtual Routine? Rutina { get; set; }
    }
}
