using Sigim.Domain.common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigim.Domain
{
    [Table("ingreso")]
    public class Income : BaseDomainModel
    {
        [Key, Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("idusuario")]
        public string IdUsuario { get; set; } = string.Empty;

        [Column("fecha", TypeName = "timestamp without time zone")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        public virtual User? Usuario { get; set; }
    }
}
