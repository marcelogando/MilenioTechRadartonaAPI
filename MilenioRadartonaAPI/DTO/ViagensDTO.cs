using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class ViagensDTO
    {
        public int ViagemId { get; set; }
        public int CodigoRadarInicio { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public int CodigoRadarFinal { get; set; }
        public DateTime DataHoraFinal { get; set; }
        public int TipoVeiculo { get; set; }
    }
}
