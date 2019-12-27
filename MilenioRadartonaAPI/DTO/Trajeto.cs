using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class Trajeto
    {
        public Trajeto()
        {
        }

        public Trajeto(int codigoRadarOrigem, double mediaVelOrigem, string periodoDia, double mediaMinutosTrajeto, int codigoRadarDestino, double mediaVelDestino)
        {
            CodigoRadarOrigem = codigoRadarOrigem;
            MediaVelOrigem = mediaVelOrigem;
            PeriodoDia = periodoDia;
            MediaMinutosTrajeto = mediaMinutosTrajeto;
            CodigoRadarDestino = codigoRadarDestino;
            MediaVelDestino = mediaVelDestino;
        }

        public int CodigoRadarOrigem { get; set; }
        public double MediaVelOrigem { get; set; }
        public string PeriodoDia { get; set; }
        public double MediaMinutosTrajeto { get; set; }
        public int  CodigoRadarDestino { get; set; }
        public double MediaVelDestino { get; set; }

    }
}
