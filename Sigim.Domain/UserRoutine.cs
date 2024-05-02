using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sigim.Domain.common;

namespace Sigim.Domain
{
    [Table("usuario_rutina")]
    public class UserRoutine : BaseDomainModel
    {
        [Key, Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("idusuario")]
        public string IdUsuario { get; set; } = string.Empty;

        [Column("idrutina")]
        public string IdRutina { get; set; } = string.Empty;

        [Column("fechaasignacion", TypeName = "timestamp without time zone")]
        public DateTime FechaAsignacion { get; set; } = DateTime.Now;

        [Column("lunes")]
        public bool Lunes { get; set; }

        [Column("martes")]
        public bool Martes { get; set; }

        [Column("miercoles")]
        public bool Miercoles { get; set; }

        [Column("jueves")]
        public bool Jueves { get; set; }

        [Column("viernes")]
        public bool Viernes { get; set; }

        [Column("sabado")]
        public bool Sabado { get; set; }

        [Column("domingo")]
        public bool Domingo { get; set; }

        public virtual User? Usuario { get; set; }

        public virtual Routine? Rutina { get; set; }
    }
}
