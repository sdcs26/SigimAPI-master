using Sigim.Domain.common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigim.Domain
{
    [Table("historia")]
    public class History : BaseDomainModel
    {
        [Key, Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Column("idusuario")]
        public string IdUsuario { get; set; } = string.Empty;
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        [Column("altura")]
        public float Altura { get; set; }
        [Column("peso")]
        public float Peso { get; set; }
        [Column("pulso")]
        public float Pulso { get; set; }
        [Column("aerobico")]
        public float Aerobico { get; set; }
        [Column("anaerobico")]
        public float Anaerobico { get; set; }
        [Column("densidadosea")]
        public float DensidadOsea { get; set; }
        [Column("pecho")]
        public float Pecho { get; set; }
        [Column("espalda")]
        public float Espalda { get; set; }
        [Column("cintura")]
        public float Cintura { get; set; }
        [Column("gluteo")]
        public float Gluteo { get; set; }
        [Column("musloizq")]
        public float MusloIzq { get; set; }
        [Column("musloder")]
        public float MusloDer { get; set; }
        [Column("pantorrillaizq")]
        public float PantorrillaIzq { get; set; }
        [Column("pantorrillader")]
        public float PantorrillaDer { get; set; }
        [Column("brazoizq")]
        public float BrazoIzq { get; set; }
        [Column("brazoder")]
        public float BrazoDer { get; set; }
        [Column("antebrazoizq")]
        public float AnteBrazoIzq { get; set; }
        [Column("antebrazoder")]
        public float AnteBrazoDer { get; set; }
        [Column("observaciones")]
        public string Observaciones { get; set; } = string.Empty;
        public virtual User? Usuario { get; set; }
    }
}
