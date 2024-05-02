using Sigim.Domain;

namespace Sigim.Application.Models
{
    public class HistoryResult
    {
        public DateTime Fecha { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public float Pulso { get; set; }
        public float Aerobico { get; set; }
        public float Anaerobico { get; set; }
        public float DensidadOsea { get; set; }
        public float Pecho { get; set; }
        public float Espalda { get; set; }
        public float Cintura { get; set; }
        public float Gluteo { get; set; }
        public float MusloIzq { get; set; }
        public float MusloDer { get; set; }
        public float PantorrillaIzq { get; set; }
        public float PantorrillaDer { get; set; }
        public float BrazoIzq { get; set; }
        public float BrazoDer { get; set; }
        public float AnteBrazoIzq { get; set; }
        public float AnteBrazoDer { get; set; }
        public string Observaciones { get; set; } = string.Empty;

    }
}
