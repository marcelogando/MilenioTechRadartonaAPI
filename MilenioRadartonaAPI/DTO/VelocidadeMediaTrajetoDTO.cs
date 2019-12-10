using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class VelocidadeMediaTrajetoDTO
    {
        public int codigoRadarOrigem { get; set; }
        public string periodoDia { get; set; }
        public decimal velocidadeMedia { get; set; }
        public int codigoRadarDestino { get; set; }
    }
}
