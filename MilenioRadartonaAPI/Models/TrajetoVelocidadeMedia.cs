using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class TrajetoVelocidadeMedia
    {
        public TrajetoVelocidadeMedia()
        {
        }

        public TrajetoVelocidadeMedia(int codigoRadarOrigem, string periodoDia, double velocidadeMedia, int codigoRadarDestino)
        {
            CodigoRadarOrigem = codigoRadarOrigem;
            PeriodoDia = periodoDia;
            VelocidadeMedia = velocidadeMedia;
            CodigoRadarDestino = codigoRadarDestino;
        }

        public int CodigoRadarOrigem { get; set; }
        public string PeriodoDia { get; set; }
        public double VelocidadeMedia { get; set; }
        public int CodigoRadarDestino { get; set; }

    }
}
