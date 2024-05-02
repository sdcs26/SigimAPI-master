using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Sigim.Domain.common;

namespace Sigim.Domain
{
    [Table("rol")]
    public class Rol : BaseDomainModel
    {
        [Key, Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;
        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; }

        public Rol()
        {
            Users = new HashSet<User>();
        }
    }
}
