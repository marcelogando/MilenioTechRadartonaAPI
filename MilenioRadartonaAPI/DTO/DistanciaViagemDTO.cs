using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class DistanciaViagemDTO
    {
        public int codigoRadarInicio { get; set; }
        public int codigoRadarFinal { get; set; }
        public decimal distancia { get; set; }
    }
}
