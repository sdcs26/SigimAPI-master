using Sigim.Domain.common;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigim.Domain
{
    [Table("usuario")]
    public class User : BaseDomainModel
    {
        [Key, Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Column("correo")]
        public string Correo { get; set; } = string.Empty;
        [Column("verificacion")]
        public bool Verificacion { get; set; }
        [Column("contrasena")]
        public string Contrasena { get; set; } = string.Empty;
        [Column("documento")]
        public string Documento { get; set; } = string.Empty;
        [Column("nombres")]
        public string Nombres { get; set; } = string.Empty;
        [Column("apellidos")]
        public string Apellidos { get; set; } = string.Empty;
        [Column("genero")]
        public string Genero { get; set; } = string.Empty;
        [Column("birthdate")]
        public DateTime Birthdate { get; set; } = DateTime.Now;
        [Column("banned")]
        public bool Banned { get; set; } = false;
        [Column("idrol")]
        public string RolId { get; set; } = string.Empty;

        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<UserRoutine> UserRoutines { get; set; }
        public virtual Rol? Rol { get; set; }

        public User()
        {
            Histories = new HashSet<History>();
            Incomes = new HashSet<Income>();
            UserRoutines = new HashSet<UserRoutine>();
        }
    }
}
