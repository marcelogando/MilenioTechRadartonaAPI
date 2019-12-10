using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class ViagensDTO
    {
        public int viagemId { get; set; }
        public int codigoRadarInicio { get; set; }
        public DateTime dataHoraInicio { get; set; }
        public int codigoRadarFinal { get; set; }
        public DateTime dataHoraFinal { get; set; }
        public int tipoVeiculo { get; set; }
    }
}
