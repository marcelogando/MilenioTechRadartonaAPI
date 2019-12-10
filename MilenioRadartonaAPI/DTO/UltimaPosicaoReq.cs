using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class UltimaPosicaoReq
    {
        public UltimaPosicaoReq()
        {
        }

        public UltimaPosicaoReq(string chave, double lat, double lon, string evento, DateTime dia, double raio)
        {
            Chave = chave;
            Lat = lat;
            Lon = lon;
            Evento = evento;
            Dia = dia;
            Raio = raio;
        }

        public string Chave { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Evento { get; set; }
        public DateTime Dia { get; set; }
        public double Raio { get; set; }

    }
}
