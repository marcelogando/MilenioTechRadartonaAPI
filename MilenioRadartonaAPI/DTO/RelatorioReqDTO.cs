using System;

namespace MilenioRadartonaAPI.DTO
{
    public class RelatorioReqDTO
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Evento { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public double Raio { get; set; }

    }
}