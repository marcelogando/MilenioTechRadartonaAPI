using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class TrajetosDTO
    {
        public int codigoRadarOrigem { get; set; }
        public decimal mediaVelOrigem { get; set; }
        public string periodoDia { get; set; }
        public decimal mediaMinutosTrajeto { get; set; }
        public int codigoRadarDestino { get; set; }
        public decimal mediaVelDestino { get; set; }
    }
}
