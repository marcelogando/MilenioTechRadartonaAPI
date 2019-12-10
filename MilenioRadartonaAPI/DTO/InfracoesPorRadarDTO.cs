using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class InfracoesPorRadarDTO
    {
        public int codigoRadar { get; set; }
        public DateTime dataHora { get; set; }
        public int tipoVeiculo { get; set; }
        public int contagem { get; set; }
        public int autuacoes { get; set; }
        public int placas { get; set; }
    }
}
